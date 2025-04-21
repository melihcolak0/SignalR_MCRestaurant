using _81MY_SignalROrderMan.DataAccessLayer.Abstract;
using _81MY_SignalROrderMan.DataAccessLayer.Concrete;
using _81MY_SignalROrderMan.DataAccessLayer.Repositories;
using _81MY_SignalROrderMan.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _81MY_SignalROrderMan.DataAccessLayer.EntityFramework
{
    public class EfBookingDal : GenericRepository<Booking>, IBookingDal
    {
        private readonly SignalRContext _context;
        public EfBookingDal(SignalRContext context) : base(context)
        {
            _context = context;
        }

        public void CancelBookingStatus(int id)
        {
            var booking = _context.Bookings.Find(id);
            booking.Description = "Rezervasyon İptal Edildi";
            _context.SaveChanges();

        }

        public void ConfirmBookingStatus(int id)
        {
            var booking = _context.Bookings.Find(id);
            booking.Description = "Rezervasyon Onaylandı";
            _context.SaveChanges();
        }
    }
}
