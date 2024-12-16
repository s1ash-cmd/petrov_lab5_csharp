using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static System.Reflection.Metadata.BlobBuilder;

namespace petrov_lab5_c_
{
    public class Shop
    {
        private List<Item> shop = new List<Item>();
        public static void display_menu()
        {
            Console.WriteLine("\n_____меню_____");
            Console.WriteLine("\n1) Добавить товар");
            Console.WriteLine("2) Добавить б/у товар");
            Console.WriteLine("3) Показать все товары");
            Console.WriteLine("4) Сохранить в файл");
            Console.WriteLine("5) Загрузить из файла");
            Console.WriteLine("6) Очистить список");
            Console.WriteLine("0) Выход");
            Console.WriteLine("===============================");
            Console.Write("\nВыберите пункт меню: ");
        }

        public void add_item()
        {
            var item = new Item();
            item.Input();
            shop.Add(item);
        }
        public void add_used_item()
        {
            var used_item = new Used_item();
            used_item.Input();
            shop.Add(used_item);
        }

        public void items_output()
        {
            if (!shop.Any())
            {
                Console.WriteLine("\nТовары отсутствуют");
                return;
            }

            foreach (var item in shop)
            {
                item.Output();
                Console.WriteLine();
            }
        }


        public void items_clear()
        {
            if (!shop.Any())
            {
                Console.WriteLine("\nТовары отсутствуют");
                return;
            }
            else
            {
                shop.Clear();
                Console.WriteLine("\nСписок очищен");
            }

        }
        public void items_write()
        {
            if (!shop.Any())
            {
                Console.WriteLine("\nТовары отсутствуют");
                return;
            }
            else
            {
                Console.Write("\nВведите название файла (без расширения) для сохранения: ");
                var filename = Console.ReadLine();

                var xs = new XmlSerializer(typeof(List<Item>), new[] { typeof(Item), typeof(Used_item) });

                using (Stream fs = new FileStream(filename + ".xml", FileMode.OpenOrCreate))
                {
                    xs.Serialize(fs, shop);
                }

                Console.WriteLine("\nДанные успешно сохранены.");
            }
        }

        public void items_read()
        {
            Console.Write("\nВведите название файла для загрузки: ");
            var filename = Console.ReadLine();

            if (File.Exists(filename + ".xml"))
            {
                try
                {
                    var xs = new XmlSerializer(typeof(List<Item>), new[] { typeof(Item), typeof(Used_item) });
                    using (Stream fs = new FileStream(filename + ".xml", FileMode.Open))
                    {
                        var deserializedItems = xs.Deserialize(fs) as List<Item>;
                        if (deserializedItems == null)
                        {
                            Console.WriteLine("\nОшибка загрузки данных: файл пуст или поврежден.");
                            return;
                        }
                        shop = deserializedItems;
                        Console.WriteLine("\nДанные успешно загружены.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка при загрузке данных: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Файл не найден.");
            }
        }
    }
}

