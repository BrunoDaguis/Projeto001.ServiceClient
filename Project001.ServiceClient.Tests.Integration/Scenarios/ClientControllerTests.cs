
using FluentAssertions;
using Project001.ServiceClient.Tests.Integration.Factory;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Project001.ServiceClient.Tests.Integration.Scenarios
{
    public class ClientControllerTests : IClassFixture<WebApiTestFactory>
    {
        private readonly HttpClient _httpClient;

        public ClientControllerTests(WebApiTestFactory factory)
        {
            _httpClient = factory.CreateClient();

        }

        [Fact(DisplayName = "[Api] Actives Clients - Expected: OK")]
        public async Task Client_Get_ReturnsOkResponse()
        {
            _httpClient.SetFakeBearerToken(new { sub = Guid.NewGuid(), role = new[] { "Admin" } });

            var response = await _httpClient.GetAsync("/v1/api/client");

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact(DisplayName = "[Api] Actives Clients - Rule Invalid - Expected: Forbidden")]
        public async Task Client_GetWithRuleInvalid_ReturnsUnauthorizedResponse()
        {
            _httpClient.SetFakeBearerToken(new { sub = Guid.NewGuid(), role = new[] { "Employer" } });

            var response = await _httpClient.GetAsync("/v1/api/client");

            response.StatusCode.Should().Be(HttpStatusCode.Forbidden);
        }
        [Theory(DisplayName = "[Api] Get Client with valid Id - Retorno NoContent")]
        [InlineData(1)]
        public async Task Client_GetById_ReturnsOkResponse(int id)
        {
            _httpClient.SetFakeBearerToken(new { sub = Guid.NewGuid(), role = new[] { "Admin" } });

            var response = await _httpClient.GetAsync($"/v1/api/client/{id}");
            
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }
        [Theory(DisplayName = "[Api] Get client with invalid ID - Retorno NoContent")]
        [InlineData(-1)]
        public async Task Client_GetById_ReturnsBadRequestResponse(int id)
        {
            _httpClient.SetFakeBearerToken(new { sub = Guid.NewGuid(), role = new[] { "Admin" } });

            var response = await _httpClient.GetAsync($"/v1/api/client/{id}");
            
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        [Fact(DisplayName = "[Api] Get Clients repproveds - Retorno OK")]
        public async Task Client_GetRepproveds_ReturnOkResponse()
        {
            _httpClient.SetFakeBearerToken(new { sub = Guid.NewGuid(), role = new[] { "Admin" } });

            var response = await _httpClient.GetAsync("/v1/api/client/Repproved");
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact(DisplayName = "[Api] Get clients pending approval - Retorno OK")]
        public async Task Client_GetPendings_ReturnOkResponse()
        {
            _httpClient.SetFakeBearerToken(new { sub = Guid.NewGuid(), role = new[] { "Admin" } });

            var response = await _httpClient.GetAsync("/v1/api/client/Pending");
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
