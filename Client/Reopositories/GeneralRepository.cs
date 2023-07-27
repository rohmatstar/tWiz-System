
using Client.Contracts;
using Client.Utilities.Handlers;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace Client.Reopositories
{
    public class GeneralRepository<Entity, Tid> : IRepository<Entity, Tid>
        where Entity : class
    {
        private readonly string request;
        private readonly HttpClient httpClient;
        private readonly IHttpContextAccessor contextAccessor;


        public GeneralRepository(string request)
        {
            this.request = request;
            contextAccessor = new HttpContextAccessor();
            httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7249/api/")

            };
            /*     this.request = request;*/
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", contextAccessor.HttpContext?.Session.GetString("JWToken"));
        }
        public async Task<ResponseHandler<Entity>> Delete(Tid id)
        {
            ResponseHandler<Entity> entityVM = null;
            using (var response = await httpClient.DeleteAsync(this.request + "?guid=" + id))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entityVM = JsonConvert.DeserializeObject<ResponseHandler<Entity>>(apiResponse);
            }
            return entityVM;
        }

        public async Task<ResponseHandler<IEnumerable<Entity>>> Get()
        {
            ResponseHandler<IEnumerable<Entity>> entityVM = null;
            using (var response = await httpClient.GetAsync(this.request))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entityVM = JsonConvert.DeserializeObject<ResponseHandler<IEnumerable<Entity>>>(apiResponse);
            }
            return entityVM;
        }

        public async Task<ResponseHandler<Entity>> Post(Entity entity)
        {
            ResponseHandler<Entity> entityVM = null;
            StringContent content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
            using (var response = httpClient.PostAsync(request, content).Result)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entityVM = JsonConvert.DeserializeObject<ResponseHandler<Entity>>(apiResponse);
            }
            return entityVM;
        }

        public async Task<ResponseHandler<Entity>> Get(Tid id)
        {
            ResponseHandler<Entity> entity = null;
            using (var response = await httpClient.GetAsync(request + id))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entity = JsonConvert.DeserializeObject<ResponseHandler<Entity>>(apiResponse);
            }
            return entity;
        }


        public async Task<ResponseHandler<Entity>> Put(Tid id, Entity entity)
        {
            ResponseHandler<Entity> entityVM = null;
            StringContent content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
            using (var response = httpClient.PutAsync(request + "?guid=" + id, content).Result)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entityVM = JsonConvert.DeserializeObject<ResponseHandler<Entity>>(apiResponse);
            }
            return entityVM;
        }
    }
}
