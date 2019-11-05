using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
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
        private readonly IPerkuliahanRepository _repo;
        private readonly IMapper _mapper;

        public DosenController(IPerkuliahanRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;

        }

        [HttpGet]
        public async Task<IActionResult> GetDosens()
        {
            var dosens = await _repo.GetDosens();
            var dosensToReturn = _mapper.Map<IEnumerable<DosenForListDto>>(dosens);
            return Ok(dosensToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDosen(int id)
        {
            var dosen = await _repo.GetDosen(id);
            var dosenToReturn = _mapper.Map<DosenForDetailDto>(dosen);
            return Ok(dosenToReturn);
        }

        // [HttpPost("daftar")]
        // public async Task<IActionResult> Daftar(DosenUDaftarDto dosenDto)
        // {
        //     if(await _repo.DosenExist(dosenDto.Nip))
        //         return BadRequest("nip sudah terdaftar");
        //     var dosenAkanDibuat = new Dosen
        //     {
        //         Nip = dosenDto.Nip,
        //         NamaDosen = dosenDto.NamaDosen
        //     };
        //     var dosenSudahDibuat = await _repo.Add(dosenAkanDibuat);
        //     return StatusCode(201);
        // }
    }
}