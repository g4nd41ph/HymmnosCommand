using System;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Collections.Generic;

namespace HymmnosRecognize
{
    class Macro
    {
        private Grammar command;
        private List<KeyCommand> keystrokes;
        private PromptBuilder prompt;

        public Macro(Grammar inCommand, List<KeyCommand> inResponse, PromptBuilder inPrompt)
        {
            command = inCommand;
            keystrokes = inResponse;
            prompt = inPrompt;
        }

        public Grammar getCommand()
        {
            return command;
        }

        public List<KeyCommand> getKeystrokes()
        {
            return keystrokes;
        }

        public PromptBuilder getPrompt()
        {
            return prompt;
        }
    }
}
