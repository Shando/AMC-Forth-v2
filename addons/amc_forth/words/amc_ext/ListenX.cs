using Godot;

namespace Forth.AMCExt
{
    [GlobalClass]
    public partial class ListenX : Words
    {
        public ListenX(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "LISTENX";
            Description =
                "Add a lookup entry for the IO port p, to execute xt."
                + "Events to port p are enqueued with q mode (0, 1, 2),"
                + " where q = enqueue: 0 - always, 1 - if new value, 2 - replace all prior.<br/>"
                + "NOTE: An input port may have only one handler word.";
            StackEffect = "( xt p q - )";
        }

        public override void Call()
        {
            // Store the queue mode
            var q = Stack.Pop(); // queue mode  ( xt p )
            var p = Stack.Pop(); // port number ( xt )
            Stack.Push(Map.IoInMapStart + p * 2 * RAM.CellSize); // address of xt  ( xt addr )
            Forth.CoreWords.Store.Call(); // store the XT        // (  )
            Stack.Push(q); // q mode
            Stack.Push(Map.IoInMapStart + RAM.CellSize * (p * 2 + 1)); // address of q mode
            Forth.CoreWords.Store.Call(); // store the Q mode
        }
    }
}