using RestSharp;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;

namespace eCACLoginAPI.Services
{
    public class CertificateLoginService
    {
        public async Task<bool> LoginWithCertificateAsync(string certificatePath, string certificatePassword)
        {
            try
            {
                // Carregar o certificado digital
                var certificate = new X509Certificate2(certificatePath, certificatePassword);

                // Configurar o HttpClientHandler para usar o certificado
                var handler = new HttpClientHandler();
                handler.ClientCertificates.Add(certificate);

                // Criar o RestClient com o HttpClientHandler
                var options = new RestClientOptions("https://login.e-cac.gov.br")
                {
                    ConfigureMessageHandler = _ => handler
                };
                var client = new RestClient(options);

                // Configurar a requisição
                var request = new RestRequest("/", Method.Get); // Define o método HTTP como GET

                // Executar a requisição
                var response = await client.ExecuteAsync(request);

                // Retornar o resultado
                return response.IsSuccessful;
            }
            catch (Exception ex)
            {
                // Log do erro, se necessário
                Console.WriteLine($"Erro ao realizar login com certificado: {ex.Message}");
                return false;
            }
        }
    }
}
