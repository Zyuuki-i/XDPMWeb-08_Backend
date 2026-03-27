using backend.Models;
using backend.MyModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChiTietGiamGiaController : ControllerBase
    {
        private ZyuukiMusicStoreContext db = new ZyuukiMusicStoreContext();

        [HttpGet("NguoiDung/{mand}")]
        public IActionResult getChiTietGiamGiaByMand(int mand)
        {
            try
            {
                var data = db.ChiTietGiamGia
                    .Where(x => x.MaNd == mand
                        && x.Soluong > 0
                        && x.MaGgNavigation.Ngaybd <= DateTime.Now
                        && x.MaGgNavigation.Ngaykt >= DateTime.Now)
                    .Select(x => new
                    {
                        x.MaNd,
                        x.MaGgNavigation.MaGg,
                        x.Soluong
                    })
                    .ToList();

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{magg}")]
        public IActionResult getChiTietGiamGia(string magg)
        {
            try
            {
                var data = db.ChiTietGiamGia
                    .Where(x => x.MaGg == magg)
                    .Select(x => new
                    {
                        x.MaNd,
                        x.MaGgNavigation.MaGg,
                        x.Soluong
                    }).ToList();

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult getDSChiTietGiamGia()
        {
            try
            {
                var data = db.ChiTietGiamGia
                    .Select(x => new
                    {
                        x.MaNd,
                        x.MaGgNavigation.MaGg,
                        x.Soluong
                    })
                    .ToList();

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult themChiTietGiamGia([FromBody] CChiTietGiamGia dto)
        {
            try
            {
                ChiTietGiamGia ct = new ChiTietGiamGia
                {
                    MaGg = dto.MaGg,
                    Soluong = dto.Soluong,
                    MaNd = dto.MaNd,
                };

                db.ChiTietGiamGia.Add(ct);
                db.SaveChanges();

                return Ok(ct);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult suaChiTietGiamGia([FromBody] CChiTietGiamGia dto)
        {
            try
            {
                ChiTietGiamGia? ct = db.ChiTietGiamGia.Where(t => t.MaGg == dto.MaGg && t.MaNd == dto.MaNd).FirstOrDefault();
                if (ct == null) return NotFound();

                ct.Soluong = dto.Soluong;

                db.SaveChanges();

                return Ok(ct);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult xoaChiTietGiamGia([FromBody] CChiTietGiamGia dto)
        {
            try
            {
                ChiTietGiamGia? ct = db.ChiTietGiamGia.Where(t => t.MaGg == dto.MaGg && t.MaNd == dto.MaNd).FirstOrDefault();
                if (ct == null) return NotFound();

                db.ChiTietGiamGia.Remove(ct);
                db.SaveChanges();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //end
    }
}
