using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonaidStand
{
    class Day
    {
        public int productSold;
        private int customerflowrate;
        private int baseCustomerFlowrate;
        private Weather todaysWeather;
        private int cupCount;
        public Player player;
        private double moneyEarned;

        public Day(Player player, Weather weather)
        {
            todaysWeather = weather;
            this.player = player;
            baseCustomerFlowrate = 100;
            productSold = 0;
        }
        public void SetCustomerFlowRate()
        {
            customerflowrate = baseCustomerFlowrate + todaysWeather.weatherInfluence * 2;
        }
        public void dayLogic()
        {
            SetCustomerFlowRate();
            MakePitcher();
            while ((player.inventory.iceAmount - player.recipe.icePerCup >= 0) && player.inventory.cupAmount - 1 >= 0 && cupCount > 0 && customerflowrate != 0)
            {
                Customer customer = new Customer(player.recipe, todaysWeather);
                if (customer.willBuy)
                {
                    productSold++;
                    cupCount--;
                    player.inventory.iceAmount -= player.recipe.icePerCup;
                    player.inventory.cupAmount -= 1;
                    Console.WriteLine("+$" + player.recipe.pricePerCup + "Sale Made!");
                }
                if (customer.satisfactionLevel < 30)
                {
                    Console.WriteLine("Customer says: YUCK!");
                }
                if (customer.satisfactionLevel > 70)
                {
                    Console.WriteLine("Customer says: Yum!");
                }
                if (cupCount == 0)
                {
                    MakePitcher();
                }
                customerflowrate--;
            }
            moneyEarned = productSold * player.recipe.pricePerCup;
            player.netCash += moneyEarned;
        }
        public int MakePitcher()
        {
            if (player.inventory.lemonAmount < player.recipe.lemonsPerPitcher || player.inventory.sugarAmount < player.recipe.sugarPerPitcher)
            {
                cupCount = 0;
            }
            else
            {
                player.inventory.lemonAmount -= player.recipe.lemonsPerPitcher;
                player.inventory.sugarAmount -= player.recipe.sugarPerPitcher;
                cupCount = 10;
            }
            return cupCount;
        }
    }
}
