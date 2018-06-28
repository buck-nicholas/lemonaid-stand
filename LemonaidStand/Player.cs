using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonaidStand
{
    public class Player
    {
        public double netCash;
        public Inventory inventory = new Inventory();
        public Recipe recipe = new Recipe();
        public double totalSold;
        public double totalCustomers;
        public double totalEarnings;
        public double successRate;

        public Player()
        {
            netCash = 20;
            totalCustomers = 0;
            totalSold = 0;
            totalEarnings = 0;
        }

        public static void GetUserInput(string message)
        {
            Console.WriteLine(message);
            string userInput = Console.ReadLine();
        }
        public void CalculateSuccessRate()
        {
            successRate = totalSold / totalCustomers;
        }

    }
}
