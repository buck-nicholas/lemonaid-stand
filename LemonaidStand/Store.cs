using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonaidStand
{
    public class Store
    {
        private double[] lemonPrices = { .99, 2.47, 4.23};
        private double[] sugarPrices = { .63, 1.51, 3.46};
        private double[] icePrices = { .87, 2, 3.77 };
        private double[] cupPrices = { .95, 1.58, 3.14 };
        private int[] bulkLemon = { 10, 30, 75 };
        private int[] bulkSugar = { 8, 20, 48 };
        private int[] bulkIce = { 100, 250, 500 };
        private int[] bulkCup = { 25, 50, 100 };
        private List<string> cartItemName = new List<string>();
        private List<int> cartItemSize = new List<int>();
        private List<double> cartItemPrice = new List<double>();
        private double totalPrice;
        private string userSelection;
        Player player;
        
        
        public Store(Player player)
        {
            this.player = player;
        }

        public void StoreMenu()
        {
            Console.WriteLine("What would you like to buy?\n[1] Lemons\n[2] Sugar\n[3] Ice\n[4] Cups\n[5] View Cart\n[6] Exit Store");
            Console.Write("Selection Number: ");
            userSelection = Console.ReadLine();
            switch (userSelection)
            {
                case "1":
                    DisplayStorePrices("Lemons", lemonPrices, bulkLemon, "lemons");
                    AddToCart("Lemons", lemonPrices, bulkLemon);
                    break;
                case "2":
                    DisplayStorePrices("Sugar", sugarPrices, bulkSugar, "cups");
                    AddToCart("Sugar", sugarPrices, bulkSugar);
                    break;
                case "3":
                    DisplayStorePrices("Ice", icePrices, bulkIce, "cubes");
                    AddToCart("Ice", icePrices, bulkIce);
                    break;
                case "4":
                    DisplayStorePrices("Cups", cupPrices, bulkCup, "cups");
                    AddToCart("Cups", cupPrices, bulkCup);
                    break;
                case "5":
                    DisplayCart();
                    break;
                case "6":
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
        public void AddToCart(string item, double[] prices, int[] itemSizes)
        {
            Console.Write("Please enter your selection or type [exit] to return back to the store menu: ");
            if (userSelection == "exit")
            {
                Console.Clear();
                StoreMenu();
            }
            else
            {
                userSelection = Console.ReadLine();
                int itemSelection = Int32.Parse(userSelection);
                itemSelection -= 1;
                cartItemName.Add(item);
                cartItemPrice.Add(prices[itemSelection]);
                cartItemSize.Add(itemSizes[itemSelection]);
                Console.Clear();
                StoreMenu();
            }
        }
        public void DisplayCart()
        {
            if (cartItemName.Count == 0)
            {
                Console.WriteLine("Your cart is currently empty!");
                Console.Write("Press [Enter] to return back to the store...");
                Console.ReadLine();
                Console.Clear();
                StoreMenu();
            }
            else
            {
                int counter = 0;
                foreach (string item in cartItemName)
                {
                    Console.WriteLine("Item: " + item + " Amount: " + cartItemSize[counter] + " $" + cartItemPrice[counter]);
                    counter++;
                }
                Console.WriteLine("******* Total Price *******");
                totalPrice = cartItemPrice.Sum();
                Console.WriteLine("$" + totalPrice);
                CompletePurchase();
            }
        }
        public void CompletePurchase()
        {
            Console.WriteLine("Complete purchase? [yes / no]");
            userSelection = Console.ReadLine();
            if (userSelection.ToLower() == "yes")
            {
                if (totalPrice > player.netCash)
                {
                    Console.WriteLine("Transaction Canceled, Insufficient Funds.");
                }
                else
                {
                    int counter = 0;
                    foreach (string item in cartItemName)
                    {
                        if (item.ToLower() == "lemons")
                        {
                            player.inventory.lemonAmount += cartItemSize[counter];
                        }
                        else if (item.ToLower() == "ice")
                        {
                            player.inventory.iceAmount += cartItemSize[counter];
                        }
                        else if (item.ToLower() == "sugar")
                        {
                            player.inventory.sugarAmount += cartItemSize[counter];
                        }
                        else if (item.ToLower() == "cups")
                        {
                            player.inventory.cupAmount += cartItemSize[counter];
                        }
                        counter++;
                    }
                }
            }
            else
            {
                StoreMenu();
            }
        }
        
            
        
    }
}
