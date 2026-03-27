using backend.Models;
using backend.MyModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonDatHangController : ControllerBase
    {
        private ZyuukiMusicStoreContext db = new ZyuukiMusicStoreContext();
        [HttpGet]
        public IActionResult getDSDondathang()
        {
            try
            {
                var data = db.DonDatHangs.Select(t => new {
                    t.MaDdh,
                    t.MaNd,
                    t.MaNv,
                    t.Nguoinhan,
                    t.Sdt,
                    t.Diachi,
                    t.Phuongxa,
                    t.Tinhthanh,
                    t.Ngaydat,
                    t.Tongtien,
                    t.Trangthai,
                    t.TtThanhtoan,
                    t.Phuongthuc,
                }).ToList();
                return Ok(data);
            }
            catch (Exception)
            { return BadRequest(); }
        }

        [HttpGet("{maddh}")]
        public IActionResult getDondathang(int maddh)
        {
            try
            {
                var data = db.DonDatHangs.Where(x => x.MaDdh == maddh).Select(t => new {
                    t.MaDdh,
                    t.MaNd,
                    t.MaNv,
                    t.Nguoinhan,
                    t.Sdt,
                    t.Diachi,
                    t.Phuongxa,
                    t.Tinhthanh,
                    t.Ngaydat,
                    t.Tongtien,
                    t.Trangthai,
                    t.TtThanhtoan,
                    t.Phuongthuc,
                }).FirstOrDefault();
                return Ok(data);
            }
            catch (Exception)
            { return BadRequest(); }
        }

        [HttpPost]
        public IActionResult themDonDatHang([FromBody] CDonDatHang dto)
        {
            try
            {
                if (dto == null)
                    return BadRequest();

                DonDatHang ddh = new DonDatHang
                {
                    MaNd = dto.MaNd,
                    MaNv = dto.MaNv,
                    Nguoinhan = dto.Nguoinhan,
                    Sdt = dto.Sdt,
                    Diachi = dto.Diachi,
                    Phuongxa = dto.Phuongxa,
                    Tinhthanh = dto.Tinhthanh,
                    Ngaydat = DateTime.Now,
                    Tongtien = dto.Tongtien,
                    Trangthai = dto.Trangthai,
                    TtThanhtoan = dto.TtThanhtoan,
                    Phuongthuc = dto.Phuongthuc
                };

                db.DonDatHangs.Add(ddh);
                db.SaveChanges();

                return Ok(ddh);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult suaDonDatHang(int id, [FromBody] CDonDatHang dto)
        {
            try
            {
                var ddh = db.DonDatHangs.Find(id);
                if (ddh == null)
                    return NotFound();

                ddh.MaNd = dto.MaNd;
                ddh.MaNv = dto.MaNv;
                ddh.Nguoinhan = dto.Nguoinhan;
                ddh.Sdt = dto.Sdt;
                ddh.Diachi = dto.Diachi;
                ddh.Phuongxa = dto.Phuongxa;
                ddh.Tinhthanh = dto.Tinhthanh;
                ddh.Tongtien = dto.Tongtien;
                ddh.Trangthai = dto.Trangthai;
                ddh.TtThanhtoan = dto.TtThanhtoan;
                ddh.Phuongthuc = dto.Phuongthuc;

                db.SaveChanges();

                return Ok(ddh);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult xoaDonDatHang(int id)
        {
            try
            {
                var ddh = db.DonDatHangs.Find(id);
                if (ddh == null)
                    return NotFound();

                db.DonDatHangs.Remove(ddh);
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
