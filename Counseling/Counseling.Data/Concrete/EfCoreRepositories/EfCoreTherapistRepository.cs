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
        public async Task<List<Department>> GetAllDepartments()
        {
            return await AppContext
                .Departments
                .ToListAsync();
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
                Education = new Education
                {
                    Id = x.Education.Id,
                    Department = new Department
                    {
                        Id =x.Education.Department.Id,
                        Name = x.Education.Department.Name
                    }
                },
                //Education = x.Education.Select(e=> new Education
                //{
                //    Id=e.Id,
                //    Department = new Department
                //    {
                //        Id=e.Department.Id,
                //        Name=e.Department.Name
                //    }
                //}).
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
        public async Task<List<University>> GetAllUniversty()
        {
            return await AppContext
                .Universities
                .ToListAsync();
        }
        public async Task<List<TherapistTitle>> GetAllTitles()
        {
            return await AppContext
                .TherapistTitles
                .ToListAsync();
        }
        public async Task<List<Certificate>> GetAllCertificates()
        {
            return await AppContext
                .Certificates
                .ToListAsync();
        }
        public async Task CreateTherapistWithFullDataAsync(Therapist therapist, int[] selectedCategories = null)
        {
            await AppContext.Therapists.AddAsync(therapist);
            await AppContext.SaveChangesAsync();
            List<TherapistCategory> therapistCategories = selectedCategories.Select(tc => new TherapistCategory
            {
                CategoryId=tc,
                TherapistId=therapist.Id,
            }).ToList();
            AppContext.TherapistCategories.AddRange(therapistCategories);
            await AppContext.SaveChangesAsync();
        }
        public async Task UpdateTherapist(Therapist therapist, int[] selectedCategories)
        {
            Therapist newTherapist = await AppContext
               .Therapists
               .Where(t=> t.Id == therapist.Id)
               .Include(t => t.TherapistCategories)
               .Include(t => t.Certificates)
               .Include(t => t.Education)
               .FirstOrDefaultAsync();

            newTherapist.Description = therapist.Description;
            newTherapist.TitleId = therapist.TitleId;
            newTherapist.Url = therapist.Url;
            newTherapist.TherapistCategories = selectedCategories
                .Select(sc => new TherapistCategory
                { 
                    TherapistId = newTherapist.Id,
                    CategoryId = sc
                }).ToList();
            AppContext.Update(newTherapist);
            await AppContext.SaveChangesAsync();
        }
        public async Task<Therapist> GetTherapistFullDataByUserName(string userName)
        {
            Therapist therapist = await AppContext
                .Therapists
                .Where(t => t.User.UserName == userName)
                .Include(t => t.TherapistCategories)
                .ThenInclude(tc => tc.Category)
                .Include(t => t.Education)
                .ThenInclude(te => te.University)
                .Include(t => t.Education)
                .ThenInclude(td => td.Department)
                .Include(t => t.Certificates)
                .FirstOrDefaultAsync();
            return therapist; 
        }
        public async Task<int> GetTherapistIdByUserName(string userName)
        {
            int id = await AppContext
                .Therapists
                .Where(t=> t.User.UserName == userName)
                .Select(t=> t.Id).FirstOrDefaultAsync();
            return id;
        }
        public Task<List<Education>> GetEducationFullData()
        {
            throw new NotImplementedException();
        }
        

    }
}
