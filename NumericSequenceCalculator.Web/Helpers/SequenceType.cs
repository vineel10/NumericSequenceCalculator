using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NumericSequenceCalculator.Web.Helpers
{
    public class SequenceType
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Func<long, List<double>> Calculate { get; set; }

        public long? ParentId { get; set; }

        public static readonly SequenceType AllNumbersSequenceType = new SequenceType
        {
            Description = "All numbers up to and including the number entered",
            Id = 1,
            Name = "All Numbers",
            Calculate = (number) =>
            {
                var result = new List<double>();
                for (long i = 1; i <= number; i++)
                    result.Add(i);
                return result;
            }
        };
        public static readonly SequenceType AllOddNumbersSequenceType = new SequenceType
        {
            Description = "All odd numbers up to and including the number entered",
            Id = 2,
            Name = "All Odd Numbers",
            Calculate = (number) =>
            {
                var result = new List<double>();
                for (double i = 1; i <= number; i++)
                    if(!(i % 2).Equals(0.0d))
                        result.Add(i);
                return result;
            }
        };
        public static readonly SequenceType AllEvenNumbersSequenceType = new SequenceType
        {
            Description = "All even numbers up to and including the number entered",
            Id = 3,
            Name = "All Even Numbers",
            Calculate = (number) =>
            {
                var result = new List<double>();
                for (double i = 1; i <= number; i++)
                    if ((i % 2).Equals(0.0d))
                        result.Add(i);
                return result;
            }
        };
        public static readonly SequenceType Multiples3SequenceType = new SequenceType
        {
            Description = "A number is a multiple of 3",
            Id = 6,
            Name = "Multiples of 3",
            ParentId = 4,
            Calculate = (number) =>
            {
                var result = new List<double>();
                for (double i = 1; i <= number; i++)
                    if ((i % 3).Equals(0.0d))
                        result.Add(i);
                return result;
            }
        };
        public static readonly SequenceType Multiples5SequenceType = new SequenceType
        {
            Description = "A number is a multiple of 5",
            Id = 7,
            Name = "Multiples of 5",
            ParentId = 4,
            Calculate = (number) =>
            {
                var result = new List<double>();
                for (double i = 1; i <= number; i++)
                    if ((i % 5).Equals(0.0d))
                        result.Add(i);
                return result;
            }
        };
        public static readonly SequenceType Multiples3And5NumbersSequenceType = new SequenceType
        {
            Description = "A number is a multiple of 3 & 5",
            Id = 8,
            Name = "Multiples of 3 & 5",
            ParentId = 4,
            Calculate = (number) =>
            {
                var result = new List<double>();
                for (double i = 1; i <= number; i++)
                    if ((i % 15).Equals(0.0d))
                        result.Add(i);
                return result;
            }
        };
        public static readonly SequenceType ComplexSequenceType = new SequenceType
        {
            Description = "All numbers up to and including the number entered, except when </br>\t A number is a multiple of 3 output C, and when </br> \t A number is a multiple of 5 output E, and when </br> \t A number is a multiple of both 3 and 5 output Z",
            Id = 4,
            Name = "All Numbers Except Multiples of 3, 5 and (3 and 5)",
            Calculate = (number) =>
            {
                var result = new List<double>();
                var multiplesOf3 = Multiples3SequenceType.Calculate(number);
                var multiplesOf5 = Multiples5SequenceType.Calculate(number);
                var multiplesOf3And5 = Multiples3And5NumbersSequenceType.Calculate(number);
                for (double i = 1; i <= number; i++)
                {
                    if(!multiplesOf3.Any(a=>a == i) && !multiplesOf5.Any(a => a == i) && !multiplesOf3And5.Any(a => a == i))
                        result.Add(i);
                }
                    return result;
            }
        };
        public static readonly SequenceType FibonacciNumbersSequenceType = new SequenceType
        {
            Description = "All fibonacci number up to and including the number entered",
            Id = 5,
            Name = "Fibonacci Sequence",
            Calculate = (number) =>
                {                    
                    double a = 1, b = 1;
                    var result = new List<double> { a };
                    for (double c = 0; c <= number;)
                    {
                        c = a + b;
                        a = b;
                        b = c;
                        if(c <= number)
                            result.Add(c);
                        else
                            break;
                    }
                    return result;
                }

        };

        public static IReadOnlyCollection<SequenceType> All = new List<SequenceType>
        {
            AllNumbersSequenceType,
            AllOddNumbersSequenceType,
            AllEvenNumbersSequenceType,
            FibonacciNumbersSequenceType,
            Multiples3And5NumbersSequenceType,
            Multiples3SequenceType,
            Multiples5SequenceType,
            ComplexSequenceType
        }.AsReadOnly();

        public static SequenceType GetSequenceType(long id)
        {
            return All.FirstOrDefault(a => a.Id == id);
        }
    }
}