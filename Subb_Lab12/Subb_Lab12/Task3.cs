using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subb_Lab12
{
    class Task3
    {
        public static void Demonstrate()
        {
            Console.Clear();
            //Console.Write((int)'A' + " " + (int)'Z' + " " + (int)'a' + " " + (int)'z');

            // Getting the capacity from the user.
            int capacity = CapacityInput();

            // Creating a dictionary with the set capacity.
            MyDictionary<int, AbstrState> myDictionary = new MyDictionary<int, AbstrState>(capacity);
            Console.WriteLine("An empty dictionary with the capacity of {0} has been successfully created!\n", capacity);

            int choice;
            do
            {
                //Console.Clear();
                Console.WriteLine(@"Choose one of the options:
1. Fill the dictionary with random elements.
2. Show the dictionary.
3. Check if there is an element with the wanted key.
4. Check if there is an element with the wanted value.
5. Add an element.
6. Clear the dictionary.
7. Clone the dictionary.
8. Remove an element with the wanted value.
9. Back.");

                choice = Program.ChoiceInput(9);

                switch (choice)
                {
                    case 1:
                        FillDic(ref myDictionary);
                        break;
                    case 2:
                        ShowDic(myDictionary);
                        break;
                    case 3:
                        CheckKey(myDictionary);
                        break;
                    case 4:
                        CheckValue(myDictionary);
                        break;
                    case 5:
                        AddElem(ref myDictionary);
                        break;
                    case 6:
                        ClearDic(ref myDictionary);
                        break;
                    case 7:
                        CloneDic(myDictionary);
                        break;
                    case 8:
                        RemoveFromDic(ref myDictionary);
                        break;
                }

                Console.Clear();
            } while (choice != 9);
        }

        // Function for capacity input.
        public static int CapacityInput()
        {
            bool ok;
            int capacity;
            do
            {
                Console.Write("Enter the dictionary's capacity (the number of elements in the hash-table actually): ");
                ok = Int32.TryParse(Console.ReadLine(), out capacity);
                if (!ok || capacity < 1)
                    Console.WriteLine("Input error! Perhaps you didn't enter a natural number");
            } while (!ok || capacity < 1);

            return capacity;
        }

        // Function for count input.
        public static int CountInput()
        {
            bool ok;
            int count;
            do
            {
                Console.Write("Enter the dictionary's count: ");
                ok = Int32.TryParse(Console.ReadLine(), out count);
                if (!ok || count < 1)
                    Console.WriteLine("Input error! Perhaps you didn't enter a natural number");
            } while (!ok || count < 1);

            return count;
        }

        // Function to fill the dictionary.
        public static void FillDic(ref MyDictionary<int, AbstrState> myDictionary)
        {
            // Getting the count.
            int count = CountInput();

            for (int i = 0; i < count; i++)
            {
                AbstrState random = RandomState();

                // The key is a state's name length.
                myDictionary.Add(random.Name.Length, random);
            }

            Console.WriteLine("The dictionary has been successfully filled with random values!\nPress ENTER to continue");
            Console.ReadLine();
        }

        // Function to generate a random state object.
        public static Random rnd = new Random();
        public static AbstrState RandomState()
        {
            Monarchy monarchy = new Monarchy();

            // Creating the element.
            for (int i = 0; i < rnd.Next(4, 20); i++)
            {
                monarchy.Name += (char)rnd.Next(65, 91);
                monarchy.LeaderName += (char)rnd.Next(97, 123);
                monarchy.Age += rnd.Next(0, 150);
                monarchy.Population += rnd.Next(0, 1000);
                monarchy.Continent += (char)rnd.Next(97, 123);
                monarchy.CurrentRullingClanName += (char)rnd.Next(65, 91);
            }

            return monarchy;
        }

        // Function to show the dictionary.
        public static void ShowDic(MyDictionary<int, AbstrState> myDictionary)
        {
            Console.Clear();

            if (myDictionary.Count != 0)
            {
                for (int i = 0; i < myDictionary.Capacity; i++)
                {
                    Console.WriteLine("INDEX: {0}", i);

                    if (myDictionary.Table[i].value != null)
                    {
                        DicPoint<int, AbstrState> curr = myDictionary.Table[i];
                        curr.value.Show();

                        while (curr.next != null)
                        {
                            curr.next.value.Show();
                            curr = curr.next;
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("The dictionary is empty");
            }

            Console.WriteLine("Press ENTER to continue");
            Console.ReadLine();
        }

        // Function to check a key.
        public static void CheckKey(MyDictionary<int, AbstrState> myDictionary)
        {
            Console.Clear();

            bool ok;
            int key;
            do
            {
                Console.Write("Enter the key: ");
                ok = Int32.TryParse(Console.ReadLine(), out key);
                if (!ok)
                    Console.WriteLine("Input error! Perhaps you didn't enter a number");
            } while (!ok);

            ok = myDictionary.ContainsKey(key);

            if (ok)
                Console.WriteLine("There is an element with this key!");
            else
                Console.WriteLine("There is no element with this key");

            Console.WriteLine("Press ENTER to continue");
            Console.ReadLine();
        }

        // Function to check a value.
        public static void CheckValue(MyDictionary<int, AbstrState> myDictionary)
        {
            Console.Clear();

            // Enter the value.
            AbstrState abstrState = ObjectInput();

            bool ok = myDictionary.ContainsValue(abstrState);

            if (ok)
                Console.WriteLine("There is an element with this value!");
            else
                Console.WriteLine("There is no element with this value");

            Console.WriteLine("Press ENTER to continue");
            Console.ReadLine();
        }

        // Function to input a monarchy object.
        public static AbstrState ObjectInput()
        {
            Monarchy monarchy = new Monarchy();

            // Name input.
            Console.Write("Enter the name: ");
            monarchy.Name = Console.ReadLine();

            // Leader name input.
            Console.Write("Enter the leader's name: ");
            monarchy.LeaderName = Console.ReadLine();

            // Population input.
            bool ok;
            int buf;
            do
            {
                Console.Write("Enter the population: ");
                ok = Int32.TryParse(Console.ReadLine(), out buf);
                if (!ok || buf < 0)
                    Console.WriteLine("Input error! Perhaps you didn't enter a natural number");
            } while (!ok || buf < 0);

            // Age input.
            do
            {
                Console.Write("Enter the age: ");
                ok = Int32.TryParse(Console.ReadLine(), out buf);
                if (!ok || buf < 0)
                    Console.WriteLine("Input error! Perhaps you didn't enter a natural number");
            } while (!ok || buf < 0);

            // Continent input.
            monarchy.Continent = ContinentsInput();

            return monarchy;
        }

        // Continents input.
        public static string ContinentsInput()
        {
            string[] continents = { "Asia", "Africa", "America", "Oceania", "Europe" };

            Console.WriteLine();
            Console.WriteLine(@"Choose one of the continents:
1. Asia
2. Africa
3. America
4. Oceania
5. Europe");

            int choice = Program.ChoiceInput(5);

            Console.WriteLine();

            return continents[choice - 1];
        }

        // Function to add an element.
        public static void AddElem(ref MyDictionary<int, AbstrState> myDictionary)
        {
            AbstrState state = ObjectInput();

            myDictionary.Add(state.Name.Length, state);

            Console.WriteLine("The element is successfully added!\nPress ENTER to continue");
            Console.ReadLine();
        }

        // Function to clear the dictionary.
        public static void ClearDic(ref MyDictionary<int, AbstrState> myDictionary)
        {
            myDictionary.Clear();
            Console.WriteLine("The dictionary is clear now!\nPress ENTER to continue");
            Console.ReadLine();
        }

        // Function to clone the dictionary.
        public static void CloneDic(MyDictionary<int, AbstrState> myDictionary)
        {
            MyDictionary<int, AbstrState> shallowClone = myDictionary.Clone();

            Console.WriteLine("Shadow clone of the dictionary:");
            ShowDic(shallowClone);
        }

        // Function to remove an object.
        public static void RemoveFromDic(ref MyDictionary<int, AbstrState> myDictionary)
        {
            Console.Clear();

            AbstrState buf = ObjectInput();

            bool ok = myDictionary.Remove(buf);

            if (ok)

                Console.WriteLine("The element is removed!\nPress ENTER to continue");
            else
                Console.WriteLine("There is no element with this value\nPress ENTER to continue");

            Console.ReadLine();
        }
    }
}