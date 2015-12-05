using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Recognition.SrgsGrammar;
using System.Windows.Forms;
using System.Diagnostics;
using System.Speech.Synthesis;
using System.Text.RegularExpressions;

namespace HymmnosRecognize
{
    public partial class DictionaryForm : Form
    {
        private HymmnosDictionary dictionary;
        private SpeechSynthesizer synthesisEngine = new SpeechSynthesizer();

        public DictionaryForm(HymmnosDictionary inDictionary)
        {
            InitializeComponent();
            dictionary = inDictionary;
            InitializeDisplay();
        }

        //Clears the display for a new dictionary
        public void InitializeDisplay()
        {
            //Clear out the current lists
            partOfSpeechList.Items.Clear();
            wordList.Items.Clear();
            pronunciationList.Items.Clear();

            //Populate the new lists
            foreach (string current in dictionary.GetPartsOfSpeech()) {
                partOfSpeechList.Items.Add(current);
            }
            foreach (string current in dictionary.GetWords())
            {
                wordList.Items.Add(current);
            }

            //Resize list view columns
            pronunciationList.Columns[0].Width = pronunciationList.Width - 20;
            wordList.Columns[0].Width = wordList.Width - 20;
            partOfSpeechList.Columns[0].Width = partOfSpeechList.Width - 20;
        }

        //Update the display to reflect this new selected word
        private void wordList_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateUI();
        }

        private void UpdateUI()
        {
            //Update the pronunciation list
            pronunciationList.Items.Clear();

            foreach (ListViewItem currentItem in wordList.SelectedItems)
            {
                foreach (String current in dictionary.GetPronunciationsForWord(currentItem.Text))
                {
                    pronunciationList.Items.Add(current);
                }

                //Update the part of speech list
                List<String> partsOfSpeech = dictionary.GetPartsOfSpeechForWord(currentItem.Text);
                foreach (ListViewItem current in partOfSpeechList.Items)
                {
                    if (partsOfSpeech.Contains(current.Text))
                    {
                        current.BackColor = Color.Green;
                    }
                    else
                    {
                        current.BackColor = SystemColors.Window;
                    }
                }
            }
        }

        private void DictionaryForm_Resize(object sender, EventArgs e)
        {
            //Resize list view columns
            pronunciationList.Columns[0].Width = pronunciationList.Width - 20;
            wordList.Columns[0].Width = wordList.Width - 20;
            partOfSpeechList.Columns[0].Width = partOfSpeechList.Width - 20;
        }

        private void testPronunciationButton_Click(object sender, EventArgs e)
        {
            //Validate that a pronunciation is selected
            if (pronunciationList.SelectedItems.Count == 0)
            {
                return;
            }

            //Test selected pronunciation
            foreach (ListViewItem current in wordList.SelectedItems)
            {
                //Create a PromptBuilder object and pack the pronunciation in it
                PromptBuilder builder = new PromptBuilder();
                builder.AppendSsmlMarkup("<phoneme alphabet=\"x-microsoft-ups\" ph=\"" + pronunciationList.SelectedItems[0].Text + "\"> test </phoneme>");

                //Speak the word
                synthesisEngine.SpeakAsync(builder);
            }
        }

        private void addPronunciationButton_Click(object sender, EventArgs e)
        {
            //Validate that a pronunciation is entered
            if (pronunciationBox.Text.Length == 0)
            {
                return;
            }

            //TO DO: Validate that the pronunciation is valid Microsoft UPS

            //Add pronunciation to dictionary
            dictionary.AddPronunciation(wordList.SelectedItems[0].Text, pronunciationBox.Text);
            UpdateUI();
        }

        private void removePronunciationButton_Click(object sender, EventArgs e)
        {
            //Validate that a pronunciation is selected
            if (pronunciationList.SelectedItems.Count == 0)
            {
                return;
            }

            //Remove pronunciation from dictionary
            dictionary.RemovePronunciation(wordList.SelectedItems[0].Text, pronunciationList.SelectedItems[0].Text);
            UpdateUI();
        }

        private void addWordButton_Click(object sender, EventArgs e)
        {
            //Validate that a pronunciation has been entered
            if (pronunciationBox.Text.Length == 0)
            {
                return;
            }

            //TO DO: Validate that the pronunciation is valid Microsoft UPS

            //Add this word to the dictionary
            dictionary.AddWord(wordBox.Text, pronunciationBox.Text);
            wordList.Items.Add(new ListViewItem(wordBox.Text));
            UpdateUI();
        }

        private void removeWordButton_Click(object sender, EventArgs e)
        {
            //Validate that a word has been selected
            if (wordList.SelectedItems.Count == 0)
            {
                return;
            }

            //Remove this word from the dictionary
            dictionary.RemoveWord(wordBox.Text);
            foreach (ListViewItem current in wordList.Items)
            {
                if (current.Text.Equals(wordBox.Text))
                {
                    wordList.Items.Remove(current);
                    return;
                }
            }
        }

        private void addPartOfSpeechButton_Click(object sender, EventArgs e)
        {
            //Confirm that a Part of Speech is selected and that a word is selected
            if (partOfSpeechList.SelectedItems.Count == 0 || wordList.SelectedItems.Count == 0)
            {
                return;
            }

            //Add this part of speech to the list for this word
            dictionary.AddWordToPartOfSpeech(wordList.SelectedItems[0].Text, partOfSpeechList.SelectedItems[0].Text);
            UpdateUI();
        }

        private void removePartOfSpeechButton_Click(object sender, EventArgs e)
        {
            //Confirm that a Part of Speech is selected and that a word is selected
            if (partOfSpeechList.SelectedItems.Count == 0 || wordList.SelectedItems.Count == 0)
            {
                return;
            }

            //Add this part of speech to the list for this word
            dictionary.RemoveWordFromPartOfSpeech(wordList.SelectedItems[0].Text, partOfSpeechList.SelectedItems[0].Text);
            UpdateUI();
        }

        private void writeButton_Click(object sender, EventArgs e)
        {
            //Write the current dictionary out to a file
            dictionary.WriteDictionaryToFile(Properties.Settings.Default.DictionaryPath);
        }

        private void wordFilter_TextChanged(object sender, EventArgs e)
        {
            wordList.Items.Clear();
            String value = wordFilter.Text.Trim();
            
            //If the selection is nothing, then show everything
            if (value.Equals(""))
            {
                value = ".*";
            }

            //Otherwise, show only words that fit the filter
            else
            {
                foreach (String current in dictionary.GetWords())
                {
                    if (Regex.Match(current, value, RegexOptions.IgnoreCase).Success)
                    {
                        wordList.Items.Add(current);
                    }
                }
            }

            //Update the UI, as the selected word has changed
            UpdateUI();
        }
    }
}
