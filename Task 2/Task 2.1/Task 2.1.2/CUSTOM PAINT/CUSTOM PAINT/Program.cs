using System;
using System.Collections.Generic;
using System.Linq;


namespace CUSTOM_PAINT
{
    class Program
    {
        static void Main(string[] args)
        {
            UserInterface userInterface = new UserInterface();
            while (true)
            {
                Console.WriteLine("Выберите действие:" + Environment.NewLine +
                                    "1. Установить пользователя" + Environment.NewLine +
                                    "2. Выйти из программы");

                bool correct = int.TryParse(Console.ReadLine(), out int choice);
                if(!correct)
                {
                    Console.WriteLine("Введите корректные значния, 1 или 2");
                    continue;
                }    
                switch (choice)
                {
                    case 1:
                        userInterface.SelectUser(SwitchUser());
                        while (userInterface.UserAction())
                        {

                        }
                        break;
                    case 2:
                        return;

                    default:
                        break;
                }
            }
        }

        static string SwitchUser()
        {
            Console.WriteLine("Введите ваше имя");
            return Console.ReadLine();
        }
    }

    public class User
    {
        public string Name;
        private List<Figure> figures = new List<Figure>();
        public User(string name)
        {
            Name = name;
        }
        public void AddFigure(Figure figure)
        {
            figures.Add(figure);
        }
        public void DrawFigures()
        {
            foreach (var item in figures)
            {
                Console.WriteLine(item.Draw());
            }
        }
        public void ClearFigures()
        {
            figures.Clear();
        }
    }

    public class UserInterface
    {
        private User user;
        private List<User> users = new List<User>();

        public void SelectUser(string name)
        {
            user = users.FirstOrDefault(user => user.Name == name);
            if(user == null)
            {
                user = new User(name);
                users.Add(user);
            }
        }
        public bool UserAction()
        {
            Console.WriteLine("Выберите действие  " + Environment.NewLine +
                                 "1. Добавить фигуру" + Environment.NewLine +
                                 "2. Вывести фигуры" + Environment.NewLine +
                                 "3. Очистить холст" + Environment.NewLine +
                                 "4. Выйти");
            bool correct = int.TryParse(Console.ReadLine(), out int choice);
            if (!correct || choice < 1 || choice > 4)
            {
                Console.WriteLine("Принимаются только цифры от 1 до 4");
                return true;
            }
            switch(choice)
            {
                case 1:
                    SelectFigure();
                    break;

                case 2:
                    user.DrawFigures();
                    break;

                case 3:
                    user.ClearFigures();
                    break;

                case 4:
                    return false;

                default:
                    break;
            }
            return true;
        }

        public void SelectFigure()
        {
            Console.WriteLine("Выберите тип фигуры " + Environment.NewLine +
                                "1. Линия" + Environment.NewLine +
                                "2. Квадрат" + Environment.NewLine +
                                "3. Круг" + Environment.NewLine +
                                "4. Треугольник" + Environment.NewLine +
                                "5. Кольцо" + Environment.NewLine +
                                "6. Прямоугольник" + Environment.NewLine +
                                "7. Окружность");
            bool correct = int.TryParse(Console.ReadLine(), out int choice);
            if (!correct || choice < 1 || choice > 7)
            {
                Console.WriteLine("Принимаются только цифры от 1 до 7");
                return;
            }
            switch (choice)
            {
                case 1:
                    AddLine();
                    break;

                case 2:
                    AddSquare();
                    break;

                case 3:
                    AddCircle();
                    break;

                case 4:
                    AddTriangle();
                    break;

                case 5:
                    AddRing();
                    break;

                case 6:
                    AddRectangle();
                    break;

                case 7:
                    AddRound();
                    break;

                default:
                    break;
            }
        }
        public Point CreatePoint(string pointName = "стартовая точка")
        {
            int x, y;
            while (true)
            {
                Console.WriteLine($"Укажите {pointName} X ");
                bool correctX = int.TryParse(Console.ReadLine(), out x);
                if (!correctX)
                {
                    Console.WriteLine("Введите число");
                    continue;
                }
                break;
            }
            while (true)
            {
                Console.WriteLine($"Укажите {pointName} Y ");
                bool correctY = int.TryParse(Console.ReadLine(), out y);
                if (!correctY)
                {
                    Console.WriteLine("Введите число");
                    continue;
                }
                break;
            }
            return new Point(x, y);
          }
        public double SetLength(string lengthName = "длина линии")
        {
            while (true)
            {
                Console.WriteLine($"Укажите {lengthName}");
                bool correctLength = double.TryParse(Console.ReadLine(), out double length);
                if (correctLength)
                    return length;
                Console.WriteLine("Введено не корректно");
            }       
        }
        public void AddLine()
        {
            Point startPoint = CreatePoint();
            Point endPoint = CreatePoint("Конечная точка");
            user.AddFigure(new Line(startPoint, endPoint));
        }

