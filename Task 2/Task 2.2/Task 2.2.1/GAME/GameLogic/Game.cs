using GAME;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace GameLogic
{
    public class Game
    {
        private Painter painter;
        private GameField gameField;

        public Game(GameField gameField)
        {
            this.gameField = gameField;
            painter = new Painter(gameField);
        }

        public void CherryCollision()
        {
            for (int i = 0; i < gameField.GameObjects.Count; i++)
            {
                if ((gameField.Player.X == gameField.GameObjects[i].X) && (gameField.Player.Y == gameField.GameObjects[i].Y) && (gameField.GameObjects[i] is Cherry))
                {
                    gameField.Player.CherryCount += 1;
                    gameField.GameObjects.RemoveAt(i);
                    break;
                }
            }
        }

        public void GhostCollision()
        {
            for (int i = 0; i < gameField.GameObjects.Count; i++)
            {
                if ((gameField.Player.X == gameField.GameObjects[i].X) && (gameField.Player.Y == gameField.GameObjects[i].Y) && (gameField.GameObjects[i] is Ghost))
                {
                    Process.GetCurrentProcess().Kill();
                }
            }
        }


        public bool[] FreeCells(GameObject gameObject)
        {
            bool[] cells = { true, true, true, true };
            for (int i = 0; i < gameField.GameObjects.Count; i++)
            {
                if (gameField.GameObjects[i].X == gameObject.X - 1 && gameField.GameObjects[i].Y == gameObject.Y && !(gameField.GameObjects[i] is Cherry) && !(gameField.GameObjects[i] is Obstale))
                    cells[0] = false;

                if (gameField.GameObjects[i].X == gameObject.X - 1 && gameField.GameObjects[i].Y == gameObject.Y && !(gameField.GameObjects[i] is Cherry) && !(gameField.GameObjects[i] is Obstale))
                    cells[1] = false;

                if (gameField.GameObjects[i].X == gameObject.X - 1 && gameField.GameObjects[i].Y == gameObject.Y && !(gameField.GameObjects[i] is Cherry) && !(gameField.GameObjects[i] is Obstale))
                    cells[2] = false;

                if (gameField.GameObjects[i].X == gameObject.X - 1 && gameField.GameObjects[i].Y == gameObject.Y && !(gameField.GameObjects[i] is Cherry) && !(gameField.GameObjects[i] is Obstale))
                    cells[3] = false;
            }
            return cells;
        }

        public void GhostMoveLogic()
        {
            Random rnd = new Random();
            for (int i = 0; i < gameField.Ghosts.Count; i++)
            {
                bool changePosition = false;
                bool[] cellsPosition = FreeCells(gameField.Ghosts[i]);
                while (!changePosition)
                {
                    int position = rnd.Next(0, cellsPosition.Length);
                    if (cellsPosition[position] == true)
                    {
                        changePosition = true;
                        switch (position)
                        {
                            case 0:
                                gameField.Ghosts[i].MoveUp();
                                break;

                            case 1:
                                gameField.Ghosts[i].MoveLeft();
                                break;

                            case 2:
                                gameField.Ghosts[i].MoveDown();
                                break;

                            case 3:
                                gameField.Ghosts[i].MoveRight();
                                break;
                        }
                        GhostCollision();
                    }
                }
            }
        }

        public void PlayerController(ConsoleKeyInfo cki)
        {
            bool[] freeCells = FreeCells(gameField.Player);
            switch (cki.Key)
            {
                case ConsoleKey.W:
                    gameField.Player.MoveUp();
                    break;

                case ConsoleKey.S:
                    gameField.Player.MoveDown();
                    break;

                case ConsoleKey.D:
                    gameField.Player.MoveRight();
                    break;

                case ConsoleKey.A:
                    gameField.Player.MoveLeft();
                    break;
            }
            CherryCollision();
            GhostCollision();
        }

        public void Start()
        {
            GameAction();
        }
        public void GameAction()
        {
            ConsoleKeyInfo cki;
            do
            {
                while (Console.KeyAvailable == false)
                {
                    painter.ConsoleDrawObjects();
                    GhostMoveLogic();
                    Thread.Sleep(60);
                    Console.Clear();
                }
                cki = Console.ReadKey(true);
                PlayerController(cki);
            }
            while (gameField.Player.CherryCount < 4);

            if (gameField.Player.CherryCount == 4)
            {
                Console.WriteLine("Вы победили");
                Console.ReadKey();
                return;
            }
        }

    }
}
