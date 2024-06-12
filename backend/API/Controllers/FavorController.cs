using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories.Interfaces;

namespace API.Controllers
{
    public class FavorController : BaseController
    {
        private readonly IBaseIdRepository<Favor, int> favorRepository;

        public FavorController(IBaseIdRepository<Favor, int> favorRepository)
        {
            this.favorRepository = favorRepository;
        }
        [HttpGet]
        public List<Favor> GetAll()
        {
            return favorRepository.All().ToList();
        }
    }
}
