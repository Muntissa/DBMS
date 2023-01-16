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

        public IEnumerable<Apartament> Apartaments = Context.LoadEntities<Apartament>();
        public IEnumerable<Tariff> Tariffs = Context.LoadEntities<Tariff>();
        public IEnumerable<Facility> Facilities = Context.LoadEntities<Facility>();
        public IEnumerable<Service> Services = Context.LoadEntities<Service>();
        public IEnumerable<IncludedServices> IncludedServices = Context.LoadEntities<IncludedServices>();
        public IEnumerable<ApartamentFacilities> ApartamentFacilities = Context.LoadEntities<ApartamentFacilities>();


        private void OnPostUpdateSum()
        {
            foreach (var apartament in Apartaments)
            {
                if (IncludedServices.Any(pair => pair.ApartamentId == apartament.Id))
                    Context.UpdateApartamentsPricesWithServices(apartament.Id);
                else 
                    Context.UpdateApartamentsPrices(apartament.Id);
            }
            Apartaments = Context.LoadEntities<Apartament>();
        }

        public void OnPostInsert(string tariff_id, int number, int area)
        {
            Context.Insert(new Apartament()
            {
                TariffId = Convert.ToInt32(Tariffs.Where(tariff => tariff.Name.Trim() == tariff_id).Select(tarif => tarif.Id).First()),
                Number = number,
                ImageUrl = "./image/HotelPic1.jpg",
                Area = area,
                Price = 0
            });
            Apartaments = Context.LoadEntities<Apartament>();
            OnPostUpdateSum();
        }

        public void OnPostDelete(int apartament_id)
        {
            Context.Delete<Apartament>(apartament_id);
            Apartaments = Context.LoadEntities<Apartament>();
            OnPostUpdateSum();
        }

        public void OnPostInsertFacility(int apartament_id, string facility_id)
        {
            Context.Insert(new ApartamentFacilities { 
                ApartamentId = apartament_id, 
                FacilityId = Convert.ToInt32(Facilities.Where(facility => facility.Name.Trim() == facility_id).Select(facility => facility.Id).First()) 
            });
            ApartamentFacilities = Context.LoadEntities<ApartamentFacilities>();
            OnPostUpdateSum();
        }

        public void OnPostInsertService(int apartament_id, string service_id)
        {
            Context.Insert(new IncludedServices { 
                ApartamentId = apartament_id, 
                ServiceId = Convert.ToInt32(Services.Where(service => service.Name.Trim() == service_id.Substring(0, service_id.IndexOf(" | "))).Select(service => service.Id).First()) 
            });
            IncludedServices = Context.LoadEntities<IncludedServices>();
            OnPostUpdateSum();
        }
    }
}
