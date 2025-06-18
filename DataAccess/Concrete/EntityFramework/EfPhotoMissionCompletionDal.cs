using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfPhotoMissionCompletionDal:EfEntityRepositoryBase<PhotoVerificationCompletion, CktDbContext>,IPhotoMissionCompletionDal
    {
        public List<PhotoVerificationCompletionDto> GetDetails()
        {
            using (CktDbContext context = new CktDbContext())
            {
                var result = from pmc in context.PhotoVerificationCompletionMissions
                    join c in context.Children on pmc.ChildId equals c.Id
                    join pvm in context.PhotoVerificationMissions on pmc.MissionId equals pvm.Id
                    select new PhotoVerificationCompletionDto
                    {
                        Id = pmc.Id,
                        ChildName = c.FirstName + c.LastName,
                        MissionTitle = pvm.MissionTitle,
                        MissionDescription = pvm.MissionDescription,
                        SessionDuration = pvm.SessionDuration,
                        AssignedDate = pvm.AssignedDate,
                        CompletionTime = pmc.CompletionTime,
                        Description = pmc.Description,
                        FilePath = pmc.FilePath,
                        Success = pmc.Success,
                        IsApproved = pmc.IsApproved
                    };
                return result.ToList();

            }
        }

        public List<PhotoVerificationCompletionDto> GetDetailsById(int childId)
        {
            using (CktDbContext context = new CktDbContext())
            {
                var result = (from pmc in context.PhotoVerificationCompletionMissions
                    join c in context.Children on pmc.ChildId equals c.Id
                    join pvm in context.PhotoVerificationMissions on pmc.MissionId equals pvm.Id
                    where c.Id == childId
                    select new PhotoVerificationCompletionDto
                    {
                        Id = pmc.Id,
                        ChildName = c.FirstName + c.LastName,
                        MissionTitle = pvm.MissionTitle,
                        MissionDescription = pvm.MissionDescription,
                        AssignedDate = pvm.AssignedDate,
                        CompletionTime = pmc.CompletionTime,
                        FilePath = pmc.FilePath,
                        Description = pmc.Description,
                        Success = pmc.Success,
                        IsApproved = pmc.IsApproved
                    });
                return result.ToList();

            }
        }

        public PhotoVerificationCompletionDto GetMissionByMissionId(int missionId)
        {
            using (CktDbContext context = new CktDbContext())
            {
                var result = (from pmc in context.PhotoVerificationCompletionMissions
                    join c in context.Children on pmc.ChildId equals c.Id
                    join pvm in context.PhotoVerificationMissions on pmc.MissionId equals pvm.Id
                    where pvm.Id == missionId
                    select new PhotoVerificationCompletionDto
                    {
                        Id = pmc.Id,
                        ChildName = c.FirstName + c.LastName,
                        MissionTitle = pvm.MissionTitle,
                        MissionDescription = pvm.MissionDescription,
                        AssignedDate = pvm.AssignedDate,
                        CompletionTime = pmc.CompletionTime,
                        FilePath = pmc.FilePath,
                        Description = pmc.Description,
                        Success = pmc.Success,
                        IsApproved = pmc.IsApproved
                    }).FirstOrDefault();
                return result;

            }
        }
    }
}
