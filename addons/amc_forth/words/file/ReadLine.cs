using Godot;

namespace Forth.File
{
    [GlobalClass]
    public partial class ReadLine : Words
    {
        public ReadLine(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "READ-LINE";
            Description =
                "Read and store one line of text from file and update FILE-POSITION. On "
                + "success, ior is zero, flag is true and n2 is the number of chars read. "
                + "On EOF, ior is zero, flag is false, and u2 is zero.";
            StackEffect = "( c-addr u1 fileid -- u2 flag ior )";
        }

        public override void Call()
        {
            var file = Files.GetFileFromId(Stack.Pop());
            var u1 = Stack.Pop();
            var c_addr = Stack.Pop();
            var u2 = 0;
            var flag = AMCForth.False;
            var ior = 0;
            if ((file != null) && !file.EofReached())
            {
                string line = file.GetLine();
                u2 = System.Math.Min(line.Length, u1);
                flag = AMCForth.True;
                Forth.Util.StringFromStr(c_addr, u1, line); // copy incoming string to buffer
                Forth.Ram.SetByte(c_addr + u2, 0); // null terminate
            }

            Stack.Push(u2);
            Stack.Push(flag);
            Stack.Push(ior);
        }
    }
}
