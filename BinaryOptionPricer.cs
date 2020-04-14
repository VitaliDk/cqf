using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using MathNet.Numerics.Distributions;

namespace CQF
{
    public class BinaryOptionPricer
    {
        public BinaryOptionPricer()
        {
            
        }

        public double Payoff(double strike, double stockPrice, OptionCallType optionType, double payoff = 1)
        {
            double payoffAmount;

            if (optionType == OptionCallType.Call)
             {

                if (stockPrice > strike)
                {
                    payoffAmount = payoff;
                }
                else
                {
                    payoffAmount = 0;
                }
            }
            else
            {
                if (stockPrice < strike)
                {
                    payoffAmount = payoff;
                }
                else
                {
                    payoffAmount = 0;
                }
            }

            return payoffAmount;

        }

        public double StandardPayoff(double strike, double stockPrice, OptionCallType optionType, double payoff = 1)
        {
            double paysoffAmount = 0;

            if (optionType == OptionCallType.Call)
            {

                if (stockPrice > strike)
                {
                    paysoffAmount = stockPrice - strike;
                }
                else
                {
                    paysoffAmount = 0;
                }
            }

            return paysoffAmount;

        }



        public double PriceCallOption(double initialStockPrice, double strike, double expiry, int numberOfSamplePoints, int numberOfSamplePaths, double vol)
        {
            double discountFactor = Math.Exp(-Config.RiskFreeRate*(expiry));

            StockPriceGenerator price = new StockPriceGenerator();
            double payoff = 0;

            for (int i = 0; i < numberOfSamplePaths; i++)
            {
                payoff += Payoff(strike, price.GeneratePrice(initialStockPrice, expiry, numberOfSamplePoints, vol), OptionCallType.Call);

            }
                return discountFactor*(payoff/numberOfSamplePaths);
        }

        public double PriceMilsteinCallOption(double initialStockPrice, double strike, double expiry, int numberOfSamplePoints, int numberOfSamplePaths)
        {
            double discountFactor = Math.Exp(-Config.RiskFreeRate * (expiry));

            StockPriceGenerator price = new StockPriceGenerator();
            double payoff = 0;

            for (int i = 0; i < numberOfSamplePaths; i++)
            {
                payoff += Payoff(strike, price.GenerateMilsteinPrice(initialStockPrice, expiry, numberOfSamplePoints), OptionCallType.Call);

            }
            return discountFactor * (payoff / numberOfSamplePaths);
        }


        public double PricePutOption(double initialStockPrice, double strike, double expiry, int numberOfSamplePoints, int numberOfSamplePaths, double vol)
        {
            double discountFactor = Math.Exp(-Config.RiskFreeRate * (expiry));

            StockPriceGenerator price = new StockPriceGenerator();
            double payoff = 0;

            for (int i = 0; i < numberOfSamplePaths; i++)
            {

               payoff += Payoff(strike, price.GeneratePrice(initialStockPrice, expiry, numberOfSamplePoints, vol), OptionCallType.Put);
            }
            return discountFactor*(payoff / numberOfSamplePaths);

        }

    }
}
