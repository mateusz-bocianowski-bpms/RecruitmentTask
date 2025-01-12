using System.Net;
using System.Text;

using Newtonsoft.Json;

using CardProcessing.Service.Contract;
using FluentAssertions;

namespace CardProcessing.Service.AcceptanceTests;

[TestFixture]
public class AllowedCardActionsTests
{
    private const string ApiUrl = "https://localhost:1001";
    private const string PostUrl = "api/allowedcardactions";

    private HttpClient? cardProcessingClient;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        cardProcessingClient = new HttpClient();
        cardProcessingClient.BaseAddress = new Uri(ApiUrl);
    }

    [OneTimeTearDown]
    public void OneTimeCleanUp()
    {
        cardProcessingClient!.Dispose();
    }

    [Test]
    public async Task PostAsync_CardType_Prepaid_CardStatus_Closed()
    {
        // Arrange
        var expectedActions = new List<string> { "ACTION3", "ACTION4", "ACTION9" };

        var postRequest = new AllowedCardActionsRequest
        {
            UserId = "User1",
            CardNumber = "Card17"
        };
        var content = JsonConvert.SerializeObject(postRequest);
        var postContent = new StringContent(content, Encoding.UTF8,"application/json");

        // Act
        var response = await cardProcessingClient!.PostAsync(PostUrl, postContent);

        // Assert
        response.IsSuccessStatusCode.Should().BeTrue();
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var responseContent = await response.Content.ReadAsStringAsync();
        var postResponse = JsonConvert.DeserializeObject<AllowedCardActionsResponse>(responseContent);

        postResponse!.AllowedActions.Should().NotBeNull();
        postResponse.AllowedActions.Should().BeEquivalentTo(expectedActions);
    }

    [Test]
    public async Task PostAsync_CardType_Credit_CardStatus_Blocked_IsPinSet_False()
    {
        // Arrange
        var expectedActions = new List<string> { "ACTION3", "ACTION4", "ACTION5", "ACTION8", "ACTION9" };

        var postRequest = new AllowedCardActionsRequest
        {
            UserId = "User1",
            CardNumber = "Card119"
        };
        var content = JsonConvert.SerializeObject(postRequest);
        var postContent = new StringContent(content, Encoding.UTF8,"application/json");

        // Act
        var response = await cardProcessingClient!.PostAsync(PostUrl, postContent);

        // Assert
        response.IsSuccessStatusCode.Should().BeTrue();
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var responseContent = await response.Content.ReadAsStringAsync();
        var postResponse = JsonConvert.DeserializeObject<AllowedCardActionsResponse>(responseContent);

        postResponse!.AllowedActions.Should().NotBeNull();
        postResponse.AllowedActions.Should().BeEquivalentTo(expectedActions);
    }
}