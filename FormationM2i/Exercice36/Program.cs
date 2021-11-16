﻿using System;
using System.Linq;

namespace Exercice36
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Gestion des notes ---");
            Console.Write("\nCombien de notes voulez-vous entrer ?");
            if (int.TryParse(Console.ReadLine(), out int nbOfNotes))
            {

                int[] notes = new int[nbOfNotes];
                int i = 0;

                while (i < nbOfNotes)
                {
                    Console.Write($"Veuilliez saisir la note {i + 1} (sur /20) : ");

                    if (int.TryParse(Console.ReadLine(), out int newNote))
                    {
                        if (newNote >= 0 && newNote <= 20)
                        {
                            notes[i] = newNote;
                            i++;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("La note doit être comprise entre 0 et 20 !");
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("ERR: La valeur entrée n'est pas correcte !");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nLa meilleure note est {notes.Max()}/20");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"La moins bonne note est {notes.Min()}/20");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"La moyenne des notes est {notes.Average()}/20");
            }
        }
    }
}
