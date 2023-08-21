using Bard.Shared;

namespace Bard.Server.Services
{
	public interface IOpenAIAPI
	{

		Task<List<Idea>> CreateRecipeIdeas(string mealtime, List<string> ingredients);

	}
}
