﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfQuestionMission:EfEntityRepositoryBase<QuestionSolvingMission,CktDbContext>,IQuestionMissionDal
    {
        public List<QuestionSolvingMissionDto> GetAllMissionDetails()
        {
            using (CktDbContext context = new CktDbContext())
            {
                var result = from q in context.QuestionSolvingMissions
                    join c in context.Children on q.ChildId equals c.Id
                    join p in context.Parents on q.ParentId equals p.Id
                    join sl in context.SchoolsLessons on q.SchoolLessonId equals sl.Id
                    join s in context.Schools on c.SchoolsId equals s.Id 
                    select new QuestionSolvingMissionDto
                    {
                        Id = q.Id,
                        ChildName = c.FirstName,
                        ParentFirstName = p.FirstName,
                        ParentLasttName = p.LastName,
                        AssignedDate = q.AssignedDate,
                        VerifiedDate = q.VerifiedDate,
                        SchoolLessonName = sl.LessonName,
                        NumberOfQuestion = q.NumberOfQuestion,
                        EducationStatu = s.SchoolName,
                        SuccessRate = q.SuccessRate,
                        AllowedTime = q.AllowedTime,
                        Description = q.Description,
                        IsApproved = q.IsApproved
                    };
                return result.ToList();
            }
        }

        public List<QuestionSolvingMissionDto> GetMissionDetailsByParentId(int ParentId)
        {
            using (CktDbContext context = new CktDbContext())
            {
                var result = from q in context.QuestionSolvingMissions
                    join c in context.Children on q.ChildId equals c.Id
                    join p in context.Parents on q.ParentId equals p.Id
                    join sl in context.SchoolsLessons on q.SchoolLessonId equals sl.Id
                    join s in context.Schools on c.SchoolsId equals s.Id
                             where p.Id == ParentId
                    select new QuestionSolvingMissionDto
                    {
                        Id = q.Id,
                        ChildName = c.FirstName,
                        ParentFirstName = p.FirstName,
                        ParentLasttName = p.LastName,
                        AssignedDate = q.AssignedDate,
                        VerifiedDate = q.VerifiedDate,
                        SchoolLessonName = sl.LessonName,
                        NumberOfQuestion = q.NumberOfQuestion,
                        EducationStatu = s.SchoolName,
                        SuccessRate = q.SuccessRate,
                        AllowedTime = q.AllowedTime,
                        Description = q.Description,
                        IsApproved = q.IsApproved
                    };
                return result.ToList();
            }
        }

        public List<QuestionSolvingMissionDto> GetMissionDetailsByChildId(int ChildId)
        {
            using (CktDbContext context = new CktDbContext())
            {
                var result = from q in context.QuestionSolvingMissions
                    join c in context.Children on q.ChildId equals c.Id
                    join p in context.Parents on q.ParentId equals p.Id
                    join sl in context.SchoolsLessons on q.SchoolLessonId equals sl.Id
                    join s in context.Schools on c.SchoolsId equals s.Id
                             where c.Id == ChildId
                    select new QuestionSolvingMissionDto
                    {
                        Id = q.Id,
                        ChildName = c.FirstName,
                        ParentFirstName = p.FirstName,
                        ParentLasttName = p.LastName,
                        AssignedDate = q.AssignedDate,
                        VerifiedDate = q.VerifiedDate,
                        SchoolLessonName = sl.LessonName,
                        NumberOfQuestion = q.NumberOfQuestion,
                        EducationStatu = s.SchoolName,
                        SuccessRate = q.SuccessRate,
                        AllowedTime = q.AllowedTime,
                        Description = q.Description,
                        IsApproved = q.IsApproved
                    };
                return result.ToList();
            }
        }

        public QuestionSolvingMissionDto GetMissionById(int MissionId)
        {
            using (CktDbContext context = new CktDbContext())
            {
                var result = (from q in context.QuestionSolvingMissions
                    join c in context.Children on q.ChildId equals c.Id
                    join p in context.Parents on q.ParentId equals p.Id
                    join sl in context.SchoolsLessons on q.SchoolLessonId equals sl.Id
                    join s in context.Schools on c.SchoolsId equals s.Id
                              where q.Id == MissionId
                    select new QuestionSolvingMissionDto
                    {
                        Id = q.Id,
                        ChildName = c.FirstName,
                        ParentFirstName = p.FirstName,
                        ParentLasttName = p.LastName,
                        AssignedDate = q.AssignedDate,
                        VerifiedDate = q.VerifiedDate,
                        SchoolLessonName = sl.LessonName,
                        NumberOfQuestion = q.NumberOfQuestion,
                        EducationStatu = s.SchoolName,
                        SuccessRate = q.SuccessRate,
                        AllowedTime = q.AllowedTime,
                        Description = q.Description,
                        IsApproved = q.IsApproved
                    }).FirstOrDefault();
                return result;
            }
        }
    }
}
