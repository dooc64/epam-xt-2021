using GAME;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameLogic
{
    public class GameField
    {
        private int width;
        private int height;
        private List<GameObject> gameObjects = new List<GameObject>();
        private List<Ghost> ghosts = new List<Ghost>();
        private Player player;

        public int Width { get => width; set { width = value; } }

        public int Height { get => height; set { height = value; } }

        public List<GameObject> GameObjects { get => gameObjects; }

        public List<Ghost> Ghosts { get => ghosts; }

        public Player Player { get => player; set { player = value; } }



        public GameField(int width, int height)
        {
            this.width = width;
            this.height = height;
            DrawBorder();
            DrawObstale();
            DrawPlayer();
            DrawCherrys();
            DrawGhosts();
        }

        public void DrawBorder()
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (y == 0 || y == height - 1)
                    {
                        gameObjects.Add(new Obstale('*', x, y));
                    }
                    if ((x == 0 || x == width - 1) && (y > 0 && y < height - 1))
                    {
                        gameObjects.Add(new Obstale('*', x, y));
                    }
                }

            }
        }

        public void DrawObstale()
        {
            Random rnd = new Random();
            for (int i = 0; i < rnd.Next(1, 5); i++)
            {
                int x = rnd.Next(2, Width - 2);
                int y = rnd.Next(1, Height - 2);
                GameObjects.Add(new GameObject('*', x, y));
            }
        }

        public void DrawCherrys()
        {
            Random rnd = new Random();
            GameObjects.Add(new Cherry('C', rnd.Next(2, Width - 2), rnd.Next(1, Height - 2)));
            GameObjects.Add(new Cherry('C', rnd.Next(2, Width - 2), rnd.Next(1, Height - 2)));
            GameObjects.Add(new Cherry('C', rnd.Next(2, Width - 2), rnd.Next(1, Height - 2)));
            GameObjects.Add(new Cherry('C', rnd.Next(2, Width - 2), rnd.Next(1, Height - 2)));
        }

        public void DrawGhosts()
        {
            Random rnd = new Random();

            Ghost firstGhost = new Ghost('G', rnd.Next(10, Width - 2), rnd.Next(1, Height));
            Ghost secondGhost = new Ghost('G', rnd.Next(10, Width - 2), rnd.Next(1, Height));

            gameObjects.Add(firstGhost);
            gameObjects.Add(secondGhost);

            ghosts.Add(firstGhost);
            ghosts.Add(secondGhost);
        }

        public void DrawPlayer()
        {
            Player = new Player('P', 3, 3);
            GameObjects.Add(Player);
        }
    }


    public class Obstale : GameObject
    {
        public Obstale(char name, int x, int y) : base(name, x, y)
        {

        }
    }

    public class Cherry : GameObject
    {
        public Cherry(char name, int x, int y) : base(name, x, y)
        {

        }
    }
}
