using System;
using System.IO;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Exception[] exceptions = new Exception[5];

            exceptions[0] = new FileNotFoundException("Файл не существует.");
            exceptions[1] = new DirectoryNotFoundException("Недопустимая часть пути к каталогу.");
            exceptions[2] = new DivideByZeroException("Знаменатель в операции деления равен нулю.");
            exceptions[3] = new DriveNotFoundException("Диск недоступен или не существует.");
            exceptions[4] = new MyException("Собственный тип исключения.");

            foreach (var item in exceptions)
            {
                try
                {
                    throw item;
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }

            Console.ReadKey();
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
