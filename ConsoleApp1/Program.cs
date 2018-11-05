using ConsoleApp1.Helper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Pet.json");

                IPetOwnerReader petOwnerReader = new JsonFileReader(filePath);

                var petOwners = petOwnerReader.GetPetOwners();

                var maleOwners = petOwners.Where(p => p.Gender == "Male").Select(p => p.Name).OrderBy(p => p);
                var femaleOwners = petOwners.Where(p => p.Gender == "Female").Select(p => p.Name).OrderBy(p => p);

                Console.WriteLine("Male");
                foreach (var ownerName in maleOwners)
                {
                    Console.Write("\t");
                    Console.WriteLine(ownerName);
                }

                Console.WriteLine("Female");
                foreach (var ownerName in femaleOwners)
                {
                    Console.Write("\t");
                    Console.WriteLine(ownerName);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred\r\n{ex}");
            }
            finally
            {
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
}
