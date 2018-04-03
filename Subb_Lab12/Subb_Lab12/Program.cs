using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Subb_Lab12
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice;
            do
            {
                Console.Clear();
                Console.WriteLine(@"Choose a task:
1. Task 1.
2. Task 2.
3. Task 3.
4. Exit.");
                choice = ChoiceInput(4);

                switch (choice)
                {
                    case 1:
                        Task1.Demostrate();
                        break;
                    case 2:
                        Task2.Demonstrate();
                        break;
                }
            } while (choice != 4);
        }

        // Choice input.
        public static int ChoiceInput(int size)
        {
            bool ok;
            int choice;
            do
            {
                Console.Write("Enter the number of the chosen option: ");
                ok = Int32.TryParse(Console.ReadLine(), out choice);
                if (!ok || choice < 1 || choice > size)
                    Console.WriteLine("Input error! Perhaps you didn't enter a number from 1 to {0}", size);
            } while (!ok || choice < 1 || choice > size);

            return choice;
        }
    }
}
