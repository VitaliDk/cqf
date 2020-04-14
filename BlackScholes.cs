using System;
using MathNet.Numerics.Distributions;
using MathNet.Numerics.Statistics;

namespace CQF
{
    public class BlackScholes
    {
        double S = 100;// #current_price
        double K = 100; //#ATM strike
        double v = 0.20;// #annualized volatility
        double r = 0.05;// #interest rate
        double T = 1;// #days remaining (annualized)

        public BlackScholes(double stockPrice, double strike, double volatility, double riskFreeRate, double timeToExpiry)
        {
            this.S = stockPrice;
            this.K = strike;
            this.v = volatility;
            this.r = riskFreeRate;
            this.T = timeToExpiry;
        }


        public double PriceBinaryCallOption()
        {
            double d2 = (Math.Log(S / K) + (r - 0.5 * Math.Pow(v, 2) * T) / (v * Math.Sqrt(T)));


            double value = Math.Exp(-r * T) * Normal.CDF(0, 1, d2);

            return value;
        }

        public double PriceBinaryPutOption()
        {
            return 1;
        }



    }
}
