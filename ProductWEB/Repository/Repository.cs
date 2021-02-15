using Newtonsoft.Json;
using ProductWEB.Models;
using ProductWEB.Repository.IRepository;
using ProductWEB.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProductWEB.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IHttpClientFactory httpClientFactory;

        public Repository(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }
        public async Task<ModelStateError> CreateAsync(string url, T entity)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url);

            request.Content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, Resource.ContentType);

            var HttpClient = httpClientFactory.CreateClient();

            HttpResponseMessage response = await HttpClient.SendAsync(request);

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ModelStateError>(json);
            }

            if (response.StatusCode == HttpStatusCode.InternalServerError)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ModelStateError>(json);
            }

            return new ModelStateError()
            {
                Response = new Response()
                {
                    Errors = new List<Errors>()
                }
            };
        }

        public Task<ModelStateError> DeleteAsync(string url, int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAllAsync(string url)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetAsync(string url, int id)
        {
            throw new NotImplementedException();
        }

        public Task<ModelStateError> UpdateAsync(string url, T entity)
        {
            throw new NotImplementedException();
        }
    }
}
