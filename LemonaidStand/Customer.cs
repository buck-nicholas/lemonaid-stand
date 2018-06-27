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
        private Random rand;
        private Weather weather;


        public Customer(Recipe recipe, Weather weather)
        {
            rand = new Random();
            DetermineMaxSpend();
            willBuy = DetermineWillBuy(recipe, weather);
            this.weather = weather;
        }

        public void DetermineMaxSpend()
        {
            double randomNumber = rand.Next(15, 51);
            willSpendMax = (randomNumber / 100);
            Console.WriteLine(willSpendMax);
        }
        public bool DetermineWillBuy(Recipe recipe, Weather weather)
        {
            if (recipe.pricePerCup <= willSpendMax)
            {
                int buyChance = rand.Next(100);
                if (buyChance + weather.weatherInfluence >= 70)
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
            int baseSatisfaction = rand.Next(101);
            satisfactionLevel = baseSatisfaction;
        }
    }
}
