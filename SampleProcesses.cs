using System;
namespace ProcessInfo
{
    class SampleProcesses
    {
        public static int p1(int a, int b)
        {
            return a + b;
        }

        public static int p2(Tuple<int, int> a)
        {
            return a.Item1 + a.Item2;
        }

        public static int p3(int a, int b, int c)
        {
            return a + b + c;
        }

        public static float p4(int a, int b, float c)
        {
            return a + b + c;
        }


        public static float p41(Tuple<int, int, int> a)
        {
            return a.Item1 + a.Item2 + a.Item3;
        }

        public static int p5(int a, Tuple<int, int, int> d, int c)
        {
            return a + d.Item1 + d.Item2 + d.Item3 + c;
        }


        public static int p7(int x)
        {
            return x = x + 1;
        }

        public static int p8(int x)
        {
            return 2 * x - 1;
        }

        public static int p9(int x)
        {
            return x * x + x + 1;
        }

        public static Tuple<int, int, int, int, int> p10(int x)
        {
            return Tuple.Create(x, x, x, x, x);
        }

        public static int f1(int x)
        {
            return x + 2;
        }

        public static int f21(int x)
        {
            return x + 7;
        }

        public static int f22(int x)
        {
            return x + 2;
        }

        public static int f23(int x)
        {
            return x - 5;
        }

        public static int f3(Tuple<int, int, int> x)
        {
            return x.Item1 + x.Item2 + x.Item3;
        }
        public static int f4(int a, int b)
        {
            return a / b;
        }
    }
}