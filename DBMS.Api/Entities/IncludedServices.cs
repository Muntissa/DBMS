using System.Data;

namespace DBMS.Api.Entities
{
    public class IncludedServices : BaseEntity
    {
        private Apartament? _apartament;

        [EntityPropertyDesc("apartament_id")]
        public int ApartamentId { get; set; }

        private Service? _service;

        [EntityPropertyDesc("serivce_id")]
        public int ServiceId { get; set; }

        public Apartament? Apartament { get { if (_apartament is null) _apartament = Context.LoadSingle<Apartament>(ApartamentId); return _apartament; } }
        public Service? Service{ get { if (_service is null) _service = Context.LoadSingle<Service>(ServiceId); return _service; } }

        public IncludedServices(DataRow row) : base(row)
        {
            ApartamentId = Convert.ToInt32(row["apartament_id"]);
            ServiceId = Convert.ToInt32(row["serivce_id"]);
        }

        public IncludedServices() { }
    }
}
