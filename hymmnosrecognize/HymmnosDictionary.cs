using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Speech.Recognition;
using System.Speech.Recognition.SrgsGrammar;
using System.Speech.Synthesis;
using System.Xml;
using System.IO;

namespace HymmnosRecognize
{
    public class HymmnosDictionary
    {
        private SrgsDocument dictionary;
        private List<String> words;
        private List<String> partsOfSpeech;
        private Dictionary<String, List<String>> backlinks;

        public HymmnosDictionary()
        {
            //Define tracking structures
            words = new List<String>();
            partsOfSpeech = new List<String>();
            backlinks = new Dictionary<String, List<String>>();

            //Define SrgsDocument object
            dictionary = new SrgsDocument();
            dictionary.Root = new SrgsRule("Root");
            dictionary.PhoneticAlphabet = SrgsPhoneticAlphabet.Ups;
        }

        public void LoadDictionary(String filename) {
            dictionary = new SrgsDocument(filename);

            //Get a list of all the rules that represent words
            foreach (SrgsRule current in dictionary.Rules)
            {
                //The root rule is empty and should be ignored
                if (current.Elements.Count == 0)
                {
                    continue;
                }

                //Both Part of Speech and Word records have an SrgsOneOf class inside
                SrgsOneOf outerElement = (SrgsOneOf)current.Elements[0];

                //All Words must contain at least one pronunciation
                if (outerElement.Items.Count == 0)
                {
                    partsOfSpeech.Add(current.Id);
                    continue;
                }

                //All SrgsOneOf objects contain SrgsItem elements
                SrgsItem item = outerElement.Items[0];

                //If the items are of type RuleRef, this is a Part of Speech and not a Word
                if (item.Elements[0] is SrgsRuleRef)
                {
                    partsOfSpeech.Add(current.Id);

                    foreach (SrgsItem currentWord in outerElement.Items)
                    {
                        string word = ((SrgsRuleRef) currentWord.Elements[0]).Uri.ToString().Substring(1);

                        if (backlinks.ContainsKey(word))
                        {
                            backlinks[word].Add(current.Id);
                        }
                        else
                        {
                            backlinks.Add(word, new List<String>());
                            backlinks[word].Add(current.Id);
                        }
                    }
                }
                else {
                    words.Add(current.Id);
                }
            }

            //Add blank backlink lists for all words that don't already have a backlink list
            foreach (String current in words)
            {
                if (!backlinks.ContainsKey(current))
                {
                    backlinks[current] = new List<String>();
                }
            }

            //TO DO: Validate format
        }

        public bool AddWord(String inWord, String inPronunciation)
        {
            //Check to be sure that this word doesn't already exist
            if (dictionary.Rules.Contains(inWord))
            {
                return false;
            }

            //Create a token object that contains the word and pronunciation
            SrgsToken pronunciation = new SrgsToken(inWord);
            pronunciation.Display = inWord;
            pronunciation.Pronunciation = inPronunciation;

            //Contain the token in a one-of object so that multiple pronunciations can be supported
            SrgsOneOf pronunciations = new SrgsOneOf(new SrgsItem(pronunciation));

            //Make a new rule containing the one-of so that we can reference the rule in parts of speech
            SrgsRule word = new SrgsRule(inWord);
            word.Add(pronunciations);

            //Add the word's rule to the dictionary
            dictionary.Rules.Add(word);
            words.Add(inWord);
            backlinks[inWord] = new List<String>();
            return true;
        }

        public bool RemoveWord(String inWord)
        {
            //Remove the word object from the dictionary
            words.Remove(inWord);
            backlinks.Remove(inWord);
            return dictionary.Rules.Remove(inWord);
        }

        public bool AddPronunciation(String inWord, String inPronunciation)
        {
            //Check that this word exists in the dictionary
            if (!dictionary.Rules.Contains(inWord))
            {
                return false;
            }

            //Get the current list of pronunciations
            SrgsOneOf pronunciations = (SrgsOneOf) dictionary.Rules[inWord].Elements[0];

            //Create a new pronunciation object
            SrgsToken pronunciation = new SrgsToken(inWord);
            pronunciation.Display = inWord;
            pronunciation.Pronunciation = inPronunciation;

            //TO TEST: Check that this pronunciation does not already exist
            if (pronunciations.Items.Contains(new SrgsItem(pronunciation)))
            {
                return false;
            }

            //Add the pronunciation to the list
            pronunciations.Add(new SrgsItem(pronunciation));
            return true;
        }

