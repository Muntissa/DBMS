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

        public void OnPostUpdateSum()
        {
            Context.UpdateApartamentsPrices(Apartaments);
        }

        public void OnPostInsert(int tariff_id, int number, int area)
        {
            Context.Insert(new Apartament()
            {
                TariffId = tariff_id,
                Number = number,
                ImageUrl = "./image/HotelPic1.jpg",
                Area = area,
                Price = 0
            });
        }

        public void OnPostDelete(int id)
        {
            Context.Delete<Apartament>(id);
        }

        public void OnPostInsertFacility(int apartament_id, int facility_id)
        {
            Context.Insert(new ApartamentFacilities { ApartamentId = apartament_id, FacilityId = facility_id });
        }

        public void OnPostInsertService(int apartament_id, int service_id)
        {
            Context.Insert(new IncludedServices { ApartamentId = apartament_id, ServiceId = service_id });
        }
    }
}
