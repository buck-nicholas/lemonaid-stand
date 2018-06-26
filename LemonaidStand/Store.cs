using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonaidStand
{
    class Store
    {
        private double[] lemonPrices = { .99, 2.47, 4.23};
        private double[] sugarPrices = { .63, 1.51, 3.46};
        private double[] icePrices = { .87, 2, 3.77 };
        private double[] cupPrices = { .95, 1.58, 3.14 };
        private int[] bulkLemon = { 10, 30, 75 };
        private int[] bulkSugar = { 8, 20, 48 };
        private int[] bulkIce = { 100, 250, 500 };
        private int[] bulkCup = { 25, 50, 100 };
        private string userSelection;

        public Store()
        {

        }

        public void StoreMenu()
        {
            Console.WriteLine("What would you like to buy?\n[1] Lemons\n[2] Sugar\n[3] Ice\n[4] Cups\n[5] Exit Store");
            Console.Write("Selection Number: ");
            userSelection = Console.ReadLine();
            switch (userSelection)
            {
                case "1":
                    DisplayStorePrices("Lemons", lemonPrices, bulkLemon, "lemons");
                    break;
                case "2":
                    DisplayStorePrices("Sugar", sugarPrices, bulkSugar, "cups");
                    break;
                case "3":
                    DisplayStorePrices("Ice", icePrices, bulkIce, "cubes");
                    break;
                case "4":
                    DisplayStorePrices("Cups", cupPrices, bulkCup, "cups");
                    break;
                case "5":
                    return;
                default:
                    break;

            }

        }
        public void DisplayStorePrices(string item, double[] prices, int[] itemSizes, string unitOfIssue)
        {
            int counter = 0;
            Console.WriteLine("Displaying product information for " + item);
            foreach (int size in itemSizes)
            {
                Console.WriteLine("[" + (counter + 1) + "] " + size + " " + unitOfIssue + " for $" + prices[counter]);
                counter++;
            }
        }
        
            
        
    }
}
