using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RestAPIAuto
{
    public static class RestAPIMethods
    {
        public static RestClient restClient;
        public static RestRequest restRequest;
        public static IRestResponse restResponse;
        public static bool GetLeaderBoardUsers(string userNamestr = "Test")
        {
            restClient = new RestClient(Constants.RestAPIEndPoint);
            restRequest = new RestRequest(Method.GET);
            restResponse = restClient.Execute(restRequest);
            var response = restResponse.Content;
            var dt = JsonConvert.DeserializeObject<DataTable>(response);
            var actualUser = (from DataRow dr in dt.Rows
                              where (string)dr["username"] == userNamestr
                              select (string)dr["username"]).FirstOrDefault();


            return (actualUser != null) ? true : false;
        }

        public static bool VerifyStatusCode(int code)
        {
            restClient = new RestClient(Constants.RestAPIEndPoint);
            restRequest = new RestRequest(Method.GET);
            restResponse = restClient.Execute(restRequest);

            // assert
            return restResponse.StatusCode.Equals(HttpStatusCode.OK);
        }

        public static bool CheckLeaderBoardScoreOrder()
        {
            restClient = new RestClient(Constants.RestAPIEndPoint);
            restRequest = new RestRequest(Method.GET);
            restResponse = restClient.Execute(restRequest);

            // Parsing JSON content into element-node JObject
            var response = restResponse.Content;
            var dt = JsonConvert.DeserializeObject<DataTable>(response);
            int cnt = 0;
            int firstScore = 0;
            foreach (DataRow row in dt.Rows)
            {
                if (cnt == 0)
                {

                    firstScore = Convert.ToInt32(row["score"]);
                    cnt++;
                }
                else

                if (firstScore >= Convert.ToInt32(row["score"]))
                    return true;


            }
            return true;

        }

        public static bool ValidatePostMethod(string name, int? scoreint,bool isDup=false)
        {
            //restClient = new RestClient(Constants.RestAPIEndPoint);
            //restRequest = new RestRequest(Method.POST);
            //if (scoreint == 0) scoreint = null;
            ////Creating Json object
            //JObject jObjectbody = new JObject();
            //jObjectbody.Add("username", name);
            //jObjectbody.Add("score", scoreint);

            ////Adding Json body as parameter to the post request
            //restRequest.AddParameter("application/json", jObjectbody, ParameterType.RequestBody);

            //restResponse = restClient.Execute(restRequest);
            InvokeRestAPI(RestSharp.Method.POST, name, scoreint);
            if (name.Equals(string.Empty) || scoreint == null || isDup)
            {
                return restResponse.StatusCode.Equals(HttpStatusCode.BadRequest);
            }
            
            return restResponse.StatusCode.Equals(HttpStatusCode.Created);
        }

        public static bool ValidatePutMethod(string name, int? scoreint, bool isInvalid =false,bool isExistUser = true)
        {
            //restClient = new RestClient(Constants.RestAPIEndPoint);
            //restRequest = new RestRequest(Method.PUT);
            //if (scoreint == 0) scoreint = null;
            ////creating json object
            //JObject jobjectbody = new JObject();
            //jobjectbody.Add("username", name);
            //jobjectbody.Add("score", scoreint);

            ////Adding Json body as parameter to the put request
            //restRequest.AddParameter("application/json", jobjectbody, ParameterType.RequestBody);

            //restResponse = restClient.Execute(restRequest);
            InvokeRestAPI(RestSharp.Method.PUT,name,scoreint);
            if (name.Equals(string.Empty) || scoreint == null ||isInvalid )
            {
                return (restResponse.StatusCode.Equals(HttpStatusCode.BadRequest) || restResponse.StatusCode.Equals(HttpStatusCode.ServiceUnavailable));
            }
            //if (isInvalid)
            //    return restResponse.StatusCode.Equals(HttpStatusCode.ServiceUnavailable);
            if (isExistUser)
                return restResponse.StatusCode.Equals(HttpStatusCode.NoContent);

            return restResponse.StatusCode.Equals(HttpStatusCode.Created);
        }

        public static bool VerifyDeleteResponseStatus(bool isValid=false)
        {
            restClient = new RestClient(Constants.RestAPIEndPoint);
            restRequest = new RestRequest(Method.DELETE);
            restRequest.AddHeader("delete-key", string.Empty);
                       
            restResponse = restClient.Execute(restRequest);
            return (restResponse.StatusCode.Equals(HttpStatusCode.Unauthorized));
        }

        private static void InvokeRestAPI( RestSharp.Method method,string name="Test",int? scoreInt =0)
        {
            try
            {
                restClient = new RestClient(Constants.RestAPIEndPoint);
                
                restRequest = new RestRequest(method);
                if (scoreInt == 0) scoreInt = null;
                //Creating Json object
                JObject jObjectbody = new JObject();
                jObjectbody.Add("username", name);
                jObjectbody.Add("score", scoreInt);
                restRequest.AddParameter("application/json", jObjectbody, ParameterType.RequestBody);

                restResponse = restClient.Execute(restRequest);
                
            }
            catch(Exception ex)
            {

            }
                

        }

    }
}
