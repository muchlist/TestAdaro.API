using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TesAdaro.API.Data;
using TesAdaro.API.Dtos;
using TesAdaro.API.Helpers;
using TesAdaro.API.Models;

namespace TesAdaro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerkuliahanController: ControllerBase
    {
        private readonly IPerkuliahanRepository _repo;
        private readonly IMapper _mapper;

        public PerkuliahanController(IPerkuliahanRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetPerkuliahans()
        {
            var perkuliahans = await _repo.GetPerkuliahans();
            var perkuliahansToReturn = _mapper.Map<IEnumerable<PerkuliahanForDetailedDto>>(perkuliahans);
            return Ok(perkuliahansToReturn);
        }

        //URL /api/perkuliahan/paged?pageNumber=1&pageSize=5
        [HttpGet("paged")]
        public async Task<IActionResult> GetPerkuliahansPaged([FromQuery]UserParams userParams)
        {
            var perkuliahans = await _repo.GetPerkuliahansPaged(userParams);
            var perkuliahansToReturn = _mapper.Map<IEnumerable<PerkuliahanForDetailedDto>>(perkuliahans);

            Response.AddPagination(perkuliahans.Currentpage, perkuliahans.PageSize, 
                perkuliahans.TotalCount, perkuliahans.TotalPages);

            return Ok(perkuliahansToReturn);
        }

        [HttpGet("search/{search}")]
        public async Task<IActionResult> Search(string search)
        {
            var perkuliahans = await _repo.SearchDosen(search);
            var perkuliahansToReturn = _mapper.Map<IEnumerable<PerkuliahanForDetailedDto>>(perkuliahans);
            return Ok(perkuliahansToReturn);
        }

        [HttpGet("mhs/{id}")]
        public async Task<IActionResult> GetPerkuliahanPerMhs(int id)
        {
            var perkuliahans = await _repo.GetPerkuliahanPerMhs(id);
            var perkuliahansToReturn = _mapper.Map<IEnumerable<PerkuliahanForDetailedDto>>(perkuliahans);
            return Ok(perkuliahansToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPerkuliahan(int id)
        {
            var perkuliahan = await _repo.GetPerkuliahan(id);
            var perkuliahanToReturn = _mapper.Map<PerkuliahanForDetailedDto>(perkuliahan);
            return Ok(perkuliahanToReturn);
        }

        [HttpPost]
        public async Task<IActionResult> AddPerkuliahan([FromBody] PerkuliahanForCreateDto perkuliahanDto)
        {
            var dosen = await _repo.GetDosen(perkuliahanDto.DosenId);
            var mahasiswa = await _repo.GetMahasiswa(perkuliahanDto.MahasiswaId);
            var mataKuliah = await _repo.GetMataKuliah(perkuliahanDto.MataKuliahId);

            var perkuliahanToCreate = new Perkuliahan
            {
                Dosen = dosen,
                DosenId = perkuliahanDto.DosenId,
                MahasiswaId = perkuliahanDto.MahasiswaId,
                Mahasiswa = mahasiswa,
                MataKuliah = mataKuliah,
                MataKuliahId = perkuliahanDto.MataKuliahId,
                Nilai = perkuliahanDto.Nilai
            };

            _repo.Add(perkuliahanToCreate);
            if (await _repo.SaveAll())
            {
                return StatusCode(201);
            }
            return BadRequest("Terjadi Kesalahan");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePerkuliahan(int id, [FromBody] PerkuliahanForCreateDto perkuliahanDto)
        {
            await _repo.UpdatePerkuliahan(id, perkuliahanDto);
            
            if (await _repo.SaveAll())
            {
                return StatusCode(200);
            }
            return BadRequest("Terjadi Kesalahan");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerkuliahan(int id)
        {
            var perkuliahanToDelete = await _repo.GetPerkuliahan(id);

            _repo.Delete(perkuliahanToDelete);
            if (await _repo.SaveAll())
            {
                return StatusCode(200);
            }
            return BadRequest("Terjadi Kesalahan");
        }
    }
}