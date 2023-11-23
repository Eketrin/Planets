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
        Boolean getIsPlanet(Planet planet);
    }
    public class Planet
    {
        public string NameOfPlanet { get; set; }
        public double Temperature { get; set; }
        public double Radius { get; set; }
        public Boolean IsPlanet { get; set; }
    }
    class Info : IGlobe
    {
        public static Info instance;
        public List<Planet> listOfPlanets;
        public List<string> namesOfPlanets;
        private Info()
        {
            listOfPlanets = new List<Planet>();
            namesOfPlanets = new List<string>();
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
        public Boolean getIsPlanet(Planet planet)
        {
            return planet.IsPlanet;
        }
        public void Description(string InputName, double Temperature,
                        double Radius, Boolean IsPlanet)
        {
            Planet newPlanet = new Planet
            {
                NameOfPlanet = InputName,
                Temperature = Temperature,
                Radius = Radius, 
                IsPlanet = IsPlanet
            };
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
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите имя новой пленеты");
            while (true)
            {

            }
            Info info = Info.Instance;
            info.Description("Марс", -50, 3396, true);
            info.PrintAllPlanets();
            Console.ReadKey();
            


            Console.ReadKey();
        }
    }
}
