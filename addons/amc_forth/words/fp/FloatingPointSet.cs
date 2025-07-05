using Forth.Core;
using Godot;

// Forth FLOATING POINT word set

namespace Forth.FloatingPoint
{
    [GlobalClass]
    public partial class FloatingPointSet : RefCounted
    {
        public Deg2Rad Deg2Rad;
        public FABS FABS;
        public FACOS FACOS;
        public FACOSH FACOSH;
        public FALOG FALOG;
        public FASIN FASIN;
        public FASINH FASINH;
        public FATAN FATAN;
        public FATANH FATANH;
        public FATAN2 FATAN2;
        public FConstant FConstant;
        public FCOS FCOS;
        public FCOSH FCOSH;
        public FDepth FDepth;
        public FDot FDot;
        public FDotDollar FDotDollar;
        public FDrop FDrop;
        public FDup FDup;
        public FEDot FEDot;
        public FEDotDollar FEDotDollar;
        public FEXP FEXP;
        public FEXPM1 FEXPM1;
        public FFetch FFetch;
        public FFloatPlus FFloatPlus;
        public FFloatS FFloatS;
        public FFLOOR FFLOOR;
        public FLess FLess;
        public FLiteral FLiteral;
        public FLN FLN;
        public FLNP1 FLNP1;
        public FLOG FLOG;
        public FMAX FMAX;
        public FMIN FMIN;
        public FMinus FMinus;
        public FNegate FNegate;
        public FOver FOver;
        public FPlus FPlus;
        public FRot FRot;
        public FROUND FROUND;
        public FSDot FSDot;
        public FSDotDollar FSDotDollar;
        public FSIN FSIN;
        public FSINCOS FSINCOS;
        public FSINH FSINH;
        public FSlash FSlash;
        public FSQRT FSQRT;
        public FStar FStar;
        public FStarStar FStarStar;
        public FStore FStore;
        public FStoreDollar FStoreDollar;
        public FSwap FSwap;
        public FTAN FTAN;
        public FTANH FTANH;
        public FTilde FTilde;
        public FToI FToI;
        public FTRUNC FTRUNC;
        public FVariable FVariable;
        public FZeroEquals FZeroEquals;
        public FZeroLess FZeroLess;
        public Precision Precision;
        public Rad2Deg Rad2Deg;
        public SetDashPrecision SetDashPrecision;

        private const string Wordset = "FLOATING POINT";

        public AMCForth forth;

        public FloatingPointSet(AMCForth _forth)
        {
            Deg2Rad = new(_forth, Wordset);
            FABS = new(_forth, Wordset);
            FACOS = new(_forth, Wordset);
            FACOSH = new(_forth, Wordset);
            FALOG = new(_forth, Wordset);
            FASIN = new(_forth, Wordset);
            FASINH = new(_forth, Wordset);
            FATAN = new(_forth, Wordset);
            FATANH = new(_forth, Wordset);
            FATAN2 = new(_forth, Wordset);
            FConstant = new(_forth, Wordset);
            FCOS = new(_forth, Wordset);
            FCOSH = new(_forth, Wordset);
            FDepth = new(_forth, Wordset);
            FDot = new(_forth, Wordset);
            FDotDollar = new(_forth, Wordset);
            FDrop = new(_forth, Wordset);
            FDup = new(_forth, Wordset);
            FEDot = new(_forth, Wordset);
            FEDotDollar = new(_forth, Wordset);
            FEXP = new(_forth, Wordset);
            FEXPM1 = new(_forth, Wordset);
            FFetch = new(_forth, Wordset);
            FFloatPlus = new(_forth, Wordset);
            FFloatS = new(_forth, Wordset);
            FFLOOR = new(_forth, Wordset);
            FLess = new(_forth, Wordset);
            FLiteral = new(_forth, Wordset);
            FLN = new(_forth, Wordset);
            FLNP1 = new(_forth, Wordset);
            FLOG = new(_forth, Wordset);
            FMAX = new(_forth, Wordset);
            FMIN = new(_forth, Wordset);
            FMinus = new(_forth, Wordset);
            FNegate = new(_forth, Wordset);
            FOver = new(_forth, Wordset);
            FPlus = new(_forth, Wordset);
            FRot = new(_forth, Wordset);
            FROUND = new(_forth, Wordset);
            FSDot = new(_forth, Wordset);
            FSDotDollar = new(_forth, Wordset);
            FSIN = new(_forth, Wordset);
            FSINCOS = new(_forth, Wordset);
            FSINH = new(_forth, Wordset);
            FSlash = new(_forth, Wordset);
            FSQRT = new(_forth, Wordset);
            FStar = new(_forth, Wordset);
            FStarStar = new(_forth, Wordset);
            FStore = new(_forth, Wordset);
            FStoreDollar = new(_forth, Wordset);
            FSwap = new(_forth, Wordset);
            FTAN = new(_forth, Wordset);
            FTANH = new(_forth, Wordset);
            FTilde = new(_forth, Wordset);
            FToI = new(_forth, Wordset);
            FTRUNC = new(_forth, Wordset);
            FVariable = new(_forth, Wordset);
            FZeroEquals = new(_forth, Wordset);
            FZeroLess = new(_forth, Wordset);
            Precision = new(_forth, Wordset);
            Rad2Deg = new(_forth, Wordset);
            SetDashPrecision = new(_forth, Wordset);

            forth = _forth;
        }
    }
}
