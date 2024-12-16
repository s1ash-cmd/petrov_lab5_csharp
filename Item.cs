using petrov_lab5_c_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace petrov_lab5_c_
{
    [Serializable]
    [XmlType(TypeName = "Item")]
    public class Item
    {
        public string name { get; set; } = "";
        public double width { get; set; } = 0.0;
        public double weight { get; set; } = 0.0;
        public double height { get; set; } = 0.0;
        public int price { get; set; } = 0;
        public bool stock { get; set; } = false;

        public Item() { }

        public virtual void Input()
        {
            Console.Write("\nВведите название товара: ");
            name = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(name))
            {
                Console.Write("Название товара не может быть пустым. Попробуйте еще раз: ");
                name = Console.ReadLine();
            }

            Console.Write("Введите вес товара (в килограммах): ");
            weight = Program.check_input(0.0, 10000.0);

            Console.Write("Введите ширину товара (в сантиметрах): ");
            width = Program.check_input(0.0, 10000.0);

            Console.Write("Введите высоту товара (в сантиметрах): ");
            height = Program.check_input(0.0, 10000.0);

            Console.Write("Введите цену товара (в рублях): ");
            price = Program.check_input(0, 1000000000);

            Console.Write("Товар в наличии? (1 - да, 0 - нет): ");
            stock = Program.check_input(0, 1) == 1;

        }

        public virtual void Output()
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Нет добавленных книг.");
            }
            else
            {
                Console.WriteLine($"\nНазвание: {name}");
                Console.WriteLine($"Вес: {weight} кг");
                Console.WriteLine($"Ширина: {width} см");
                Console.WriteLine($"Высота: {height} см");
                Console.WriteLine($"Цена: {price} руб");
                Console.WriteLine($"В наличии: {(stock ? "Да" : "Нет")}");
            }
        }
    }
}
