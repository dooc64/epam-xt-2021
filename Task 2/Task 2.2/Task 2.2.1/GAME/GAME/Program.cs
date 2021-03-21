using System;
using System.Collections.Generic;
using System.Text;
using GameLogic;

namespace GAME
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game(new GameField(100, 50));
            game.Start();
        }
    }
}
