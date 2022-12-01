using System.Data;

namespace DBMS.Api.Entities
{
    public class BookingServices : BaseEntity
    {
        private Booking? _booking;
        private int _bookingId;

        private Service? _service;
        private int _serviceId;

        public Booking? Booking { get { if (_booking is null) _booking = Context.LoadSingle<Booking>(_bookingId); return _booking; } }
        public Service? Service { get { if (_service is null) _service = Context.LoadSingle<Service>(_serviceId); return _service; } }

        public BookingServices(DataRow row) : base(row) 
        {
            _bookingId = Convert.ToInt32(row["booking_id"]);
            _serviceId = Convert.ToInt32(row["service_id"]);
        }
    }
}
