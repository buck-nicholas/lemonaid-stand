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
            player = new Player();
            Store store = new Store(player);
            store.StoreMenu();
        }
    }
}
