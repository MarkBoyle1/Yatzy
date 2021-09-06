using System;

namespace Yatzy
{
    public class Program
    {
        static void Main(string[] args)
        {
            DiceRoll rolledDice = new DiceRoll();
            Console.WriteLine(rolledDice.RollDice());
        }
    }
}