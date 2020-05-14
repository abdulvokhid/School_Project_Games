using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            // menu
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("        <<<<<<<<<<<<<<<<<<<<<<<<<");
            Console.Write("        |"); Console.ForegroundColor = ConsoleColor.Green; Console.Write("    Battleship Game    "); Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("|");
            Console.WriteLine("        >>>>>>>>>>>>>>>>>>>>>>>>>");
            Console.ForegroundColor = ConsoleColor.Green;

            char input;
            Console.WriteLine("Please select an action");
            Console.WriteLine("Play - [P]");
            Console.WriteLine("Exit - [E]");   
            input = char.ToUpper (Console.ReadKey(true).KeyChar);        
            switch (input)
            {
                case 'P':               //the game starts from here
                    Battleship game = new Battleship();
                    int guess;
                    bool isInteger;

                    game.PositionShip();
                    do
                    {
                        Console.WriteLine("\n\nEnter a number between 1 and 9");
                        Console.WriteLine("Board: \n{0}", game.board);

                        isInteger = Int32.TryParse(Console.ReadLine(), out guess);

                        if (isInteger && (guess >= 1 && guess <= 9))
                        {
                            game.HitPosition(guess);
                        }
                        else
                        {
                            Console.WriteLine("That's not a valid number!");
                        }

                        if (!game.shipIsHit)
                        {
                            Console.WriteLine("You missed!");
                        }
                    }
                    while (!game.shipIsHit);

                    Console.WriteLine("\n\nBoard: \n{0}", game.board);
                    Console.WriteLine("BOOM! My congratulation you found ship! {0}", game.shipPosition);
                    Console.ReadKey();
                    break;
                case 'E':             // the game end starts from here
                    Console.WriteLine("Thank you for being with us.\nGoodBye!");
                    Console.ReadKey();
                    break;
                default:
                    Console.WriteLine("\nWrong input.");
                    break;
            }
            while (input != 'E');
            
        }
    }
    class Battleship            //the game boards starts from here
    {
        public int shipPosition;
        public string board = "-------------\n| 1 | 2 | 3 |\n-------------\n| 4 | 5 | 6 |\n-------------\n| 7 | 8 | 9 |\n-------------";
        public bool shipIsHit = false;

        public void PositionShip()
        {
            Random randomNumber = new Random();
            shipPosition = randomNumber.Next(1, 10); // random number between 1 and 9
        }
        public void HitPosition(int hit)
        {
            if (hit == shipPosition)
            {
                board = board.Replace(hit.ToString(), "X");
                shipIsHit = true;
            }
            else
            {
                board = board.Replace(hit.ToString(), "O");
            }
            Console.ReadKey();
        }
    }
}
