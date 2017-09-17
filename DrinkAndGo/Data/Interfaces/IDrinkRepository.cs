using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrinkAndGo.Data.Models;

namespace DrinkAndGo.Data.Interfaces
{
    interface IDrinkRepository
    {
        // IEnumerable<Drink> Drinks { get; set; }
        IEnumerable<Drink> Drinks { get; }
        IEnumerable<Drink> PreferredDrinks { get; set; }
        Drink GetDrinkById(int drinkId);
    }
}
