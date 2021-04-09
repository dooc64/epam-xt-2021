using System;
using System.Collections.Generic;
using System.Text;

namespace PIZZA_TIME
{
    public class Pizza
    {
        public string Name { get; private set; }
        public int cookingTime { get; private set; }

        public Pizza(string name, int cookingTime)
        {
            this.Name = name;
            this.cookingTime = cookingTime;
        }
    }
    
    public class PizzaMaker
    {
        public Pizza GetPepperoni()
        {
            return new Pizza("Пепперони", 10);
        }

        public Pizza GetMargarita()
        {
            return new Pizza("Маргарита", 20);
        }

        public Pizza GetMeats()
        {
            return new Pizza("Мясная", 30);
        }
    }
}