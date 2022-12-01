using System.Data;

namespace DBMS.Api.Entities
{
	public class Apartament : BaseEntity
    {
        private Tariff? _tariff;

        [EntityPropertyDesc("tarrif_id")]
        public int TariffId { get; set; }
        public Tariff? Tariff { get { if (_tariff is null) _tariff = Context.LoadSingle<Tariff>(TariffId); return _tariff; } }


        [EntityPropertyDesc("apartament_number")]
        public int Number { get; set; }


        [EntityPropertyDesc("apartament_picture")]
        public string? ImageUrl { get; set; }


        [EntityPropertyDesc("apartament_area")]
        public int Area { get; set; }


        [EntityPropertyDesc("apartament_price")]
        public int Price { get; set; }

        public Apartament(DataRow row) : base(row)
        {
            Number = Convert.ToInt32(row["apartament_number"]);
            TariffId = Convert.ToInt32(row["tariff_id"]);
            ImageUrl = row["apartament_picture"]?.ToString();
            Area = Convert.ToInt32(row["apartament_area"]);
            Price = Convert.ToInt32(row["apartament_price"]);
        }

        public Apartament() { }
    }
}