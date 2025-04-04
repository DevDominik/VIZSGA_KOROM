using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutokConsole.Models
{
    public class Auto
    {
        static List<Auto> cars = new List<Auto>();
        public string Serial { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }
        public int Sold { get; set; }
        public int AvgPrice { get; set; }
        public string Brand { get; set; }
        public Auto(string line) 
        { 
            string[] parts = line.Split(';');
            Serial = parts[0];
            Brand = parts[1];
            Model = parts[2];
            Year = int.Parse(parts[3]);
            Color = parts[4];
            Sold = int.Parse(parts[5]);
            AvgPrice = int.Parse(parts[6]);
        }
        public static void LoadFromCSV(string path)
        {
            cars = File.ReadAllLines(path).Skip(1).Select(line => new Auto(line)).ToList();
        }
        public static List<Auto> GetCars()
        {
            return cars;
        }
    }
}
