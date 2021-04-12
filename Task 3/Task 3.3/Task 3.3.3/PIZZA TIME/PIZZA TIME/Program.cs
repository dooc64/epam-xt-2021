using System;
using System.Collections.Generic;


namespace PIZZA_TIME
{
    class Program
    {
        static Pizzeria dodo = new Pizzeria();
        static void Main(string[] args)
        {
            dodo.OnOrderComplete += ShowMessage;
            while (true)
            {
                Console.WriteLine("Свободная касса!");
                Console.WriteLine("Press Enter to continue!");
                Console.ReadLine();
                GetOrder();
            }
        }

        public static void ShowMessage(string name, Pizza[] pizzas)
        {
            Console.Write($"{name}, ваш заказ на: ");
            foreach (var item in pizzas)
            {
                Console.Write(item.Name + ", ");
            }
            Console.WriteLine("готов.");
        }

        public static void GetOrder()
        {
            PizzaMaker pm = new PizzaMaker();
            List<Pizza> pizzas = new List<Pizza>();
            Console.WriteLine("Добрый день, как вас зовут?");
            string name = Console.ReadLine();
            Console.WriteLine("Какую пиццу хотите заказать?");
            bool tak = true;
            while (tak)
            {
                Console.WriteLine("1. Пепперони.");
                Console.WriteLine("2. Маргарита.");
                Console.WriteLine("3. Мясная.");
                Console.WriteLine("4. Заказ сделан");
                bool choice = int.TryParse(Console.ReadLine(), out int userChoice);
                switch (userChoice)
                {
                    case 1:
                        pizzas.Add(pm.GetPepperoni());
                        break;
                    case 2:
                        pizzas.Add(pm.GetMargarita());
                        break;
                    case 3:
                        pizzas.Add(pm.GetMeats());
                        break;

                    case 4:
                        tak = false;
                        break;

                    default:
                        break;
                }
            }
            Console.WriteLine("Ваш заказ принят, ожидайте");
            dodo.CreateOrder(name, pizzas.ToArray());
        }
    }
}
