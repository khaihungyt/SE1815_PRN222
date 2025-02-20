using Open_Closed_Principle.Model;
using System;
using System.Collections.Generic;

class Program
{
    static List<Book> bookList;

    static void PrintBooks(List<Book> books)
    {
        Console.WriteLine("List of Books");
        foreach (var item in books)
        {
            Console.WriteLine($"{item.Title.PadRight(39, ' ')} {item.Author.PadRight(20, ' ')} {item.Price}");
        }
        Console.ReadLine();
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Please, press 'yes' to read an extra file, or any other key for a single file:");
        var ans = Console.ReadLine();

        bookList = (ans.ToLower() == "yes") ? Utilities.ReadDataExtra() : Utilities.ReadData();

        PrintBooks(bookList);
    }
}