using System.Diagnostics;
using System.IO;

public class ToDebugWriter : StringWriter
{
    public override void WriteLine(string value)
    {
        Debug.WriteLine(value);
        base.WriteLine(value);
    }
}
