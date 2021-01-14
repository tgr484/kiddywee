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

        public EnumFoodType FoodType { get; set; }
    }
}
