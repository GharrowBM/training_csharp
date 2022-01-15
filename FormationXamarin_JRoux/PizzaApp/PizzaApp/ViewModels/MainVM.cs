﻿using Newtonsoft.Json;
using PizzaApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Text;

namespace PizzaApp.ViewModels
{
    public class MainVM : INotifyPropertyChanged
    {
        private List<Pizza> pizzas;
        private Pizza selectedPizza;
        private string fileLocation = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Datas/Pizza.json");
        private string message;

        public List<Pizza> Pizzas
        {
            get { return pizzas; }
            set
            {
                this.pizzas = value;
                OnPropertyChanged("Pizzas");
            }
        }

        public Pizza SelectedPizza
        {
            get => selectedPizza;
            set
            {
                selectedPizza = value;
                OnPropertyChanged("SelectedPizza");
            }
        }

        public string Message
        {
            get => message;
            set
            {
                message = value;
                OnPropertyChanged("Message");
            }
        }
        public string FileLocation 
        { 
            get => fileLocation; 
            set
            {
                fileLocation = value;
                OnPropertyChanged("FileLocation");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        
        public MainVM()
        {
            string URL = "data:image/jpeg;base64,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";

            Pizzas = new List<Pizza>()
            {
                new Pizza()
                {
                    Id = 1,
                    Name="Marguerita",
                    Price = 7.99m,
                    ImageUrl= URL,
                    Ingredients = new List<string>
                    {
                        "Tomatoes",
                        "Mozzarella",
                        "Pecorino",
                        "Olives"
                    }
                },
                new Pizza()
                {
                    Id = 2,
                    Name="4 Seasons",
                    Price = 10.99m,
                    ImageUrl= URL,
                    Ingredients = new List<string>
                    {
                        "Cream",
                        "Mozzarella",
                        "Edam",
                        "Gouda",
                        "Reblochon"
                    }
                },
                new Pizza()
                {
                    Id = 3,
                    Name="Montaineer",
                    Price = 12.99m,
                    ImageUrl= URL,
                    Ingredients = new List<string>
                    {
                        "Tomatoes",
                        "Sausages",
                        "Mozzarella",
                        "Potatoes"
                    }
                }

            };

        }

        public void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
