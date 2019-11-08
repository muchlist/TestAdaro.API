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

        [HttpGet("search/{search}")]
        public async Task<IActionResult> Search(string search)
        {
            var dosens = await _repo.SearchDosen(search);
            var dosensToReturn = _mapper.Map<IEnumerable<DosenForListDto>>(dosens);
            return Ok(dosensToReturn);
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
        public async Task<IActionResult> AddDosen([FromBody]DosenForCreateDto dosenDto)
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

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDosen(int id, [FromBody]DosenForCreateDto dosenDto)
        {
            await _repo.UpdateDosen(id, dosenDto);
            
            if (await _repo.SaveAll())
            {
                return StatusCode(200);
            }
            return BadRequest("Terjadi Kesalahan");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDosen(int id)
        {
            var dosenToDelete = await _repo.GetDosen(id);

            _repo.Delete(dosenToDelete);
            if (await _repo.SaveAll())
            {
                return StatusCode(200);
            }
            return BadRequest("Terjadi Kesalahan");
        }

    }
}