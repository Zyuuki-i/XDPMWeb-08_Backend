using backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiaoHangController : ControllerBase
    {
        private ZyuukiMusicStoreContext db = new ZyuukiMusicStoreContext();

        [HttpGet]
        public IActionResult getDSGiaoHang()
        {
            try
            {
                var data = db.GiaoHangs.Select(t => new {
                    t.MaGh,
                    t.MaDdh,
                    t.MaNv,
                    t.Ngaybd,
                    t.Ngaykt,
                    t.Tongthu,
                    t.Trangthai
                }).ToList();
                return Ok(data);
            }
            catch (Exception)
            { return BadRequest(); }
        }

    }
}
