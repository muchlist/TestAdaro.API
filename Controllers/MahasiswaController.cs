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
    public class MahasiswaController: ControllerBase
    {
        private readonly IPerkuliahanRepository _repo;
        private readonly IMapper _mapper;

        public MahasiswaController(IPerkuliahanRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet("search/{search}")]
        public async Task<IActionResult> Search(string search)
        {
            var mahasiswas = await _repo.SearchMahasiswa(search);
            var mahasiswaToReturn = _mapper.Map<IEnumerable<MahasiswaForListDto>>(mahasiswas);
            return Ok(mahasiswaToReturn);
        }

        [HttpGet]
        public async Task<IActionResult> GetMahasiswas()
        {
            var mahasiswas = await _repo.GetMahasiswas();
            var mahasiswaToReturn = _mapper.Map<IEnumerable<MahasiswaForListDto>>(mahasiswas);
            return Ok(mahasiswaToReturn);
        }

        //URL /api/mahasiswa/paged?pageNumber=1&pageSize=5
        [HttpGet("paged")]
        public async Task<IActionResult> GetMahasiswasPaged([FromQuery]UserParams userParams)
        {
            var mahasiswas = await _repo.GetMahasiswasPaged(userParams);
            var mahasiswaToReturn = _mapper.Map<IEnumerable<MahasiswaForListDto>>(mahasiswas);

            Response.AddPagination(mahasiswas.Currentpage, mahasiswas.PageSize, 
                mahasiswas.TotalCount, mahasiswas.TotalPages);

            return Ok(mahasiswaToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMahasiswa(int id)
        {
            var mahasiswa = await _repo.GetMahasiswa(id);
            var mahasiswaToReturn = _mapper.Map<MahasiswaForDetailDto>(mahasiswa);
            return Ok(mahasiswaToReturn);
        }


        [HttpPost]
        public async Task<IActionResult> AddMahasiswa([FromBody] MahasiswaForCreate mahasiswaDto)
        {
            if (await _repo.MahasiswaExist(mahasiswaDto.Nim))
                return BadRequest("NIM sudah terdaftar");

            var mahasiswaToCreate = new Mahasiswa
            {
                Nim = mahasiswaDto.Nim,
                NamaMhs = mahasiswaDto.NamaMhs,
                TglLahir = mahasiswaDto.TglLahir,
                Alamat = mahasiswaDto.Alamat,
                JenisKelamin = mahasiswaDto.JenisKelamin
            };

            _repo.Add(mahasiswaToCreate);
            if (await _repo.SaveAll())
            {
                return StatusCode(201);
            }
            return BadRequest("Terjadi Kesalahan");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMahasiswa(int id, [FromBody] MahasiswaForCreate mahasiswaDto)
        {
            await _repo.UpdateMahasiswa(id, mahasiswaDto);
            
            if (await _repo.SaveAll())
            {
                return StatusCode(200);
            }
            return BadRequest("Terjadi Kesalahan");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMahasiswa(int id)
        {
            var mahasiswaToDelete = await _repo.GetMahasiswa(id);

            _repo.Delete(mahasiswaToDelete);
            if (await _repo.SaveAll())
            {
                return StatusCode(200);
            }
            return BadRequest("Terjadi Kesalahan");
        }
        
    }
}