using System.Data;

namespace DBMS.Api.Entities
{
    public class Booking : BaseEntity
    {
        private Apartament? _apartament;
        private int ApartamentId { get; set; }
        
        private Client? _client;
        private int ClientId { get; set; }
        
        private DateTime _firstdate;
        private DateTime _seconddate;

        public Apartament? Apartament { get { if (_apartament is null) _apartament = Context.LoadSingle<Apartament>(ApartamentId); return _apartament; } }
        public Client? Client { get { if (_client is null) _client = Context.LoadSingle<Client>(ClientId); return _client; } }
        public string FirstDate { get { return _firstdate.ToString("dd/MM/yyyy"); } }
        public string EndDate { get { return _seconddate.ToString("dd/MM/yyyy"); } }
        public int? SumPrice { get; set; }
        public bool Reservation { get; set; }

        public Booking(DataRow row) : base(row)
        {
            ApartamentId = Convert.ToInt32(row["apartament_id"]);
            ClientId = Convert.ToInt32(row["client_id"]);
            _firstdate = Convert.ToDateTime(row["booking_firstdate"]);
            _seconddate = Convert.ToDateTime(row["booking_seconddate"]);
            SumPrice = Convert.ToInt32(row["booking_sumprice"]);
            Reservation = Convert.ToBoolean(row["booking_reservation"]);
        }
    }
}