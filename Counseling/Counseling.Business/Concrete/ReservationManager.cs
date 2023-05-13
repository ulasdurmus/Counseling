using Counseling.Business.Abstract;
using Counseling.Data.Abstract;
using Counseling.Entity.Concrete;
using Counseling.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counseling.Business.Concrete
{
    public class ReservationManager : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;

        public ReservationManager(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task CretaeAsync(Reservation reservation)
        {
            await _reservationRepository.CreateAsync(reservation);
        }

        public void Delete(Reservation reservation)
        {
            _reservationRepository.Delete(reservation);
        }

        public async Task<List<Reservation>> GetAllAsync()
        {
            return await _reservationRepository.GetAllAsync();
        }

        public async Task<Reservation> GetReservationFullDataAsync(int reservationId)
        {
            return await _reservationRepository.GetReservationFullDataAsync(reservationId);
        }

        public List<Reservation> GetAllReservations(bool? isPaid = null, string roleName = null, int? id = null)
        {
            return _reservationRepository.GetAllReservations(isPaid,roleName,id);
        }

        public async Task<Reservation> GetByIdAsync(int id)
        {
            return await _reservationRepository.GetByIdAsync(id);
        }

        public void Update(Reservation reservation)
        {
            _reservationRepository.Update(reservation);
        }
    }
}
