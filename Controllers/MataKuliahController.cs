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
    public class MataKuliahController: ControllerBase
    {
        private readonly IPerkuliahanRepository _repo;
        private readonly IMapper _mapper;

        public MataKuliahController(IPerkuliahanRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetMataKuliahs()
        {
            var mataKuliahs = await _repo.GetMataKuliahs();
            var mataKuliahsToReturn = _mapper.Map<IEnumerable<MataKuliahForListDto>>(mataKuliahs);
            return Ok(mataKuliahsToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMataKuliah(int id)
        {
            var mataKuliah = await _repo.GetMahasiswa(id);
            var mataKuliahsToReturn = _mapper.Map<MataKuliahForDetailDto>(mataKuliah);
            return Ok(mataKuliahsToReturn);
        }

        [HttpPost]
        public async Task<IActionResult> AddMataKuliah([FromBody] MataKuliahForCreate mataKuliahdto)
        {
            var mataKuliahToCreate = new MataKuliah
            {
                KodeMK = mataKuliahdto.KodeMK,
                NamaMK = mataKuliahdto.NamaMK,
                Sks = mataKuliahdto.Sks
            };

            _repo.Add(mataKuliahToCreate);
            if (await _repo.SaveAll())
            {
                return StatusCode(201);
            }
            return BadRequest("Terjadi Kesalahan");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMataKuliah(int id, [FromBody] MataKuliahForCreate matkulDto)
        {
            await _repo.UpdateMataKuliah(id, matkulDto);
            
            if (await _repo.SaveAll())
            {
                return StatusCode(200);
            }
            return BadRequest("Terjadi Kesalahan");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMataKuliah(int id)
        {
            var mataKuliahToDelete = await _repo.GetMataKuliah(id);

            _repo.Delete(mataKuliahToDelete);
            if (await _repo.SaveAll())
            {
                return StatusCode(200);
            }
            return BadRequest("Terjadi Kesalahan");
        }
        
    }
}