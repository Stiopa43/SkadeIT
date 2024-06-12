using DTO.TechnologyDto;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories.Interfaces;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnologyController : ControllerBase
    {
        private readonly IBaseIdRepository<Technology, int> technologyRepository;

        public TechnologyController(IBaseIdRepository<Technology, int> technologyRepository)
        {
            this.technologyRepository = technologyRepository;
        }
        [HttpGet]
        public List<Technology> GetAll()
        {
            return technologyRepository.All().ToList();
        }
        [HttpGet("id")]
        public Technology GetAll(int id)
        {
            return technologyRepository.Get(id);
        }
        [HttpPost]
        public Technology Create(CreateTechnologyDto technologydto)
        {
            return technologyRepository.InsertAndSave(technologydto.ToEntity());
        }
        [HttpDelete("id")]
        public bool Delete(int id)
        {
            return technologyRepository.DeleteAndSave(id);
        }

    }
}