        public void AddSquare()
        {
            Point firstPoint = CreatePoint();
            double length = SetLength();
            user.AddFigure(new Square(firstPoint, length));
        }

        public void AddCircle()
        {
            Point firstPoint = CreatePoint();
            double radius = SetLength("радиус");
            user.AddFigure(new Circle(firstPoint, radius));
        }

        public void AddRound()
        {
            Point firstPoint = CreatePoint();
            double radius = SetLength("радиус");
            user.AddFigure(new Round(firstPoint, radius));
        }

        public void AddTriangle()
        {
            Point firstPoint = CreatePoint("первую точку");
            Point secondPoint = CreatePoint("вторую точку");
            Point thirdPoint = CreatePoint("третью точку");
            user.AddFigure(new Triangle(firstPoint, secondPoint, thirdPoint));
        }

        public void AddRing()
        {
            Point startPoint = CreatePoint("центр");
            double radiusInner = SetLength("внутренний радиус");
            double radiusOuter = SetLength("внешний радиус");
            user.AddFigure(new Ring(startPoint, new Circle(startPoint, radiusInner), new Circle(startPoint, radiusOuter)));
        }
        
        public void AddRectangle()
        {
            Point startPoint = CreatePoint();
            double firstLine = SetLength("длину");
            double secondLine = SetLength("ширину");
            user.AddFigure(new Rectangle(startPoint, firstLine, secondLine));
        }
    }

    public class Point
    {
        public int X;
        public int Y;
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

    }

    public abstract class Figure
    {
        protected Point startPoint;
        public Figure(Point startPoint)
        {
            this.startPoint = startPoint;
        }
        public abstract string Draw();
    }

    public abstract class Figure2D : Figure
    {
        public Figure2D(Point startPoint) : base(startPoint)
        {

        }
        public abstract double GetArea();
        public abstract double GetPerimeter();
    }

    public class Circle : Figure
    {
        public double Radius;
        public Circle(Point center, double radius) : base(center)
        {
            Radius = radius;
        }
        public override string Draw()
        {
            return $"Окружность с центром: X:{startPoint.X} Y:{startPoint.Y} и радиусом: {Radius}";
        }
    }

    public class Round : Figure2D
    {
        private Circle circle;
        public Round(Point startPoint, double center) : base(startPoint)
        {
            circle = new Circle(startPoint, center);
        }
        public override string Draw()
        {
            return $"Окружность с центром: X:{startPoint.X} Y:{startPoint.Y} и радиусом: {circle.Radius}";
        }

        public override double GetArea()
        {
            return Math.Pow(circle.Radius * Math.PI, 2);
        }

        public override double GetPerimeter()
        {
            return 2 * circle.Radius * Math.PI;
        }
    }

