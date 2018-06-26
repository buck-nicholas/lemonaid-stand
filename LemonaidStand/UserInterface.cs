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

        public UserInterface(Player player, Store store)
        {
            this.player = player;
            this.store = store;
        }

        public void MainMenu()
        {
            Console.WriteLine("Main Menu\n[1] Store\n[2] Player Menu");
            userInput = Console.ReadLine();
            Console.Clear();
            switch (userInput)
            {
                case "1":
                    store.StoreMenu();
                    break;
                case "2":
                    PlayerMenu();
                    break;
                case "3":
                    break;
                default:
                    break;
                    
            }
            Console.Clear();
            MainMenu();
        }
        public void PlayerMenu()
        {
            Console.WriteLine("Player Menu\n[1] Total Cash\n[2] Inventory\n[3] Recipe Menu\n[4] Popularity\n[5] Back to Main Menu");
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
                    // player popularity
                    break;
                case "5":
                    break;
                default:
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
                    break;

            }
            PlayerMenu();
        }
    }
}
