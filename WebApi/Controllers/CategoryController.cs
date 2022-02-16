using ApplicationLayer.Queries.Categories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllCategory() => Ok(await Mediator.Send(new GetAllCategoriesQuery()));
    }
}
