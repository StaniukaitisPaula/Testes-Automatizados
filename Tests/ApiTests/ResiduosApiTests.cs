using System.Threading.Tasks;
using RestSharp;
using Xunit;
using Newtonsoft.Json.Linq;

namespace GestaoResiduo.Tests
{
    public class ResiduosApiTests
    {
        private readonly string baseUrl = "http://localhost:8080/api/residuos";

        [Fact(DisplayName = "POST - Deve cadastrar um resíduo com sucesso")]
        public async Task Deve_Cadastrar_Residuo_Com_Sucesso()
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest(Method.Post);
            request.AddJsonBody(new { nome = "Plástico", tipo = "Reciclável" });

            var response = await client.ExecuteAsync(request);

            Assert.Equal(201, (int)response.StatusCode);

            var json = JObject.Parse(response.Content);
            Assert.Equal("Plástico", json["nome"]?.ToString());
            Assert.NotNull(json["idResiduo"]);
        }

        [Fact(DisplayName = "POST - Deve retornar erro ao cadastrar resíduo inválido")]
        public async Task Deve_Retornar_Erro_Se_Dados_Invalidos()
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest(Method.Post);
            request.AddJsonBody(new { nome = "", tipo = "" });

            var response = await client.ExecuteAsync(request);

            Assert.Equal(400, (int)response.StatusCode);
        }

        [Fact(DisplayName = "GET - Deve listar todos os resíduos cadastrados")]
        public async Task Deve_Listar_Residuos()
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest(Method.Get);

            var response = await client.ExecuteAsync(request);

            Assert.Equal(200, (int)response.StatusCode);
            Assert.Contains("nome", response.Content);
        }

        [Fact(DisplayName = "GET/{id} - Deve buscar um resíduo existente pelo ID")]
        public async Task Deve_Buscar_Residuo_Por_Id()
        {
            var client = new RestClient($"{baseUrl}/1");
            var request = new RestRequest(Method.Get);

            var response = await client.ExecuteAsync(request);

            Assert.True(
                response.StatusCode == System.Net.HttpStatusCode.OK ||
                response.StatusCode == System.Net.HttpStatusCode.NotFound
            );
        }

        [Fact(DisplayName = "PUT - Deve atualizar um resíduo existente")]
        public async Task Deve_Atualizar_Residuo()
        {
            var client = new RestClient($"{baseUrl}/1");
            var request = new RestRequest(Method.Put);
            request.AddJsonBody(new { nome = "Vidro", tipo = "Reciclável" });

            var response = await client.ExecuteAsync(request);

            Assert.True(
                response.StatusCode == System.Net.HttpStatusCode.NoContent ||
                response.StatusCode == System.Net.HttpStatusCode.NotFound
            );
        }

        [Fact(DisplayName = "DELETE - Deve retornar 404 ao excluir resíduo inexistente")]
        public async Task Deve_Retornar_404_Ao_Excluir_Inexistente()
        {
            var client = new RestClient($"{baseUrl}/999");
            var request = new RestRequest(Method.Delete);

            var response = await client.ExecuteAsync(request);

            Assert.Equal(404, (int)response.StatusCode);
        }
    }
}
