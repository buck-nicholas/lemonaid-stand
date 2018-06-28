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
            lemonAmount = 10;
            sugarAmount = 10;
            iceAmount = 10;
            cupAmount = 10;
        }

        public void DisplayInventory()
        {
            Console.WriteLine("Player Inventory:\nLemons {0}\nSugar {1} cups\nIce {2} cubes\nCups {3}", lemonAmount, sugarAmount, iceAmount, cupAmount);
        }
        public void CalculateInventoryLoss()
        {
            iceAmount = 0;
            Console.WriteLine("Your ice has melted...");
        }

    }
}
