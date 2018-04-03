using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections; // Library for work with standart collections.

namespace Subb_Lab12
{
    class Task1
    {
        public static void Demostrate()
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

            // Creating new arraylist. 
            ArrayList arrayList = new ArrayList
            {
                //republicCongo,
                republicCzech,
                republicTurkey,
                republicArgentina,
                republicNauru,
                //monarchyBelgium,
                monarchyAustralia,
                monarchyJamaica,
                //kingdomSaudiArabia,
                kingdomMarocco,
            };

            int choice = -1 ;
            do
            {
                Console.Clear();
                // Showing the created arraylist.
                Console.WriteLine("CURRENT ARRAYLIST:");
                foreach (AbstrState state in arrayList)
                    state.Show();

                Console.WriteLine(@"Choose one of the options:
1. Add element.
2. Delete element.
3. Show the number of republics.
4. Show all the monarchy states.
5. Show all the African states.
6. Clone the arraylist.
7. Sort the arraylist.
8. Search element.
9. Back.");

                // Getting the number of the chosen option.
                choice = Program.ChoiceInput(9);

                switch (choice)
                {
                    case 1:
                        AddElem(ref arrayList);
                        break;
                    case 2:
                        DelElem(ref arrayList);
                        break;
                    case 3:
                        ShowNumOfRep(arrayList);
                        break;
                    case 4:
                        ShowMon(arrayList);
                        break;
                    case 5:
                        ShowAfrSt(arrayList);
                        break;
                    case 6:
                        CloneArrayList(arrayList);
                        break;
                    case 7:
                        SortArrayList(ref arrayList);
                        break;
                    case 8:
                        BinarySearchArrL(arrayList);
                        break;
                }
            } while (choice != 9);

            //Console.ReadLine();
        }

        // Function to add an element to the arraylist properly.
        public static void AddElem(ref ArrayList arrayList)
        {
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

            switch(choice)
            {
                case 1:
                    arrayList.Add(republicCongo);
                    Console.WriteLine("The Republic of the Congo has been successfully added to the arraylist!\nPress ENTER to go back.");
                    Console.ReadLine();
                    break;
                case 2:
                    arrayList.Add(monarchyBelgium);
                    Console.WriteLine("Belgium has been successfully added to the arraylist!\nPress ENTER to go back.");
                    Console.ReadLine();
                    break;
                case 3:
                    arrayList.Add(kingdomSaudiArabia);
                    Console.WriteLine("The Kingdom of Saudi Arabia has been successfully added to the arraylist!\nPress ENTER to go back.");
                    Console.ReadLine();
                    break;
                case 4:
                    break;
            }
        }

        // Function to delete an element from the arraylist properly.
        public static void DelElem(ref ArrayList arrayList)
        {
            Console.Clear();
            if (arrayList.Count != 0)
            {
                int index;
                bool ok;
                do
                {
                    Console.Write("Enter the index of the element you want to delete: ");
                    ok = Int32.TryParse(Console.ReadLine(), out index);
                    if (!ok || index < 0 || index > arrayList.Count - 1)
                        Console.WriteLine("Input error! You probably didn't enter a real index of the arraylist element");
                } while (!ok || index < 0 || index > arrayList.Count - 1);

                arrayList.RemoveAt(index);
                Console.WriteLine("The element with {0} index has been successfully removed from the arraylist!" +
                    "\nPress Enter to go back", index);
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("The arraylist is empty!\nPress ENTER to continue");
                Console.ReadLine();
            }
        }

        // Function to show the number of republics.
        public static void ShowNumOfRep(ArrayList arrayList)
        {
            int count = 0;

            foreach (AbstrState state in arrayList)
                if (state is Republic)
                    count++;

            Console.WriteLine("The number of republics in the arraylist is {0}\nPress ENTER to continue", count);
            Console.ReadLine();
        }

        // Function to show all the monarchy states.
        public static void ShowMon(ArrayList arrayList)
        {
            Console.Clear();

            Console.WriteLine("THE LIST OF MONARCHY STATES:");
            foreach(AbstrState state in arrayList)
            {
                if (state is Monarchy)
                    state.Show();
            }

            Console.WriteLine("Press ENTER to go back");
            Console.ReadLine();
        }

