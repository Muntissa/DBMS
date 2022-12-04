using System.Data;

namespace DBMS.Api.Entities
{
    public class Booking : BaseEntity
    {
        private Apartament? _apartament;

        [EntityPropertyDesc("apartament_id")]
        public int ApartamentId { get; set; }
        
        private Client? _client;

        [EntityPropertyDesc("client_id")]
        public int ClientId { get; set; }

        public Apartament? Apartament { get { if (_apartament is null) _apartament = Context.LoadSingle<Apartament>(ApartamentId); return _apartament; } }
        public Client? Client { get { if (_client is null) _client = Context.LoadSingle<Client>(ClientId); return _client; } }

        [EntityPropertyDesc("booking_firstdate")]
        public DateTime FirstDate { get; set; }
        
        [EntityPropertyDesc("booking_seconddate")]
        public DateTime EndDate { get; set; }

        [EntityPropertyDesc("booking_sumprice")]
        public int? SumPrice { get; set; }
        
        [EntityPropertyDesc("booking_reservation")]
        public bool Reservation { get; set; }

        public Booking(DataRow row) : base(row)
        {
            ApartamentId = Convert.ToInt32(row["apartament_id"]);
            ClientId = Convert.ToInt32(row["client_id"]);
            FirstDate = Convert.ToDateTime(row["booking_firstdate"]);
            EndDate = Convert.ToDateTime(row["booking_seconddate"]);
            SumPrice = Convert.ToInt32(row["booking_sumprice"]);
            Reservation = Convert.ToBoolean(row["booking_reservation"]);
        }

        public Booking() { }
    }
}