using backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamController : ControllerBase
    {
        private ZyuukiMusicStoreContext db = new ZyuukiMusicStoreContext();
        [HttpGet]
        public IActionResult getDSSanpham()
        {
            try
            {
                var data = db.SanPhams
                    .Include(sp => sp.MaLoaiNavigation)
                    .Include(sp => sp.MaNsxNavigation)
                    .Select(t => new {
                    t.MaSp,
                    t.Tensp,
                    t.MaLoaiNavigation.Tenloai,
                    t.MaNsxNavigation.Tennsx,
                    t.MaNsx,
                    t.MaLoai,
                    t.Giasp,
                    t.Soluongton,
                    t.Mota
                }).ToList();
                return Ok(data);
            }
            catch (Exception)
            { return BadRequest(); }
        }
    }
}
