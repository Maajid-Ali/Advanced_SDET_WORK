using RestSharp;
using Newtonsoft.Json;
using System.Security.Cryptography;
using Newtonsoft.Json.Linq;

namespace MyAPIClientApp;

public class Program
{
     static void Main(string[] args)
     {
        var restClient = new RestClient("https://api.football-data.org/v4/");

        var restRequest = new RestRequest();
        // build the request 
        restRequest.Method = Method.Get;
        restRequest.AddHeader("Content-Type", "application/json");

        restRequest.Timeout = -1; //stops the request from timing out since there is basically no timer, as time can't go back

        string fixtures = "competitions";

        restRequest.Resource = fixtures;

        var Response = restClient.Execute(restRequest);

        Console.WriteLine(Response.Content);



     }
}