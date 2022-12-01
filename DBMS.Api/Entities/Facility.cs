using System.Data;

namespace DBMS.Api.Entities
{
    public class Facility : BaseEntity
    {
        public string? Name { get; set; }
        public Facility(DataRow row) : base(row) 
        {
            Name = row["facilities_name"].ToString();
        }
    }
}
