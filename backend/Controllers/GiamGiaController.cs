using backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiamGiaController : ControllerBase
    {
        private ZyuukiMusicStoreContext db = new ZyuukiMusicStoreContext();
        [HttpGet("{magg}")]
        public IActionResult getGiamGia(string magg)
        {
            try
            {
                var data = db.GiamGia
                    .Where(x => x.MaGg == magg)
                    .Select(x => new
                    {
                        x.MaGg,
                        x.Tenma,
                        x.Loaima,
                        x.Dieukien,
                        x.Phantramgiam,
                        x.Ngaybd,
                        x.Ngaykt,
                        x.Tongsl
                    }).FirstOrDefault();
                if(data == null) { return NotFound(); }
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult getDSGiamGia()
        {
            try
            {
                var data = db.GiamGia
                    .Select(x => new
                    {
                        x.MaGg,
                        x.Tenma,
                        x.Loaima,
                        x.Dieukien,
                        x.Phantramgiam,
                        x.Ngaybd,
                        x.Ngaykt,
                        x.Tongsl
                    }).ToList();

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //end
    }
}
