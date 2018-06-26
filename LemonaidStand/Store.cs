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
        private int userSelection;

        public Store()
        {

        }

        public void StoreMenu()
        {
            Console.WriteLine("What would you like to buy?\n[1] Lemons\n[2] Sugar\n[3] Ice\n[4] Cups");
            Console.Write("Selection Number: ");
            userSelection = Int32.Parse(Console.ReadLine());

        }
        
            
        
    }
}
