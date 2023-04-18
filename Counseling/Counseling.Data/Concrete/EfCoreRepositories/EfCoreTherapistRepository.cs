using Counseling.Data.Abstract;
using Counseling.Data.Concrete.Context;
using Counseling.Entity.Entity;
using Counseling.Entity.Entity.Identitiy;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counseling.Data.Concrete.EfCoreRepositories
{
    public class EfCoreTherapistRepository : EfCoreGenericrepository<Therapist>,ITherapistRepository
    {
        public EfCoreTherapistRepository(CounselingContext _appContext) : base(_appContext)
        {
        }
        CounselingContext AppContext
        {
            get { return _dbContext as CounselingContext; }
        }

        public List<Therapist> GetAllEntityAndUserInformation(List<Therapist> therapists, IList<User> users)
        {
            List<Therapist> therapistList = therapists
                .Select(x => new Therapist
            {
                Id = x.Id,
                IsApproved = x.IsApproved,
                IsOnline = x.IsOnline,
                Url = x.Url,
                TitleId = x.TitleId,
                UserId = x.UserId,
                Description = x.Description,
                Certificates = x.Certificates.Select(x=> new Certificate
                {
                    Name = x.Name,
                    Description = x.Description,
                    Id = x.Id,
                    PdfUrl = x.PdfUrl
                }).ToList(),
                ClientTherapists = x.ClientTherapists.Select(ct=> new ClientTherapist
                {
                    ClientId = ct.ClientId,
                    TherapistId = ct.TherapistId
                }).ToList(),
                Educations = x.Educations.Select(e=> new Education
                {
                    Id=e.Id,
                    Department = new Department
                    {
                        Id=e.Department.Id,
                        Name=e.Department.Name
                    }
                }).ToList(),
                TherapistCategories = x.TherapistCategories.Select(tc=> new TherapistCategory
                {
                    CategoryId = tc.CategoryId,
                    TherapistId=tc.TherapistId
                }).ToList(),
                

                User = users.Where(u => u.Id == x.UserId)
                .Select(u => new User
                {
                    Id = x.UserId,
                    DateOfBirth = u.DateOfBirth,
                    DateOfRegistration = u.DateOfRegistration,
                    AccessFailedCount = u.AccessFailedCount,
                    Address = u.Address,
                    Email = u.Email,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Gender = u.Gender,
                    Image = new Image
                    {
                        Id = u.Image.Id,
                        IsApproved = u.Image.IsApproved,
                        Url = u.Image.Url
                    }
                }).First(),



            }).ToList();

          
            return therapistList;
        }
    }
}
