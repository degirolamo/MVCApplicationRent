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
   public class CountryRESTService
    {
        readonly string baseUri = "http://localhost:51063/api/Countrys/";

        public List<Country> getCountries()
        {
            string uri = baseUri;
            using (HttpClient httpClient = new HttpClient())
            {
                Task<string> response = httpClient.GetStringAsync(uri);
                return JsonConvert.DeserializeObject<List<Country>>(response.Result);

            }

        }

        public bool PostCountry(Country c)
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

        public bool PutCountry(Country c)
        {
            string uri = baseUri;
            using (HttpClient httpClient = new HttpClient())
            {
                string pro = JsonConvert.SerializeObject(c);
                StringContent frame = new StringContent(pro, Encoding.UTF8, "Application/json");
                Task<HttpResponseMessage> response = httpClient.PutAsync(uri, frame);
                return response.Result.IsSuccessStatusCode;
            }
        }

        public bool DeleteCountry(int i)
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
