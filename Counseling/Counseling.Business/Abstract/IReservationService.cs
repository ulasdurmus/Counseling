using Counseling.Entity.Concrete;
using Counseling.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counseling.Business.Abstract
{
    public interface IReservationService
    {
        Task CretaeAsync(Reservation reservation);
        Task<Reservation> GetByIdAsync(int id);
        Task<List<Reservation>> GetAllAsync();
        void Update(Reservation reservation);
        void Delete(Reservation reservation);
        public List<Reservation> GetAllReservations(bool? isPaid = null, string roleName = null, int? id = null);

    }
}
