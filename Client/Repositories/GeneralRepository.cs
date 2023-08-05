using Client.Contracts;
using Client.DTOs;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace Client.Repositories
{
    public class GeneralRepository<Entity, TId> : IRepository<Entity, TId>
        where Entity : class
    {
        protected readonly string request;
        protected readonly HttpClient httpClient;
        protected readonly IHttpContextAccessor contextAccessor;

        public GeneralRepository(string request)
        {
            this.request = request;
            contextAccessor = new HttpContextAccessor();
            httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7249/api/")
            };
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", contextAccessor.HttpContext?.Session.GetString("JWTToken"));
        }

        public async Task<ResponseMessageDto> Delete(TId guid)
        {
            ResponseMessageDto entityDto = null!;
            StringContent content = new StringContent(JsonConvert.SerializeObject(guid), Encoding.UTF8, "application/json");
            using (var response = httpClient.DeleteAsync(request + guid).Result)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entityDto = JsonConvert.DeserializeObject<ResponseMessageDto>(apiResponse)!;
            }
            return entityDto;
        }

        public async Task<ResponseMessageDto> Put(Entity entity)
        {
            ResponseMessageDto entityDto = null!;
            StringContent content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
            using (var response = httpClient.PutAsync(request, content).Result)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entityDto = JsonConvert.DeserializeObject<ResponseMessageDto>(apiResponse)!;
            }
            return entityDto;
        }

        public async Task<ResponseMessageDto> Post(Entity entity)
        {
            ResponseMessageDto entityDto = null!;
            StringContent content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");

            using (var response = httpClient.PostAsync(request, content).Result)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entityDto = JsonConvert.DeserializeObject<ResponseMessageDto>(apiResponse)!;
            }
            return entityDto;
        }

        public async Task<ResponseListDto<Entity>> Get()
        {
            ResponseListDto<Entity> entityDto = null!;
            //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
            using (var response = await httpClient.GetAsync(request))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entityDto = JsonConvert.DeserializeObject<ResponseListDto<Entity>>(apiResponse)!;
            }
            return entityDto;
        }

        public async Task<ResponseDto<Entity>> Get(TId Guid)
        {
            ResponseDto<Entity> entity = null!;

            using (var response = await httpClient.GetAsync(request + Guid))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entity = JsonConvert.DeserializeObject<ResponseDto<Entity>>(apiResponse)!;
            }
            return entity;
        }
    }
}