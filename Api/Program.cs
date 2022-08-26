using CrossCutting.Configuration;
using Domain.Contracts.v1;
using Domain.Handlers.v1;
using FluentValidation.AspNetCore;
using Infra.Data.Command;
using Infra.Data.Query.Contracts;
using Infra.Data.Query.Queries.v1;
using Infra.Service;
using MediatR;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.Converters.
                Add(new JsonStringEnumConverter()));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IAccountRepository, AccountRepository>();
builder.Services.AddSingleton<IGetAccountRepository, GetAccountRepository>();
builder.Services.AddSingleton<IBillRepository, BillRepository>();
builder.Services.AddSingleton<INotificationClient, NotificationClient>();
builder.Services.AddMediatR(typeof(AccountCommandHandler).Assembly, typeof(GetAccountQueryHandler).Assembly);
builder.Services.AddFluentValidationAutoValidation();
builder.Services.Configure<TransactionDbSettings>(options => builder.Configuration.GetSection(nameof(TransactionDbSettings)).Bind(options));
builder.Services.Configure<ReadOnlyDbSettings>(options => builder.Configuration.GetSection(nameof(ReadOnlyDbSettings)).Bind(options));
builder.Services.Configure<ClientSettings>(options => builder.Configuration.GetSection("ClientSettings").Bind(options));
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
