﻿using System;

using Blackjack.Game;

class Program
{
    static async Task Main(string[] args)
    {
        bool exitRequested = false;

        while (!exitRequested)
        {
            Console.WriteLine("Üdvözöllek a BlackJack-en!\n");
            Console.WriteLine("Válassz a következő lehetőségek közül:");
            Console.WriteLine("1. Játék indítása");
            Console.WriteLine("2. Eredmények megtekintése");
            Console.WriteLine("3. Kilépés");

            Console.Write("Kérem válasszon (1-3): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Clear();
                    StartGame();
                    break;
                case "2":
                    Console.Clear();
                    await ViewResults();
                    break;
                case "3":
                    exitRequested = true;
                    break;
                default:
                    Console.WriteLine("Érvénytelen választás. Kérlek, válassz újra.");
                    Console.Clear();
                    break;
            }
        }
    }

    static void StartGame()
    {
        string playerName = GetValidPlayerName();

        if (!string.IsNullOrEmpty(playerName))
        {
            Console.Clear();
            BlackjackGame game = new BlackjackGame(playerName);
            game.Start();
        }
    }

    static string GetValidPlayerName()
    {
        while (true)
        {
            try
            {
                Console.Write("Kérlek, add meg a neved: ");
                string playerName = Console.ReadLine()?.Trim();

                if (!string.IsNullOrEmpty(playerName))
                {
                    return playerName;
                }

                throw new ArgumentException("Hibás bemenet. Kérlek, adj meg érvényes nevet.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    static async Task ViewResults()
    {
        Statistics statistics = new Statistics();
        await statistics.DisplayTopPlayersTable(5);
        ReturnToMainMenu();
    }

    static void ReturnToMainMenu()
    {
        Console.WriteLine("\nNyomj meg egy gombot a főmenübe való visszatéréshez...");
        Console.ReadKey(true);
        Console.Clear();
    }

}