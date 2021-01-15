using Kiddywee.DAL.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kiddywee.DAL.Models
{
    public class DailyReportFood : BaseEntity
    {
        public DailyReportMeal DailyReportMeal { get; set; }
        public Guid DailyReportMealId { get; set; }

        public string Food { get; set; }
        public EnumFoodType FoodType { get; set; }

        public static DailyReportFood Create(string food, EnumFoodType foodType, Guid mealId, string userId)
        {
            return new DailyReportFood() 
            { 
                CreatedById = userId,
                FoodType = foodType,
                DailyReportMealId = mealId,
                Food = food,
                
            };
        }
    }
}
