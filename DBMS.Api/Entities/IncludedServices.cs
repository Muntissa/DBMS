using System.Data;

namespace DBMS.Api.Entities
{
    public class IncludedServices : BaseEntity
    {
        private Apartament? _apartament;
        private int _apartamentId;

        private Service? _service;
        private int _serviceId;

        public Apartament? Apartament { get { if (_apartament is null) _apartament = Context.LoadSingle<Apartament>(_apartamentId); return _apartament; } }
        public Service? Service{ get { if (_service is null) _service = Context.LoadSingle<Service>(_serviceId); return _service; } }

        public IncludedServices(DataRow row) : base(row)
        {
            _apartamentId = Convert.ToInt32(row["apartament_id"]);
            _serviceId = Convert.ToInt32(row["serivce_id"]);
        }
    }
}
