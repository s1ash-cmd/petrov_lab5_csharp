using petrov_lab5_c_;
using System.Xml.Serialization;

namespace petrov_lab5_c_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Shop shop = new Shop();
            for (; ; )
            {
                Shop.display_menu();
                int menuItem = check_input(0, 6);

                switch (menuItem)
                {
                    case 1:
                        shop.add_item();
                        break;
                    case 2:
                        shop.add_used_item();
                        break;
                    case 3:
                        shop.items_output();
                        break;
                    case 4:
                        shop.items_write();
                        break;
                    case 5:
                        shop.items_read();
                        break;
                    case 6:
                        shop.items_clear();
                        break;
                    case 0: return;
                }

            }
        }

        public static T check_input<T>(T min, T max) where T : IComparable<T>
        {
            T input;
            while (true)
            {
                try
                {

                    input = (T)Convert.ChangeType(Console.ReadLine(), typeof(T));


                    if (input.CompareTo(min) >= 0 && input.CompareTo(max) <= 0)
                    {
                        return input;
                    }
                    else
                    {
                        Console.Write($"\nВведите корректное значение ({min} до {max}): ");
                    }
                }
                catch
                {
                    Console.Write($"\nВведите число от ({min} до {max}): ");
                }
            }
        }
    }
}