using System;

namespace RodCut
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] P = { 0, 1, 2, 4, 6, 8 };

            int Best = rodCut(P,5);
            int Best1 = rodCut(P, 5, new int[5 + 1]);
            Console.WriteLine(Best);
            Console.WriteLine(Best1);
            Console.ReadKey();
        }


        //Up To Bottom
        public static int rodCut(int[] Price, int rodLenght, int[] r)
        {
            if (rodLenght <= 1)
                return Price[rodLenght];

            if (r[rodLenght] > 0)
                return r[rodLenght];

            int max = -1;

            for (int k = 1; k <= rodLenght; k++)
            {
                int p = Price[k] + rodCut(Price, rodLenght - k, r);

                if (p > max)
                {
                    max = p;
                }
            }
            r[rodLenght] = max;
            return max;
        }

        //Down To Up
        public static int rodCut(int[] Price, int rodLenght)
        {
            int[] r = new int[rodLenght + 1];

            r[0] = 0;
            r[1] = Price[1];

            for (int i = 2; i <= rodLenght ; i++)
            {
                int max = -1;

                for (int k = 0; k <= i; k++)
                {
                    int p = Price[k] + r[i-k];

                    if (p > max)
                    {
                        max= p;
                        
                    }
                }
                r[i] = max;
            }
            return r[rodLenght];
        }
    }
}