    public class Line : Figure
    {
        private Point endPoint;
        public Line(Point startPoint, Point endPoint) : base(startPoint)
        {
            this.endPoint = endPoint;
        }
        public override string Draw()
        {
            return $"Линия с координтами начала: X:{startPoint.X}, Y:{startPoint.Y} и конца: X:{endPoint.X}, Y:{endPoint.Y}";
        }
        public double GetLengthLine()
        {
            int x1, x2, y1, y2;
            if (startPoint.X > endPoint.X)
            { x1 = startPoint.X; x2 = endPoint.X; }
            else
            { x1 = endPoint.X; x2 = startPoint.X; }

            if (startPoint.Y > endPoint.Y)
            { y1 = startPoint.Y; y2 = endPoint.Y; }
            else
            { y1 = endPoint.Y; y2 = startPoint.Y; }

            return Math.Pow(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2), 0.5);
        }
    }

    public class Triangle : Figure2D
    {
        private Point secondPoint;
        private Point thirdPoint;
        public Triangle(Point startPoint, Point secondPoint, Point thirdPoint) : base(startPoint)
        {
            this.secondPoint = secondPoint;
            this.thirdPoint = thirdPoint;
        }
        public override string Draw()
        {
            return $"Треугольник с координатами первой вершины: X:{startPoint.X}, Y:{startPoint.Y}, " +
                   $"второй вершины: X:{secondPoint.X}, Y:{secondPoint.Y}, " +
                   $"третей вершины: X:{thirdPoint.X}, Y:{thirdPoint.Y}";
        }

        public override double GetArea()
        {
            double first = GetLengthLine(startPoint, secondPoint);
            double second = GetLengthLine(thirdPoint, secondPoint);
            double third = GetLengthLine(startPoint, thirdPoint);
            double halfPerimeter = GetPerimeter() / 2;

            return Math.Pow(halfPerimeter * (halfPerimeter - first) * (halfPerimeter - second) * (halfPerimeter - third), 0.5);
        }

        public override double GetPerimeter()
        {
            double first = GetLengthLine(startPoint, secondPoint);
            double second = GetLengthLine(thirdPoint, secondPoint);
            double third = GetLengthLine(startPoint, thirdPoint);

            return first + second + third;
        }

        public double GetLengthLine(Point first, Point second)
        {
            int x1, x2, y1, y2;
            if (first.X > second.X)
            { x1 = first.X; x2 = second.X; }
            else
            { x1 = second.X; x2 = first.X; }

            if (first.Y > second.Y)
            { y1 = first.Y; y2 = second.Y; }
            else
            { y1 = second.Y; y2 = first.Y; }

            return Math.Pow(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2), 0.5);
        }
    }

    public class Square : Figure2D
    {
        private double lengthLine;
        public Square(Point startPoint, double lengthLine) : base(startPoint)
        {
            this.lengthLine = lengthLine;
        }
        public override string Draw()
        {
            return $"Квадрат с координатами левого верхнего угла: X:{startPoint.X}, Y:{startPoint.Y} и длиной сторон: {lengthLine}";
        }

        public override double GetArea()
        {
            return lengthLine * lengthLine;
        }

        public override double GetPerimeter()
        {
            return lengthLine * 4;
        }
    }

    public class Ring : Figure2D
    {
        private Circle circleInner;
        private Circle circleOuter;
        public Ring(Point startPoint, Circle circleInner, Circle circleOuter) : base(startPoint)
        {
            this.circleInner = circleInner;
            this.circleOuter = circleOuter;
        }
        public override string Draw()
        {
            return $"Кольцо с центром: X:{startPoint.X} Y:{startPoint.Y} и внутренним радиусом: {circleInner.Radius}, и внешним радиусом: {circleOuter.Radius}";
        }

        public override double GetArea()
        {
            return Math.Pow(circleOuter.Radius - circleInner.Radius, 2);
        }

        public override double GetPerimeter()
        {
            return 2 * Math.PI * (circleOuter.Radius + circleInner.Radius);
        }
    }

    public class Rectangle : Figure2D
    {
        private double lengthLine;
        private double widthLine;
        public Rectangle(Point startPoint, double lengthLine, double widthLine) : base(startPoint)
        {
            this.lengthLine = lengthLine;
            this.widthLine = widthLine;
        }
        public override string Draw()
        {
            return $"Прямоугольник с координатами левого верхнего угла: X:{startPoint.X}, Y:{startPoint.Y}, длиной сторон: {lengthLine} и шириной сторон: {widthLine}";
        }

        public override double GetArea()
        {
            return lengthLine * widthLine;
        }

        public override double GetPerimeter()
        {
            return (lengthLine + widthLine) * 2;
        }
    }
}
