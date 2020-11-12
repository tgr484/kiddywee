using Kiddywee.DAL.Data;
using Kiddywee.DAL.Interfaces;
using Kiddywee.DAL.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kiddywee.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool _disposed;
        private readonly ApplicationDbContext _context;

        private IGenericRepository<Person> _peopleRepository;
        private IGenericRepository<ChildInfo> _childInfoRepository;
        private IGenericRepository<MedicalInfo> _medicalInfoRepository;

        private IGenericRepository<Contact> _contactsRepository;
        private IGenericRepository<Organization> _organizationsRepository;
        private IGenericRepository<Class> _classesRepository;
        private IGenericRepository<Subject> _subjectsRepository;
        private IGenericRepository<Curriculum> _curriculumsRepository;
        private IGenericRepository<CurriculumSubjectGoal> _curriculumSubjectGoalsRepository;
        private IGenericRepository<CurriculumSubjectGoalHierarchy> _curriculumSubjectGoalHierarchiesRepository;
        private IGenericRepository<CurriculumToSubject> _curriculumToSubjectsRepository;
        private IGenericRepository<LessonPlan> _lessonPlansRepository;
        private IGenericRepository<LessonPlanWeakly> _lessonPlanWeakliesRepository;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IGenericRepository<Person> People => _peopleRepository ??= new GenericRepository<Person>(_context);
        public IGenericRepository<ChildInfo> ChildInfos => _childInfoRepository ??= new GenericRepository<ChildInfo>(_context);
        public IGenericRepository<MedicalInfo> MedicalInfos => _medicalInfoRepository ??= new GenericRepository<MedicalInfo>(_context);

        public IGenericRepository<Contact> Contacts => _contactsRepository ??= new GenericRepository<Contact>(_context);
        public IGenericRepository<Organization> Organizations => _organizationsRepository ??= new GenericRepository<Organization>(_context);
        public IGenericRepository<Class> Classes => _classesRepository ??= new GenericRepository<Class>(_context);
        public IGenericRepository<Subject> Subjects => _subjectsRepository ??= new GenericRepository<Subject>(_context);
        public IGenericRepository<Curriculum> Curriculums => _curriculumsRepository ??= new GenericRepository<Curriculum>(_context);
        public IGenericRepository<CurriculumSubjectGoal> CurriculumSubjectGoals => _curriculumSubjectGoalsRepository ??= new GenericRepository<CurriculumSubjectGoal>(_context);
        public IGenericRepository<CurriculumSubjectGoalHierarchy> CurriculumSubjectGoalHierarchies => _curriculumSubjectGoalHierarchiesRepository ??= new GenericRepository<CurriculumSubjectGoalHierarchy>(_context);
        public IGenericRepository<CurriculumToSubject> CurriculumToSubjects => _curriculumToSubjectsRepository ??= new GenericRepository<CurriculumToSubject>(_context);
        public IGenericRepository<LessonPlan> LessonPlans => _lessonPlansRepository ??= new GenericRepository<LessonPlan>(_context);
        public IGenericRepository<LessonPlanWeakly> LessonPlanWeaklies => _lessonPlanWeakliesRepository ??= new GenericRepository<LessonPlanWeakly>(_context);
        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task<IdentityResult> SaveAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
                return IdentityResult.Success;
            }
            catch (Exception e)
            {
                return IdentityResult.Failed(new IdentityError() { Code = "Error", Description = e.Message });
            }
        }

        public virtual void Dispose(bool disposing)
        {
            if (_disposed) return;
            if (disposing)
            {
                _context.Dispose();
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
