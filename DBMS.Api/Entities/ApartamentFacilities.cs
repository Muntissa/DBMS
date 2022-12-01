using System.Data;

namespace DBMS.Api.Entities
{
	public class ApartamentFacilities : BaseEntity
    {
        private Apartament? _apartament;
        public int ApartamentId { get; set; }

        private Facility? _facility;
        private int FacilityId { get; set; }

        public Apartament? Apartament { get { if (_apartament is null) _apartament = Context.LoadSingle<Apartament>(ApartamentId); return _apartament; } }
        public Facility? Facility { get { if (_facility is null) _facility = Context.LoadSingle<Facility>(FacilityId); return _facility; } }

        public ApartamentFacilities(DataRow row) : base(row) 
        {
            ApartamentId = Convert.ToInt32(row["apartament_id"]);
            FacilityId = Convert.ToInt32(row["facility_id"]);
        }
    }
}