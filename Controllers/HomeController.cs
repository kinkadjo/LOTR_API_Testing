using LOTR_API_Testing.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Http.Headers;

namespace LOTR_API_Testing.Controllers
{
    public class HomeController : Controller
    {        
        public IActionResult Index()
        {
            ViewModel viewModel = new();
            return View(viewModel);
        }    

        public async Task<IActionResult> GetQuote(string characterId)
        {
            ViewModel viewModel = new();
            if (characterId != "")
            {
                string result = string.Empty;

                HttpClient client = new();

                // Get the response and content
                HttpResponseMessage response = await client.GetAsync("https://localhost:1941/Quote?author=" + characterId);
                HttpContent responseContent = response.Content;

                // Get the stream of the content
                using (StreamReader reader = new(await responseContent.ReadAsStreamAsync()))
                {
                    result = await reader.ReadToEndAsync();                    
                }
                
                viewModel.Quote = result;
            }

            if (viewModel.Quote == "")
            {
                viewModel.Quote = "Not quotes for the selected Character";
            }

            return View("Index", viewModel);
        }

        public async Task<IActionResult> GetRandom()
        {
            ViewModel viewModel = new();
            
            string result = string.Empty;
            string characterId = string.Empty;

            HttpClient client = new();

            // Get the response and content from random character
            HttpResponseMessage response = await client.GetAsync("https://localhost:1941/RandomCharacter");
            HttpContent responseContent = response.Content;

            // Get the stream of the content from random character
            using (StreamReader reader = new(await responseContent.ReadAsStreamAsync()))
            {
                characterId = await reader.ReadToEndAsync();
            }

            if (characterId != "")
            {                
                // Get the response and content from the character quote
                response = await client.GetAsync("https://localhost:1941/Quote?author=" + characterId);
                responseContent = response.Content;

                // Get the stream of the content
                using (StreamReader reader = new(await responseContent.ReadAsStreamAsync()))
                {
                    result = await reader.ReadToEndAsync();
                }
                viewModel.Quote = result;                                                                                                
            }

            if (viewModel.Quote == "")
            {
                viewModel.Quote = "No quote for character";
            }

            return View("Index", viewModel);
        }
    }
}
