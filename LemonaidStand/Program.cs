using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonaidStand
{
    class Program
    {
        static void Main(string[] args)
        {
            Recipe test = new Recipe();
            test.DisplayRecipe();
            Console.ReadLine();
            Console.Clear();
            test.AlterRecipe();
            Console.ReadLine();        }
    }
}
