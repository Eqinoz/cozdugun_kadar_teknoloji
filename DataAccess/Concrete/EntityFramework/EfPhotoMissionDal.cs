using System;
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
    public class EfPhotoMissionDal:EfEntityRepositoryBase<PhotoVerificationMission,CktDbContext>,IPhotoMissionDal
    {
        public List<PhotoVerificationMissionDto> GetAllMissionDetails()
        {
            using (CktDbContext context = new CktDbContext())
            {
                var result = from m in context.PhotoVerificationMissions
                    join c in context.Children on m.ChildId equals c.Id
                    join p in context.Parents on m.ParentId equals p.Id
                    select new PhotoVerificationMissionDto
                    {
                        Id = m.Id,
                        ChildName = c.FirstName + c.LastName,
                        ParentFirstName = p.FirstName,
                        ParentLastName = p.LastName,
                        AssignedDate = m.AssignedDate,
                        VerifiedDate = m.VerifiedDate,
                        MissionTitle = m.MissionTitle,
                        HasTimeLimit = m.HasTimeLimit,
                        MissionDuration = m.MissionDuration,
                        SessionDuration = m.SessionDuration,
                        MissionDescription = m.MissionDescription,
                        PhotoUrl = m.PhotoUrl,
                        IsApproved = m.IsApproved
                    };
                return result.ToList();

            }
        }

        public List<PhotoVerificationMissionDto> GetMissionDetailsByParentId(int ParentId)
        {
            using (CktDbContext context = new CktDbContext())
            {
                var result = from m in context.PhotoVerificationMissions
                    join c in context.Children on m.ChildId equals c.Id
                    join p in context.Parents on m.ParentId equals p.Id
                    where c.ParentId==ParentId
                    select new PhotoVerificationMissionDto
                    {
                        Id = m.Id,
                        ChildName = c.FirstName + c.LastName,
                        ParentFirstName = p.FirstName,
                        ParentLastName = p.LastName,
                        AssignedDate = m.AssignedDate,
                        VerifiedDate = m.VerifiedDate,
                        MissionTitle = m.MissionTitle,
                        HasTimeLimit = m.HasTimeLimit,
                        MissionDuration = m.MissionDuration,
                        SessionDuration = m.SessionDuration,
                        MissionDescription = m.MissionDescription,
                        PhotoUrl = m.PhotoUrl,
                        IsApproved = m.IsApproved
                    };
                return result.ToList();

            }
        }

        public List<PhotoVerificationMissionDto> GetMissionDetailsByChildId(int ChildId)
        {
            using (CktDbContext context = new CktDbContext())
            {
                var result = from m in context.PhotoVerificationMissions
                    join c in context.Children on m.ChildId equals c.Id
                    join p in context.Parents on m.ParentId equals p.Id
                    where c.Id == ChildId
                    select new PhotoVerificationMissionDto
                    {
                        Id = m.Id,
                        ChildName = c.FirstName + c.LastName,
                        ParentFirstName = p.FirstName,
                        ParentLastName = p.LastName,
                        AssignedDate = m.AssignedDate,
                        VerifiedDate = m.VerifiedDate,
                        MissionTitle = m.MissionTitle,
                        HasTimeLimit = m.HasTimeLimit,
                        MissionDuration = m.MissionDuration,
                        SessionDuration = m.SessionDuration,
                        MissionDescription = m.MissionDescription,
                        PhotoUrl = m.PhotoUrl,
                        IsApproved = m.IsApproved
                    };
                return result.ToList();

            }
        }
    }
}
