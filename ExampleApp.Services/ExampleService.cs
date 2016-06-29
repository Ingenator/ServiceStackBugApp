using Example.DTO;
using ExampleApp.Abstractions;
using Newtonsoft.Json;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleApp.Services
{
    public class ExampleService : IExampleService
    {
        public string serviceURL = "http://200.53.180.89/PayitIssues/";
        public async Task<bool> ReproduceBug()
        {
            MyExampleService request = new MyExampleService();
            request.Param = "test";
            using (JsonServiceClient client = new JsonServiceClient(serviceURL))
            {
                try
                {
                    var result = await client.PostAsync(request);
                    Debug.WriteLine(JsonConvert.SerializeObject(result, Formatting.Indented));
                    return true;
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                    return false;
                }
            }
        }
    }
}
