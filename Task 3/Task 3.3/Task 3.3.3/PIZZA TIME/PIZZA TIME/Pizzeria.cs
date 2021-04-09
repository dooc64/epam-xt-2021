using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PIZZA_TIME
{
    class Pizzeria
    {
        public Action<string, Pizza[]> OnOrderComplete;
        public void CreateOrder(string name, Pizza[] pizzas)
        {
            Task.Factory.StartNew(() =>
            {
                int sum = 0;
                foreach (var item in pizzas)
                {
                    sum += item.cookingTime;
                }
                Thread.Sleep(sum * 1000);
                OnOrderComplete(name, pizzas);
            });
        }
    }
}
