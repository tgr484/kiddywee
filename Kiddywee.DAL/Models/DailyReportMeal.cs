using Kiddywee.DAL.Enum;
using Kiddywee.DAL.ViewModels.DailyReportsViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kiddywee.DAL.Models
{
    public class DailyReportMeal : BaseEntity
    {
        public Guid PersonId { get; set; }

        public Person Person { get; set; }

        public Class Class { get; set; }
        public Guid ClassId { get; set; }

        public Organization Organization { get; set; }
        public Guid OrganizationId { get; set; }

        public string Note { get; set; }

        public EnumMealType MealType {get;set;}
        public DateTime Date { get; set; }

        public List<DailyReportFood> DailyReportFoods { get; set; }

        public static DailyReportMeal Create(Guid personId, 
                                         Guid classId, 
                                         Guid organizationId, 
                                         DateTime date, 
                                         string note,
                                         string createdBy)
        {
            return new DailyReportMeal() 
            { 
                PersonId = personId,
                ClassId = classId,
                OrganizationId = organizationId,
                Date = date,
                Note = note,
                CreatedById = createdBy
            };
        }

        public static DailyReportMealViewModel Init(Guid personId,
                                         Guid classId,
                                         Guid organizationId,
                                         DateTime date
                                         )
        {
            return new DailyReportMealViewModel()
            {
                ClassId = classId,
                Date = date,
                OrganizationId = organizationId,
                PersonId = personId,
                Foods = new List<DailyReportFoodViewModel>(),

            };
        }

        public void Update(DailyReportMealViewModel model)
        {
            this.Note = model.Note;
            this.MealType = model.MealType;            
        }

        public void Delete()
        {
            this.IsActive = false;
            this.DailyReportFoods?.ForEach(x => x.IsActive = false);
        }

        public static List<DailyReportMealViewModel> Init(List<DailyReportMeal> meals)
        {
            return meals.Select(x => new DailyReportMealViewModel()
            {
                ClassId = x.ClassId,
                Id = x.Id,
                Date = x.Date,
                Note = x.Note,
                OrganizationId = x.OrganizationId,
                PersonId = x.PersonId,
                MealType = x.MealType,
                Foods = x.DailyReportFoods.Where(x => x.IsActive).Select(x => new DailyReportFoodViewModel() { Food = x.Food, FoodType = x.FoodType, Id = x.Id }).ToList()
            }).ToList();
        }
    }
}
