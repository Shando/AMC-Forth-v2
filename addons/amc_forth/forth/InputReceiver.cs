using Godot;

namespace Forth
{
    [GlobalClass]
    public partial class InputReceiver : RefCounted
    {
        private AMCForth Forth;
        private int Port;

        private void Emit(int value)
        {
            Forth.InputEvent(Port, value);
        }

        public void Initialize(AMCForth forth, int port, Signal s)
        {
            Forth = forth;
            Port = port;
            Callable handler = new(this, MethodName.Emit);
            s.Owner.Connect(s.Name, handler);
        }
    }
}
