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
        private Random randomNumber = new Random();

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
            player.totalCustomers += customerflowrate;
        }
        public void dayLogic()
        {
            SetCustomerFlowRate();
            MakePitcher();
            int customerCountDown = customerflowrate;
            while ((player.inventory.iceAmount - player.recipe.icePerCup >= 0) && player.inventory.cupAmount - 1 >= 0 && cupCount > 0 && customerCountDown != 0)
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
                if (cupCount == 0)
                {
                    MakePitcher();
                }
                customerCountDown--;
            }
            moneyEarned = productSold * player.recipe.pricePerCup;
            player.totalSold += productSold;
            player.totalEarnings += moneyEarned;
            player.netCash += moneyEarned;
            Console.Write("Press Enter to Continue to Results...");
            Console.ReadLine();
            Console.Clear();
        }
        public void dayResults()
        {
            Console.WriteLine("You sold {0} cups to {1} customers and made ${2} today.", productSold, customerflowrate, moneyEarned);
            player.inventory.CalculateInventoryLoss();
            Console.Write("Press Enter to Continue to the Main Menu...");
            Console.ReadLine();
            Console.Clear();
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
