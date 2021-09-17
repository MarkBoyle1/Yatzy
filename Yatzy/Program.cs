﻿
namespace Yatzy
{
    public class Program
    {
        static void Main(string[] args)
        {
            YatzyGameplay gameplay = new YatzyGameplay(new UserInput(), new ConsoleOutput());
            gameplay.SetUpGame();
        }
    }
}