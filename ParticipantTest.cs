namespace AspNetCoreApiMongoDBMeditatRTest;

public class ParticipantTest
{
    [Fact]
    public async Task CreateParticipantCommand()
    {
        // Arrange
        await using var application = new WebApplicationFactory<Program>();
        using var client = application.CreateClient();
        client.BaseAddress = new Uri("https://localhost:7255/");

        // Act
        Participant participant = new Participant()
        {
            Id = null,
            Name = "Willian Drovesky",
            Salary = 8799.00m,
            AddressStreet = "Rua Marcas",
            AddressNumber = 12,
            AddressSupplement = "",
            AddressZipCode = "30260-310",
            AddressCity = "Belo Horizonte",
            AddressState = "MG",
            Status = 1
        };
        var httpcontent = new StringContent(JsonConvert.SerializeObject(participant), Encoding.UTF8, "application/json");
        var response = await client.PostAsync("api/participant/add", httpcontent);
        var contents = await response.Content.ReadAsStringAsync();

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task ListParticipationCommand()
    {
        // Arrange
        await using var application = new WebApplicationFactory<Program>();
        using var client = application.CreateClient();
        client.BaseAddress = new Uri("https://localhost:7255/");

        // Act
        var httpcontent = new StringContent("{}", Encoding.UTF8, "application/json");
        var response = await client.PostAsync("api/participant/list", httpcontent);
        var contents = await response.Content.ReadAsStringAsync();

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}