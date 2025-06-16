using Godot;
using System;

namespace Forth.Shando
{
    [GlobalClass]
    public partial class Rnd : Words
    {
        public Rnd(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "RAND";
            Description = "Generate a random number between 'n1' and 'n2' inclusive."
                + " Example usage: 0 10 RAND";
            StackEffect = "( n1 n2 -- n3 )";
        }

        public override void Call()
        {
            int n2 = Stack.Pop();
            int n1 = Stack.Pop();

            if (n1 < 0)
            {
                throw new ArgumentOutOfRangeException($"RAND - Minimum value of {n1} is less than 0.");
            }
            else if (n2 < n1)
                throw new ArgumentOutOfRangeException($"RAND - Maximum value {n2} is less than Minimum value {n1}.");
            else
            {
                var random = new Random();
                int rnd = random.Next(n1, n2 + 1);

                Stack.Push(rnd);
            }
        }
    }
}
