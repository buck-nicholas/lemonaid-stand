using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonaidStand
{
    public class Store
    {
        public double[] lemonPrices = { .99, 2.47, 4.23};
        public double[] sugarPrices = { .63, 1.51, 3.46};
        public double[] icePrices = { .87, 2, 3.77 };
        public double[] cupPrices = { .95, 1.58, 3.14 };
        public int[] bulkLemon = { 10, 30, 75 };
        public int[] bulkSugar = { 8, 20, 48 };
        public int[] bulkIce = { 100, 250, 500 };
        public int[] bulkCup = { 25, 50, 100 };
        public List<string> cartItemName = new List<string>();
        public List<int> cartItemSize = new List<int>();
        public List<double> cartItemPrice = new List<double>();
        public double totalPrice;
        public string userSelection;
        Player player;
        public Store(Player player)
        {
            this.player = player;
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
            }
        }
        public void DisplayCart()
        {
            Console.Clear();
            if (cartItemName.Count == 0)
            {
                Console.WriteLine("Your cart is currently empty!");
                Console.Write("Press [Enter] to return back to the store...");
                Console.ReadLine();
                Console.Clear();
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
                Console.WriteLine("$" + CalculateCartTotal());
                Console.WriteLine("***************************");
                Console.Write("Press [Enter] to continue...");
                Console.ReadLine();
            }
        }
        private double CalculateCartTotal()
        {
            totalPrice = cartItemPrice.Sum();
            return totalPrice;
        }
        public void EditCart()
        {
            if (cartItemName.Count == 0)
            {
                Console.WriteLine("Your cart is currently empty!");
                Console.Write("Press [Enter] to return back to the store...");
                Console.ReadLine();
                Console.Clear();
            }
            else
            {
                int counter = 0;
                foreach (string item in cartItemName)
                {
                    Console.WriteLine("[" + (counter + 1) + "]" + " Item: " + item + " Amount: " + cartItemSize[counter] + " $" + cartItemPrice[counter]);
                    counter++;
                }
                Console.Write("Please select the item you would like to remove: ");
                userSelection = Console.ReadLine();
                try
                {
                    cartItemName.RemoveAt(Int32.Parse(userSelection) - 1);
                    cartItemPrice.RemoveAt(Int32.Parse(userSelection) - 1);
                    cartItemSize.RemoveAt(Int32.Parse(userSelection) - 1);
                }
                catch (Exception)
                {
                    Console.WriteLine("\"{0}\" is not a valid selection", userSelection);
                    Console.Write("Please enter a valid selection...");
                    Console.ReadLine();
                    Console.Clear();
                    EditCart();
                }
                
                DisplayCart();
                Console.Clear();
            }
        }
        public void CompletePurchase()
        {
            DisplayCart();
            Console.WriteLine("***************************");
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
                    player.netCash -= totalPrice;
                }
            }
            Console.Clear();
        }
    }
}
