using Client.Contracts;
using Client.DTOs;
using Client.DTOs.Auths;
using Client.Models;
using Newtonsoft.Json;
using System.Text;

namespace Client.Repositories;

public class AuthRepository : GeneralRepository<Account, string>, IAuthRepository
{
    private readonly HttpClient httpClient;
    private readonly string request;

    public AuthRepository(string request = "auths/") : base(request)
    {
        httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7249/api/")
        };
        this.request = request;
    }

    public async Task<ResponseDto<string>> SignIn(SignInDto loginDto)
    {
        ResponseDto<string> entity = null!;
        StringContent content = new StringContent(JsonConvert.SerializeObject(loginDto), Encoding.UTF8, "application/json");
        var response = httpClient.PostAsync(request + "login", content).Result;
        using (response)
        {
            string apiResponse = await response.Content.ReadAsStringAsync();
            entity = JsonConvert.DeserializeObject<ResponseDto<string>>(apiResponse)!;
        }
        return entity;
    }

    public async Task<ResponseDto<SignUpDto>> SignUp(SignUpDto signUpDto)
    {
        ResponseDto<SignUpDto> entity = null!;
        StringContent content = new StringContent(JsonConvert.SerializeObject(signUpDto), Encoding.UTF8, "application/json");
        using (var response = httpClient.PostAsync(request + "register", content).Result)
        {
            string apiResponse = await response.Content.ReadAsStringAsync();
            entity = JsonConvert.DeserializeObject<ResponseDto<SignUpDto>>(apiResponse)!;
        }
        return entity;
    }

    public async Task<ResponseDto<ForgotPasswordDto>> ForgetPassword(ForgotPasswordDto forgotPasswordDto)
    {
        ResponseDto<ForgotPasswordDto> entity = null!;
        StringContent content = new StringContent(JsonConvert.SerializeObject(forgotPasswordDto), Encoding.UTF8, "application/json");
        using (var response = httpClient.PostAsync(request + "forgot-password?email=" + Uri.EscapeDataString(forgotPasswordDto.Email), content).Result)
        {
            string apiResponse = await response.Content.ReadAsStringAsync();
            entity = JsonConvert.DeserializeObject<ResponseDto<ForgotPasswordDto>>(apiResponse)!;
        }
        return entity;
    }

    public async Task<ResponseDto<ChangePasswordDto>> ResetPassword(ChangePasswordDto changePasswordDto)
    {
        ResponseDto<ChangePasswordDto> entity = null!;
        StringContent content = new StringContent(JsonConvert.SerializeObject(changePasswordDto), Encoding.UTF8, "application/json");
        using (var response = httpClient.PutAsync(request + "change-password", content).Result)
        {
            string apiResponse = await response.Content.ReadAsStringAsync();
            entity = JsonConvert.DeserializeObject<ResponseDto<ChangePasswordDto>>(apiResponse)!;
        }
        return entity;
    }
}
