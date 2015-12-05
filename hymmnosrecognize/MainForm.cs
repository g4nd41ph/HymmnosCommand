using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Speech.Synthesis;
using System.Speech.Recognition;
using System.Speech.Recognition.SrgsGrammar;
using System.IO;
using System.Xml;
using WindowsInput;
using WindowsInput.Native;
using System.Diagnostics;

namespace HymmnosRecognize
{
	public partial class MainForm : Form
	{
		private SpeechRecognitionEngine recognitionEngine = new SpeechRecognitionEngine();
        private SpeechSynthesizer synthesisEngine = new SpeechSynthesizer();
        private List<Macro> macros = new List<Macro>();
        private HymmnosDictionary dictionary;

        //Reads in the file of command-response pairs
        public void ReadMacros(string filename)
        {
            try
            {
                //Open file input stream
                StreamReader reader = new StreamReader(filename);
                String line = reader.ReadLine();

                while (line != null)
                {
                    //If this is the command section, start defining a grammar
                    if (line == "Command:")
                    {
                        String name = reader.ReadLine();

                        //Define a rule
                        SrgsDocument tempDictionary = dictionary.GetSrgsDocument();
                        SrgsRule rule = new SrgsRule(name);
                        rule.Scope = SrgsRuleScope.Public;
                        line = reader.ReadLine();
                        while (line != "End")
                        {
                            rule.Add(new SrgsItem(new SrgsRuleRef(tempDictionary.Rules[line])));
                            line = reader.ReadLine();
                        }

                        //Add this rule to the dictionary document
                        tempDictionary.Rules.Remove(rule);
                        tempDictionary.Rules.Add(rule);

                        //Create a grammar object
                        Grammar grammar = new Grammar(tempDictionary, name);
                        grammar.Name = name;

                        //Load this grammar object into the speech recognition engine
                        recognitionEngine.LoadGrammar(grammar);

                        //Advance to the definition for the keystrokes
                        while (line != "Keys:")
                        {
                            line = reader.ReadLine();
                        }
                        line = reader.ReadLine();

                        //Read the strokes in this command
                        List<KeyCommand> command = new List<KeyCommand>();
                        while (line != "End")
                        {
                            //Read the keystroke data
                            String type = line;
                            String key = reader.ReadLine();

                            switch (type)
                            {
                                case "DOWN":
                                    command.Add(new KeyCommand(CommandType.Down, KeyCommand.GetKeyCode(key)));
                                    break;
                                case "UP":
                                    command.Add(new KeyCommand(CommandType.Up, KeyCommand.GetKeyCode(key)));
                                    break;
                                case "PRESS":
                                    command.Add(new KeyCommand(CommandType.Press, KeyCommand.GetKeyCode(key)));
                                    break;
                                default:
                                    break;
                            }

                            line = reader.ReadLine();
                        }

                        //Advance to the definition for the speech output
                        while (line != "Prompt:")
                        {
                            line = reader.ReadLine();
                        }
                        line = reader.ReadLine();

                        //Read in the words for the speech output and add them to a prompt
                        PromptBuilder prompt = new PromptBuilder();
                        while (line != "End")
                        {
                            //Add this word to the prompt
                            prompt.AppendSsmlMarkup(dictionary.GetSpeechSynthesisMarkupForWord(line, 0));

                            //Advance a line
                            line = reader.ReadLine();
                        }

                        //Add this command to the list of macros
                        macros.Add(new Macro(grammar, command, prompt));
                    }

                    //Advance a line
                    line = reader.ReadLine();
                }
                LogToBox("Macro file loaded successfully!");
            }
            catch (Exception e)
            {
                LogToBox("Macro file failed to load. Exception with message:");
                LogToBox(e.Message);
            }
        }

		
		public MainForm()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
            //Add event handlers
            recognitionEngine.AudioSignalProblemOccurred += engine_AudioSignalProblemOccurred;
            recognitionEngine.RecognizeCompleted += engine_RecognizeCompleted;
            recognitionEngine.SpeechDetected += engine_SpeechDetected;
            recognitionEngine.SpeechRecognitionRejected += engine_SpeechRecognitionRejected;
            recognitionEngine.SpeechRecognized += engine_SpeechRecognized;

