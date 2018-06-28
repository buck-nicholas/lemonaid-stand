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
    }
}
