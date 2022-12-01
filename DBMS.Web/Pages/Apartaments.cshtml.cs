using DBMS.Api;
using DBMS.Api.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SUBDCOURSE.Pages
{
    public class ApartamentsModel : PageModel
    {
        private readonly ILogger<ApartamentsModel> _logger;

        public ApartamentsModel(ILogger<ApartamentsModel> logger)
        {
            _logger = logger;
        }

        public IEnumerable<IncludedServices> IncludedServices = Context.LoadEntities<IncludedServices>();
        public IEnumerable<Apartament> Apartaments = Context.LoadEntities<Apartament>();
        public IEnumerable<ApartamentFacilities> ApartamentFacilities = Context.LoadEntities<ApartamentFacilities>();

        public void OnGet()
        {
        }
    }
}
