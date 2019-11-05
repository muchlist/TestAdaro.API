using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TesAdaro.API.Data;
using TesAdaro.API.Dtos;
using TesAdaro.API.Models;

namespace TesAdaro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DosenController : ControllerBase
    {
        private readonly IDosenRepository _repo;

        public DosenController(IDosenRepository repo)
        {
            _repo = repo;

        }

        [HttpPost("daftar")]
        public async Task<IActionResult> Daftar(DosenUDaftarDto dosenDto)
        {
            if(await _repo.DosenExists(dosenDto.Nip))
                return BadRequest("nip sudah terdaftar");
            var dosenAkanDibuat = new Dosen
            {
                Nip = dosenDto.Nip,
                NamaDosen = dosenDto.NamaDosen
            };
            var dosenSudahDibuat = await _repo.Daftar(dosenAkanDibuat);
            return StatusCode(201);
        }
    }
}