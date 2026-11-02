  using Microsoft.AspNetCore.Mvc.RazorPages;
//      ^^^^^^^^^ reference scip-dotnet nuget . . Microsoft/
//                ^^^^^^^^^^ reference scip-dotnet nuget . . AspNetCore/
//                           ^^^ reference scip-dotnet nuget . . Mvc/
//                               ^^^^^^^^^^ reference scip-dotnet nuget Microsoft.AspNetCore.Mvc.RazorPages 8.0.0.0 RazorPages/

  namespace RazorApp.Pages;
//          ^^^^^^^^ reference scip-dotnet nuget . . RazorApp/
//                   ^^^^^ reference scip-dotnet nuget . . Pages/

  public class IndexModel : PageModel
//             ^^^^^^^^^^ definition scip-dotnet nuget . . Pages/IndexModel#
//                        documentation ```cs\nclass IndexModel\n```
//                        relationship implementation scip-dotnet nuget Microsoft.AspNetCore.Mvc.RazorPages 8.0.0.0 RazorPages/PageModel#
//                        relationship implementation scip-dotnet nuget Microsoft.AspNetCore.Mvc.RazorPages 8.0.0.0 Filters/IAsyncPageFilter#
//                        relationship implementation scip-dotnet nuget Microsoft.AspNetCore.Mvc.RazorPages 8.0.0.0 Filters/IPageFilter#
//                        relationship implementation scip-dotnet nuget Microsoft.AspNetCore.Mvc.Abstractions 8.0.0.0 Filters/IFilterMetadata#
//                          ^^^^^^^^^ reference scip-dotnet nuget Microsoft.AspNetCore.Mvc.RazorPages 8.0.0.0 RazorPages/PageModel#
  {
      public string Greeting { get; set; } = "Hello";
//                  ^^^^^^^^ definition scip-dotnet nuget . . Pages/IndexModel#Greeting.
//                           documentation ```cs\npublic string IndexModel.Greeting { get; set; }\n```

      public string Shout(string name) => $"{Greeting}, {name}!";
//                  ^^^^^ definition scip-dotnet nuget . . Pages/IndexModel#Shout().
//                        documentation ```cs\npublic string IndexModel.Shout(string name)\n```
//                               ^^^^ definition scip-dotnet nuget . . Pages/IndexModel#Shout().(name)
//                                    documentation ```cs\nstring name\n```
//                                           ^^^^^^^^ reference scip-dotnet nuget . . Pages/IndexModel#Greeting.
//                                                       ^^^^ reference scip-dotnet nuget . . Pages/IndexModel#Shout().(name)

      public void OnGet()
//                ^^^^^ definition scip-dotnet nuget . . Pages/IndexModel#OnGet().
//                      documentation ```cs\npublic void IndexModel.OnGet()\n```
      {
          Greeting = "Welcome";
//        ^^^^^^^^ reference scip-dotnet nuget . . Pages/IndexModel#Greeting.
      }
  }