        public bool RemovePronunciation(String inWord, String inPronunciation)
        {
            //Check that this word exists in the dictionary
            if (!dictionary.Rules.Contains(inWord))
            {
                return false;
            }

            //Get the current list of pronunciations
            SrgsOneOf pronunciations = (SrgsOneOf)dictionary.Rules[inWord].Elements[0];

            foreach (SrgsItem current in pronunciations.Items)
            {
                if (((SrgsToken) current.Elements[0]).Pronunciation.Equals(inPronunciation))
                {
                    //A word cannot contain no pronunciations
                    if (pronunciations.Items.Count == 1) 
                    {
                        return false;
                    }

                    return pronunciations.Items.Remove(current);
                }
            }

            //Pronunciation was not found. Return failure.
            return false;
        }

        public bool AddWordToPartOfSpeech(String inWord, String inPartOfSpeech)
        {
            //Check that this word and part of speech exist in the dictionary
            if (!dictionary.Rules.Contains(inWord) || !dictionary.Rules.Contains(inPartOfSpeech))
            {
                return false;
            }

            //Get the part of speech
            SrgsOneOf partOfSpeech = (SrgsOneOf) dictionary.Rules[inPartOfSpeech].Elements[0];

            //Create a rule reference object
            SrgsRuleRef word = new SrgsRuleRef(dictionary.Rules[inWord]);

            //Confirm that this word is not already contained in the part of speech
            if (partOfSpeech.Items.Contains(new SrgsItem(word)))
            {
                return false;
            }

            //TO TEST: Add the word to the part of speech
            partOfSpeech.Items.Add(new SrgsItem(word));
            backlinks[inWord].Add(inPartOfSpeech);
            return true;
        }

        public bool RemoveWordFromPartOfSpeech(String inWord, String inPartOfSpeech)
        {
            //Check that this word and part of speech exist in the dictionary
            if (!dictionary.Rules.Contains(inWord) || !dictionary.Rules.Contains(inPartOfSpeech))
            {
                return false;
            }

            //Get the part of speech
            SrgsOneOf partOfSpeech = (SrgsOneOf)dictionary.Rules[inPartOfSpeech].Elements[0];

            //TO TEST: Remove the word from the part of speech
            backlinks[inWord].Remove(inPartOfSpeech);
            foreach(SrgsItem current in partOfSpeech.Items)
            {
                if (((SrgsRuleRef) current.Elements[0]).Uri.ToString().Substring(1).Equals(inWord))
                {
                    return partOfSpeech.Items.Remove(current);
                }
            }
            return false;
        }

        public List<String> GetWords()
        {
            return words;
        }

        public List<String> GetPartsOfSpeech()
        {
            return partsOfSpeech;
        }

        public List<String> GetPronunciationsForWord(String inWord)
        {
            List<String> toReturn = new List<String>();

            //Check that this word exists in the dictionary
            if (!dictionary.Rules.Contains(inWord))
            {
                return null;
            }

            //Get the current list of pronunciations
            SrgsOneOf pronunciations = (SrgsOneOf) dictionary.Rules[inWord].Elements[0];

            //Add the pronunciation to the list
            foreach (SrgsItem current in pronunciations.Items) {
                SrgsToken currentWord = (SrgsToken) current.Elements[0];
                toReturn.Add(currentWord.Pronunciation);
            }

            return toReturn;
        }

        public List<String> GetPartsOfSpeechForWord(String inWord)
        {
            List<String> toReturn = new List<String>();

            //Check that this word exists in the dictionary
            if (!dictionary.Rules.Contains(inWord) || !backlinks.ContainsKey(inWord))
            {
                return null;
            }

            //Get the current list of parts of speech
            return backlinks[inWord];
        }

        public String GetSpeechSynthesisMarkupForWord(String desiredWord, int pronunciationIndex)
        {
            return "<phoneme alphabet=\"x-microsoft-ups\" ph=\"" + ((SrgsToken)((SrgsOneOf)dictionary.Rules[desiredWord].Elements[0]).Items[pronunciationIndex].Elements[0]).Pronunciation + "\"> " + desiredWord + " </phoneme>";
        }

        public void WriteDictionaryToFile(String filename)
        {
            XmlWriter writer = XmlWriter.Create(filename);
            dictionary.WriteSrgs(writer);
            writer.Flush();
            writer.Close();
        }
    }
}
