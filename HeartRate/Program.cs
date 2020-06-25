using System;
using System.Collections.Generic;

namespace HeartRate
{
    class Program
    {
        static void Main(string[] args)
        {
            // Heart Rate
            // https://open.kattis.com/problems/heartrate 
            // (show 4 digits after point)

            var casesNum = EnterNumOfCases();

            var myCases = EnterAllCases(casesNum);

            var myResults = GetAllResults(myCases);

            PrintList(myResults);
        }
        private static void PrintList(List<double[]> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                PrintArrayOneLine(list[i]);
            }
        }

        private static void PrintArrayOneLine(double[] arr)
        {
            string str = "";

            for (int i = 0; i < arr.Length; i++)
            {
                str = str + String.Format("{0:0.0000}", arr[i]) + " ";
            }
            Console.WriteLine(str);
        }

        private static List<double[]> GetAllResults(List<object[]> yourCase)
        {
            var yourResults = new List<double[]>();
            for (int i = 0; i < yourCase.Count; i++)
            {
                yourResults.Add(GetTripleResult(yourCase[i]));
            }
            return yourResults;
        }

        private static double[] GetTripleResult(object[] yourCase)
        {
            var youAnswer = new double[3] { 0, 0, 0 };

            youAnswer[1] = BPMCalculation(yourCase);

            youAnswer[0] = MinABPM(yourCase, youAnswer[1]);
            youAnswer[2] = MaxABPM(yourCase, youAnswer[1]);

            return youAnswer;
        }

        private static List<object[]> EnterAllCases(int casesCount)
        {
            var yourCases = new List<object[]>();
            for (int i = 0; i < casesCount; i++)
            {
                yourCases.Add(EnterACase());
            }
            return yourCases;
        }

        private static double MinABPM(object[] myCase, double bpm)
        {
            int beats = (int)myCase[0];
            double period = (double)myCase[1];

            double ans = 60 / period;
            return bpm - ans;
        }

        private static double MaxABPM(object[] myCase, double bpm)
        {
            int beats = (int)myCase[0];
            double period = (double)myCase[1];

            double ans = 60 / period;
            return bpm + ans;
        }

        private static double BPMCalculation(object[] myCase)
        {
            int beats = (int)myCase[0];
            double period = (double)myCase[1];
            return 60 * beats / period;
        }

        private static object[] EnterACase()
        {
            var arr = new string[2] { "", "" };
            var res = new object[2] { 0,0};

            int a = 0;
            double b = 0;
            try
            {
                arr = Console.ReadLine().Split(' ', 2);

                a = int.Parse(arr[0]);
                b = double.Parse(arr[1]);
                if (NumsConditions(a, b) == false)
                    throw new ArgumentException();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return EnterACase();
            }
            res[0] = a;
            res[1] = b;
            return res;
        }

        private static int EnterNumOfCases()
        {
            int a = 0;
            try
            {
                a = int.Parse(Console.ReadLine());
                if (a < 1 || a > 1000)
                    throw new ArgumentException();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return EnterNumOfCases();
            }
            return a;
        }
        private static bool NumsConditions(int b, double p)
        {
            if (b < 2 || b > 1000 || p <= 0 || p >= 1000)
                return false;
            else return true;
        }
    }
}
