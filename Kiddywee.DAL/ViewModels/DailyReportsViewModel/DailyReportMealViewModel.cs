using Kiddywee.DAL.Enum;
using Kiddywee.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiddywee.DAL.ViewModels.DailyReportsViewModel
{
    public class DailyReportMealViewModel
    {
        public DailyReportMealViewModel()
        {
            Foods = new List<DailyReportFoodViewModel>();
        }

        public Guid? Id { get; set; }

        public DateTime Date { get; set; }
        public Guid PersonId { get; set; }
        public Guid ClassId { get; set; }
        public Guid OrganizationId { get; set; }
        public string Note { get; set; }

        public EnumMealType MealType { get; set; }

        public List<DailyReportFoodViewModel> Foods { get; set; }
        public static DailyReportMealViewModel Create(DailyReportMeal meal, List<DailyReportFood> _foods)
        {
            var foods = _foods?.Select(x => new DailyReportFoodViewModel() { Food = x.Food, FoodType = x.FoodType, Id = x.Id }).ToList();
            return new DailyReportMealViewModel()
            {
                ClassId = meal.ClassId,
                Id = meal.Id,
                Date = meal.Date,
                Note = meal.Note,
                OrganizationId = meal.OrganizationId,
                PersonId = meal.PersonId,
                MealType = meal.MealType,
                Foods = foods
            };
        }

        public static object Create(DailyReportMeal meal)
        {
            var foods = meal.DailyReportFoods?.Where(x => x.IsActive)?.Select(x => new DailyReportFoodViewModel() { Food = x.Food, FoodType = x.FoodType, Id = x.Id }).ToList();

            return new DailyReportMealViewModel()
            {
                ClassId = meal.ClassId,
                Id = meal.Id,
                Date = meal.Date,
                Note = meal.Note,
                OrganizationId = meal.OrganizationId,
                PersonId = meal.PersonId,
                MealType = meal.MealType,
                Foods = foods
            };
        }
    }
}
