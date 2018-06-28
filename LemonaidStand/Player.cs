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
        //private double popularity;
        public Inventory inventory = new Inventory();
        public Recipe recipe = new Recipe();

        public Player()
        {
            netCash = 20;
        }

        public static void GetUserInput(string message)
        {
            Console.WriteLine(message);
            string userInput = Console.ReadLine();
        }

    }
}
