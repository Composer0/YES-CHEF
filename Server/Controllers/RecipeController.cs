﻿//Created using an API Controller - Empty

using Bard.Server.Data;
using Bard.Server.Services;
using Bard.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bard.Server.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class RecipeController : ControllerBase
	{ 
		private readonly IOpenAIAPI _openAIService;

		public RecipeController (IOpenAIAPI openAIService)
		{
			_openAIService = openAIService;
		}

		[HttpPost, Route("GetRecipeIdeas")]
		public async Task<ActionResult<List<Idea>>> GetRecipeIdeas(RecipeParms recipeParms)
		{
			string mealtime = recipeParms.MealTime;
			List<string> ingredients = recipeParms.Ingredients
						.Where(x => !string.IsNullOrEmpty(x.Description))
						.Select(x => x.Description)
						.ToList();
			if (string.IsNullOrEmpty(mealtime))
			{
				mealtime = "Breakfast";
			}

			var ideas = await _openAIService.CreateRecipeIdeas(mealtime, ingredients);

			return ideas;

			//return SampleData.RecipeIdeas;
		}
		//A type within a type within a type. :) ActionResult is used to return data to be displayed along with an appropriate HTTP status code. In our instance we are using it to grab List<Idea> model data to be rendered and displayed as a part of our Task

		[HttpPost, Route("GetRecipe")]
		public async Task<ActionResult<Recipe?>> GetRecipe(RecipeParms recipeParms)
		{
			//return SampleData.Recipe;
			List<string> ingredients = recipeParms.Ingredients
							.Where(x => !string.IsNullOrEmpty(x.Description)).Select(XmlConfigurationExtensions => XmlConfigurationExtensions.Description!).ToList();

			string? title = recipeParms.SelectedIdea;

			if (string.IsNullOrEmpty(title))
			{
				return BadRequest();
			}

			var recipe = await _openAIService.CreateRecipe(title, ingredients);
			return recipe;

        }

		[HttpGet, Route("GetRecipeImage")]
		public async Task<RecipeImage> GetRecipeImage(string title)
		{
			string description = "Description of the selected idea";
			//return SampleData.RecipeImage;
			var recipeImage = await _openAIService.CreateRecipeImage(title, description);
			return recipeImage ?? SampleData.RecipeImage;
		}
	}
}
