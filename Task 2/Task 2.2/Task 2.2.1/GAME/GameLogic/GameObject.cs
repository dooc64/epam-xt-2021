using System;
using System.Collections.Generic;
using System.Text;

namespace GameLogic
{
    public class GameObject
    {
        public char Name;
        public int X;
        public int Y;

        public GameObject(char name, int x, int y)
        {
            Name = name;
            X = x;
            Y = y;
        }
    }

    public class Player : GameObject, IMoveble
    {
        public int CherryCount;
        public Player(char name, int x, int y) : base(name, x, y)
        {
            
        }

        public void MoveRight()
        {
            this.X += 1;
        }
        public void MoveLeft()
        {
            this.X -= 1;
        }
        public void MoveUp()
        {
            this.Y -= 1;
        }
        public void MoveDown()
        {
            this.Y += 1;
        }
    }

    public class Ghost : GameObject, IMoveble
    {
        public Ghost(char name, int x, int y) : base(name, x, y)
        {

        }
        public void MoveRight()
        {
                this.X += 1;
        }
        public void MoveLeft()
        {
                this.X -= 1;
        }
        public void MoveUp()
        {
                this.Y -= 1;
        }
        public void MoveDown()
        {
                this.Y += 1;
        }
    }
}
