using APBD_test01.Models.DTOs;

namespace APBD_test01.Services;

public interface IDbService
{
    Task<int> CreateBookingRequestAsync(CreateBookingRequestDTO createBookingRequestDTO);
}