using System.Data;

namespace DBMS.Api.Entities
{
    public class BookingServices : BaseEntity
    {
        private Booking? _booking;

        [EntityPropertyDesc("booking_id")]
        public int BookingId;

        private Service? _service;

        [EntityPropertyDesc("service_id")]
        public int ServiceId;

        public Booking? Booking { get { if (_booking is null) _booking = Context.LoadSingle<Booking>(BookingId); return _booking; } }
        public Service? Service { get { if (_service is null) _service = Context.LoadSingle<Service>(ServiceId); return _service; } }

        public BookingServices(DataRow row) : base(row) 
        {
            BookingId = Convert.ToInt32(row["booking_id"]);
            ServiceId = Convert.ToInt32(row["service_id"]);
        }

        public BookingServices() { }
    }
}
