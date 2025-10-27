using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Praktika11
{
    class Car
    {
        private int speed;
      
        public int Speed
        {
            get { return speed; }
            set
            {
                if (  value < 0)
                    Console.WriteLine("скорость меньше 0");
                else if (value > 300)
                    Console.WriteLine("скорость больше 300");
                else
                   speed = value;
            }
        }
        public string Model { get; set; } = "Unknown";

        public Car (int speed, string model)
        {
            this.speed = speed;
            this.Model = model;
        }
        public void Drive()
        {
            Console.WriteLine($"{Model} едет со скоростью {speed} км/ч");
        }

    }
    class Phone
    {
        private int battery;
        public int Battery
        {
            get { return battery; }
            set
            {
                if (value < 0)
                    Console.WriteLine("Заряд не может быть меньше 0");
                else if (value > 100)
                    Console.WriteLine("Заряд не может быть больше 100");
                
                else battery = value;
            }
        }
        public string Brand { get; set; } 
        public Phone(string brand, int initBattery)
        {
            Brand = brand;
            Battery = initBattery;
        }

        public void Use()
        {
            Battery = battery - 10 < 0 ? 0 : battery - 10;
            Console.WriteLine($"{Brand}: заряд {Battery}% ");
        }
    }
    class Book
    {
        private string title;
        public string Title
        {
            get { return title; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    Console.WriteLine(" строка пуста или null");
                else title = value;
            }
        }
        public int Pages { get; set; } = 1;
        public bool IsLong { get { return Pages > 300; } }
        public Book(string title)
        {
            Title = title;
        }
        public void Info()
        {
            Console.WriteLine($"Книга: {title}, страниц : {Pages}, длинная: {(IsLong ?"да" : "нет")}");
        }
    }
    class Player
    {
        private int level;
        private int health;
       
        public int Level
        {
            get { return level; }
            set
            {
                if (level < 1 || level > 100)
                {
                    Console.WriteLine("Уровень должен быть от 1 до 100!");
                }
                else 
                {
                    level = value;
                }
            }

        }
        public int Health
        {
            get { return health; }
            set
            {
                if  (value > 100) health = 100;         
                else if (value < 0) health = 0;
                else health = value;
            }
        }
        public string Name { get; set; }

        public bool IsAlive { get { return Health > 0; } }

        public Player(string name, int level, int health)
        {
            Name = name;
            this.level = level;
            this.health = health;
        }
        public void TakeDamage(int damage)
        {
            Health -= damage;
            Console.WriteLine($" Игрок: {Name}, уровень: {Level}, здоровье: {Health}, жив: {(IsAlive ? "Да" : "Нет" )}");
        }

    }
    class Product
    {
        private int price;
        private int discount;
        public int Price
        {
            get { return price; }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Цена не может быть отрицательной!");
                }
                else
                {
                    price = value;
                }
            }
        }
        public int Discount
        {
            get { return discount; }
            set
            {
                if (value < 0)
                    discount = 0;
                else if (value > 100)
                    discount = 100;
                else
                    discount = value;
            }
        }

        public decimal FinalPrice { get { return Price * (1 - Discount / 100m); } }
        public string Name { get; set; } = "Без названия";
        public Product(int price, int discount)
        {
            Price = price;
            Discount = discount;
        }

        public void Show()
        {
            Console.WriteLine($"{Name}: {FinalPrice} (скидка {Discount}%)");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car(150,"BMW" );
            car.Drive();
            car.Speed = -2;
            car.Model = "BMW";
             
            Phone phon = new Phone("Redmi", 60);
            phon.Use(); 
            phon.Battery =-2;
           
            Book book1 = new Book("Война и мир") { Pages = 1200 } ;
            book1.Info();
            Book book2 = new Book("");

            Player player = new Player("Кирилл", 5, 100);
            player.TakeDamage(99);
            Player player1 = new Player("Кирилл", 5, 100);
            player1.Level = 1;
            player1.TakeDamage(-4);
            Player player2 = new Player("Кирилл", 5, 100);
            player2.TakeDamage(101);

            Product product = new Product(1000, 50);
            product.Name = "Плейстейшен";
            product.Show();

            Product product1 = new Product(-2425, 52);
            product1.Name = "Плейстейшен";
            product1.Show();
        }
    }
}
