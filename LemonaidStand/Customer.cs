using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonaidStand
{

    class Customer
    {
        public bool willBuy;
        public double willSpendMax;
        public double satisfactionLevel;
        private static Random randomInt = new Random();
        private static object syncLock = new object();
        private Weather weather;


        public Customer(Recipe recipe, Weather weather)
        {
            
            DetermineMaxSpend();
            willBuy = DetermineWillBuy(recipe, weather);
            this.weather = weather;
        }
        public int RandomNumberGenerater(int min, int max)
        {
            lock (syncLock)
            {
                int RandomNumber = randomInt.Next(min, max);
                return RandomNumber;
            }
        }
        public void DetermineMaxSpend()
        {
            double randomNumber = RandomNumberGenerater(15, 51);
            willSpendMax = (randomNumber / 100);
        }
        public bool DetermineWillBuy(Recipe recipe, Weather weather)
        {
            if (recipe.pricePerCup <= willSpendMax)
            {
                int buyChance = RandomNumberGenerater(0, 101);
                if (buyChance + weather.weatherInfluence >= 61)
                {
                    willBuy = true;
                }
                else
                {
                    willBuy = false;
                }
            }
            return willBuy;
        }
        
        public void DetermineIfSatisfied()
        {
            int baseSatisfaction = RandomNumberGenerater(0, 101);
            satisfactionLevel = baseSatisfaction;
        }
    }
}
