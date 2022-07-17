using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace OnlineShop
{
    public class User
    {
        public string NameUser;

        public List<Order> UsersOrders;

        public User(string nameuser)
        {
            NameUser = nameuser;
            UsersOrders = new List<Order>();
        }
        public void Print()
        {
            Console.WriteLine("Здравствуйте " + NameUser + "!");
        }
        public void ShowUserOrders()
        {
            if (UsersOrders.Count > 0)
            {
                foreach(Order order in UsersOrders)
                {
                    Console.WriteLine($"Номер: {order.OrderNumber} Стоимость: {order.FullPrice}");
                }
            }
            else
            {
                Console.WriteLine("Нет оформленных заказов.");
            }
        }
    }
    public class Product
    {
        public string Name;
        public decimal Price;
        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
        public void Print()
        {
            Console.WriteLine($"{Name}{Price}");
        }
    }

   
    public class Order
    {
        public int OrderNumber;
        public List<Product> Products;
        public decimal FullPrice;
        public List<Product> Basket;
       
        public Order(List<Product> products)
        {
            OrderNumber++;
            Products = products;
            foreach (var product in products)
            {
                FullPrice += product.Price;
            }
        }
    }
  
    public class Store
    {
        public List<Product> Basket;

        public List<Product> Products;

        public List<Order> Orders;

        
        public Store()
        {
            Products = new List<Product>
            {
                new Product("Хлеб ", 25),
                new Product("Печенье ", 50),
                new Product("Масло ", 250),
                new Product("Йогурт ", 300),
                new Product("Сок ", 80),
            };

            
            Basket = new List<Product>();

            Orders = new List<Order>();

            

        }
        
        public void AddToBasket(int numberProduct)
        {
            Basket.Add(Products[numberProduct - 1]);
            Console.WriteLine($"Продукт {Products[numberProduct - 1].Name} успешно добавлен в корзину.");
            Console.WriteLine($"В корзине {Basket.Count} продуктов.");
        }
       

        public void ShowProducts(List<Product> products)
        {

            int number = 1;
            foreach (Product product in Products)
            {
                Console.Write(number + ". ");
                product.Print();
                number++;
            }
        }
        public void ShowBasket(List<Product> products)
        {
            int number = 1;
            foreach (Product product in Basket)
            {
                Console.Write(number + ". ");
                product.Print();
                number++;
            }
        }
        public void ShowCatalog()
        {
            Console.WriteLine("Каталог продуктов");
            ShowProducts(Products);
        }
        public void ShowBasket()
        {
            Console.WriteLine("Содержимое корзины");
            ShowBasket(Basket);
        }
        public void CreateOrder()
        {
            // передать в отдел доставки
            Order order = new Order(Basket);
            Orders.Add(order);
            Basket.Clear();
        }  
        public class Admin
        {
            public string Login;
            public string Password;
            public Admin(string login, string password)
            {
                Login = login;
                Password = password;
            }
        }
        public void AddProduct(string name, int price)
        {
            Product newProduct = new Product(name, price);
            Products.Add(newProduct);
            Console.WriteLine($"Продукт{newProduct.Name} добавлен в каталог.");
        }
       
    }
    class Program
    {
        static void Main(string[] args)
        {

            Store onlineStore = new Store();
            Console.WriteLine("Введите имя.");
            string s = Console.ReadLine();
            User user1 = new User(s);
            

            Console.WriteLine("Здравствуйте. Выберите действие:");
            Console.WriteLine("1. Показать каталог продуктов.");
            Console.WriteLine("2. Добавить продукт в корзину.");
            Console.WriteLine("3. Посмотреть корзину.");
            Console.WriteLine("4. Оформить заказ.");
            Console.WriteLine("5. Войти как администратор.");
            Console.WriteLine("Выберите номер действия, которое хотите совершить.");
            bool f = false;
            while (f == false)
            {

                try
                {
                    int numberAction = Convert.ToInt32(Console.ReadLine());
                    if (numberAction > 0 && numberAction < 6)
                    {
                        f = true;
                        if (f == true)
                        {
                            switch (numberAction)
                            {

                                case 1: onlineStore.ShowCatalog(); break;
                                case 2:
                                    Console.WriteLine("Напишите номер продукта, которого нужно добавить в корзину");
                                    try
                                    {
                                        int productNumber = Convert.ToInt32(Console.ReadLine());
                                        onlineStore.AddToBasket(productNumber);     
                                    }
                                    catch (Exception productNumber)
                                    {
                                        Console.WriteLine(productNumber.Message + "\nВведите корректное число");
                                    }
                                    break;
                                case 3: onlineStore.ShowBasket(); break;
                                case 4: onlineStore.CreateOrder(); break;
                                case 5:
                                    Console.WriteLine("Введите логин и пароль.");
                                    string login = Console.ReadLine();
                                    int password = Convert.ToInt32(Console.ReadLine());
                                   
                                        if (login == "Admin" && password == 2898)
                                        {
                                            bool g = true;
                                            Console.WriteLine("Логин и пароль введены успешно! Приветствую господин.");
                                            Console.WriteLine("Выберите действие милорд.");
                                            Console.WriteLine("1. Добавить товар в каталог");
                                            Console.WriteLine("2. Выйти из учётки.");
                                            int number = Convert.ToInt32(Console.ReadLine());
                                        if (number == 1)
                                        {
                                            try {
                                                Console.WriteLine("Введите название товара.");
                                                string name = Console.ReadLine();

                                                Console.WriteLine("Введите цену товара.");
                                                int price = Convert.ToInt32(Console.ReadLine());
                                                onlineStore.AddProduct(name, price);
                                                if (name != "" && price != 0)
                                                {
                                                    g = true;
                                                }
                                                else
                                                {
                                                    g = false;
                                                }
                                            }
                                            catch(FormatException)
                                            {
                                                Console.WriteLine("ОШИБКА 101: Вы ввели неправильно имя или цену. Введите верный формат.");
                                            }
                                            }
                                        else
                                        {
                                            Console.WriteLine("Непросвещенным вход воспрещён");
                                        }
                                        }
                                        break;
                                default:
                                    Console.WriteLine("Выберите номер действия из списка");
                                    break;
                            }
                        }
                    }
                    else
                    {
                        f = false;
                        if (f == false)
                        {
                            Console.WriteLine("Выберите номер действия из списка");
                        }
                        continue;
                    }
                }
                catch (Exception numberAction)
                {
                    Console.WriteLine(numberAction.Message + "\nВведите число из списка");
                    continue;
                }
                bool yes;
                do
                {
                    Console.WriteLine("Хотите добавить продукт в корзину? Наберите Да или Нет.");
                    yes = IsYes(Console.ReadLine());
                    if (yes)
                    {
                        onlineStore.ShowCatalog();
                        Console.WriteLine("Напишите номер продукта, которого нужно добавить в корзину");
                        int productNumber = Convert.ToInt32(Console.ReadLine());
                        onlineStore.AddToBasket(productNumber);

                    }
                }
              



                while (yes);

                Console.WriteLine("Хотите посмотреть корзину? Наберите Да или Нет.");
                yes = IsYes(Console.ReadLine());
                if (yes)
                {
                    onlineStore.ShowBasket();
                }

                Console.WriteLine("Хотите оформить заказ? Наберите Да или Нет.");
                yes = IsYes(Console.ReadLine());
                if (yes)
                {
                    onlineStore.CreateOrder();
                    Console.WriteLine("Заказ оформолен! Спасибо за выбор нашего продуктового магазина!");
                }
            }
            static bool IsYes(string answer)
            {
                return (answer.ToLower() == "да");
            }
            user1.ShowUserOrders();
        }
    }
}
 