using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbarbee.GraphicsEngine._3DEngine
{
    public class myDouble
    {
        static myDouble()
        {
            Epsilon = 1e-6;
        }
        public double Value { get; set; }

        public myDouble(double v)
        {
            _upperLimit = null;
            _lowerLimit = null;
            if (Math.Abs(v) < Epsilon)
            {
                v = 0;
            }
            else
            {
                Value = v;
            }
        }
        public myDouble(double v, double limit)
            : this(v)
        {
            UpperLimit = limit;
            LowerLimit = -limit;
        }
        public myDouble(double v, double upper, double lower)
            : this(v)
        {
            UpperLimit = upper;
            LowerLimit = lower;
        }
        // anything smaller than Epsilon is effectively 0 zero
        public static double Epsilon { get; set; }

        private double? _upperLimit;
        public double UpperLimit
        {
            get { return _upperLimit.Value; }
            set
            {
                _upperLimit = value;
                if (Value > value) Value = value;
            }
        }
        public double? _lowerLimit;
        public double LowerLimit
        {
            get { return _lowerLimit.Value; }
            set
            {
                _lowerLimit = value;
                if (Value < value) Value = value;
            }
        }

        public double Limit
        {
            set
            {
                UpperLimit = value;
                LowerLimit = -value;
            }
        }
        public static implicit operator double(myDouble v) { return v.Value; }
        public static implicit operator myDouble(double v) { return new myDouble(v); }

        public override bool Equals(object obj)
        {
            return Equals(obj as myDouble);
        }

        public bool Equals(myDouble v)
        {
            if ((object)v == null)
                return false;
            return Compare(v) == 0;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
        public override string ToString()
        {
            return Value.ToString();
        }
        public static myDouble operator +(myDouble v1, myDouble v2)
        {
            return new myDouble(v1.Value + v2.Value);
        }
         public static myDouble operator +(myDouble v)
        {
            return new myDouble(v.Value);
        }
       public static myDouble operator -(myDouble v1, myDouble v2)
        {
            return new myDouble(v1.Value - v2.Value);
        }
        public static myDouble operator -(myDouble v)
        {
            return new myDouble(-v.Value);
        }
        public static myDouble operator *(myDouble v1, myDouble v2)
        {
            return new myDouble(v1.Value * v2.Value);
        }
        public static myDouble operator /(myDouble v1, myDouble v2)
        {
            return new myDouble(v1.Value / v2.Value);
        }
        public static bool operator ==(myDouble v1, myDouble v2)
        {
            if ((object)v1 == null) return (object)v2 == null;
            return v1.Equals(v2);
        }
        public static bool operator !=(myDouble v1, myDouble v2)
        {
            if ((object)v1 == null) return (object)v2 != null;
            return !v1.Equals(v2);
        }
        public static bool operator <(myDouble v1, myDouble v2)
        {
            if ((object)v1 == null) return (object)v2 == null;
            return v1.Compare(v2) < 0;
        }
        public static bool operator >(myDouble v1, myDouble v2)
        {
            if ((object)v1 == null) return (object)v2 == null;
            return v1.Compare(v2) > 0;
        }
        public static bool operator <=(myDouble v1, myDouble v2)
        {
            if ((object)v1 == null) return (object)v2 == null;
            return v1.Compare(v2) <= 0;
        }
        public static bool operator >=(myDouble v1, myDouble v2)
        {
            if ((object)v1 == null) return (object)v2 == null;
            return v1.Compare(v2) >= 0;
        }

        /// <summary>
        /// Tested value effectively == 0
        /// </summary>
        /// <param name="val"></param>
        /// <returns>true if abs(val) less than Epsilon</returns>
        public bool EqZero(double val)
        {
            return (Math.Abs(val) < Epsilon);
        }

        /// <summary>
        /// Tested value effectively != 0
        /// </summary>
        /// <param name="val"></param>
        /// <returns>true if abs(val) >= Epsilon</returns>
        public bool NeqZero(double val)
        {
            return (Math.Abs(val) >= Epsilon);
        }

        public int Compare (myDouble v)
        {
            if ((object)v == null)
                throw new ArgumentNullException();
            double delta = Value - v.Value;
            if (delta >= Epsilon) return 1;
            if (delta <= -Epsilon) return -1;
            return 0;
        }
    }
}
