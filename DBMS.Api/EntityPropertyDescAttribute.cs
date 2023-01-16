using DBMS.Api.Entities;
using System.Reflection;

namespace DBMS.Api
{
	/// <summary>
	/// Описание свойства сущности
	/// </summary>
	public class EntityPropertyDescAttribute : Attribute
	{
		public EntityPropertyDescAttribute(string dbName, bool isPk = false, bool toDelete = false)
		{
			Description = new DescriptionPart(dbName, isPk, toDelete);
		}

		public DescriptionPart Description { get; set; }
	}

	public class DescriptionPart
	{
		public DescriptionPart(string dbName, bool isPk, bool toDelete)
		{
			DbName = dbName;
			ToDelete = toDelete;
			IsPK = isPk;
		}

		/// <summary>
		/// Имя в БД
		/// </summary>
		public string DbName { get; set; }
		public bool ToDelete { get; set; }

		/// <summary>
		/// Первичный-ли ключ
		/// </summary>
		public bool IsPK { get; set; }
	}

	public static class EntittyDescriptionExtensions
	{
		public static Dictionary<PropertyInfo, DescriptionPart> GetProperties(this object obj)
		{
			var result = new Dictionary<PropertyInfo, DescriptionPart>();

			foreach (var prp in obj.GetType().GetProperties())
			{
				var propDesc = ((EntityPropertyDescAttribute?)Attribute.GetCustomAttribute(prp, typeof(EntityPropertyDescAttribute)))?.Description;
				if (propDesc != null)
					result.Add(prp, propDesc);
			}

			return result;
		}
	}
}