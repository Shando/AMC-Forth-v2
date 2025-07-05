using System;


// From https://jonskeet.uk/csharp/DoubleConverter.cs

public static class DoubleExtensions
{
    // Usage: string engString = myvalue.ToEngineeringNotation();
    public static string ToEngineeringNotation(this double value, int precision)
    {
        if (value == 0.0)
        {
            return "0";
        }

        // Handle negative numbers
        string sign = "";
        if (value < 0)
        {
            sign = "-";
            value = Math.Abs(value);
        }

        // Determine the exponent
        double exponent = Math.Floor(Math.Log10(value));
        int engineeringExponent = (int)(Math.Floor(exponent / 3.0) * 3);

        // Adjust the mantissa
        double mantissa = value / Math.Pow(10, engineeringExponent);

        // Format the mantissa with the specified precision
        string mantissaString = mantissa.ToString($"F{precision}");

        // Construct the final string with the appropriate suffix
        string suffix = GetEngineeringSuffix(engineeringExponent);

        return $"{sign}{mantissaString}{suffix}";
    }

    public static string ToScientificNotation(this double value, int precision) 
    {
        if (value == 0)
        {
            return "0";
        }
        else
        {
            string e = "E" + precision.ToString();
            return value.ToString(e);
        }
    }

    public static string ToFixedPointNotation(this double value, int precision) 
    {
        if (value == 0.0)
        {
            return "0.0";
        }
        else
        {
            string e = "F" + precision.ToString();
            return value.ToString(e);
        }
    }

    private static string GetEngineeringSuffix(int exponent)
    {
        return exponent switch
        {
            -24 => "y",
            -21 => "z",
            -18 => "a",
            -15 => "f",
            -12 => "p",
            -9 => "n",
            -6 => "µ", // Micro
            -3 => "m",
            0 => "",
            3 => "k",
            6 => "M",
            9 => "G",
            12 => "T",
            15 => "P",
            18 => "E",
            21 => "Z",
            24 => "Y",
            _ => $"E{exponent}" // Fallback for exponents outside standard prefixes
        };
    }
}