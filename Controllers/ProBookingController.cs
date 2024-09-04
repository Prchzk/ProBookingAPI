using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProBookingAPI.Models;
using ProBookingAPI.Data;

namespace ProBookingAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProBookingController : ControllerBase
    {
        private readonly ApiContext _context;

        public ProBookingController(ApiContext context)
        {
            _context = context;
        }

        [HttpPost]
        public JsonResult CreateEdit(ProBookingModel booking)
        {
            if (booking.Id == 0)
            {
                _context.Bookings.Add(booking);
            }
            else
            {
                var bookingInDb = _context.Bookings.Find(booking.Id);

                if (bookingInDb == null)
                {
                    return new JsonResult(NotFound());
                }

                bookingInDb = booking;
            }

            _context.SaveChanges();

            return new JsonResult(Ok(booking));
        }

        [HttpGet]
        public JsonResult Get(int id)
        {
            var result = _context.Bookings.Find(id);

            if (result == null)
            {
                return new JsonResult(NotFound());
            }

            return new JsonResult(Ok(result));
        }

        [HttpGet]
        public JsonResult GetAll()
        {
            var result = _context.Bookings.ToList();

            return new JsonResult(Ok(result));
        }

        [HttpDelete]
        public JsonResult Delete(int id)
        {
            var result = _context.Bookings.Find(id);

            if (result == null)
            {
                return new JsonResult(NotFound());
            }

            _context.Bookings.Remove(result);
            _context.SaveChanges();

            return new JsonResult(NoContent());
        }
    }
}
