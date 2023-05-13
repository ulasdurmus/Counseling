using Counseling.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counseling.Data.Abstract
{
    public interface IReservationRepository : IGenericRepository<Reservation>
    {
        public List<Reservation> GetAllReservations(bool? isPaid = null, string roleName = null, int? id = null);
        public Task<Reservation> GetReservationFullDataAsync(int reservationId);
    }
}
