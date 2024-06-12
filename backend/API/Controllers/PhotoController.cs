using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories.Interfaces;
using Services;

namespace API.Controllers
{
    public class PhotoController : BaseController
    {
        private readonly IPhotoRepository photoRepository;

        public PhotoController(IPhotoRepository photoRepository)
        {
            this.photoRepository = photoRepository;
        }
        [HttpGet("Photos")]
        public List<ProjectPhoto> GetPhotos()
        {
            return photoRepository.GetActivePhotos().ToList();
        }
    }
}
