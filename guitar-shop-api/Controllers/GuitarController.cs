using guitar_shop_api.Models;
using guitar_shop_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace guitar_shop_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuitarController : ControllerBase
    {
        private readonly GuitarService _guitarService;

        public GuitarController(GuitarService guitarService)
        {
            _guitarService = guitarService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] GuitarModel guitarModel)
        {
            var result = await _guitarService.Create(guitarModel);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _guitarService.Get();
            return Ok(result);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> GetById([FromRoute] long id)
        {
            var result = await _guitarService.GetById(id);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] GuitarModel guitarModel)
        {
            var result = await _guitarService.Update(guitarModel);
            return Ok(result);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] long id)
        {
            var result = await _guitarService.Delete(id);
            return Ok(result);
        }
    }
}
