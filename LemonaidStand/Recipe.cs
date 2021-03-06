﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonaidStand
{
    public class Recipe
    {
        public int lemonsPerPitcher;
        public int sugarPerPitcher;
        public int icePerCup;
        public double pricePerCup;
        public Recipe()
        {
            lemonsPerPitcher = 4;
            sugarPerPitcher = 4;
            icePerCup = 3;
            pricePerCup = .25;
        }   
        public void DisplayRecipe()
        {
            Console.WriteLine("Lemons per pitcher: {0}\nSugar per pitcher: {1} cups\nIce per cup: {2}\nPrice per cup: ${3}", lemonsPerPitcher,  sugarPerPitcher, icePerCup, pricePerCup);
            Console.Write("Press [Enter] to continue...");
            Console.ReadLine();
            Console.Clear();
        }
        public void AlterRecipe()
        {
            Console.Clear();
            string[] recipePrompts = { "Lemons per pitcher: ", "Cups of Sugar per pitcher: ", "Number of Ice Cubes per cup: "};
            int[] ingredients = { lemonsPerPitcher, sugarPerPitcher, icePerCup };
            int counter = 0;
            Console.WriteLine("Please enter the amount of each item you would like to use and adjust the price as needed:");

            foreach (string item in recipePrompts)
            {
                Console.WriteLine(item);
                ingredients[counter] = Int32.Parse(Console.ReadLine());
                counter++;
            }
            Console.WriteLine("Price per Cup: ");
            pricePerCup =  Double.Parse(Console.ReadLine());
            Console.Clear();
            Console.Write("New Recipe: ");
            DisplayRecipe();
        }
    }
}
