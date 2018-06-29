using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonaidStand
{
    public class Inventory
    {
        public int lemonAmount;
        public int sugarAmount;
        public int iceAmount;
        public int cupAmount;
        public Inventory()
        {
            lemonAmount = 0;
            sugarAmount = 0;
            iceAmount = 0;
            cupAmount = 0;
        }
        public void DisplayInventory()
        {
            Console.WriteLine("Player Inventory:\nLemons {0}\nSugar {1} cups\nIce {2} cubes\nCups {3}", lemonAmount, sugarAmount, iceAmount, cupAmount);
        }
        public void CalculateInventoryLoss()
        {
            if (iceAmount > 0)
            {
                iceAmount = 0;
                Console.WriteLine("Your ice has melted...");
            }
        }
    }
}
