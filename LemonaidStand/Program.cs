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
            Store store = new Store();
            store.StoreMenu();
            Console.ReadLine();
        }
    }
}
