using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGlobe
{
    interface IGlobe
    {
        double getTemperature(Planet planet);
        double getRadius(Planet planet);
        bool getIsPlanet(Planet planet);
    }
    public class Planet
    {
        public string NameOfPlanet { get; set; }
        public double Temperature { get; set; }
        public double Radius { get; set; }
        public bool IsPlanet { get; set; }
    }
    class Info : IGlobe
    {
        public static Info instance;
        public List<Planet> listOfPlanets;
        public List<string> listNamesOfPlanets;
        private Info()
        {
            listOfPlanets = new List<Planet>();
            listNamesOfPlanets = new List<string>();
        }
        public static Info Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Info();
                }
                return instance;
            }
        }
        public double getTemperature(Planet planet) 
        {
            return planet.Temperature;
        }
        public double getRadius(Planet planet)
        {
            return planet.Radius;
        }
        public bool getIsPlanet(Planet planet)
        {
            return planet.IsPlanet;
        }
        public void Description(string InputName, double Temperature,
                        double Radius, string IsPlanett)
        {
            bool IsPlanet = false;
            if (IsPlanett == "да" || IsPlanett == "Да")
            {
                IsPlanet = true;
            }
            Planet newPlanet = new Planet
            {
                NameOfPlanet = InputName,
                Temperature = Temperature,
                Radius = Radius, 
                IsPlanet = IsPlanet
            };
            listNamesOfPlanets.Add(InputName.ToLower());
            listOfPlanets.Add(newPlanet);
        }
        public void PrintAllPlanets()
        {
            Console.WriteLine("All planets:\n");
            foreach (var pl in listOfPlanets)
            {
                Console.WriteLine($"Названиие: {pl.NameOfPlanet}\n" +
                    $"Температура: {pl.Temperature}°С\nРадиус: {pl.Radius} км\nЯвляется планетой: {pl.IsPlanet}");
            }
        }
        public void PrintOnePlanet(string name)
        {
            Console.WriteLine($"Характеристики объекта:\n");
            foreach (var pl in listOfPlanets)
            {
                if (pl.NameOfPlanet.ToLower() == name.ToLower())
                {
                    Console.WriteLine($"Названиие: {pl.NameOfPlanet}\n" +
                    $"Температура: {pl.Temperature}°С\nРадиус: {pl.Radius} км\nЯвляется планетой: {pl.IsPlanet}");
                }
                
            }
        }
        public void RecordPlanet(string name)
        {
            if (!listNamesOfPlanets.Contains(name.ToLower()))
            {
                Console.WriteLine();
                Console.Write("Укажите температуру  ");
                double temp = Convert.ToDouble(Console.ReadLine());
                Console.Write("Укажите радиус  ");
                double rad = Convert.ToDouble(Console.ReadLine());
                Console.Write("Этот объект является планетой?  ");
                string ispl = Console.ReadLine();
                Description(name, temp, rad, ispl);
            }
            else
            {
                Console.WriteLine("Такая планета уже существует");
                Console.WriteLine("Хотите посмотреть описание?");
                string answer = Console.ReadLine();
                if (answer == "Да" || answer == "да")
                {
                    PrintOnePlanet(name);
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string name = ""; 
            Info info = Info.Instance;
            while (name != "Да" && name != "да")
            {
                Console.WriteLine("Введите имя объекта");
                name = Console.ReadLine();

                info.RecordPlanet(name);
                Console.Write("Хотите завершить программу? ");
                name = Console.ReadLine();
                Console.WriteLine();
                
            }




            /*
            info.Description("Марс", -50, 3396, true);
            info.PrintAllPlanets();
            Console.ReadKey();*/
            


            
        }
    }
}
