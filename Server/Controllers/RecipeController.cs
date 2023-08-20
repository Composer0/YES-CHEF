//Created using an API Controller - Empty

using Bard.Server.Data;
using Bard.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bard.Server.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class RecipeController : ControllerBase
	{
		[HttpPost, Route("GetRecipeIdeas")]
		public async Task<ActionResult<List<Idea>>> GetRecipeIdeas(RecipeParms recipeParms)
		{
			return SampleData.RecipeIdeas;
		}
			//A type within a type within a type. :) ActionResult is used to return data to be displayed along with an appropriate HTTP status code. In our instance we are using it to grab List<Idea> model data to be rendered and displayed as a part of our Task

	}
}
