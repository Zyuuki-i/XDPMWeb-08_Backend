using backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DanhGiaController : ControllerBase
    {
        private ZyuukiMusicStoreContext db = new ZyuukiMusicStoreContext();

        [HttpGet("{mand}")]
        public IActionResult getDanhgia(int mand)
        {
            try
            {
                var data = db.DanhGia.Where(x => x.MaNd == mand).Select(t => new {
                    t.MaNd,
                    t.MaSp,
                    t.Noidung,
                    t.Sosao
                }).FirstOrDefault();
                return Ok(data);
            }
            catch (Exception)
            { return BadRequest(); }
        }

        [HttpGet]
        public IActionResult getDSDanhgia()
        {
            try
            {
                var data = db.DanhGia.Select(t => new {
                    t.MaNd,
                    t.MaSp,
                    t.Noidung,
                    t.Sosao
                }).ToList();
                return Ok(data);
            }
            catch (Exception)
            { return BadRequest(); }
        }

        [HttpGet("SanPham/{masp}")]
        public IActionResult getDSDanhgiaByMasp(string masp)
        {
            try
            {
                var query = db.DanhGia.Where(t => t.MaSp == masp).ToList();
                if (query.Count <= 0) return NotFound();
                var data = query.Select(
                    t => new {
                        t.MaNd,
                        t.MaSp,
                        t.Noidung,
                        t.Sosao
                    }).ToList();
                return Ok(data);
            }
            catch (Exception)
            { return BadRequest(); }
        }



        //end
    }
}
