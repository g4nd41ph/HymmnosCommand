using System;
using System.Threading;
using System.Diagnostics;
using WindowsInput;
using WindowsInput.Native;

namespace HymmnosRecognize
{

    enum CommandType
    {
        Down,
        Up,
        Press
    }

    class KeyCommand
    {
        private CommandType type;
        private VirtualKeyCode key;

        public KeyCommand(CommandType inType, VirtualKeyCode inKey)
        {
            type = inType;
            key = inKey;
        }

        public void Execute(InputSimulator input)
        {
            switch (type)
            {
                case CommandType.Down:
                    input.Keyboard.KeyDown(key);
                    break;
                case CommandType.Up:
                    input.Keyboard.KeyUp(key);
                    break;
                case CommandType.Press:
                    input.Keyboard.KeyPress(key);
                    break;
                default:
                    break;
            }

            Thread.Sleep(100);
        }

        public static VirtualKeyCode GetKeyCode(String input) {
            input = input.ToUpper().Trim();

            switch (input)
            {
                case "ACCEPT":
                    return VirtualKeyCode.ACCEPT;
                case "ADD":
                    return VirtualKeyCode.ADD;
                case "APPS":
                    return VirtualKeyCode.APPS;
                case "ATTN":
                    return VirtualKeyCode.ATTN;
                case "BACK":
                    return VirtualKeyCode.BACK;
                case "BROWSER_BACK":
                    return VirtualKeyCode.BROWSER_BACK;
                case "BROWSER_FAVORITES":
                    return VirtualKeyCode.BROWSER_FAVORITES;
                case "BROWSER_FORWARD":
                    return VirtualKeyCode.BROWSER_FORWARD;
                case "BROWSER_HOME":
                    return VirtualKeyCode.BROWSER_HOME;
                case "BROWSER_REFRESH":
                    return VirtualKeyCode.BROWSER_REFRESH;
                case "BROWSER_SEARCH":
                    return VirtualKeyCode.BROWSER_SEARCH;
                case "BROWSER_STOP":
                    return VirtualKeyCode.BROWSER_STOP;
                case "CANCEL":
                    return VirtualKeyCode.CANCEL;
                case "CAPITAL":
                    return VirtualKeyCode.CAPITAL;
                case "CLEAR":
                    return VirtualKeyCode.CLEAR;
                case "CONTROL":
                    return VirtualKeyCode.CONTROL;
                case "CONVERT":
                    return VirtualKeyCode.CONVERT;
                case "CRSEL":
                    return VirtualKeyCode.CRSEL;
                case "DECIMAL":
                    return VirtualKeyCode.DECIMAL;
                case "DELETE":
                    return VirtualKeyCode.DELETE;
                case "DIVIDE":
                    return VirtualKeyCode.DIVIDE;
                case "DOWN":
                    return VirtualKeyCode.DOWN;
                case "END":
                    return VirtualKeyCode.END;
                case "EREOF":
                    return VirtualKeyCode.EREOF;
                case "ESCAPE":
                    return VirtualKeyCode.ESCAPE;
                case "EXECUTE":
                    return VirtualKeyCode.EXECUTE;
                case "EXSEL":
                    return VirtualKeyCode.EXSEL;
                case "F1":
                    return VirtualKeyCode.F1;
                case "F10":
                    return VirtualKeyCode.F10;
                case "F11":
                    return VirtualKeyCode.F11;
                case "F12":
                    return VirtualKeyCode.F12;
                case "F13":
                    return VirtualKeyCode.F13;
                case "F14":
                    return VirtualKeyCode.F14;
                case "F15":
                    return VirtualKeyCode.F15;
                case "F16":
                    return VirtualKeyCode.F16;
                case "F17":
                    return VirtualKeyCode.F17;
                case "F18":
                    return VirtualKeyCode.F18;
                case "F19":
                    return VirtualKeyCode.F19;
                case "F2":
                    return VirtualKeyCode.F2;
                case "F20":
                    return VirtualKeyCode.F20;
                case "F21":
                    return VirtualKeyCode.F21;
                case "F22":
                    return VirtualKeyCode.F22;
                case "F23":
                    return VirtualKeyCode.F23;
                case "F24":
                    return VirtualKeyCode.F24;
                case "F3":
                    return VirtualKeyCode.F3;
                case "F4":
                    return VirtualKeyCode.F4;
                case "F5":
                    return VirtualKeyCode.F5;
                case "F6":
                    return VirtualKeyCode.F6;
                case "F7":
                    return VirtualKeyCode.F7;
                case "F8":
                    return VirtualKeyCode.F8;
                case "F9":
                    return VirtualKeyCode.F9;
                case "FINAL":
                    return VirtualKeyCode.FINAL;
                case "HANGEUL":
                    return VirtualKeyCode.HANGEUL;
                case "HANGUL":
                    return VirtualKeyCode.HANGUL;
                case "HANJA":
                    return VirtualKeyCode.HANJA;
                case "HELP":
                    return VirtualKeyCode.HELP;
                case "HOME":
                    return VirtualKeyCode.HOME;
                case "INSERT":
                    return VirtualKeyCode.INSERT;
                case "JUNJA":
                    return VirtualKeyCode.JUNJA;
                case "KANA":
                    return VirtualKeyCode.KANA;
                case "KANJI":
                    return VirtualKeyCode.KANJI;
                case "LAUNCH_APP1":
                    return VirtualKeyCode.LAUNCH_APP1;
                case "LAUNCH_APP2":
                    return VirtualKeyCode.LAUNCH_APP2;
                case "LAUNCH_MAIL":
                    return VirtualKeyCode.LAUNCH_MAIL;
                case "LAUNCH_MEDIA_SELECT":
                    return VirtualKeyCode.LAUNCH_MEDIA_SELECT;
                case "LBUTTON":
                    return VirtualKeyCode.LBUTTON;
                case "LCONTROL":
                    return VirtualKeyCode.LCONTROL;
                case "LEFT":
                    return VirtualKeyCode.LEFT;
                case "LMENU":
                    return VirtualKeyCode.LMENU;
                case "LSHIFT":
                    return VirtualKeyCode.LSHIFT;
                case "LWIN":
                    return VirtualKeyCode.LWIN;
                case "MBUTTON":
                    return VirtualKeyCode.MBUTTON;
                case "MEDIA_NEXT_TRACK":
                    return VirtualKeyCode.MEDIA_NEXT_TRACK;
                case "MEDIA_PLAY_PAUSE":
                    return VirtualKeyCode.MEDIA_PLAY_PAUSE;
                case "MEDIA_PREV_TRACK":
                    return VirtualKeyCode.MEDIA_PREV_TRACK;
                case "MEDIA_STOP":
                    return VirtualKeyCode.MEDIA_STOP;
                case "MENU":
                    return VirtualKeyCode.MENU;
                case "MODECHANGE":
                    return VirtualKeyCode.MODECHANGE;
                case "MULTIPLY":
                    return VirtualKeyCode.MULTIPLY;
                case "NEXT":
                    return VirtualKeyCode.NEXT;
                case "NONAME":
                    return VirtualKeyCode.NONAME;
                case "NONCONVERT":
                    return VirtualKeyCode.NONCONVERT;
                case "NUMLOCK":
                    return VirtualKeyCode.NUMLOCK;
                case "NUMPAD0":
                    return VirtualKeyCode.NUMPAD0;
                case "NUMPAD1":
                    return VirtualKeyCode.NUMPAD1;
                case "NUMPAD2":
                    return VirtualKeyCode.NUMPAD2;
                case "NUMPAD3":
                    return VirtualKeyCode.NUMPAD3;
                case "NUMPAD4":
                    return VirtualKeyCode.NUMPAD4;
                case "NUMPAD5":
                    return VirtualKeyCode.NUMPAD5;
                case "NUMPAD6":
                    return VirtualKeyCode.NUMPAD6;
                case "NUMPAD7":
                    return VirtualKeyCode.NUMPAD7;
                case "NUMPAD8":
                    return VirtualKeyCode.NUMPAD8;
                case "NUMPAD9":
                    return VirtualKeyCode.NUMPAD9;
                case "OEM_1":
                    return VirtualKeyCode.OEM_1;
                case "OEM_102":
                    return VirtualKeyCode.OEM_102;
                case "OEM_2":
                    return VirtualKeyCode.OEM_2;
                case "OEM_3":
                    return VirtualKeyCode.OEM_3;
                case "OEM_4":
                    return VirtualKeyCode.OEM_4;
                case "OEM_5":
                    return VirtualKeyCode.OEM_5;
                case "OEM_6":
                    return VirtualKeyCode.OEM_6;
                case "OEM_7":
                    return VirtualKeyCode.OEM_7;
                case "OEM_8":
                    return VirtualKeyCode.OEM_8;
                case "OEM_CLEAR":
                    return VirtualKeyCode.OEM_CLEAR;
                case "OEM_COMMA":
                    return VirtualKeyCode.OEM_COMMA;
                case "OEM_MINUS":
                    return VirtualKeyCode.OEM_MINUS;
                case "OEM_PERIOD":
                    return VirtualKeyCode.OEM_PERIOD;
                case "OEM_PLUS":
                    return VirtualKeyCode.OEM_PLUS;
                case "PA1":
                    return VirtualKeyCode.PA1;
                case "PACKET":
                    return VirtualKeyCode.PACKET;
                case "PAUSE":
                    return VirtualKeyCode.PAUSE;
                case "PLAY":
                    return VirtualKeyCode.PLAY;
                case "PRINT":
                    return VirtualKeyCode.PRINT;
                case "PRIOR":
                    return VirtualKeyCode.PRIOR;
                case "PROCESSKEY":
                    return VirtualKeyCode.PROCESSKEY;
                case "RBUTTON":
                    return VirtualKeyCode.RBUTTON;
                case "RCONTROL":
                    return VirtualKeyCode.RCONTROL;
                case "RETURN":
                    return VirtualKeyCode.RETURN;
                case "RIGHT":
                    return VirtualKeyCode.RIGHT;
                case "RMENU":
                    return VirtualKeyCode.RMENU;
                case "RSHIFT":
                    return VirtualKeyCode.RSHIFT;
                case "RWIN":
                    return VirtualKeyCode.RWIN;
                case "SCROLL":
                    return VirtualKeyCode.SCROLL;
                case "SELECT":
                    return VirtualKeyCode.SELECT;
                case "SEPARATOR":
                    return VirtualKeyCode.SEPARATOR;
                case "SHIFT":
                    return VirtualKeyCode.SHIFT;
                case "SLEEP":
                    return VirtualKeyCode.SLEEP;
                case "SNAPSHOT":
                    return VirtualKeyCode.SNAPSHOT;
                case "SPACE":
                    return VirtualKeyCode.SPACE;
                case "SUBTRACT":
                    return VirtualKeyCode.SUBTRACT;
                case "TAB":
                    return VirtualKeyCode.TAB;
                case "UP":
                    return VirtualKeyCode.UP;
                case "0":
                    return VirtualKeyCode.VK_0;
                case "1":
                    return VirtualKeyCode.VK_1;
                case "2":
                    return VirtualKeyCode.VK_2;
                case "3":
                    return VirtualKeyCode.VK_3;
                case "4":
                    return VirtualKeyCode.VK_4;
                case "5":
                    return VirtualKeyCode.VK_5;
                case "6":
                    return VirtualKeyCode.VK_6;
                case "7":
                    return VirtualKeyCode.VK_7;
                case "8":
                    return VirtualKeyCode.VK_8;
                case "9":
                    return VirtualKeyCode.VK_9;
                case "A":
                    return VirtualKeyCode.VK_A;
                case "B":
                    return VirtualKeyCode.VK_B;
                case "C":
                    return VirtualKeyCode.VK_C;
                case "D":
                    return VirtualKeyCode.VK_D;
                case "E":
                    return VirtualKeyCode.VK_E;
                case "F":
                    return VirtualKeyCode.VK_F;
                case "G":
                    return VirtualKeyCode.VK_G;
                case "H":
                    return VirtualKeyCode.VK_H;
                case "I":
                    return VirtualKeyCode.VK_I;
                case "J":
                    return VirtualKeyCode.VK_J;
                case "K":
                    return VirtualKeyCode.VK_K;
                case "L":
                    return VirtualKeyCode.VK_L;
                case "M":
                    return VirtualKeyCode.VK_M;
                case "N":
                    return VirtualKeyCode.VK_N;
                case "O":
                    return VirtualKeyCode.VK_O;
                case "P":
                    return VirtualKeyCode.VK_P;
                case "Q":
                    return VirtualKeyCode.VK_Q;
                case "R":
                    return VirtualKeyCode.VK_R;
                case "S":
                    return VirtualKeyCode.VK_S;
                case "T":
                    return VirtualKeyCode.VK_T;
                case "U":
                    return VirtualKeyCode.VK_U;
                case "V":
                    return VirtualKeyCode.VK_V;
                case "W":
                    return VirtualKeyCode.VK_W;
                case "X":
                    return VirtualKeyCode.VK_X;
                case "Y":
                    return VirtualKeyCode.VK_Y;
                case "Z":
                    return VirtualKeyCode.VK_Z;
                case "VOLUME_DOWN":
                    return VirtualKeyCode.VOLUME_DOWN;
                case "VOLUME_MUTE":
                    return VirtualKeyCode.VOLUME_MUTE;
                case "VOLUME_UP":
                    return VirtualKeyCode.VOLUME_UP;
                case "XBUTTON1":
                    return VirtualKeyCode.XBUTTON1;
                case "XBUTTON2":
                    return VirtualKeyCode.XBUTTON2;
                case "ZOOM":
                    return VirtualKeyCode.ZOOM;
                default:
                    Debug.Print("Unrecognized key string: " + input);
                    return VirtualKeyCode.NONAME;
            }
        }
    }
}
