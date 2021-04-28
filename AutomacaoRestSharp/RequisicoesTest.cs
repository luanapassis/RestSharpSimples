using NUnit.Framework;
using RestSharp;
using System;
using System.Net;

namespace AutomacaoRestSharp
{
    public class RequisicoesTest
    {
        [Test]
        public void CadastraPet()
        {
            // arrange
            RestClient client = new RestClient("https://petstore.swagger.io/");
            RestRequest request = new RestRequest("v2/pet", Method.POST);
            string body = @"{
                              ""id"": 5599,
                              ""category"": {
                                ""id"": 5,
                                ""name"": ""categName""
                              },
                              ""name"": ""doguinho"",
                              ""photoUrls"": [
                                ""fotinhas""
                              ],
                              ""tags"": [
                                {
                                  ""id"": 5,
                                  ""name"": ""tagName""
                                }
                              ],
                              ""status"": ""available""
                            }";

            request.AddParameter("application/json", body, ParameterType.RequestBody);

            // act
            IRestResponse<dynamic> response = client.Execute<dynamic>(request);

            // assert
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode, "Requisição apresentou status code divergente do esperado");
            Assert.AreEqual("5599", response.Data["id"].ToString(), "Id do Pet divergente.");
            Assert.AreEqual("categName", response.Data["category"]["name"].ToString(), "Id do Pet divergente.");
            Assert.AreEqual("fotinhas", response.Data["photoUrls"][0].ToString(), "Id do Pet divergente.");
        }

        [Test]
        public void ConsultaPet()
        {
            // arrange
            RestClient client = new RestClient("https://petstore.swagger.io/");
            RestRequest request = new RestRequest("v2/pet/5599", Method.GET);

            // act
            IRestResponse<dynamic> response = client.Execute<dynamic>(request);

            // assert
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode, "Requisição apresentou status code divergente do esperado");
            Assert.AreEqual("5599", response.Data["id"].ToString(), "Id do Pet divergente.");
            Assert.AreEqual("categName", response.Data["category"]["name"].ToString(), "Id do Pet divergente.");
            Assert.AreEqual("fotinhas", response.Data["photoUrls"][0].ToString(), "Id do Pet divergente.");
        }
    }
}
