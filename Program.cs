using System;
using System.Collections.Generic;
using System.Linq;

namespace DomaciUloha1 // Arseniy Zolotarev
{
    public class Calculator
    {
        public static List<double> NumbersList { get; } = new List<double>();

        public double MinNumber => NumbersList.Min();

        public double MaxNumber => NumbersList.Max();

        public double NumbersSum => NumbersList.Sum();

        public double AverageNum => NumbersList.Average();

        public double Median
        {
            get
            {
                var sortedList = NumbersList;
                sortedList.Sort();
                if (NumbersList.Count % 2 == 0)
                    return (sortedList[sortedList.Count / 2] + sortedList[sortedList.Count / 2 - 1]) / 2;
                else
                    return sortedList[sortedList.Count / 2];
            }
        }

        public void AddNumbersToList()
        {
            NumbersList.Clear();
            for (int i = 1; i < int.MaxValue; i++)
            {
                Console.WriteLine($"Zadej {i} cislo nebo napis konec");
                var userInput = Console.ReadLine();
                if (userInput == "konec") break;
                if (double.TryParse(userInput, out double number))
                {
                    NumbersList.Add(number);
                }
                else
                {
                    Console.WriteLine("To neni cislo");
                    i--;
                }
            }
        }
    }

    public class Program
    {
        private static void Main()
        {
            var menuOn = true;
            while (menuOn)
            {
                PrintMenu();
                SelectAction();
            }
        }

        private static void SelectAction()
        {
            var selectedAuction = Console.ReadKey(true).KeyChar;
            char[] auctions = { '2', '3', '4', '5', '6', '7' };
            Calculator calculator = new Calculator();
            if (Calculator.NumbersList.Count == 0 && auctions.Contains(selectedAuction))
            {
                Console.WriteLine("Nejprve zadejte cisla");
                Console.ReadKey();
                return;
            }

            switch (selectedAuction)
            {
                case '1':
                    calculator.AddNumbersToList();
                    break;
                case '2':
                    PrintResult($"Vypis cisel: {string.Join(", ", Calculator.NumbersList)}");
                    break;
                case '3':
                    PrintResult($"Minimum ze vsech cisel je: {calculator.MinNumber}");
                    break;
                case '4':
                    PrintResult($"Maximum ze vsech cisel je: {calculator.MaxNumber}");
                    break;
                case '5':
                    PrintResult($"Suma vsech cisel je: {calculator.NumbersSum}");
                    break;
                case '6':
                    PrintResult($"Prumer ze vsech cisel je: {calculator.AverageNum}");
                    break;
                case '7':
                    PrintResult($"Median ze vsech cisel je: {calculator.Median}");
                    break;
                case '8':
                    Environment.Exit(0);
                    break;
            }
        }

        private static void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine("Super kalkulacka\n" +
                              "Volby:\n" +
                              "[1] Zadani cisel\n" +
                              "[2] Vypis cisel\n" +
                              "[3] Nalezeni minima ze vsech cisel\n" +
                              "[4] Nalezeni maxima ze vsech cisel\n" +
                              "[5] Vypocet sumy vsech cisel\n" +
                              "[6] Vypocet prumeru ze vsech cisel\n" +
                              "[7] Vypocet medianu\n" +
                              "[8] Konec programu");
        }

        private static void PrintResult(string message)
        {
            Console.Write(message);
            Console.WriteLine("\nPokracujte stisknutim libovolneho tlacitka");
            Console.ReadKey();
        }
    }
}