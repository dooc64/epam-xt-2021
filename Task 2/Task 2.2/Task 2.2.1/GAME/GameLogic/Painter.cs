using System;
using System.Collections.Generic;
using System.Text;
using GameLogic;

namespace GAME
{
    public class Painter
    {
        private GameField gameField;
 
        public Painter(GameField gf)
        {
            gameField = gf;
        }


        public void ConsoleDrawObjects()
        {
            for (int y = 0; y < gameField.Height; y++)
            {
                for (int x = 0; x < gameField.Width; x++)
                {
                    bool Object = false;
                    for (int i = 0; i < gameField.GameObjects.Count; i++)
                    {
                        if (gameField.GameObjects[i].X == x && gameField.GameObjects[i].Y == y)
                        {
                            Console.Write(gameField.GameObjects[i].Name);
                            Object = true;
                        }
                    }
                    if (!Object)
                    {
                        Console.Write(' ');
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
