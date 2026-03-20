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
