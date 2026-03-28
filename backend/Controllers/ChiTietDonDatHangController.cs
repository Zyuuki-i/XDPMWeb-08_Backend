using backend.Models;
using backend.MyModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChiTietDonDatHangController : ControllerBase
    {
        private ZyuukiMusicStoreContext db = new ZyuukiMusicStoreContext();
        [HttpGet]
        public IActionResult getDSChitietdondathang()
        {
            try
            {
                var data = db.ChiTietDonDatHangs.Select(t => new
                {
                    t.MaDdh,
                    t.MaSp,
                    t.Soluong,
                    t.Gia,
                    t.Thanhtien
                }).ToList();
                return Ok(data);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("DonDatHang/{maddh}")]
        public IActionResult getDSChitietdondathang(int maddh)
        {
            try
            {
                var data = db.ChiTietDonDatHangs.Where(x=>x.MaDdh==maddh).Select(t => new
                {
                    t.MaDdh,
                    t.MaSp,
                    t.Soluong,
                    t.Gia,
                    t.Thanhtien
                }).ToList();
                return Ok(data);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("SanPham/{masp}")]
        public IActionResult getDSChitietdondathangByMasp(string masp)
        {
            try
            {
                var data = db.ChiTietDonDatHangs.Where(x => x.MaSp == masp).Select(t => new
                {
                    t.MaDdh,
                    t.MaSp,
                    t.Soluong,
                    t.Gia,
                    t.Thanhtien
                }).ToList();
                return Ok(data);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult themCTDDH([FromBody] CChiTietDonDatHang ct)
        {
            try
            {
                if (ct == null)
                    return BadRequest();
                ChiTietDonDatHang c = new ChiTietDonDatHang();
                c.MaDdh = ct.MaDdh;
                c.MaSp = ct.MaSp;
                c.Soluong = ct.Soluong;
                c.Gia = ct.Gia;
                c.Thanhtien = ct.Thanhtien;

                db.ChiTietDonDatHangs.Add(c);
                db.SaveChanges();

                return Ok(ct);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult suaCTDDH([FromBody] CChiTietDonDatHang dto)
        {
            try
            {
                ChiTietDonDatHang? ct = db.ChiTietDonDatHangs.Where(t => t.MaDdh == dto.MaDdh && t.MaSp == dto.MaSp).FirstOrDefault();
                if (ct == null) return NotFound();

                ct.Soluong = dto.Soluong;
                ct.Gia = dto.Gia;
                ct.Thanhtien= dto.Thanhtien;

                db.SaveChanges();

                return Ok(ct);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{maddh}")]
        public IActionResult xoaCTDDH(int maddh)
        {
            try
            {
                var list = db.ChiTietDonDatHangs
                    .Where(x => x.MaDdh == maddh)
                    .ToList();

                if (list.Count == 0)
                    return NotFound();

                db.ChiTietDonDatHangs.RemoveRange(list);
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
