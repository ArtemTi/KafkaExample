using Confluent.Kafka;
using KafkaExample.Api;
using KafkaExample.App;
using KafkaExample.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

var kafkaServers = builder.Configuration.GetSection("KafkaServers");
if (kafkaServers == null) throw new ArgumentException("Cannot parse kafka servers section");

var kafkaSettings = new SimpleKafkaSettings(kafkaServers.Value);
builder.Services.AddSingleton(new KafkaProducer(kafkaSettings));
builder.Services.AddTransient<UserDataService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
