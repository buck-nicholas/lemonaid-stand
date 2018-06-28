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
        private int dayCount;
        private Day day;
        private Store store;
        private Weather weather;
        private UserInterface mainMenu;
        private int gameLength;
        public Game()
        {
            GameMaster();
            GameEndResults();
        }
        public void GameMaster()
        {
            player = new Player();
            store = new Store(player);
            gameLength = 7;
            weather = new Weather(); // Day 1 Weather
            day = new Day(player, weather); // Day 1
            dayCount = 0;
            mainMenu = new UserInterface(player, store, weather);
            while (dayCount < gameLength)
            {
                Console.WriteLine("Day: " + (dayCount + 1));
                weather.DisplayWeather();
                mainMenu.MainMenu();
                day.dayLogic();
                day.dayResults();
                day = new Day(player, weather);
                weather = new Weather();
                dayCount++;
            }
        }
        private void GameEndResults()
        {
            Console.WriteLine("Game End!\nYou ended with a total networth of: ${0}\nYou sold a total of {1} cups to {2} potential customers.\nSuccessRate: {3}\n Total Earnings: ${4}", player.netCash, player.totalSold, player.totalCustomers, (player.totalSold / player.totalCustomers), player.totalEarnings);
        }
    }
}
