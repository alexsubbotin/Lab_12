using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Subb_Lab12
{
    class Task2
    {
        public static void Demonstrate()
        {
            // Republic class.
            //Republic republicCongo = new Republic("The Republic of the Congo", "Denis Sassou Nguesso", 5125821, 58, "Africa", 7, 72, 6);
            Republic republicCzech = new Republic("The Czech Republic", "Milos Zeman", 10610947, 25, "Europe", 10, 200, 4);
            Republic republicTurkey = new Republic("The Republic of Turkey", "Recep Tayyip Erdogan", 80810525, 95, "Asia", 5, 550, 4);
            Republic republicArgentina = new Republic("The Argentine Republic", "Mauricio Macri", 43847430, 102, "America", 4, 329, 2);
            Republic republicNauru = new Republic("The Republic of Nauru", "Baron Waqa", 10084, 50, "Oceania", 3, 19, 3);

            // Monarchy class.
            //Monarchy monarchyBelgium = new Monarchy("Belgium", "Philippe", 11358357, 189, "Europe", "The House of Saxe-Coburg and Gotha");
            Monarchy monarchyAustralia = new Monarchy("Australia", "Elizabeth II", 24067700, 117, "Oceania", "House of Windsor");
            Monarchy monarchyJamaica = new Monarchy("Jamaica", "Elizabeth II", 43847430, 56, "America", "House of Windsor");

            // Kingdom class.
            //Kingdom kingdomSaudiArabia = new Kingdom("The Kingdom of Saudi Arabia", "Salman", 33000000, 87, "Asia", "The Sudairi Seven");
            Kingdom kingdomMarocco = new Kingdom("The Kingdom of Morocco", "Mohammed VI", 33848242, 62, "Africa", "The Alaouite dynasty");

            // Creating a stack.
            Stack<AbstrState> stack = new Stack<AbstrState>();

            // Adding elements to the stack.
            stack.Push(republicCzech);
            stack.Push(republicTurkey);
            stack.Push(republicArgentina);
            stack.Push(republicNauru);

            stack.Push(monarchyAustralia);
            stack.Push(monarchyJamaica);

            stack.Push(kingdomMarocco);

            int choice = -1;
            do
            {
                Console.Clear();
                // Showing the created arraylist.
                Console.WriteLine("CURRENT STACK:");
                foreach (AbstrState state in stack)
                    state.Show();

                Console.WriteLine(@"Choose one of the options:
1. Add element.
2. Delete element.
3. Show the number of republics.
4. Show all the monarchy states.
5. Show all the African states.
6. Clone the stack.
7. Sort the stack.
8. Search element.
9. Back.");

                // Getting the number of the chosen option.
                choice = Program.ChoiceInput(9);

                switch (choice)
                {
                    case 1:
                        AddElem(ref stack);
                        break;
                    case 2:
                        DelElem(ref stack);
                        break;
                    case 3:
                        NumOfRep(stack);
                        break;
                    case 4:
                        ShowMonSt(stack);
                        break;
                    case 5:
                        ShowAfrSt(stack);
                        break;
                    case 6:
                        CloneStack(stack);
                        break;
                    case 7:
                        SortStack(ref stack);
                        break;
                    case 8:
                        BinarySearchStack(stack);
                        break;
                }
            } while (choice != 9);

        }

        // Function to add element to the stack.
        public static void AddElem(ref Stack<AbstrState> stack)
        {
            Console.Clear();

            // Objects that will be added.
            Republic republicCongo = new Republic("The Republic of the Congo", "Denis Sassou Nguesso", 5125821, 58, "Africa", 7, 72, 6);
            Monarchy monarchyBelgium = new Monarchy("Belgium", "Philippe", 11358357, 189, "Europe", "The House of Saxe-Coburg and Gotha");
            Kingdom kingdomSaudiArabia = new Kingdom("The Kingdom of Saudi Arabia", "Salman", 33000000, 87, "Asia", "The Sudairi Seven");

            Console.Clear();

            Console.WriteLine(@"Choose the class of the adding object
1. Republic.
2. Monarchy.
3. Kingdom.
4. Back.");
            // Getting the class of the adding object.
            int choice = Program.ChoiceInput(4);

            switch (choice)
            {
                case 1:
                    stack.Push(republicCongo);
                    Console.WriteLine("The Republic of the Congo has been successfully added to the stack!\nPress ENTER to go back.");
                    Console.ReadLine();
                    break;
                case 2:
                    stack.Push(monarchyBelgium);
                    Console.WriteLine("Belgium has been successfully added to the stack!\nPress ENTER to go back.");
                    Console.ReadLine();
                    break;
                case 3:
                    stack.Push(kingdomSaudiArabia);
                    Console.WriteLine("The Kingdom of Saudi Arabia has been successfully added to the stack!\nPress ENTER to go back.");
                    Console.ReadLine();
                    break;
                case 4:
                    break;
            }
        }

        // Function to delete an element.
        public static void DelElem(ref Stack<AbstrState> stack)
        {
            Console.Clear();

            if (stack.Count != 0)
            {
                stack.Pop();
                Console.WriteLine("The last element has been successfully deleted from the stack!\nPress ENTER to continue");
            }
            else
            {
                Console.WriteLine("The stack is empty!\nPress ENTER to continue");
            }
            Console.ReadLine();
        }

        // Function to show the number of republics.
        public static void NumOfRep(Stack<AbstrState> stack)
        {
            int count = 0;

            foreach (AbstrState state in stack)
                if (state is Republic)
                    count++;

            Console.WriteLine("The number of republics in the stack is {0}\nPress ENTER to continue", count);
            Console.ReadLine();
        }

        // Function to show all the monarchy states.
        public static void ShowMonSt(Stack<AbstrState> stack)
        {
            Console.Clear();

            Console.WriteLine("THE LIST OF MONARCHY STATES:");
            foreach (AbstrState state in stack)
                if (state is Monarchy)
                    state.Show();

            Console.WriteLine("Press ENTER to go back");
            Console.ReadLine();
        }

        // Function to show all the African states.
        public static void ShowAfrSt(Stack<AbstrState> stack)
        {
            Console.Clear();

            Console.WriteLine("THE LIST OF AFRICAN STATES:");
            foreach (AbstrState state in stack)
            {
                if (state.Continent == "Africa")
                    state.Show();
            }

            Console.WriteLine("Press ENTER to go back");
            Console.ReadLine();
        }

        // Function to clone the stack.
        public static void CloneStack(Stack<AbstrState> stack)
        {
            Console.Clear();

            Stack<AbstrState> clone = stack;

            Console.WriteLine("STACK CLONE:");
            foreach (AbstrState state in clone)
            {
                state.Show();
            }

            Console.WriteLine("Press ENTER to go back");
            Console.ReadLine();
        }

        // Function to sort the stack.
        public static void SortStack(ref Stack<AbstrState> stack)
        {
            Console.Clear();

            Console.WriteLine(@"Choose the kind of sorting:
1. By name.
2. By leader's name.
3. By population.
4. By age.");

            int choice = Program.ChoiceInput(4);

            switch (choice)
            {
                // Using special classes to compare by different fields.

                case 1:
                    AbstrState[] buf = stack.ToArray();
                    Array.Sort(buf, new CompareName());
                    // You need to reverse array because othewise elements wiil be in the wrong order in the stack.
                    Array.Reverse(buf);
                    stack.Clear();
                    foreach (AbstrState state in buf)
                        stack.Push(state);
                    break;
                case 2:
                    buf = stack.ToArray();
                    Array.Sort(buf, new CompareLeaderName());
                    // You need to reverse array because othewise elements wiil be in the wrong order in the stack.
                    Array.Reverse(buf);
                    stack.Clear();
                    foreach (AbstrState state in buf)
                        stack.Push(state);
                    break;
                case 3:
                    buf = stack.ToArray();
                    Array.Sort(buf, new ComparePopulation());
                    // You need to reverse array because othewise elements wiil be in the wrong order in the stack.
                    Array.Reverse(buf);
                    stack.Clear();
                    foreach (AbstrState state in buf)
                        stack.Push(state);
                    break;
                case 4:
                    buf = stack.ToArray();
                    Array.Sort(buf, new CompareAge());
                    // You need to reverse array because othewise elements wiil be in the wrong order in the stack.
                    Array.Reverse(buf);
                    stack.Clear();
                    foreach (AbstrState state in buf)
                        stack.Push(state);
                    break;
            }

            Console.WriteLine("Array list has be successfully sorted!\nPress ENTER to go back and see.");
            Console.ReadLine();
        }

        // Functio to search element.
        public static void BinarySearchStack(Stack<AbstrState> stack)
        {
            Console.Clear();

            Console.WriteLine(@"By what field you want to search:
1. Name.
2. Leader's name.
3. Population.
4. Age.");

            int choice = Program.ChoiceInput(4);
            int index = -1;
            AbstrState[] buf = null;
            switch (choice)
            {
                // Using special classes to compare by different fields.

                // Search by name.
                case 1:
                    Console.Write("Enter the name: ");
                    string name = Console.ReadLine();
                    // Buffer variable to compare with.
                    Monarchy buffer = new Monarchy(name, "", 0, 0, "", "");
                    buf = stack.ToArray();
                    index = Array.BinarySearch(buf, buffer, new CompareName());
                    break;

                // Search by leader's name.
                case 2:
                    Console.Write("Enter the leader's name: ");
                    string leaderName = Console.ReadLine();
                    buffer = new Monarchy("", leaderName, 0, 0, "", "");
                    buf = stack.ToArray();
                    index = Array.BinarySearch(buf, buffer, new CompareLeaderName());
                    break;

                // Search by population.
                case 3:
                    int population = Task1.InputPopulation();
                    buffer = new Monarchy("", "", population, 0, "", "");
                    buf = stack.ToArray();
                    index = Array.BinarySearch(buf, buffer, new ComparePopulation());
                    break;

                // Search by age.
                case 4:
                    int age = Task1.InputAge();
                    buffer = new Monarchy("", "", 0, age, "", "");
                    buf = stack.ToArray();
                    index = Array.BinarySearch(buf, buffer, new CompareAge());
                    break;
            }

            Console.WriteLine();

            if (index < 0)
                Console.WriteLine("The element doesn't exist in the arraylist\nPerhaps you didn't sort the stack before the search.");
            else
            {
                Console.WriteLine("The index of the element is {0}", index);
                (buf[index] as AbstrState).Show();
            }

            Console.WriteLine("Press ENTER to go back");
            Console.ReadLine();
        }
            
    }
}