            //Load dictionary file
            try
            {
                dictionary = new HymmnosDictionary();
                dictionary.LoadDictionary(Properties.Settings.Default.DictionaryPath);
                LogToBox("Dictionary file loaded successfully!");
            }
            catch (Exception ex)
            {
                LogToBox("Dictionary failed to load. Exception with message:");
                LogToBox(ex.Message);
            }
            dictionaryText.Text = Properties.Settings.Default.DictionaryPath;

            //Load macro file
            ReadMacros(Properties.Settings.Default.MacroPath);
            macroText.Text = Properties.Settings.Default.MacroPath;
		
		    //Set engine parameters
            recognitionEngine.SetInputToDefaultAudioDevice();
            recognitionEngine.EndSilenceTimeout = new TimeSpan(0, 0, 2);
		}

		private void engine_AudioSignalProblemOccurred(Object sender, AudioSignalProblemOccurredEventArgs e) {
			LogToBox("Audio Signal Problem: " + e.AudioSignalProblem.ToString());
		}

	    private void engine_SpeechRecognitionRejected(Object sender, SpeechRecognitionRejectedEventArgs e) {
		    LogToBox("Speech Rejected.");
	    }

	    private void engine_RecognizeCompleted(Object sender, RecognizeCompletedEventArgs e) {
		    LogToBox("Recognition Complete!");
	    }

	    private void engine_SpeechRecognized(Object sender, SpeechRecognizedEventArgs e) {
		    //Debug ouptut
            LogToBox("Recognized: " + e.Result.Text);
            LogToBox("Confidence: " + e.Result.Confidence.ToString("##0.0##"));

            //Execute proper response
            InputSimulator input = new InputSimulator();
            foreach (Macro macro in macros)
            {
                if (macro.getCommand() == e.Result.Grammar)
                {
                    //Speak response prompt
                    synthesisEngine.SpeakAsync(macro.getPrompt());

                    //Execute keyboard macro
                    foreach (KeyCommand current in macro.getKeystrokes())
                    {
                        current.Execute(input);
                    }
                }
            }
	    }

	    private void engine_SpeechDetected(Object sender, SpeechDetectedEventArgs e) {
		    LogToBox("Speech Detected!");
	    }

		private void TestButton_Click(object Sender, EventArgs e)
		{
            recognitionEngine.RecognizeAsync();
		}

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Remove event handlers
            recognitionEngine.AudioSignalProblemOccurred -= engine_AudioSignalProblemOccurred;
            recognitionEngine.RecognizeCompleted -= engine_RecognizeCompleted;
            recognitionEngine.SpeechDetected -= engine_SpeechDetected;
            recognitionEngine.SpeechRecognitionRejected -= engine_SpeechRecognitionRejected;
            recognitionEngine.SpeechRecognized -= engine_SpeechRecognized;
        }

        private void dictionaryOpen_Click(object sender, EventArgs e)
        {
            //Create the dictionary if it is not already initialized
            if (dictionary == null)
            {
                dictionary = new HymmnosDictionary();
            }

            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //Set text on the UI
                dictionaryText.Text = dialog.FileName;

                //Reload the dictionary from the new file
                try
                {
                    dictionary.LoadDictionary(dialog.FileName);
                    LogToBox("Dictionary file loaded successfully!");
                }
                catch (Exception ex)
                {
                    LogToBox("Dictionary failed to load. Exception with message:");
                    LogToBox(ex.Message);
                }


                //Change applicaiton setting and save it
                Properties.Settings.Default.DictionaryPath = dialog.FileName;
                Properties.Settings.Default.Save();
            }
        }

        private void macroOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //Set text on the UI
                macroText.Text = dialog.FileName;

                //Reload the macros
                macros = new List<Macro>();
                ReadMacros(dialog.FileName);

                //Change applicaiton setting and save it
                Properties.Settings.Default.MacroPath = dialog.FileName;
                Properties.Settings.Default.Save();
            }
        }

        public void LogToBox(string message)
        {
            //Add a message to the box
            logBox.AppendText(message + "\r\n");

            //Remove text to keep the total size to a sane amount
            if (logBox.Text.Length > 2048)
            {
                logBox.Text = logBox.Text.Substring(logBox.Text.Length - 2048, 2048);
            }
        }

        private void dictionaryManage_Click(object sender, EventArgs e)
        {
            DictionaryForm dictionaryForm = new DictionaryForm(dictionary);
            dictionaryForm.Show();
        }
	}
}
