using backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NguoiDungController : ControllerBase
    {
        private ZyuukiMusicStoreContext db = new ZyuukiMusicStoreContext();

        [HttpGet("{id}")]
        public IActionResult getNguoidung(int id)
        {
            try
            {
                var nguoiDung = db.NguoiDungs.Find(id);
                if (nguoiDung == null)
                {
                    return NotFound();
                }
                var data = new
                {
                    nguoiDung.MaNd,
                    nguoiDung.Tennd,
                    nguoiDung.Matkhau,
                    nguoiDung.Sdt,
                    nguoiDung.Diachi,
                    nguoiDung.Phuongxa,
                    nguoiDung.Tinhthanh,
                    nguoiDung.Email,
                    nguoiDung.Hinh,
                    nguoiDung.Trangthai
                };
                return Ok(data);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        [HttpGet]
        public IActionResult getDSNguoidung()
        {
            try
            {
                var data = db.NguoiDungs.Select(t => new {
                    t.MaNd,
                    t.Tennd,
                    t.Matkhau,
                    t.Sdt,
                    t.Diachi,
                    t.Phuongxa,
                    t.Tinhthanh,
                    t.Email,
                    t.Hinh,
                    t.Trangthai
                }).ToList();
                return Ok(data);
            }
            catch (Exception)
            { return BadRequest(); }
        }
    }
}
