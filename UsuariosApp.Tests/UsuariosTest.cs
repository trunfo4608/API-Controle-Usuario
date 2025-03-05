using Bogus;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Text;
using UsuariosApp.Aplication.Dto;
using System.Net;

namespace UsuariosApp.Tests
{
    public class UsuariosTest
    {
        private Faker _faker = new Faker("pt_BR");
        private static string _email = string.Empty;
        private static string _senha = string.Empty;


        //[Fact(Skip ="Não implementado")]
        [Fact]
        [Trait("CriarConta_ReturnsCreated","1")]
        public void CriarConta_RetunsCreated()
        {
            

            var client = new WebApplicationFactory<Program>().CreateClient();
            var dto = new CriarContaRequestDto
            {
                Nome = _faker.Person.FullName,
                Email = _faker.Internet.Email().ToLower(),
                Senha = "R@v789456",
                SenhaConfirmacao = "R@v789456"
            };


            var jsonRequest = new StringContent(JsonConvert.SerializeObject(dto),
                Encoding.UTF8,"application/json");

            var response = client.PostAsync("api/usuarios/criarconta", jsonRequest).Result;

            response.StatusCode.Should().Be(HttpStatusCode.Created);

        }

        // [Fact(Skip ="Não implementado")]
        [Fact]
        [Trait("CriarConta_ReturnsBadRequest","2")]
        public void CriarConta_ReturnsBadRequest()
        {
            var client = new WebApplicationFactory<Program>().CreateClient();

            var dto = new CriarContaRequestDto
            {
                Nome = _faker.Person.FullName,
                Email = _email,
                Senha = _senha,
                SenhaConfirmacao = _senha
            };


            var jsonResquest = new StringContent(JsonConvert.SerializeObject(dto),
                Encoding.UTF8,"application/json");

            var response = client.PostAsync("api/usuarios/criarconta", jsonResquest).Result;

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }


        // [Fact(Skip ="Não implementado")]
        [Fact]
        [Trait("Autentificar_ReturnOk","3")]
        public void Autentificar_ReturnOk()
        {
            var client = new WebApplicationFactory<Program>().CreateClient();

            var dto = new AutenticarRequestDto
            {
                Email = "camila@gmail.com",
                Senha = "R@v00726"
            };

            var jsonRequest = new StringContent(JsonConvert.SerializeObject(dto),
                Encoding.UTF8, "application/json");

            var response = client.PostAsync("api/usuarios/autenticar", jsonRequest).Result;

            response.StatusCode.Should().Be(HttpStatusCode.OK);

        }

        //[Fact(Skip ="Não implementado")]
        [Fact]
        [Trait("Autentificar_ReturnsBadRequest","4")]
        public void Autentificar_ReturnsBadRequest()
        {
            var client = new WebApplicationFactory<Program>().CreateClient();

            var dto = new AutenticarRequestDto
            {
                Email = _email,
                Senha = _senha
            };

            var jsonRequest = new StringContent(JsonConvert.SerializeObject(dto),
                Encoding.UTF8, "application/json");

            var response = client.PostAsync("api/usuarios/autenticar", jsonRequest).Result;

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
    }
}