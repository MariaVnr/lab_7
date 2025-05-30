using System;
using System.Text;

namespace lab_7
{
    internal class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            DoublyLinkedList list = new DoublyLinkedList();
            list.AddLast(15);
            list.AddLast(30);
            list.AddLast(7);
            list.AddLast(22);
            list.AddLast(5);
            list.AddLast(40);

            string choice = "";

            do
            {
                Console.WriteLine("\nОберіть дію:");
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("Завдання з варіанту:");
                Console.WriteLine("1. Знайти перше входження елемента, кратного 5");
                Console.WriteLine("2. Знайти суму елементів на парних позиціях");
                Console.WriteLine("3. Отримати новий список з елементами, більшими за X");
                Console.WriteLine("4. Видалити елементи, більші за середнє значення");
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("Звичайні дії над списком:");
                Console.WriteLine("5. Додати елемент в кінець списку");
                Console.WriteLine("6. Вивести список");
                Console.WriteLine("7. Отримати елемент за індексом");
                Console.WriteLine("8. Перевірити, чи список порожній");
                Console.WriteLine("0. Вийти");
                Console.WriteLine("----------------------------------------");
                Console.Write("Ваш вибір: ");

                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        if (list.IsEmpty())
                        {
                            Console.WriteLine("Список порожній. Виконання операції неможливе.");
                        }
                        else
                        {
                            long firstMultiple = list.FindFirstMultipleOf5();
                            Console.WriteLine($"Перше входження елемента, кратного 5: {firstMultiple}");
                        }
                        break;
                    case "2":
                        if (list.IsEmpty())
                        {
                            Console.WriteLine("Список порожній. Виконання операції неможливе.");
                        }
                        else
                        {
                            long sumOfEvens = list.SumOfEvenPositionElements();
                            Console.WriteLine($"Сума елементів на парних позиціях: {sumOfEvens}");
                        }
                        break;
                    case "3":
                        if (list.IsEmpty())
                        {
                            Console.WriteLine("Список порожній. Виконання операції неможливе.");
                        }
                        else
                        {
                            Console.Write("Введіть число X для порівняння: ");
                            if (long.TryParse(Console.ReadLine(), out long valueGreater))
                            {
                                DoublyLinkedList greaterList = list.GetElementsGreaterThan(valueGreater);
                                Console.WriteLine($"Список елементів, більших за {valueGreater}:");
                                foreach (long item in greaterList)
                                {
                                    Console.Write($"{item} ");
                                }
                                Console.WriteLine();
                            }
                            else
                            {
                                Console.WriteLine("Некоректний ввід.");
                            }
                        }
                        break;
                    case "4":
                        if (list.IsEmpty())
                        {
                            Console.WriteLine("Список порожній. Виконання операції неможливе.");
                        }
                        else
                        {
                            list.RemoveElementsGreaterThanAverage();
                            Console.WriteLine("Елементи, більші за середнє, видалено.");
                        }
                        break;
                    case "5":
                        Console.Write("Введіть елемент для додавання: ");
                        if (long.TryParse(Console.ReadLine(), out long elementToAdd))
                        {
                            list.AddLast(elementToAdd);
                            Console.WriteLine($"{elementToAdd} додано до списку.");
                        }
                        else
                        {
                            Console.WriteLine("Некоректний ввід.");
                        }
                        break;
                    case "6":
                        Console.WriteLine("Вміст списку:");
                        foreach (long item in list)
                        {
                            Console.Write($"{item} ");
                        }
                        Console.WriteLine();
                        break;
                    case "7":
                        Console.Write("Введіть індекс для отримання елемента: ");
                        if (int.TryParse(Console.ReadLine(), out int indexToGet))
                        {
                            try
                            {
                                long element = list[indexToGet];
                                Console.WriteLine($"Елемент за індексом {indexToGet}: {element}");
                            }
                            catch (IndexOutOfRangeException ex)
                            {
                                Console.WriteLine($"Помилка: {ex.Message}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Некоректний ввід.");
                        }
                        break;
                    case "8":
                        Console.WriteLine($"Чи список порожній? {list.IsEmpty()}");
                        break;
                    case "0":
                        Console.WriteLine("Вихід з програми.");
                        break;
                    default:
                        Console.WriteLine("Некоректний вибір. Спробуйте ще раз.");
                        break;
                }
            } while (choice != "0");
        }
    }
}