using DBMS.Api.Entities;
using System.Data;
using System.Data.SqlClient;

namespace DBMS.Api
{
    public static class Context
    {
        public static string ConnectionString = $"Data Source={Environment.MachineName};Initial Catalog=university;Integrated Security=True";

        public static void InContext(Action<SqlConnection> action)
        {
            using var connection = new SqlConnection(ConnectionString);

            if (connection.State == ConnectionState.Closed)
                connection.Open();

            try
            {
                action(connection);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
        }

        static DataTable SelectDataTableByEntity<T>() where T : BaseEntity
        {
            var result = new DataTable();

            InContext((connection) =>
            {
                var command = new SqlCommand($"select * from {typeof(T).Name.ToLower()} order by id", connection);

                var dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(result);
            });

            return result;
        }

        private static DataTable LoadSingleData<T>(int id) where T : BaseEntity
        {
            var result = new DataTable();

            InContext(connection =>
            {
                SqlCommand command = new SqlCommand($"Select * from {typeof(T).Name.ToLower()} where id = {id} ", connection);

                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(result);
            });

            return result;
        }

        public static void Delete<T>(int id) where T : BaseEntity
        {
            InContext((connection) =>
            {
                var command = new SqlCommand($"Delete from {typeof(T).Name.ToLower()} where id = {id}", connection);
                command.ExecuteNonQuery();
            });
        }

        public static void Insert(object entity)
        {
            InContext((connection) =>
            {
                var command = new SqlCommand(GetSqlInsertCommand(entity), connection);
                command.ExecuteNonQuery();
            });
        }

        public static void Update<T>(int id, string name, string desc, int price) where T : Service
        {
            InContext((connection) =>
            {
                var command = new SqlCommand($"update {typeof(T).Name.ToLower()} set service_name = '{name}', service_description = '{desc}', service_price = {price} where id = {id}", connection);
                command.ExecuteNonQuery();
            });
        }

        public static T? LoadSingle<T>(int id) where T : BaseEntity { return (T?)Activator.CreateInstance(typeof(T), LoadSingleData<T>(id).Rows[0]); }

        public static IEnumerable<T> LoadEntities<T>() where T : BaseEntity
        {
            var listEntities = new List<T?>();

            foreach (DataRow dataRow in SelectDataTableByEntity<T>().Rows)
                listEntities.Add((T?)Activator.CreateInstance(typeof(T), dataRow));

            return listEntities.Where(e => e is not null);
        }

        public static void UpdateApartamentsPrices(IEnumerable<Apartament> list)
        {
            foreach (var apartament in list)
                Context.UpdatePriceApartament(apartament.Id);
        }

        public static void UpdateBookingPriceWithServices(int id) { Context.UpdateSumPriceBookingWithServices(id); }

        public static void UpdateBookingPriceWithoutServices(int id) { Context.UpdateSumPriceBookingWithoutServices(id); }

        public static int GetTableCount<T>() where T : BaseEntity
        {
            var result = 0;

            InContext((context) =>
            {
                using SqlCommand cmd = new SqlCommand("GetCount", context);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@tablename", SqlDbType.NVarChar).Value = typeof(T).Name.ToLower();

                var dataTable = new DataTable();
                var dataAdapter = new SqlDataAdapter(cmd);
                dataAdapter.Fill(dataTable);

                result = Convert.ToInt32(dataTable.Rows[0][0]);
            });

            return result;
        }

        public static string GetSqlInsertCommand(object entity)
        {
            var type = entity.GetType();
            var valuedNames = new Dictionary<string, string?>();

            foreach (var prop in entity.GetProperties().Where(p => !p.Value.IsPK))
                valuedNames.Add(prop.Value.DbName.ToLower(), prop.Key.GetValue(entity)?.ToString() ?? null);

            return $"insert into {type.Name.ToLower()} ({string.Join(", ", valuedNames.Keys)}) values ({string.Join(", ", valuedNames.Select(s => s.Value is null ? "null" : $"'{s.Value}'"))})";
        }

        static void UpdatePriceApartament(int id)
        {
            InContext((connection) =>
            {
                using var cmd = new SqlCommand("UpdatePriceApartaments", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@identificator", SqlDbType.Int).Value = id;
                cmd.ExecuteNonQuery();
            });
        }

        static void UpdateSumPriceBookingWithServices(int id)
        {
            InContext((connection) =>
            {
                using var cmd = new SqlCommand("UpdateSumPriceBookingWithServices", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@identificator", SqlDbType.Int).Value = id;
                cmd.ExecuteNonQuery();
            });
        }

        static void UpdateSumPriceBookingWithoutServices(int id)
        {
            InContext((connection) =>
            {
                using var cmd = new SqlCommand("UpdateSumPriceBookingWithoutServices", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@identificator", SqlDbType.Int).Value = id;
                cmd.ExecuteNonQuery();
            });
        }
    }
}