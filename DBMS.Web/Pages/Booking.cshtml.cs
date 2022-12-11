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
        public IEnumerable<Apartament> Apartaments = Context.LoadEntities<Apartament>();
        public IEnumerable<Service> Services = Context.LoadEntities<Service>();
        public IEnumerable<Client> Clients = Context.LoadEntities<Client>();

        public void OnPostInsertService(int booking_id, string service_id)
        {
            Context.Insert(new BookingServices() { BookingId = booking_id, ServiceId = Convert.ToInt32(service_id.Split(" ").First()) });
            BookingServices = Context.LoadEntities<BookingServices>();
        }
        public void OnPostDelete(int booking_id)
        {
            Context.Delete<Booking>(booking_id);
            Bookings = Context.LoadEntities<Booking>();
        }

        public void OnPostInsert(string apartament_id, string client_id, string firstdate, string enddate, int reservation)
        {
            Context.Insert(new Booking()
            {
                ApartamentId = Convert.ToInt32(apartament_id.Split(" ").First()),
                ClientId = Convert.ToInt32(client_id.Split(" ").First()),
                FirstDate = Convert.ToDateTime(firstdate),
                EndDate = Convert.ToDateTime(enddate),
                Reservation = Convert.ToBoolean(reservation),
                SumPrice = 0
            });
            Bookings = Context.LoadEntities<Booking>();
        }

        public void OnPostUpdateSum()
        {
            foreach (var booking in Bookings)
            {
                if (BookingServices.Any(pair => pair.BookingId == booking.Id))
                    Context.UpdateBookingPriceWithServices(booking.Id);
                else
                    Context.UpdateBookingPriceWithoutServices(booking.Id);
            }
            Bookings = Context.LoadEntities<Booking>();
        }
    }
}
