using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace petrov_lab5_c_
{
    [Serializable]
    [XmlType(TypeName = "Used_item")]
    public class Used_item : Item
    {
        public int age { get; set; } = 0;
        public double condition { get; set; } = 0.0;
        public string description { get; set; } = "";

        public Used_item() { }

        public override void Input()
        {
            base.Input();

            Console.Write("Введите возраст товара (в годах): ");
            age = Program.check_input(0, 10000);

            Console.Write("Введите состояние товара (0.0 - 10.0): ");
            condition = Program.check_input(0.0, 10.0);

            Console.Write("Введите описание товара: ");
            description = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(name))
            {
                Console.Write("Описание товара не может быть пустым. Попробуйте еще раз: ");
                description = Console.ReadLine();
            }
        }
        public override void Output()
        {
            base.Output();
            Console.WriteLine($"Возраст: {age} год(а)/лет");
            Console.WriteLine($"Состояние: {condition} из 10");
            Console.WriteLine($"Описание: {description}");
        }
    }
}
