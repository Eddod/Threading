using System.Threading;
using System;
using Threading;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ThreadingDemo
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            for (int i = 3; i > 0; i--)
            {
                Console.WriteLine("The race starts in " + i);
                Thread.Sleep(1000);
            }

            Car Car1 = new Car(1, "Volvo745", 300);
            Car Car2 = new Car(2, "Äkta Saab", 300);
            Car Car3 = new Car(3, "En gammal amazon", 300);

            
            var race1 = Race(Car1);
            var race2 = Race(Car2);
            var race3 = Race(Car3);
            var RaceCars = new List<Task>()
            {
               race1, race2, race3
                
            };
            Task FinishedRace = await Task.WhenAny(RaceCars);
            if (FinishedRace == race1)
            {
                Console.WriteLine(Car1.Model + " VANNNN!!!!!! HAHAH");
            }
            else if (FinishedRace == race2)
            {
                Console.WriteLine(Car2.Model + " SICK VANN KING");
            }
            else if (FinishedRace == race3)
            {
                Console.WriteLine(Car3.Model + " MANNEN DU VANN");
            }
        }
        
        public static void RandomAccident(Car car)
        {
            Accident a1 = new Accident(1, " Bytte till cykel");
            Accident a2 = new Accident(1, " Fick en fågel i motorn");
            Accident a3 = new Accident(1, " Fick en räv i motorn");
            Accident a4 = new Accident(1, " Fick punktering");
            Random rnd = new Random();
            int number = rnd.Next(1, 50);
            if (number >= 1 && number < 10)
            {
                Console.WriteLine(car.Model + a1.Cause);
                car.Speed--;


            }
            else if (number >= 10 && number < 30)
            {
                Console.WriteLine(car.Model + a2.Cause);
                Console.WriteLine("plockar ut fågeln");
                Thread.Sleep(2000);
                Console.WriteLine("Fågeln är utplockad");

            }
            else if (number >= 30 && number < 40)
            {
                Console.WriteLine(car.Model + a3.Cause);
                Console.WriteLine("plockar ut räven....");
                Thread.Sleep(4000);
                Console.WriteLine("Räven är utplockad!");

            }
            else if (number >= 40 && number < 49)
            {
                Console.WriteLine(car.Model + a4.Cause);
                Console.WriteLine("Lagar punktering...");
                Thread.Sleep(5000);
                Console.WriteLine("Punkteringen är lagad!");

            }
        }

        static async Task<Car> Race(Car car)
        {

            int distance = 0;
            DateTime _previousGameTime = DateTime.Now;
            
            for (int i = 0; i <= 70; i++)
            {

                TimeSpan _currentGameTime = DateTime.Now - _previousGameTime;
                Console.WriteLine("brumbrum");

                distance++;
                await Task.Delay(car.Speed);

                if (_currentGameTime.Seconds > 5)
                {
                    RandomAccident(car);
                    _previousGameTime = DateTime.Now;
                }
                
            }
            
            return car;
        }

    }
}