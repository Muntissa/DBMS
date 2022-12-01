using DBMS.Api;
using DBMS.Api.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SUBDCOURSE.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        
        public void OnGet()
        {
            
        }

        public void OnPostAuth()
        {
            IEnumerable<Booking> bookings = Context.LoadEntities<Booking>();
            Context.UpdateSumList(bookings);
        }
    }
}