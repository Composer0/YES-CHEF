# YES CHEF!

## Description

"YES CHEF!" is a C# project that allows users to generate recipe ideas based on a list of ingredients and mealtime. The project utilizes OpenAI's GPT-3.5 Turbo model to provide users with creative and personalized recipe suggestions.

## Features

- Users can input a list of ingredients.
- Users can select the mealtime for which they want recipe ideas.
- Upon clicking the 'Generate' button, the application communicates with OpenAI's GPT-3.5 Turbo model to generate five recipe ideas.
- Users can select a recipe idea to view additional information.
- The recipe information includes an image, summary, list of ingredients, and cooking instructions.
- Users have the option to print the recipe for reference.

## Installation

To run the project locally, follow these steps:

1. Clone the repository:

   ```bash
   git clone https://github.com/yourusername/yes-chef.git
   cd yes-chef
   ```

2. Set up your OpenAI API key by updating the `appsettings.json` file with your key:

   ```json
   "OpenAi": {
       "OpenAiKey": "YOUR_API_KEY"
   }
   ```

3. Build and run the application using Visual Studio or the .NET CLI:

   ```bash
   dotnet build
   dotnet run
   ```

4. Access the application in your web browser at `http://localhost:5000`.

## Usage

1. Input a list of ingredients and select the mealtime.
2. Click the 'Generate' button to receive five recipe suggestions.
3. Select a recipe to view additional details, including an image, summary, ingredients, and instructions.
4. Print the recipe for reference.

## API Endpoints

- `POST /recipe/GetRecipeIdeas`: Generates recipe ideas based on ingredients and mealtime.
- `POST /recipe/GetRecipe`: Retrieves a specific recipe based on the selected idea.
- `GET /recipe/GetRecipeImage`: Retrieves a recipe image.

## Technologies Used

- C# (.NET 7)
- OpenAI GPT-3.5 Turbo
- ASP.NET Core
- Entity Framework Core
- HTML/CSS
- Bootstrap 5
- JavaScript

## License

This project is licensed under the [MIT License](LICENSE).

## Roadmap

- Add user authentication and profiles.
- Implement a rating and review system for recipes.
- Expand the database of recipes and ingredients.
