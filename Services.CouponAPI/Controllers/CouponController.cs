using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services.CouponAPI.Data.Contexts;
using Services.CouponAPI.Data.Dtos;
using Services.CouponAPI.Data.Models;

namespace Services.CouponAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CouponController : ControllerBase
    {
        private readonly CouponContext _context;
        private readonly IMapper _mapper;

        public CouponController(CouponContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(CouponDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCouponById(int id)
        {
            var coupon = await _context.Coupons
                .Where(c => c.Id == id)
                .ProjectTo<CouponDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            if (coupon == null)
                return NotFound();

            return Ok(coupon);
        }

        [HttpGet]
        [ProducesResponseType(typeof(CouponDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCouponByCode(string code)
        {
            var coupon = await _context.Coupons
                .Where(c => c.Code.ToLower().Equals(code.ToLower()))
                .ProjectTo<CouponDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            if (coupon == null)
                return NotFound();

            return Ok(coupon);
        }

        [HttpGet]
        [ProducesResponseType(typeof(ICollection<CouponDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCoupons()
        {
            var coupons = await _context.Coupons
                .ProjectTo<CouponDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return Ok(coupons);
        }

        [HttpPost]
        [ProducesResponseType(typeof(CouponDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateCoupon([FromBody] CouponDto couponDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var coupon = _mapper.Map<Coupon>(couponDto);

            _context.Coupons.Add(coupon);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCouponById), new { id = coupon.Id }, coupon);
        }

        [HttpPut]
        [ProducesResponseType(typeof(CouponDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateCoupon([FromBody] CouponDto couponDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var coupon = await _context.Coupons
                .Where(c => c.Id == couponDto.Id)
                .FirstOrDefaultAsync();

            if (coupon == null)
                return NotFound();

            _mapper.Map(couponDto, coupon);

            _context.Coupons.Update(coupon);
            await _context.SaveChangesAsync();

            return Ok(coupon);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteCoupon(int id)
        {
            var coupon = await _context.Coupons
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();

            if (coupon == null)
                return NotFound();

            _context.Coupons.Remove(coupon);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
