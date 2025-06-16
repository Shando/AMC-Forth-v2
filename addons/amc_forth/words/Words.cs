using System;
using System.Collections;
using System.Globalization;
using System.Threading;
using Godot;

// Base class and utilities for Forth word definition

namespace Forth
{
    [GlobalClass]
    public partial class Words : RefCounted, IComparable<Words>
    {
        public AMCForth Forth;
        public Stack Stack;
        public Files Files;
        public bool Immediate;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                _saltedName = Salt + _name;
                Xt = (int)(AMCForth.BuiltInXtMask + (AMCForth.BuiltInMask & _saltedName.Hash()));
                XtX = (int)(AMCForth.BuiltInXtXMask + (AMCForth.BuiltInMask & _saltedName.Hash()));
                CheckXtDuplicates(); // requires name to be set, sets Xt and XtX
                Forth.BuiltinNameDict[value] = this; // associate <Forth Word> to its C# instance
                Forth.BuiltinXtDict[Xt] = this; // associate Xt and XtX with their C# instance
                Forth.BuiltinXtDict[XtX] = this;
            }
        }

        public string Description;
        public string StackEffect;
        public int PreVal = 0;
        public int PostVal = 0;
        public string WordSet;
        public int Xt; // built-in execution token
        public int XtX; // built-in compiled execution token

        private string _name;
        private string _saltedName;
        protected string Salt = ""; // define BEFORE Name in overriding classes (if collision).
        public static bool bRunning = false;

        public Words(AMCForth forth, string wordset)
        {
            Forth = forth;
            Stack = Forth.Stack;
            Files = Forth.Files;
            Immediate = false;
            WordSet = wordset;
        }

        public virtual void Call() { }

        public virtual void CallExec() { }

        private void CheckXtDuplicates()
        {
            if (Forth.BuiltinXtDict.ContainsKey(Xt) || Forth.BuiltinXtDict.ContainsKey(XtX))
                throw new InvalidOperationException("Duplicate Forth word was defined (hash collision): (" + _name + ")");
        }

        public bool HasName(string name)
        {
            return Forth.BuiltinNameDict.ContainsKey(name);
        }

        public Words FromXt(int xt)
        {
            if (Forth.BuiltinXtDict.ContainsKey(xt))
                return Forth.BuiltinXtDict[xt];
            else
                throw new ArgumentOutOfRangeException(xt.ToString(), "Unrecognised Built-In Execution Token");
        }

        // Is the xt for a built-in function?
        public static bool IsBuiltInXt(int xt)
        {
            return (xt & (AMCForth.BuiltInXtMask | AMCForth.BuiltInXtXMask)) != 0;
        }

        public void CallXt(int xt)
        {
            if (bRunning)
            {
                Thread.Sleep(25);
                bRunning = false;
            }

            var word = FromXt(xt);

            try
            {
                if ((xt & AMCForth.BuiltInXtMask) != 0)
                    word.Call();
                else
                    word.CallExec();
            }
            catch (Exception e)
            {
                Forth.Util.RprintError($" {e.GetType().Name} : {e.Message}");
            }
        }

        public int CompareTo(Words x)
        {
            var comparer = new Comparer(CultureInfo.InvariantCulture);
            return comparer.Compare(Name, x.Name);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
