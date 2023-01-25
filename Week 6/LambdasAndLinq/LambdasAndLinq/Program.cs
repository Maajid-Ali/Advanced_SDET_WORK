using System;
using System.Security.Cryptography.X509Certificates;

namespace LambdasAndLinq;

public class Program
{
    static void Main(string[] args)
    {
        //Language Intergrated Queries
        var nums  = new List<int> { 3, 4, 6, 2, 1, 8, 9, 4, 0, 5 };    

        var numsCount = nums.Count();

        /* int countEven = 0;
        foreach(int num in nums)
        {
            if (IsEven(num)) countEven++;
        }*/

        int countEven = nums.Count(IsEven);
      
        List<Person> people = new List<Person>
        {
            new Person { Name = "Cathy", Age = 40, City = "Ottawa"},
            new Person { Name = "Nish", Age = 55,City = "Birmingham"},
            new Person { Name = "Martin", Age = 20, City = "London"}
        };

        var countYoungPeople = people.Count(IsYoung);
        

        int countDEven = nums.Count (delegate (int num)
        {
            return num % 2 == 0;
        });

        //lambda expressions

        // given something return something
        int sumOfSquares = nums.Sum(x => x * x);

        int countLEven = nums.Count(n => n % 2 == 0);

        var peopleInLondonQuery = people.Where(p => p.City == "London").ToList();

        var peopleByAge = people.OrderBy(p => p.Age);
        foreach (var person in peopleByAge)
        {
            Console.WriteLine(person);
        }

        var namesOfThoseOver20 = people.Where (p => p.Age > 20).Select(p => p.Name).FirstOrDefault();
       string newString = ModifyString("Hello World", s => s.Replace(" ", "_").ToUpper());
    }

    private static void ModifyString(string v, Func<string, string> strModify)
    {
        return strModify(string);
    }

    public static int Square(int x)
    {
        return x * x;
    }
    private static bool IsEven(int num)
    {
        return num % 2 == 0; 
    }

    private static bool IsYoung(int num)
    {
        return p.Age < 30;
    } 

    public class Person
    {
        public string Name { get; set; }
        private int _age;
        public int Age { 
            get => _age;
            set => _age = value < 0 ? throw new ArgumentException() : value;

        }
        public string City { get; set; }

        public override string ToString()
        {
            return $"{Name} - {City} - {Age}";
        }
    }
}
