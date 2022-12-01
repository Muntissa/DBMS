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

        public void OnGet()
        {

        }
    }
}