        // Function to show all the African states.
        public static void ShowAfrSt(ArrayList arrayList)
        {
            Console.Clear();

            Console.WriteLine("THE LIST OF AFRICAN STATES:");
            foreach(AbstrState state in arrayList)
            {
                if (state.Continent == "Africa")
                    state.Show();
            }

            Console.WriteLine("Press ENTER to go back");
            Console.ReadLine();
        }

        // Function to clone the arraylist.
        public static void CloneArrayList(ArrayList arrayList)
        {
            Console.Clear();

            ArrayList clone = (ArrayList)arrayList.Clone();

            Console.WriteLine("ARRAYLIST CLONE:");
            foreach(AbstrState state in clone)
            {
                state.Show();
            }

            Console.WriteLine("Press ENTER to go back");
            Console.ReadLine();
        }

        // Function to sort the arraylist.
        public static void SortArrayList(ref ArrayList arrayList)
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
                    arrayList.Sort(new CompareName());
                    break;
                case 2:
                    arrayList.Sort(new CompareLeaderName());
                    break;
                case 3:
                    arrayList.Sort(new ComparePopulation());
                    break;
                case 4:
                    arrayList.Sort(new CompareAge());
                    break;
            }

            Console.WriteLine("Array list has be successfully sorted!\nPress ENTER to go back and see.");
            Console.ReadLine();

        }

        // Function for binary search.
        public static void BinarySearchArrL(ArrayList arrayList)
        {
            Console.Clear();

            Console.WriteLine(@"By what field you want to search:
1. Name.
2. Leader's name.
3. Population.
4. Age.");

            int choice = Program.ChoiceInput(4);
            int index = -1;
            switch (choice)
            {
                // Using special classes to compare by different fields.

                // Search by name.
                case 1:
                    Console.Write("Enter the name: ");
                    string name = Console.ReadLine();
                    // Just a buffer variable to compare with.
                    Monarchy buffer = new Monarchy(name, "", 0, 0, "", "");
                    index = arrayList.BinarySearch(buffer, new CompareName());
                    break;

                // Search by leader's name.
                case 2:
                    Console.Write("Enter the leader's name: ");
                    string leaderName = Console.ReadLine();
                    buffer = new Monarchy("", leaderName, 0, 0, "", "");
                    index = arrayList.BinarySearch(buffer, new CompareLeaderName());
                    break;

                // Search by population.
                case 3:
                    int population = InputPopulation();
                    buffer = new Monarchy("", "", population, 0, "", "");
                    index = arrayList.BinarySearch(buffer, new ComparePopulation());
                    break;
                
                // Search by age.
                case 4:
                    int age = InputAge();
                    buffer = new Monarchy("", "", 0, age, "", "");
                    index = arrayList.BinarySearch(buffer, new CompareAge());
                    break;
            }

            Console.WriteLine();

            if (index < 0)
                Console.WriteLine("The element doesn't exist in the arraylist\nPerhaps you didn't sort the arraylist before the search.");
            else
            {
                Console.WriteLine("The index of the element is {0}", index);
                (arrayList[index] as AbstrState).Show();
            }

            Console.WriteLine("Press ENTER to go back");
            Console.ReadLine();
        }

        // Special function for binary search to get population.
        public static int InputPopulation()
        {
            bool ok;
            int pop;
            do
            {
                Console.Write("Enter the population: ");
                ok = Int32.TryParse(Console.ReadLine(), out pop);
                if (!ok || pop < 0)
                    Console.WriteLine("Input error! You probable didn't enter a natural number");
            } while (!ok || pop < 0);

            return pop;
        }

        // Special function for binary search to get age.
        public static int InputAge()
        {
            bool ok;
            int age;
            do
            {
                Console.Write("Enter the age: ");
                ok = Int32.TryParse(Console.ReadLine(), out age);
                if (!ok || age < 0)
                    Console.WriteLine("Input error! You probable didn't enter a natural number");
            } while (!ok || age < 0);

            return age;
        }
    }
}
