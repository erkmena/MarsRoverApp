using MarsRoverApp.Model;
using MarsRoverApp.Model.Implementations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverApp.Helper
{
    class ScreenHelper
    {

        static char vehicleDirection;
        static ArrayList vehicleArray = new ArrayList();
        static Plateau originalPlateau;

        internal static char WriteMenu()
        {
            Console.WriteLine("Aşağıda ki menüden seçiminizi giriniz:");
            Console.WriteLine("1- Yeni Araç Ekleme");
            Console.WriteLine("2- Sonuçları Listele");
            Console.WriteLine("3- Ekranı Temizle");

            Console.WriteLine("ESC- Çıkış\n");
            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.Escape)
            {
                Environment.Exit(0);
            }
            Console.WriteLine();
            return key.KeyChar;

        }

        internal static void CleanScreen()
        {
            Console.Clear();
        }

        internal static void WriteResults()
        {
            foreach (IVehicle item in vehicleArray)
            {
                Plateau plateau = item.CurrentCoordinates();
                Console.WriteLine("Aracın Mevcut Koordinatları : {0}-{1} \n Aracın Yönü : {2}", plateau.XAxis, plateau.YAxis, item.CurrentDirection());
                Console.WriteLine();
            }
        }

        internal static void WrongChoice()
        {
            Console.WriteLine("Geçersiz Seçim");
        }

        public static void WriteBeginningMenu()
        {
            Console.WriteLine("Lütfen Mars Alanının Boyutunu Giriniz (Arada boşluk bırakarak giriniz. Ör: 4 5)");
            originalPlateau = GetPlateauField();
        }

        internal static void WriteAndReadVehicleMenu()
        {
            Console.WriteLine("Lütfen yeni aracın başlangıç koordinatlarını ve yönünü giriniz (Arada boşluk bırakarak giriniz. Ör: 4 5 E)");
            Plateau startingCoordinates = GetNewVehicleCoordinates();
            IVehicle vehicle = VehicleFactory.MakeVehicle(new RoboticRover(vehicleDirection, startingCoordinates));
            Console.WriteLine("Lütfen yeni aracın yol bilgisini giriniz");
            string rawData = Console.ReadLine();
            VehicleHelper.ProcessData(rawData, vehicle, originalPlateau);
            vehicleArray.Add(vehicle);
        }

        private static Plateau GetNewVehicleCoordinates()
        {
            string[] rawData = Console.ReadLine().Split(' ');
            Plateau plateau =new Plateau(0, 0);
            plateau.XAxis = Convert.ToInt32(rawData[0]);
            plateau.YAxis = Convert.ToInt32(rawData[1]);
            vehicleDirection = rawData[2].ToCharArray()[0];

            return plateau;
        }

        private static Plateau GetPlateauField()
        {
            int[] plateauField = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            return new Plateau(plateauField[0], plateauField[1]);
        }
    }
}
