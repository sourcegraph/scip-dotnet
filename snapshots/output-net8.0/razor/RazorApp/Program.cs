  var builder = WebApplication.CreateBuilder(args);
//    ^^^^^^^ definition local 0
//            documentation ```cs\nWebApplicationBuilder? builder\n```
//              ^^^^^^^^^^^^^^ reference scip-dotnet nuget Microsoft.AspNetCore 8.0.0.0 Builder/WebApplication#
//                             ^^^^^^^^^^^^^ reference scip-dotnet nuget Microsoft.AspNetCore 8.0.0.0 Builder/WebApplication#CreateBuilder(+1).
//                                           ^^^^ reference scip-dotnet nuget . . ``/Program#`<Main>$`().(args)
  builder.Services.AddRazorPages();
//^^^^^^^ reference local 0
//        ^^^^^^^^ reference scip-dotnet nuget Microsoft.AspNetCore 8.0.0.0 Builder/WebApplicationBuilder#Services.
//                 ^^^^^^^^^^^^^ reference scip-dotnet nuget Microsoft.AspNetCore.Mvc 8.0.0.0 DependencyInjection/MvcServiceCollectionExtensions#AddRazorPages().
  var app = builder.Build();
//    ^^^ definition local 1
//        documentation ```cs\nWebApplication? app\n```
//          ^^^^^^^ reference local 0
//                  ^^^^^ reference scip-dotnet nuget Microsoft.AspNetCore 8.0.0.0 Builder/WebApplicationBuilder#Build().
  app.MapRazorPages();
//^^^ reference local 1
//    ^^^^^^^^^^^^^ reference scip-dotnet nuget Microsoft.AspNetCore.Mvc.RazorPages 8.0.0.0 Builder/RazorPagesEndpointRouteBuilderExtensions#MapRazorPages().
  app.Run();
//^^^ reference local 1
//    ^^^ reference scip-dotnet nuget Microsoft.AspNetCore 8.0.0.0 Builder/WebApplication#Run().
