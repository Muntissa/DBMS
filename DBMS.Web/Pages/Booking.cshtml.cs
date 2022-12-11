using DBMS.Api;
using DBMS.Api.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SUBDCOURSE.Pages
{
    public class BookingModel : PageModel
    {
        private readonly ILogger<BookingModel> _logger;

        public BookingModel(ILogger<BookingModel> logger)
        {
            _logger = logger;
        }

        public IEnumerable<Booking> Bookings = Context.LoadEntities<Booking>();
        public IEnumerable<BookingServices> BookingServices = Context.LoadEntities<BookingServices>();

        public void OnPostInsertService(int booking_id, int service_id)
        {
            Context.Insert(new BookingServices() { BookingId = booking_id, ServiceId = service_id });
        }
        public void OnPostDelete(int id)
        {
            Context.Delete<Booking>(id);
        }
        public void OnPostInsert(int apartament_id, int client_id, string firstdate, string enddate, int reservation)
        {
            Context.Insert(new Booking()
            {
                ApartamentId = apartament_id,
                ClientId = client_id,
                FirstDate = Convert.ToDateTime(firstdate),
                EndDate = Convert.ToDateTime(enddate),
                Reservation = Convert.ToBoolean(reservation),
                SumPrice = 0
            });
        }

        public void OnPostUpdateSum()
        {
            foreach(var booking in Bookings) 
            {
                if(BookingServices.Any(pair => pair.BookingId == booking.Id))
                {
                    Context.UpdateBookingPriceWithServices(booking.Id);
                }
                else { Context.UpdateBookingPriceWithoutServices(booking.Id); }
            }
        }
    }
}
