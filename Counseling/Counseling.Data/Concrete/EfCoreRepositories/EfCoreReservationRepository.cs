using Counseling.Data.Abstract;
using Counseling.Data.Concrete.Context;
using Counseling.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counseling.Data.Concrete.EfCoreRepositories
{
    public class EfCoreReservationRepository : EfCoreGenericrepository<Reservation>, IReservationRepository
    {
        public EfCoreReservationRepository(CounselingContext _appContext) : base(_appContext)
        {
        }
        CounselingContext AppContext
        {
            get { return _dbContext as CounselingContext; }
        }
        // terapistId ve ClientId ile rezervasyon çekilecek
        public List<Reservation> GetAllReservations(bool? isPaid=null, string roleName=null, int? id=null)
        {
            var reservations = AppContext
                .Reservations
                .Include(r => r.ClientServices)
                .ThenInclude(ct => ct.Client)
                .ThenInclude(cu => cu.User)
                .Include(r => r.ClientServices)
                .ThenInclude(cs => cs.Service).AsQueryable();
            if(isPaid!=null)
            {
                reservations = reservations
                    .Where(r => r.IsPaid == isPaid);
            }
            if(roleName == "therapist")
            {
                reservations = reservations
                    .Where(r => r.TherapistId == id);
            }
            else if (roleName == "client")
            {
                reservations = reservations
                    .Where(r => r.ClientId == id);
            }

            return reservations.ToList();
        }
    }
}
