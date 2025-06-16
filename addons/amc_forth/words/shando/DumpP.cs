using Godot;

namespace Forth.Shando
{
    [GlobalClass]
    public partial class DumpP : Words
    {
        public DumpP(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "DUMPP";
            Description =
                "If 'u' is greater than zero and 'addr' is less than the size of the Parameter Stack, display the contents of"
                + " 'u' consecutive addresses of the Parameter Stack starting at 'addr'."
                + " Example usage: 500 100 DUMPP";
            StackEffect = "( addr u -- )";
        }

        public override void Call()
        {
            var u = Stack.Pop();
            var a1 = Stack.Pop();

            if (u > 0 && a1 < Stack.DataStackSize)
            {
                if (a1 + u > Stack.DataStackSize)
                    u = Stack.DataStackSize - a1;

                // OUTPUT DATA from addr -> addr + u
                int[] ds = Stack.DataStack;
                string tText = "";

                for (int i = a1; i < a1 + u; i += 2)
                {
                    string sTmp = "";
                    string ds1 = IntToHex(ds[i]);
                    string ds2 = IntToHex(ds[i + 1]);

                    byte[] x1 = ds1.HexDecode();
                    byte[] x2 = ds2.HexDecode();

                    for (int y = 0; y < x1.Length; y++)
                    {
                        if (x1[y] > 31 && x1[y] != 129 && x1[y] != 141 && x1[y] != 143 && x1[y] != 144 && x1[y] != 157)
                            sTmp += (char)x1[y];
                        else
                            sTmp += ".";
                    }

                    for (int y = 0; y < x2.Length; y++)
                    {
                        if (x2[y] > 31 && x2[y] != 129 && x2[y] != 141 && x2[y] != 143 && x2[y] != 144 && x2[y] != 157)
                            sTmp += (char)x2[y];
                        else
                            sTmp += ".";
                    }

                    tText += IntToHex(i).PadZeros(6) + ": " + IntToHex2(ds[i]);
                    tText += " - " + IntToHex2(ds[i + 1]) + "  " + sTmp + "\n";
                }

                tText = tText.StripEdges();
                Forth.Util.PrintTerm(tText + Terminal.CRLF);
            }
        }

        public string IntToHex(int iIn)
        {
            var hexStr = string.Format("{0:X8}", iIn);
            return hexStr.StripEdges();
        }

        public string IntToHex2(int iIn)
        {
            var hexStr = string.Format("{0:X8}", iIn);
            var formattedHex = "";

            for (int i = 0; i < hexStr.Length; i += 4)
                formattedHex += hexStr.Substr(i, 4) + " ";

            return formattedHex.StripEdges();
        }
    }
}
