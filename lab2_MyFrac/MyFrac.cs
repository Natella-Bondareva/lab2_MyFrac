using System;

namespace lab2_MyFrac
{
    internal class MyFrac
    {
        private long nom { get; set; }
        private long denom_;

        public long denom
        {
            get { return denom_; } 
            set 
            {
                if (value != 0) denom_ = (long)value; 
                else
                {
                    throw new ArgumentException("Знаменник не може бути нулем");
                }
            }
        }
        public MyFrac(long nom_, long denom_)
        {
            long divider = 1;
            if (Math.Abs(nom_)>=Math.Abs(denom_)) { divider = GCD(nom_, denom_);}
            else if (Math.Abs(denom_) >Math.Abs(nom_)) { divider = GCD(denom_, nom_);}

            this.nom = nom_ / divider;
            denom = denom_ / divider;

            if (denom_ < 0) {  denom *= -1; this.nom *= -1; }
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
        public MyFrac Plus(MyFrac f1, MyFrac f2)
        {
            return new MyFrac(f1.nom * f2.denom + f1.denom * f2.nom, f1.denom * f2.denom);
        }
        public MyFrac Minus(MyFrac f1, MyFrac f2)
        {
            return new MyFrac(f1.nom * f2.denom - f1.denom * f2.nom, f1.denom * f2.denom);
        }
        public MyFrac Multiply(MyFrac f1, MyFrac f2)
        {
            return new MyFrac(f1.nom * f2.nom, f1.denom * f2.denom);
        }
        public MyFrac Divide(MyFrac f1, MyFrac f2)
        {
            return new MyFrac(f1.nom * f2.denom, f1.denom * f2.nom);
        }
        public MyFrac  CalcSum1(int n)
        {
            MyFrac res = new MyFrac(0, 1);
            for (int i = 1; i <= n; i++)
            {
                MyFrac add = new MyFrac(1, i * (i + 1));
                res = Plus(res, add); 
            }
            return res;
        }
        public MyFrac CalcSum2(int n)
        {
            MyFrac res = new MyFrac(1, 1);
            MyFrac one = new MyFrac(1, 1);
            for (int i = 2; i <= n +1; i++)
            {
                MyFrac add = Minus(one,new MyFrac(1,(long) Math.Pow(i,2)));
                res = Multiply(res, add);
            }
            return res;
        }
    }
}
