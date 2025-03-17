// See https://aka.ms/new-console-template for more information

using Birthday;
using System;
using System.Collections.Generic;

// This jawn will run a console app
// it will first ask the user if they would like to see all names and birthdays, or add a name and a birthday.
// further implementation will add option to calculate how many days until a provided name's birthday

BirthdayCalculator application = new BirthdayCalculator();
application.Run();

namespace Birthday
{
    public class Person
    {
        public string _name { get; set; }
        public string _birthday { get; set; }
        //public int ID { get; set; }
        public Person(string name, string birthday)
        {
            _name = name;
            _birthday = birthday;
        }
    }
    
    public class BirthdayCalculator
    {

        //private HashSet<Person> _people { get; set; } = new HashSet<Person>();
        private static Dictionary<int, Person> _people = new Dictionary<int, Person>()
        {
            { 0, new Person ("Farty", "11/11/1111") },
            { 1, new Person ("Stevie", "12/23/1921") },
            { 2, new Person ("Constance", "03/12/1994") },
            { 3, new Person ("Timmy", "01/12/1943") },
            { 4, new Person ("Maltha", "11/11/1111") },
        };

        int nextId = _people.Count + 1;

        public void TakeInNames()
        {
            Console.WriteLine("Enter name: ");
            string personName = Console.ReadLine();
            Console.WriteLine("Enter their birthday in the format: mm/dd/yyyy");
            string birthday = Console.ReadLine();
            //_people.Add(new Person(personName, birthday));
            //_people[personName] = birthday;
            _people.Add(nextId, new Person(personName, birthday));
            nextId = nextId += 1;
        }

        public void ReadNames()
        {

             string result = "";
             foreach (var person in _people)
             {
                 result += $"{person.Value._name} <==> {person.Value._birthday}\n";
                //Console.WriteLine($"{Person._name} , {Person._birthday}\n");
            }
            Console.WriteLine(result);
            Console.WriteLine("When you're done just hit ENTER to go back to the main menu.");
            Console.ReadLine();
        }

        public Person FindPersonByName(string name)
        {
            //Person personToDelete = _people.FirstOrDefault(person => person._name == name);
            //Person personToDelete = _people[name];
            Person personToDelete = _people.Values.FirstOrDefault(p => p._name == name);
            return personToDelete;
        }

        public void RemovePerson()
        {
            // ask for persons name
            Console.WriteLine("Who would you like to remove? Enter their first name");
            string firstName = Console.ReadLine();
            // find person
            Person personToDelete = FindPersonByName(firstName);
            // delete person from hashset
            //_people.Remove(personToDelete);
            _people.Values.FirstOrDefault(Person => Person == personToDelete);
            Console.WriteLine($"Person: {personToDelete._name} with birthday {personToDelete._birthday} has been deleted");
            Console.WriteLine("When you're done just hit ENTER to go back to the main menu.");
            Console.ReadLine();
        }


        public void DisplayPeople()
        {
            // this will clear the console, get all the People objects, display on each line, and when the user navigates the names with arrow keys then the name selected will have a highlighted color, and when enter is clicked that person will be deleted from the records

            List<Person> peopleList = _people.Values.ToList();


            int selectedIndex = 0;
            ConsoleKeyInfo keyPressInfo;

            do
            {
                Console.Clear();
                for (int i = 0; i < _people.Count; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    }
                    Console.WriteLine($"{peopleList[i]._name} <==> {peopleList[i]._birthday}");
                    Console.ResetColor();
                }

                keyPressInfo = Console.ReadKey();

                if (keyPressInfo.Key == ConsoleKey.DownArrow)
                {
                    selectedIndex = (selectedIndex == peopleList.Count - 1) ? 0 : selectedIndex + 1;
                } else if(keyPressInfo.Key == ConsoleKey.UpArrow)
                {
                    selectedIndex = (selectedIndex == 0) ? selectedIndex = peopleList.Count - 1 : selectedIndex -= 1;
                } else if(keyPressInfo.Key == ConsoleKey.Enter)
                {
                    var personToDeleteName = _people.FirstOrDefault(p => p.Value._name == peopleList[selectedIndex]._name);
                    _people.Remove(personToDeleteName.Key);
                }
                //var selectedPerson = _people.ElementAt(selectedIndex);
                // can use index to find and delete person since people have a key of their ID ----- that wont work because as the list is pruned the indexes for remaining people won't match up to the ID of the people in the shared _people list. Instead, take their name and do a LINQ lookup to rm them
                //_people.Remove(selectedIndex);
            } while (keyPressInfo.Key != ConsoleKey.Enter);

                Console.ReadLine();
        }



        public static bool _displayMenu = true;
        public void Run()
        {
            //bool displayMenu = true;
            while (_displayMenu == true)
            {
                _displayMenu = MainMenu();
            }
        }


        private bool MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Choose and Option:");
            Console.WriteLine("1) Add Person and their Birthday");
            Console.WriteLine("2) Read Name(s)");
            Console.WriteLine("3) Remove Person");
            Console.WriteLine("69) Quit");
            string task = Console.ReadLine();

            if (task == "1")
            {
                TakeInNames();
            } else if(task == "2")
            {
                ReadNames();
            } else if(task == "3")
            {
                DisplayPeople();
                //RemovePerson();
            } else if(task == "69")
            {
                //return false;
                return _displayMenu = false;
            }
            else
            {
                MainMenu();
            }
            return true;
        }

    } // End of Sorting Names



}





