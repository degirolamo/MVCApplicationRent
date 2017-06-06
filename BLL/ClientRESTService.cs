using System.Collections.Generic;
using System.Threading.Tasks;
using DTO;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;

namespace BLL
{
    public class ClientRESTService
    {
        readonly string baseUri = "http://localhost:51063/api/Clients/";

        public List<Client> getClients()
        {
            string uri = baseUri;
            using (HttpClient httpClient = new HttpClient())
            {
                Task<string> response = httpClient.GetStringAsync(uri);
                return JsonConvert.DeserializeObject<List<Client>>(response.Result);

            }

        }

        public Client getClient(int id)
        {
            string uri = baseUri + id;
            using (HttpClient httpClient = new HttpClient())
            {
                Task<string> response = httpClient.GetStringAsync(uri);
                return JsonConvert.DeserializeObject<Client>(response.Result);

            }
        }

        public bool PostClient (Client c)
        {
            string uri = baseUri;
            using (HttpClient httpClient = new HttpClient())
            {
                string pro = JsonConvert.SerializeObject(c);
                StringContent frame = new StringContent(pro, Encoding.UTF8, "Application/json");
                Task<HttpResponseMessage> response = httpClient.PostAsync(uri, frame);
                return response.Result.IsSuccessStatusCode;
            }
        }

        public bool PutClient(Client c)
        {
            string uri = baseUri +c.Id ;
            using (HttpClient httpClient = new HttpClient())
            {
                string pro = JsonConvert.SerializeObject(c);
                StringContent frame = new StringContent(pro, Encoding.UTF8, "Application/json");
                Task<HttpResponseMessage> response = httpClient.PutAsync(uri, frame);
                return response.Result.IsSuccessStatusCode;
            }
        }

        public bool DeleteClient(int i)
        {
            string uri = baseUri +i;
            using (HttpClient httpClient = new HttpClient())
            {
                Task<HttpResponseMessage> response = httpClient.DeleteAsync(uri);
                return response.Result.IsSuccessStatusCode;
            }
        }

    }
}
