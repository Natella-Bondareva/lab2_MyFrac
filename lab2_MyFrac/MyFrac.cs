using System;

namespace lab2_MyFrac
{
    internal class MyFrac
    {
        private long nom { get; set; }
        private long _denom;

        public long denom
        {
            get { return _denom; } 
            set 
            {
                if (value != 0) _denom = (long)value; 
                else
                {
                    throw new ArgumentException("Знаменник не може бути нулем");
                }
            }
        }
        public MyFrac(long nom, long denom)
        {
            long divider = 1;
            if (Math.Abs(nom)>=Math.Abs(denom)) { divider = GCD(nom, denom);}
            else if (Math.Abs(denom) >Math.Abs(nom)) { divider = GCD(denom, nom);}

            this.nom = nom / divider;
            this.denom = denom / divider;

            if (this.denom < 0) {  this.denom *= -1; this.nom *= -1; }
        }

        private long GCD(long a, long b)
        {
            while (b != 0)
            {
                var temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
        public override string ToString()
        {
            if(Math.Abs(nom) == Math.Abs(denom) || nom ==0)
            {
                return $"{nom}";
            }
            return $"{nom}/{denom}";
        }

        public string ToStringWithIntegerPart()
        {
            if (nom > Math.Abs(denom) && nom >= 0)
            {
                long integralPart = (long)(nom / denom);
                return $"{integralPart} + {nom % integralPart}/{denom}";
            }
            else if (nom > Math.Abs(denom) && nom < 0)
            {
                long integralPart = (long)(nom / denom);
                return $"-({integralPart} + {nom % integralPart}/{denom})";
            }
            else if (denom == nom) { return $"1"; }
            else { return $"{nom}/{denom}"; }
        }
        public double DoubleValue()
        {
            double res = Convert.ToDouble(nom)/ Convert.ToDouble(denom);
            return res;
        }
        public MyFrac Plus(MyFrac otherFrac)
        {
            return new MyFrac(this.nom * otherFrac.denom + this.denom * otherFrac.nom, this.denom * otherFrac.denom);
        }
        public MyFrac Minus(MyFrac otherFrac)
        {
            return new MyFrac(this.nom * otherFrac.denom - this.denom * otherFrac.nom, this.denom * otherFrac.denom);
        }
        public MyFrac Multiply(MyFrac otherFrac)
        {
            return new MyFrac(this.nom * otherFrac.nom, this.denom * otherFrac.denom);
        }
        public MyFrac Divide(MyFrac otherFrac)
        {
            return new MyFrac(this.nom * otherFrac.denom, this.denom * otherFrac.nom);
        }
        static public MyFrac  CalcSum1(int n)
        {
            MyFrac res = new MyFrac(0, 1);
            for (int i = 1; i <= n; i++)
            {
                MyFrac add = new MyFrac(1, i * (i + 1));
                res = res.Plus(add); 
            }
            return res;
        }
        static public MyFrac CalcSum2(int n)
        {
            MyFrac res = new MyFrac(1, 1);
            MyFrac one = new MyFrac(1, 1);
            for (int i = 2; i <= n +1; i++)
            {
                MyFrac add = one.Minus(new MyFrac(1,(long) Math.Pow(i,2)));
                res = res.Multiply(add);
            }
            return res;
        }
    }
}
