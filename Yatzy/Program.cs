
namespace Yatzy
{
    public class Program
    {
        static void Main(string[] args)
        {
            GameSetUp gameplay = new GameSetUp(new UserInput(), new ConsoleOutput());
            gameplay.RunProgram();
        }
    }
}