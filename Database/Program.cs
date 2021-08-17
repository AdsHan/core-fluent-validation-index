using Database.Data;
using Database.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Database
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new Context();

            PopulateDB(db);
            FindRegister(db);
        }

        static void PopulateDB(Context db)
        {
            if (!db.Schools.Any())
            {
                var schools = Enumerable.Range(1, 1_000_000).Select(s => new SchoolModel()
                {
                    Id = new Guid(),
                    Name = $"{ (s % 3 == 0 ? "Alpha School" : "Beta School")} - {s}"

                }).ToArray();

                db.Schools.AddRange(schools);
                db.SaveChanges();
            };
        }

        static void FindRegister(Context db)
        {
            var time = System.Diagnostics.Stopwatch.StartNew();

            var number = new Random().Next(700000, 1000000);
            var content = $"{ (number % 3 == 0 ? "Alpha School" : "Beta School")} - {number}";
            var schools = db.Schools.Where(s => EF.Functions.Like(s.Name, content)).ToList();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Out.WriteLine($"Tempo: {time.Elapsed.ToString(@"mm\:ss\.fff")}");
            Console.ForegroundColor = ConsoleColor.White;

        }
    }
}
