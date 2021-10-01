using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp_FileIO
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("File IO\n");

            string filename = "MyFile.txt";
            string next_file = "MyFile2.txt";
            string currentDir = Environment.CurrentDirectory;

            // Write to file
            File.WriteAllText("MyFile.txt", "BMW;750L" + Environment.NewLine);
            File.AppendAllText("MyFile.txt", "Yugo;205 SS" + Environment.NewLine);


            // Read from file
            string read = File.ReadAllText(filename);
            List<string> fileData = File.ReadAllLines(filename).ToList();


            // Create file [with StreamWriter] and write text
            using (StreamWriter sw = File.CreateText(next_file))
            {
                sw.WriteLine("VW;Polo");
                sw.WriteLine("Volvo;S60");
            }

            List<Car> cars = new List<Car>();
            string filePath = currentDir + "\\" + filename;
            bool fileExist = File.Exists(filePath);

            if (fileExist)
            {
                using(StreamReader sr = File.OpenText(next_file))
                {
                    string s;
                    while ((s = sr.ReadLine()) != null)
                    {
                        string[] carArray = s.Split(";");
                        Car newCar = new Car(carArray[0], carArray[1]);
                        cars.Add(newCar);
                    }
                }

                Console.WriteLine($"All Cars in file {filename}:\n");
                foreach (Car car in cars)
                {
                    Console.WriteLine(car.Brand + " - " + car.Model);
                }
            }
            Console.ReadLine();
        }
    }

    class Car
    {
        public Car(string brand, string model)
        {
            Brand = brand;
            Model = model;
        }
        public string Brand { get; set; }
        public string Model { get; set; }
    }
}
