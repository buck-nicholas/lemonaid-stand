using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonaidStand
{
    public class Game
    {
        public Player player;
        public Game()
        {
            
        }
        public void GameMaster()
        {
            
            Player player = new Player();
            Store store = new Store(player);
            Weather weather = new Weather();
            Day day = new Day(player);
            UserInterface mainMenu = new UserInterface(player, store, weather);
            mainMenu.MainMenu();
            
        }
    }
}
