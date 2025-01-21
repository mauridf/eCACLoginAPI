using RestSharp;

namespace eCACLoginAPI.Services
{
    public class GovBrLoginService
    {
        public async Task<bool> LoginAsync(string username, string password)
        {
            // Criar o cliente apontando para o endpoint de login
            var client = new RestClient("https://sso.acesso.gov.br/login");

            // Criar a requisição e configurar o método HTTP
            var request = new RestRequest("/", Method.Post);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

            // Adicionar os parâmetros do formulário
            request.AddParameter("username", username);
            request.AddParameter("password", password);

            // Executar a requisição
            var response = await client.ExecuteAsync(request);

            // Retornar se o login foi bem-sucedido
            return response.IsSuccessful;
        }
    }
}
