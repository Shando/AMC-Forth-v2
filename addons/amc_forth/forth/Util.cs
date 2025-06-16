using System;
using System.Globalization;
using System.Linq;
using Godot;

//# Forth internal utilities

//#

namespace Forth
{
    [GlobalClass]
    public partial class Util : RefCounted
    {
        protected AMCForth _Forth;

        //# Create with a reference to AMCForth
        public void Initialize(AMCForth forth)
        {
            _Forth = forth;
        }

        //# Send a newline character to the terminal out
        public void EmitNewline()
        {
            _Forth.EmitSignal("TerminalOut", Terminal.CRLF);
        }

        //# Send text to the terminal out, with a following newline
        public void RprintTerm(string text)
        {
            PrintTerm(text);
            EmitNewline();
        }

        public void RprintError(string text)
        {
            text = "[color=#FFA500]" + text + "[/color]";
            PrintTerm(text);
            EmitNewline();
        }

        //# Send text to the terminal out
        public void PrintTerm(string text)
        {
            _Forth.EmitSignal("TerminalOut", text);
        }

        //# Report an unrecognized Forth word
        public void PrintUnknownWord(string word)
        {
            RprintError(" " + word + " ?");
        }

        //# Return a gdscript string from address and length
        public string StrFromAddrN(int addr, int n)
        {
            var t = "";

            for (int c = 0; c < n; c++)
            {
                t += (char)_Forth.Ram.GetByte(addr + c);
            }

            return t;
        }

        //# Create a Forth counted string frm a gdscript string
        public void CstringFromStr(int addr, string s)
        {
            var n = addr;
            _Forth.Ram.SetByte(n, s.Length);
            n += 1;

            foreach (char c in s.ToAsciiBuffer().Select(v => (char)v))
            {
                _Forth.Ram.SetByte(n, c);
                n += 1;
            }
        }

        //# Copy at most n string characters to address
        public void StringFromStr(int addr, int n, string s)
        {
            var ptr = addr;

            foreach (char c in s.Substr(0, n).ToAsciiBuffer().Select(v => (char)v))
            {
                _Forth.Ram.SetByte(ptr, c);
                ptr += 1;
            }
        }

        public static bool IsValidInt(string word, int radix = 10)
        {
            if (radix == 16)
            {
                return word.IsValidHexNumber();
            }

            return word.IsValidInt();
        }

        public static bool IsValidLong(string word, int radix = 10)
        {
            if (radix == 16)
            {
                return long.TryParse(
                    word,
                    NumberStyles.AllowHexSpecifier,
                    CultureInfo.InvariantCulture,
                    out long _
                );
            }

            return long.TryParse(word, out _);
        }

        public static int ToInt(string word, int radix = 10)
        {
            return Convert.ToInt32(word, radix);
        }

        public static long ToLong(string word, int radix = 10)
        {
            return Convert.ToInt64(word, radix);
        }
    }
}
