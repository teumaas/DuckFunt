using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        public enum GameState
        {
            InGame,
            Intro,
            Menu,
            Options,
            Loading,
            Exit,
            Default
        }
        static void Main(string[] args)
        {
        start:
            GameState state = GameState.Default;

            Console.WriteLine("choose:\nintro\ngame\nmenu\noptions\nloading\nexit\n");
            Console.WriteLine("Please enter a state:");
            string userInput = Console.ReadLine();
            Console.Clear();

            if (userInput == "intro" || userInput == "1")
            {
                state = GameState.Intro;
            }
            else if (userInput =="game" || userInput == "2")
            {
                state = GameState.InGame;
            }
            else if (userInput == "menu" || userInput == "3") 
            {
                state = GameState.Menu;
            }
            else if (userInput == "options" || userInput == "4")
            {
                state = GameState.Options;
            }
            else if (userInput == "loading" || userInput == "5")
            {
                state = GameState.Loading;
            }
            else if (userInput == "exit" || userInput == "6")
            {
               state = GameState.Exit;
            }
            else
            {
                state = GameState.Default;
            }


            switch (state)
            {
                case GameState.Intro: 
                    {
                        Console.WriteLine("here is the intro.");
                        Console.ReadKey();
                        state = GameState.Default;
                        break;
                    }
                case GameState.InGame:
                    {
                        Console.WriteLine("this is in game.");
                        Console.ReadKey();
                        state = GameState.Default;
                        break;
                    }
                case GameState.Menu:
                    {
                        Console.WriteLine("You should be in the menu.");
                        Console.ReadKey();
                        state = GameState.Default;
                        break;
                    }
                case GameState.Options:
                    {
                        Console.WriteLine("Welcome in the options.");
                        Console.ReadKey();
                        state = GameState.Default;
                        break;
                    }
                case GameState.Loading:
                    {
                        Console.WriteLine("Wait please I am loading.");
                        Console.ReadKey();
                        state = GameState.Default;
                        break;
                    }
                case GameState.Exit:
                    {
                        Console.WriteLine("Wow, such Exit. Much leave.");
                        Console.ReadKey();
                        System.Environment.Exit(0);
                        break;
                    }
                case GameState.Default:
                    {
                        break;
                    }
            }

            Console.Clear();
            goto start;
            //niet bashen...
            //dit is een voorbeeld.
        }
    }
}
