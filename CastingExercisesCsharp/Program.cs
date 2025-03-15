// casting exercises
using static System.Formats.Asn1.AsnWriter;
using System.Reflection.Metadata;
using Animals;
using System.Threading.Channels;
using System.Runtime.CompilerServices;

//Basic Casting Problems

//Implicit vs. Explicit Casting
//Write a program that demonstrates the difference between implicit and explicit casting using int, double, and decimal types.
//Numeric Type Conversions
//Create variables of different numeric types (byte, short, int, long, float, double, decimal) and practice converting between them. Comment on which conversions require explicit casting and which ones happen implicitly.
//Character to Number
//Write code that converts char values to their numeric ASCII/Unicode values and vice versa.

//Intermediate Casting Problems

//Object Casting with is/as Operators
//Create a base class and derived class. Store instances in variables of the base class type, then use the 'is' operator to check types and the 'as' operator to perform safe casts.
//Boxing and Unboxing
//Write a program that demonstrates boxing (converting a value type to an object) and unboxing (converting an object back to a value type). Track and display performance differences.
//Parse vs. Cast
//Create a program that compares parsing strings to numbers using int.Parse() and Convert.ToInt32() versus casting. Handle potential exceptions.





// Implicit casting is converting smaller type to larger type
//int number = 14;
//double doubleNumber = number;
//Console.WriteLine($"Number: {number}");
//Console.WriteLine($"DoubleNumber: {doubleNumber}");

// Explicit casting then is converting a larger value to a smaller one, likely losing some of the information in the process:
//double doubleNum = 14.141414;
//int num = (int)doubleNum;
//Console.WriteLine($"DoubleNum: {doubleNum}");
//Console.WriteLine($"num: {num}");

// Converting chars to their ASCII values and vice-versa
//char letter = 'a';
//int castLetter = (int)letter;
//Console.WriteLine($"letter: {letter}");
//Console.WriteLine($"castLetter: {castLetter}");
//char newLetter = (char)(letter + 10);
//int newLetterInt = (int)newLetter;
//Console.WriteLine($"newLetter: {newLetter}");
//Console.WriteLine($"newLetterInt: {newLetterInt}");
//Console.ReadLine();




//Object Casting with is/as Operators
//Create a base class and derived class. Store instances in variables of the base class type, then use the 'is' operator to check types and the 'as' operator to perform safe casts.

Dog doggie = new Dog();
Dog newDoggie = new Dog();
Animal tiger = new Tiger();

Console.WriteLine($"OG doggie type: {doggie}");
Console.WriteLine($"OG doggie: {doggie._Name}");
Console.WriteLine("==============");
Console.WriteLine("Now make a new doggie with a name");
Console.WriteLine($"new doggie: {newDoggie._Name}");
Console.WriteLine("==============");
Console.WriteLine($"new Tiger: {tiger._Name}");
Console.WriteLine($"new Tiger is pet? ===> {tiger.IsPet}");


namespace Animals
{
    public class Animal
    {
        public virtual string _Name { get; set; } = "DefaultName";
        public virtual bool IsPet { get; set; } = true; // default value set to true

        public Animal(string? name = "Default NAMMMEEE")
        {
            _Name = name;
        }
    }
    public class Dog : Animal
    {
        //public required override string Name {get; set;} = "Carlton";
        public Dog(string? name = "Default Dogg Name")
        {
            Console.WriteLine("Provide a name for doggo:");
            string? input = Console.ReadLine();

            if(input.Length > 1)
            {
                _Name = input;
            }
        }
    }

    public class Cat : Animal
    {
        public Cat(string? name = "Default Cat Name") : base(name)
        {
            Console.WriteLine("What's the cat's name?");
            _Name = Console.ReadLine();
        }
    }

    public class Tiger : Animal
    {
        public override bool IsPet { get; set; } = false;
        public Tiger(string? name = "Default Tiger Name") : base(name)
        {
            Console.WriteLine("What is the name of this Tiger?");
            _Name = Console.ReadLine();
        }
    }
}



