using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            NumberReader numberReader = new();
            numberReader.NumberEnteredEvent += SortArray;

            while (true)
            {
                try
                {
                    numberReader.Read();
                }
                catch (FormatException)
                {
                    Console.WriteLine("Введено некорректное значение: необходимо ввести число");
                }
                catch (MyException)
                {
                    Console.WriteLine("Введено некорректное значение: необходимо ввести либо 1, либо 2");
                }
            }
            
        }

        static void SortArray (int number)
        {
            UsersData data = new();
            var arr = data.Data;
            
            switch (number)
            {
                case 1:
                    Console.WriteLine("Введено значение 1");
                    Console.WriteLine();
                    Array.Sort(arr);
                    Console.WriteLine("Отсортированный массив: \n");
                    foreach(var item in arr)
                    {
                        Console.WriteLine(item);
                    }

                    break;

                case 2:
                    Console.WriteLine("Введено значение 2");
                    Console.WriteLine();
                    Array.Sort(arr);
                    Array.Reverse(arr);
                    Console.WriteLine("Отсортированный массив: \n");
                    foreach (var item in arr)
                    {
                        Console.WriteLine(item);
                    }

                    break;
            }
        }
    }

    public class UsersData
    {
        public string[] Data { get; set; }
        public UsersData()
        {
            Data = new string[5]
            {
                    "Смирнов",
                    "Иванов",
                    "Кузнецов",
                    "Соколов",
                    "Попов"
            };
        }
    }

    class NumberReader
    {
        public delegate void NumberEnteredDelegate(int number);
        public event NumberEnteredDelegate NumberEnteredEvent;

        public void Read()
        {
            Console.WriteLine();
            Console.WriteLine("Необходимо ввести значение: либо 1, либо 2");
            Console.WriteLine("1 - сортировка от А до Я");
            Console.WriteLine("2 - сортировка от Я до А");

            int number = Convert.ToInt32(Console.ReadLine());

            if (number != 1 && number != 2)
            {
                throw new MyException();
            }

            NumberEntered(number);
        }

        protected virtual void NumberEntered(int number)
        {
            NumberEnteredEvent?.Invoke(number);
        }
    }

    public class MyException : Exception
    {
        public MyException()
        { }

        public MyException(string message) : base(message)
        { }
    }
}
