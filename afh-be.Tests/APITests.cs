using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

public class UserControllerTests : IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public UserControllerTests(CustomWebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetUser_ReturnsSuccessAndCorrectContentType()
    {
        // Arrange
        var userId = 2;

        // Act
        var response = await _client.GetAsync($"/User/{userId}");

        // Assert
        response.EnsureSuccessStatusCode(); // Status Code 200-299
        response.Content.Headers.ContentType.ToString().Should().Contain("application/json");
    }

    // [Fact]
    // public async Task GetUser_ReturnsCorrectUser()
    // {
    //     // Arrange
    //     var userId = 1;

    //     // Act
    //     var response = await _client.GetAsync($"/User/{userId}");

    //     // Assert
    //     response.EnsureSuccessStatusCode();
    //     var user = await response.Content.ReadFromJsonAsync<UserDto>();
    //     user.Should().NotBeNull();
    //     user.Id.Should().Be(userId);
    // }

    [Fact]
    public async Task GetUser_WithInvalidId_ReturnsNotFound()
    {
        // Arrange
        var invalidUserId = 9999;

        // Act
        var response = await _client.GetAsync($"/User/{invalidUserId}");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task GetUser_WithInvalidParameter_ReturnsBadRequest()
    {
        // Arrange
        var invalidUserId = "abc";

        // Act
        var response = await _client.GetAsync($"/User/{invalidUserId}");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    // [Fact]
    // public async Task GetUser_WithoutAuthorization_ReturnsUnauthorized()
    // {
    //     // Arrange
    //     var userId = 1;
    //     _client.DefaultRequestHeaders.Authorization = null; // Remove auth header

    //     // Act
    //     var response = await _client.GetAsync($"/api/users/{userId}");

    //     // Assert
    //     response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
    // }
}
