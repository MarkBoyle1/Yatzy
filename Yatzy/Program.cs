using System;
using System.Collections.Generic;

namespace Yatzy
{
    public class Program
    {
        static void Main(string[] args)
        {
            YatzyGameplay gameplay = new YatzyGameplay(new UserInput());
            gameplay.UserAction();

        }
    }
}