using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Net.Http;
using Newtonsoft.Json;

namespace BLL
{
  public class MaterialRESTService
    {
        readonly string baseUri = "http://localhost:51063/api/Materials/";

        public List<Material> getMaterials()
        {
            string uri = baseUri;
            using (HttpClient httpClient = new HttpClient())
            {
                Task<string> response = httpClient.GetStringAsync(uri);
                return JsonConvert.DeserializeObject<List<Material>>(response.Result);

            }

        }

        public Material getMaterial(int id)
        {
            string uri = baseUri + id;
            using (HttpClient httpClient = new HttpClient())
            {
                Task<string> response = httpClient.GetStringAsync(uri);
                return JsonConvert.DeserializeObject<Material>(response.Result);

            }
        }

        public bool PostMaterial(Material m)
        {
            string uri = baseUri;
            using (HttpClient httpClient = new HttpClient())
            {
                string pro = JsonConvert.SerializeObject(m);
                StringContent frame = new StringContent(pro, Encoding.UTF8, "Application/json");
                Task<HttpResponseMessage> response = httpClient.PostAsync(uri, frame);
                return response.Result.IsSuccessStatusCode;
            }
        }

        public bool PutMaterial(Material m)
        {
            string uri = baseUri + m.Id;
            using (HttpClient httpClient = new HttpClient())
            {
                string pro = JsonConvert.SerializeObject(m);
                StringContent frame = new StringContent(pro, Encoding.UTF8, "Application/json");
                Task<HttpResponseMessage> response = httpClient.PutAsync(uri, frame);
                return response.Result.IsSuccessStatusCode;
            }
        }

        public bool DeleteMaterial(int i)
        {
            string uri = baseUri + i;
            using (HttpClient httpClient = new HttpClient())
            {
                Task<HttpResponseMessage> response = httpClient.DeleteAsync(uri);
                return response.Result.IsSuccessStatusCode;
            }
        }

    }
}
