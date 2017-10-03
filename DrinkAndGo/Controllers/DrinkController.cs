using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DrinkAndGo.Data.Interfaces;
using DrinkAndGo.ViewModels;
using DrinkAndGo.Data.Models;

namespace DrinkAndGo.Controllers
{
    public class DrinkController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IDrinkRepository _drinkRepository;

        public DrinkController(ICategoryRepository categoryRepository, IDrinkRepository drinkRepository)
        {
            _categoryRepository = categoryRepository;
            _drinkRepository = drinkRepository;
        }

        //Shows all the drinks or by category
        public ViewResult List(string category)
        {
            string _category = category;
            IEnumerable<Drink> drinks;

            string currentCategory = string.Empty;

            if (string.IsNullOrEmpty(category))
            {
                drinks = _drinkRepository.Drinks.OrderBy(n => n.DrinkId);
                currentCategory = "All drinks";
            }
            else
            {
                if (string.Equals("Alcoholic", _category, StringComparison.OrdinalIgnoreCase))
                {
                    drinks = _drinkRepository.Drinks.Where(p => p.Category.CategoryName.Equals("Alcoholic")).OrderBy(p => p.Name);
                }
                else
                    drinks = _drinkRepository.Drinks.Where(p => p.Category.CategoryName.Equals("Non-alcoholic")).OrderBy(p => p.Name);

                currentCategory = _category;
            }

            var drinkListViewModel = new DrinkListViewModel
            {
                Drinks = drinks,
                CurrentCategory = currentCategory
            };

            return View(drinkListViewModel);
        }

            /*
            //No category, all drinks are included
            public ViewResult List()
            {
                DrinkListViewModel vm = new DrinkListViewModel();
                vm.Drinks = _drinkRepository.Drinks;
                vm.CurrentCategory = "DrinkCategory";

                return View(vm);
            }
            */
        }
}
