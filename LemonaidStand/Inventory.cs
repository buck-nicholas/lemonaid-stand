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
        private int spoilAmount;
        private static readonly Random randomInt = new Random();
        public Inventory()
        {
            lemonAmount = 0;
            sugarAmount = 0;
            iceAmount = 0;
            cupAmount = 0;
        }
        public int RandomNumberGenerater(int min, int max)
        {
            int RandomNumber = randomInt.Next(min, max);
            return RandomNumber;
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
            if (lemonAmount > 0 && RandomNumberGenerater(0, 3) == 2)
            {
                spoilAmount = lemonAmount / 2;
                if (spoilAmount > 10)
                {
                    spoilAmount = 10;
                }
                lemonAmount -= spoilAmount;
                Console.WriteLine($"Some of your lemons have spoiled! -{spoilAmount} Lemon(s)");
            }
            if (sugarAmount > 0 && RandomNumberGenerater(0, 3) == 2)
            {
                spoilAmount = sugarAmount / 2;
                sugarAmount -= spoilAmount;
                if (spoilAmount > 10)
                {
                    spoilAmount /= 3;
                }
                Console.WriteLine($"You've got ants! -{spoilAmount} cup(s) of sugar");
            }
        }
    }
}
