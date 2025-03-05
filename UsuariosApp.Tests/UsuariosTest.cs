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


        [Fact(Skip ="Não implementado")]
        public void Autentificar_ReturnOk()
        {

        }

        [Fact(Skip ="Não implementado")]
        public void Autentificar_ReturnsBadRequest()
        {

        }
    }
}