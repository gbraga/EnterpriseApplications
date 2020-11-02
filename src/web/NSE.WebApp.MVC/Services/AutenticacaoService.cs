using NSE.WebApp.MVC.Models;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NSE.WebApp.MVC.Services
{
    public class AutenticacaoService : Service, IAutenticacaoService
    {
        private readonly HttpClient _httpClient;

        public AutenticacaoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<UsuarioRespostaLoginViewModel> Login(UsuarioLoginViewModel usuarioLogin)
        {
            var loginContent = new StringContent(
                content: JsonSerializer.Serialize(usuarioLogin),
                encoding: Encoding.UTF8,
                mediaType: "application/json"
            );

            var response = await _httpClient.PostAsync(requestUri: "https://localhost:44346/api/identidade/autenticar", loginContent);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            if (!TratarErrosResponse(response))
            {
                return new UsuarioRespostaLoginViewModel
                {
                    ResponseResult = JsonSerializer.Deserialize<ResponseResult>(await response.Content.ReadAsStringAsync(), options),
                };
            }

            return JsonSerializer.Deserialize<UsuarioRespostaLoginViewModel>(await response.Content.ReadAsStringAsync(), options);
        }

        public async Task<UsuarioRespostaLoginViewModel> Registro(UsuarioRegistroViewModel usuarioRegistro)
        {
            var registroContent = new StringContent(
                content: JsonSerializer.Serialize(usuarioRegistro),
                encoding: Encoding.UTF8,
                mediaType: "application/json"
            );

            var response = await _httpClient.PostAsync(requestUri: "https://localhost:44396/api/identidade/nova-conta", registroContent);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            if (!TratarErrosResponse(response))
            {
                return new UsuarioRespostaLoginViewModel
                {
                    ResponseResult = JsonSerializer.Deserialize<ResponseResult>(await response.Content.ReadAsStringAsync(), options),
                };
            }

            return JsonSerializer.Deserialize<UsuarioRespostaLoginViewModel>(await response.Content.ReadAsStringAsync(), options);
        }
    }
}
