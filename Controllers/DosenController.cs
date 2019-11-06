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

        [HttpPost]
        public async Task<IActionResult> AddDosen(DosenUDaftarDto dosenDto)
        {
            if (await _repo.DosenExist(dosenDto.Nip))
                return BadRequest("Nip sudah terdaftar");

            var dosenToCreate = new Dosen
            {
                NamaDosen = dosenDto.NamaDosen,
                Nip = dosenDto.Nip
            };

            _repo.Add(dosenToCreate);
            if (await _repo.SaveAll())
            {
                return StatusCode(201);
            }
            return BadRequest("Terjadi Kesalahan");
        }

    }
}