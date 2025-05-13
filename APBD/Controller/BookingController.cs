using APBD_test01.Exceptions;
using APBD_test01.Models.DTOs;
using APBD_test01.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBD_test01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IDbService _dbService;

        public BookingController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet("{id}/bookings")]
        public async Task<IActionResult> GetGuestBooking(int id)
        {
            try
            {
                var res = await _dbService.GetBookingForGuestByIdAsync(id);
                return Ok(res);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost("{id}/bookings")]
        public async Task<IActionResult> addNewBooking(int id, CreateBookingRequestDTO createBookingDTO)
        {
            if (!createBookingDTO.Bookings.Any())
            {
                return ArgumentException("At least one item is required.");
            }

            try
            {
                await _dbService.CreateBookingRequestAsync(id, createBookingDTO);
            }
            catch (ConflictException e)
            {
                return ConflictException(e.Message);
            }
            catch (NotFoundException e)
            {
                return NotFoundException(e.Message);
            }

            return CreatedAtAction(nameof(getGuestBookings), new { id }, createBookingDTO);
        }
    }
}

