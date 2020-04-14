using System;
using System.IO;
using MathNet.Numerics.Distributions;
using System.Collections.Generic;
using MathNet.Numerics.Statistics;

namespace CQF
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Hello World! {Config.Strike} {Config.RiskFreeRate}");

            BinaryOptionPricer pricer = new BinaryOptionPricer();
            double a = Normal.Sample(0.0, 1.0);

            Console.WriteLine($"Test PayOff function {pricer.Payoff(100, 105, OptionCallType.Put)} {pricer.Payoff(100, 105, OptionCallType.Call)}");
            Console.WriteLine($"Random Number: {a}");



            //Price Call Option

            double S = 100;// #current_price
            double K = 100; //#ATM strike
            double v = 0.20;// #annualized volatility
            double r = 0.05;// #interest rate
            double T = 1;//   time to maturity in years

            double d2 = (Math.Log(S / K) + (r - 0.5 * Math.Pow(v,2) * T) / (v * Math.Sqrt(T)));

            
            double value =  Math.Exp(-r * T) *Normal.CDF(0, 1, d2);


            Console.WriteLine($"Option Price = {pricer.PriceCallOption(100, 100, 1, 252, 40000, 0.2)}");

            BlackScholes blackScholes = new BlackScholes(S,K,v,r,T);
            Console.WriteLine($"black scholes class:  {blackScholes.PriceBinaryCallOption()}");
            using (StreamWriter writetext = new StreamWriter("VolAtTheMoney_v2.csv"))
            {
                writetext.WriteLine($" Call Option At the money");
                writetext.WriteLine($"Frequency, Daily");
                writetext.WriteLine($"Time Intervals, 252");
                writetext.WriteLine($" Stock Price, 100" +
                    $"");
                writetext.WriteLine($"Strike, 100");
                writetext.WriteLine($"Volatility, varying 0.01 to 2");
                writetext.WriteLine($" Call Option");
                writetext.WriteLine($" Risk Free Rate, {r}");
                writetext.WriteLine($"Time to Expiry,{T}");
                writetext.WriteLine($" ");

                /*                writetext.WriteLine($"{pricer.PriceCallOption(100, 100, 1, 252, 1000)}");
                                writetext.WriteLine($"{pricer.PriceCallOption(100, 100, 0.8, 252, 1000)}");
                                writetext.WriteLine($"{pricer.PriceCallOption(100, 100, 0.6, 252, 1000)}");
                                writetext.WriteLine($"{pricer.PriceCallOption(100, 100, 0.4, 252, 1000)}");
                                writetext.WriteLine($"{pricer.PriceCallOption(100, 100, 0.2, 252, 1000)}");
                                writetext.WriteLine($"{pricer.PriceCallOption(100, 100, 0.1, 252, 1000)}");*/


                /*                for (int i = 1; i < 100; i++)
                                {
                                    writetext.WriteLine($"{pricer.PriceCallOption((95+i*0.1), 100, 1, 252, 10000)}");
                                }*/






                /*                StockPriceGenerator stock = new StockPriceGenerator();
                                List<double> list1 = stock.GenerateMontePath(100, 1, 1000);
                                List<double> list2 = stock.GenerateMontePath(100, 1, 1000);
                                List<double> list3 = stock.GenerateMontePath(100, 1, 1000);
                                List<double> list4 = stock.GenerateMontePath(100, 1, 1000);
                                List<double> list5 = stock.GenerateMontePath(100, 1, 1000);
                                List<double> list11 = stock.GenerateMontePath(100, 1, 1000);
                                List<double> list12 = stock.GenerateMontePath(100, 1, 1000);
                                List<double> list13 = stock.GenerateMontePath(100, 1, 1000);
                                List<double> list14 = stock.GenerateMontePath(100, 1, 1000);
                                List<double> list15 = stock.GenerateMontePath(100, 1, 1000);
                                List<double> list21 = stock.GenerateMontePath(100, 1, 1000);
                                List<double> list22 = stock.GenerateMontePath(100, 1, 1000);
                                List<double> list23 = stock.GenerateMontePath(100, 1, 1000);
                                List<double> list24 = stock.GenerateMontePath(100, 1, 1000);
                                List<double> list25 = stock.GenerateMontePath(100, 1, 1000);
                                List<double> list211 = stock.GenerateMontePath(100, 1, 1000);
                                List<double> list212 = stock.GenerateMontePath(100, 1, 1000);
                                List<double> list213 = stock.GenerateMontePath(100, 1, 1000);
                                List<double> list214 = stock.GenerateMontePath(100, 1, 1000);
                                List<double> list215 = stock.GenerateMontePath(100, 1, 1000);
                                for (int i =0; i< 1000; i++)
                                {
                                    writetext.WriteLine($"{list1[i]},{list2[i]},{list3[i]},{list4[i]},{list5[i]},{list11[i]},{list12[i]},{list13[i]},{list14[i]},{list15[i]},{list21[i]},{list22[i]},{list23[i]},{list24[i]},{list25[i]},{list211[i]},{list212[i]},{list213[i]},{list214[i]},{list215[i]}");
                                }*/




                /*                writetext.WriteLine($" Call Option");
                                writetext.WriteLine($"Frequency, Daily");
                                writetext.WriteLine($"Time Intervals, 252");
                                writetext.WriteLine($" Stock Price, {S}");
                                writetext.WriteLine($"Strike, {K}");
                                writetext.WriteLine($"Volatility, {v}");
                                writetext.WriteLine($" Call Option");
                                writetext.WriteLine($" Risk Free Rate, {r}");
                                writetext.WriteLine($"Time to Expiry,{T}");
                                writetext.WriteLine($" ");

                                writetext.WriteLine($"Binary Call Option Value, Black Scholes Value,number of paths");

                                for (int i = 1; i < 252; i++)
                                {
                                    writetext.WriteLine($"{pricer.PriceCallOption(100, 100, 1-(i/252), (252-i), 5000)}, {blackScholes.PriceBinaryCallOption()}, increment {i*0.01}");
                                }*/



                /*                for (int i = 1; i < 31; i++)
                                {
                                   writetext.WriteLine($"{pricer.PriceCallOption(100, 100, 1, 5040, i*1000)}, {blackScholes.PriceBinaryCallOption()}, {i*1000} paths");
                               }*/

                for (int i=0; i<200;i++)
                {
                    writetext.WriteLine($"{ i * 0.01},{pricer.PriceCallOption(100, 100, 1, 252, 10000, i*0.01)}, {blackScholes.PriceBinaryCallOption()}");/*
                    writetext.WriteLine($"{pricer.PriceCallOption(90, 100, 1, 252, 10000, i * 0.1)}, {blackScholes.PriceBinaryCallOption()}, { i * 0.1} vol");
                    writetext.WriteLine($"{pricer.PriceCallOption(90, 100, 1, 252, 10000, i * 0.1)}, {blackScholes.PriceBinaryCallOption()}, { i * 0.1} vol");
                    writetext.WriteLine($"{pricer.PriceCallOption(90, 100, 1, 252, 10000, i * 0.1)}, {blackScholes.PriceBinaryCallOption()}, { i * 0.1} vol");
                    writetext.WriteLine($"{pricer.PriceCallOption(90, 100, 1, 252, 10000, i * 0.1)}, {blackScholes.PriceBinaryCallOption()}, { i * 0.1} vol");
                    writetext.WriteLine($"{pricer.PriceCallOption(90, 100, 1, 252, 10000, i * 0.1)}, {blackScholes.PriceBinaryCallOption()}, { i * 0.1} vol");
                    writetext.WriteLine($"{pricer.PriceCallOption(90, 100, 1, 252, 10000, i * 0.1)}, {blackScholes.PriceBinaryCallOption()}, { i * 0.1} vol");
                    writetext.WriteLine($"{pricer.PriceCallOption(90, 100, 1, 252, 10000, i * 0.1)}, {blackScholes.PriceBinaryCallOption()}, { i * 0.1} vol");
                    writetext.WriteLine($"{pricer.PriceCallOption(90, 100, 1, 252, 10000, i * 0.1)}, {blackScholes.PriceBinaryCallOption()}, { i * 0.1} vol");*/
                }


            }


        }
    }
}
