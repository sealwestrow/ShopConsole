using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopLibrary;
using NewDiscount;

namespace ShopConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //Создаем товары
            Product noski = new Product("Носки", 15, "Одежда");
            Product pidzhak = new Product("Пиджак", 120, "Верхняя одежда");
            Product jeans = new Product("Джинсы", 85, "Штаны");
            Product glasses = new Product("Очки", 35, "Аксессуары");
            Product hat = new Product("Шляпа", 50, "Головные уборы");
            //Создаем покупателей
            Customer c1 = new Customer("Николай", 12, 10000);
            Customer c2 = new Customer("Валентин", 10, 4000);

            List<Item> list = new List<Item>() { new Item(noski, 5), new Item(pidzhak, 1), new Item(jeans, 12), new Item(glasses, 2), new Item(hat, 4)};
            foreach (var item in list)
            {
                Console.WriteLine(item.Product.ToString());
            }
            Order o1 = new Order(list, c1);
            List<Item> newList = o1.GetAll().ToList();
            double dis = o1.GetDiscount();
            Console.WriteLine("Стандартная скидка {0}", dis);
            dis = o1.GetTotalWithOtherDiscount();
            Console.WriteLine("Новая скидка {0}", dis);
            //Добавляем тотал
            o1.Customer.Total = 51000;
            dis = o1.GetTotalWithOtherDiscount();
            Console.WriteLine("Новая скидка после добавления {0}", dis);
            //Проверка на удаление
            Console.WriteLine("Было {0} элементов", o1.List.Count);
            o1.Remove(pidzhak);
            Console.WriteLine("После удаления стало {0} элементов", o1.List.Count);
            //Проверка GetTotal
            Console.WriteLine("Была такая сумма: {0}", o1.Customer.Total);
            o1.GetTotal();
            Console.WriteLine("Стала такая сумма: {0}", o1.Customer.Total);
            //Проверка сортировки
            Product[] prods = new Product[] { new Product("Носки", 15, "Одежда"), new Product("Пиджак", 120, "Одежда"), new Product("Джинсы", 85, "Одежда"), new Product ("Очки", 35, "Аксессуары") };

            Array.Sort(prods, new SortByName());
            Array.Sort(prods, new SortByType());
            Array.Sort(prods, new SortByTypeAndPrice());
        }
    }
}
