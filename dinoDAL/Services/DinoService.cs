using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;

using Dino.Common.Repositories;
using Dino.DAL.Mappers;
using Entities = Dino.DAL.Entities;

namespace Dino.DAL.Services;

public class DinoService : BaseService, IDinoRepository<Entities.Dino>
{
    public DinoService(IConfiguration configuration) : base(configuration, "localDB") { }

    public Entities.Dino? Get(int id)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            using (SqlCommand command = new SqlCommand("SELECT * FROM Dino WHERE Id = @Id", connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return reader.ToDino();
                    }
                    return null;
                }
            }
        }

    }

    public IEnumerable<Entities.Dino> Get()
    {
        List<Entities.Dino> dinos = new List<Entities.Dino>();
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            using (SqlCommand command = new SqlCommand("SELECT * FROM Dino", connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dinos.Add(reader.ToDino());
                    }
                }
            }
        }
        return dinos;
    }

    public Entities.Dino Create(Entities.Dino entity)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            using (SqlCommand command = new SqlCommand("INSERT INTO Dino  OUTPUT INSERTED.Id VALUES (@Espece,@LengthMeters,@WeightKg)", connection))
            {
                command.Parameters.AddWithValue("@Espece", entity.Espece);
                command.Parameters.AddWithValue("@LengthMeters", entity.LengthMeters);
                command.Parameters.AddWithValue("@WeightKg", entity.WeightKg);
                entity.Id = (int)command.ExecuteScalar();
                return entity;
            }
        }
    }

    public Entities.Dino Update(Entities.Dino entity)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            using (SqlCommand command = new SqlCommand("UPDATE Dino SET Espece = @Espece, Length_Meters = @LengthMeters, Weight_Kg = @WeightKg WHERE Id = @Id", connection))
            {
                command.Parameters.AddWithValue("@Id", entity.Id);
                command.Parameters.AddWithValue("@Espece", entity.Espece);
                command.Parameters.AddWithValue("@LengthMeters", entity.LengthMeters);
                command.Parameters.AddWithValue("@WeightKg", entity.WeightKg);
                command.ExecuteNonQuery();
                return entity;
            }
        }
    }

    public void Delete(int id)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            using (SqlCommand command = new SqlCommand("DELETE FROM Dino WHERE Id = @Id", connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }
        }
    }
}
