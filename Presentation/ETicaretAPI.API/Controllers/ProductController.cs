using ETicaretAPI.Application.Abstract;
using ETicaretAPI.Application.Repositories.ProductRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductWriteRepository _productWriteRepository;
        readonly private IProductReadRepository _productReadRepository;

        public ProductController(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
        }

        [HttpGet]
        public async void Get()
        {
           await  _productWriteRepository.AddRangeAsync(new()
            {
                new(){Id=Guid.NewGuid(),Name="Klavye",Price=100,CreatedDate=DateTime.UtcNow,Stock=10},
                new(){Id=Guid.NewGuid(),Name="Mouse",Price=150,CreatedDate=DateTime.UtcNow,Stock=100},
                new(){Id=Guid.NewGuid(),Name="Usb Bellek",Price=100,CreatedDate=DateTime.UtcNow,Stock=100},

            });
            var count=await _productWriteRepository.SaveAsync();
        }
    }
}
