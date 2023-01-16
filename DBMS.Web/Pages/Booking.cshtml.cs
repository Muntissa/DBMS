using DBMS.Api;
using DBMS.Api.Entities;
using Microsoft.AspNetCore.Components.Forms;
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
            Context.Insert(new BookingServices() {
                BookingId = booking_id,
                ServiceId = Convert.ToInt32(Services.Where(service => service.Name.Trim() == service_id.Substring(0, service_id.IndexOf(" | "))).Select(service => service.Id).First())
            });
            BookingServices = Context.LoadEntities<BookingServices>();
            OnPostUpdateSum();
        }
        public void OnPostDelete(int booking_id)
        {
            Context.Delete<Booking>(booking_id);
            Bookings = Context.LoadEntities<Booking>();
            OnPostUpdateSum();
        }

        public void OnPostInsert(string apartament_id, string client_id, string firstdate, string enddate, string reservation)
        {
            var clientSplit = client_id.Split(" ");
            Context.Insert(new Booking()
            {
                ApartamentId = Apartaments.Where(apartament => apartament.Number == Convert.ToInt32(apartament_id.Split(" ")[1])).Select(apart => apart.Id).First(),
                ClientId = Convert.ToInt32(Clients.Where(client => client.SecondName.Trim() == clientSplit[0] && client.FirstName.Trim() == clientSplit[1] && client.ThirdName.Trim() == clientSplit[2]).Select(client => client.Id).First()),
                FirstDate = Convert.ToDateTime(firstdate),
                EndDate = Convert.ToDateTime(enddate),
                Reservation = reservation == "Да",
                SumPrice = 0
            });
            Bookings = Context.LoadEntities<Booking>();
            OnPostUpdateSum();
        }

        private void OnPostUpdateSum()
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
