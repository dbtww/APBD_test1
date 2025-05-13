using APBD_test01.Exceptions;
using APBD_test01.Models.DTOs;
using APBD_test01.Services;
using Microsoft.Data.SqlClient;

namespace Tutorial9.Services;

public class DbService : IDbService
{
    private readonly string _connectionString;
    public DbService(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("Default");
    }
    
public async Task<int> CreateBookingRequestAsync(CreateBookingRequestDTO createBookingRequestDto)
{
    await using var connection = new SqlConnection(_connectionString);
    await connection.OpenAsync();
    await using var transaction = await connection.BeginTransactionAsync();

    try
    {
        var bookingExistsCmd =
            new SqlCommand("SELECT 1 FROM Booking WHERE ID= @ID", connection, (SqlTransaction)transaction);
        using (var reader = await bookingExistsCmd.ExecuteReaderAsync())
        {
            if (!await reader.ReadAsync())
                throw new NotFoundException("Booking not found");
        }

        var guestExistsCmd =
            new SqlCommand("SELECT 1 FROM Guest WHERE ID = @ID", connection, (SqlTransaction)transaction);
        using (var reader = await guestExistsCmd.ExecuteReaderAsync())
        {
            if (!await reader.ReadAsync())
                throw new NotFoundException("Guest not found");
        }

        var employeeExistsCmd =
            new SqlCommand("SELECT 1 FROM Employee WHERE ID = @ID", connection, (SqlTransaction)transaction);
        using (var reader = await employeeExistsCmd.ExecuteReaderAsync())
        {
            if (!await reader.ReadAsync())
                throw new NotFoundException("Guest not found");
        }
    
}