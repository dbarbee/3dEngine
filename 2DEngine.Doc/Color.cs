using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbarbee.GraphicsEngine._2DCanvas.Doc
{

    public class Color
    {
        public Color(Byte a, Byte r, Byte g, Byte b)
        {
            A = a;
            R = r;
            G = g;
            B = b;
        }
        public Color(Int32 argb)
        {
            ARBG = argb;
        }

        public Color(uint argb)
        {
            ARBG = (Int32) argb;
        }

        public Byte A { get; private set; }
        public Byte R { get; private set; }
        public Byte G { get; private set; }
        public Byte B { get; private set; }

        public Int32 ARBG 
            {
            get
            {
                return A << 24 | R << 16 | G << 8 | B;
            }
            private set
            {
                A = (Byte)((value & 0xFF000000) >> 24);
                R = (Byte)((value & 0x00FF0000) >> 16);
                G = (Byte)((value & 0x0000FF00) >> 8);
                B = (Byte) (value & 0x000000FF);
            }
        }

        public static implicit operator Color(UInt32 c)
        {
            return new Color(c);
        }

        public static implicit operator Color(Int32 c)
        {
            return new Color(c);
        }

        public static implicit operator UInt32(Color c)
        {
            return (UInt32) c.ARBG;
        }

        public static implicit operator Int32(Color c)
        {
            return c.ARBG;
        }

        public static Color Black = new Color(0xFFFFFFFF);
        public static Color MediumGray = new Color(0xFF7F7F7F);
        public static Color DarkerGray = new Color(0xFFBEBEBE);

        public static Color TransBlack = new Color(0x7FFFFFFF);
        public static Color TransMediumGray = new Color(0x7F7F7F7F);
        public static Color TransDarkerGray = new Color(0x7FBEBEBE);
    }
}
