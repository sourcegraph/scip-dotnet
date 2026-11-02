using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorApp.Pages;

public class IndexModel : PageModel
{
    public string Greeting { get; set; } = "Hello";

    public string Shout(string name) => $"{Greeting}, {name}!";

    public void OnGet()
    {
        Greeting = "Welcome";
    }
}
