using System;
using System.Collections.Generic;
using System.Text;
using MathNet.Numerics.Distributions;

namespace CQF
{
    public class StockPriceGenerator
    {
        double Volatility;
        double RiskFreeRate;

        public StockPriceGenerator()
        {
            this.Volatility = Config.Volatility;
            this.RiskFreeRate = Config.RiskFreeRate;
        }

        public double GeneratePrice(double initialStockPrice, double expiry, int timeSteps, double vol)
        {
            double stockPrice = initialStockPrice;
            double deltaT = expiry / timeSteps;
            double sqrtdeltaT = Math.Sqrt(deltaT);

            for (int i = 0; i < timeSteps; i++)
            {
                stockPrice += RiskFreeRate*stockPrice*deltaT + vol*stockPrice*sqrtdeltaT* Normal.Sample(0.0, 1.0);            
            }

            return stockPrice;
        }

        public double GenerateMilsteinPrice(double initialStockPrice, double expiry, int timeSteps)
        {
            double stockPrice = initialStockPrice;
            double deltaT = expiry / timeSteps;
            double sqrtdeltaT = Math.Sqrt(deltaT);

            for (int i = 0; i < timeSteps; i++)
            {
                stockPrice += RiskFreeRate * stockPrice * deltaT + Volatility * stockPrice * sqrtdeltaT * Normal.Sample(0.0, 1.0) + 0.5 * Volatility * (deltaT * (Math.Pow(Normal.Sample(0.0, 1.0),2)) - Math.Pow(deltaT,2));
            }

            return stockPrice;
        }

        public List<double> GenerateMontePath(double initialStockPrice, double expiry, int timeSteps)
        {
            double stockPrice = initialStockPrice;
            double deltaT = expiry / timeSteps;
            double sqrtdeltaT = Math.Sqrt(deltaT);
            List<double> monte = new List<double>();

            for (int i = 0; i < timeSteps; i++)
            {
                stockPrice += RiskFreeRate * stockPrice * deltaT + Volatility * stockPrice * sqrtdeltaT * Normal.Sample(0.0, 1.0);
                monte.Add(stockPrice);

            }

            return monte;
        }
        
    }
}
