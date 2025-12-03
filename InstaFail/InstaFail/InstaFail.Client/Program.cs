using Insta.Shared.Dal;
using Insta.Shared.Entities;
using InstaFail.Client.Dal;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddTransient<IPhotoDal, PhotoDal>();
builder.Services.AddTransient<ICommentDal, CommentDal>();

await builder.Build().RunAsync();