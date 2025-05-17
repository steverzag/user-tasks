var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.UsersTasks_API>("userstasks-api");

builder.Build().Run();
