using System;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
using Microsoft.Azure.Devices;
using System.Text;
using System.Threading;
using Newtonsoft.Json;

static RegistryManager registryManager;
static string connectionString = Environment.GetEnvironmentVariable("iotHubConnectionString");

public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, TraceWriter log)
{
    HttpResponseMessage response;
    registryManager = RegistryManager.CreateFromConnectionString(connectionString);
    // parse query parameter
    string action = req.GetQueryNameValuePairs()
        .FirstOrDefault(q => string.Compare(q.Key, "action", true) == 0)
        .Value;

    if (action == "get")
    {
        string callback = req.GetQueryNameValuePairs()
            .FirstOrDefault(q => string.Compare(q.Key, "callback", true) == 0)
            .Value;

        if (String.IsNullOrEmpty(callback))
        {
            callback = "callback";
        }
        var twin = await registryManager.GetTwinAsync("AZ3166");
        var json = JsonConvert.SerializeObject(twin.Properties);
        response = new HttpResponseMessage(HttpStatusCode.OK);
        response.Content = new StringContent(callback + "(" + json + ");", System.Text.Encoding.UTF8, "application/javascript");
    }
    else if (action == "set")
    {
        string _state = req.GetQueryNameValuePairs()
            .FirstOrDefault(q => string.Compare(q.Key, "state", true) == 0)
            .Value;
        int state;
        bool parsed = Int32.TryParse(_state, out state);

        if (parsed)
        {
            SetDeviceTwin(state).Wait();
            response = new HttpResponseMessage(HttpStatusCode.NoContent);
        }
        else
        {
            response = new HttpResponseMessage(HttpStatusCode.BadRequest);
        }
    }
    else
    {
        response = new HttpResponseMessage(HttpStatusCode.BadRequest);
    }
    
    return response;
}

public static async Task SetDeviceTwin(int userLEDState)
{
     var twin = await registryManager.GetTwinAsync("AZ3166");
     var patch = new {
        properties = new {
            desired = new {
                userLEDState = userLEDState
            }
        }
    };
     
    await registryManager.UpdateTwinAsync(twin.DeviceId, JsonConvert.SerializeObject(patch), twin.ETag);
}