using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonaidStand
{
    class UserInterface
    {
        // member var
        public string userInput;
        Player player;
        Store store;
        Weather weather;

        public UserInterface(Player player, Store store, Weather weather)
        {
            this.player = player;
            this.store = store;
            this.weather = weather;
        }

        public void MainMenu()
        {
            Console.WriteLine("Main Menu\n[1] Store\n[2] Player Menu\n[3] Today's Forecast\n[4] Start Day");
            userInput = Console.ReadLine();
            Console.Clear();
            switch (userInput)
            {
                case "1":
                    StoreMenu();
                    break;
                case "2":
                    PlayerMenu();
                    break;
                case "3":
                    weather.DisplayWeather();
                    Console.WriteLine("Press [enter] to return to the Main Menu...");
                    Console.ReadLine();
                    break;
                case "4":
                    return;
                default:
                    DisplayImproperSelectionPrompt(userInput);
                    break;
            }
            Console.Clear();
            MainMenu();
        }
        public void PlayerMenu()
        {
            Console.WriteLine("Player Menu\n[1] Total Cash\n[2] Inventory\n[3] Recipe Menu\n[4] Back to Main Menu");
            userInput = Console.ReadLine();
            Console.Clear();
            switch (userInput)
            {
                case "1":
                    Console.WriteLine("Total Cash ${0}\nPress [enter] to return to the Main Menu...", player.netCash);
                    Console.ReadLine();
                    break;
                case "2":
                    player.inventory.DisplayInventory();
                    Console.WriteLine("Press [enter] to return to the Main Menu...");
                    Console.ReadLine();
                    break;
                case "3":
                    RecipeMenu();
                    break;
                case "4":
                    break;
                default:
                    DisplayImproperSelectionPrompt(userInput);
                    break;
            }
        }
        public void RecipeMenu()
        {
            Console.WriteLine("Recipe Menu\n[1] Display Recipe\n[2] Alter Recipe\n[3] Return to Player Menu");
            userInput = Console.ReadLine();
            Console.Clear();
            switch (userInput)
            {
                case "1":
                    player.recipe.DisplayRecipe();
                    break;
                case "2":
                    player.recipe.AlterRecipe();
                    break;
                case "3":
                    break;
                default:
                    DisplayImproperSelectionPrompt(userInput);
                    break;

            }
            PlayerMenu();
        }
        public void StoreMenu()
        {
            Console.WriteLine("What would you like to buy?\n[1] Lemons\n[2] Sugar\n[3] Ice\n[4] Cups\n[5] View Cart\n[6] Edit Cart\n[7] Check Out\n[8] Back to Main Menu");
            Console.Write("Selection Number: ");
            userInput = Console.ReadLine();
            Console.Clear();
            switch (userInput)
            {
                case "1":
                    store.DisplayStorePrices("Lemons", store.lemonPrices, store.bulkLemon, "lemons");
                    store.AddToCart("Lemons", store.lemonPrices, store.bulkLemon);
                    break;
                case "2":
                    store.DisplayStorePrices("Sugar", store.sugarPrices, store.bulkSugar, "cups");
                    store.AddToCart("Sugar", store.sugarPrices, store.bulkSugar);
                    break;
                case "3":
                    store.DisplayStorePrices("Ice", store.icePrices, store.bulkIce, "cubes");
                    store.AddToCart("Ice", store.icePrices, store.bulkIce);
                    break;
                case "4":
                    store.DisplayStorePrices("Cups", store.cupPrices, store.bulkCup, "cups");
                    store.AddToCart("Cups", store.cupPrices, store.bulkCup);
                    break;
                case "5":
                    store.DisplayCart();
                    Console.Clear();
                    break;
                case "6":
                    store.EditCart();
                    break;
                case "7":
                    store.CompletePurchase();
                    break;
                case "8":
                    return;
                default:
                    DisplayImproperSelectionPrompt(userInput);
                    break;
            }
            StoreMenu();
        }
        private static void DisplayImproperSelectionPrompt(string userInput)
        {
            Console.WriteLine("\"{0}\" is not a valid selection", userInput);
            Console.Write("Please enter a valid selection...");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
