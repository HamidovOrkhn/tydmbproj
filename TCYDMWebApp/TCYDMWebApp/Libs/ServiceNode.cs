
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using TCYDMWebServices.Repositories;
using Microsoft.Extensions.Localization;
using TCYDMWebApp.Repositories.Lang;
using Microsoft.AspNetCore.Components;

namespace TCYDMWebApp.Libs
{
    public class ServiceNode<T,U> where T:class,new() 
    {
        public string BaseAdress { get; set; }

        IStringLocalizer<SharedResource> _localizer;

        HttpClient Client;

        public ServiceNode(HttpClient factory)
        {
            //Client = factory.CreateClient(name:"ApiRequests");
            Client = factory;
        }
        public ServiceNode(IStringLocalizer<SharedResource> localizer, HttpClient factory)
        {
            // Client = factory.CreateClient(name: "ApiRequests");
            Client = factory;
            _localizer = localizer;
        }
        public ReturnMessage<U> DeleteClient(string url, string token = null)
        {
            try
            {

                if (token != null)
                {
                    Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }
                var respraw = Client.DeleteAsync(url).Result;
                if (respraw.IsSuccessStatusCode)
                {
                    var response = respraw.Content.ReadAsAsync<ReturnMessage<U>>().Result;
                    return response;
                }
                else
                {
                    var response = respraw.Content.ReadAsAsync<ReturnErrorMessage>().Result;
                    ReturnMessage<U> returnData = new ReturnMessage<U>();
                    returnData.IsCatched = 1;
                    switch (response.ErrorType)
                    {

                        case 1:
                            returnData.Message = _localizer["There is problem with server, please try again"];
                            returnData.Code = 500;
                            break;
                        case 2:
                            returnData.Message = _localizer["Cannot find this type of data"];
                            returnData.Code = 400;
                            break;
                        case 3:
                            returnData.Message = _localizer["Wrong credentials"];
                            returnData.Code = 400;
                            break;
                        case 4:
                            returnData.Message = _localizer["This credentials are already exists, please try another one"];
                            returnData.Code = 400;
                            break;
                        case 5:
                            returnData.Message = _localizer["Password is wrong"];
                            returnData.Code = 400;
                            break;
                        case 6:
                            returnData.Message = _localizer["There is no such user with this credentials"];
                            returnData.Code = 400;
                            break;
                        case 7:
                            returnData.Message = _localizer["This time has taken by other user, please change time or date"];
                            returnData.Code = 400;
                            break;
                        case 8:
                            returnData.Message = _localizer["You have already unfinished query. Please wait until it will be finished. You will receive email when query finish"];
                            returnData.Code = 400;
                            break;
                        case 9:
                            returnData.Message = _localizer["Please confirm your email adress"];
                            returnData.Code = 400;
                            break;
                        default:
                            returnData.Message = "ERROR_TYPE_UNKNOWN";
                            returnData.Code = 500;
                            break;
                    }
                    return returnData;
                }


            }
            catch (Exception x)
            {
                var errorResp = new ReturnMessage<U>();
                errorResp.Code = 500;
                errorResp.IsCatched = 1;
                errorResp.Message = "Something wrong with server : " + x.Message;
                return errorResp;
            }

        }
        public ReturnMessage<U> GetClient(string url, string token = null)
        {
            try
            {

                if (token != null)
                {
                    Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }
                var respraw = Client.GetAsync(url).Result;
                var responsecode = respraw.StatusCode;
                var response = respraw.Content.ReadAsAsync<ReturnMessage<U>>().Result;
                return response;

            }
            catch (Exception x)
            {
                var errorResp = new ReturnMessage<U>();
                errorResp.Code = 500;
                errorResp.IsCatched = 1;
                errorResp.Message = "Something wrong with server : " + x.Message;
                return errorResp;
            }



        }
        public ReturnMessage<U> PostClient(object data,string url, string token = null)
        {
            try
            {

                if (token != null)
                {
                    Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }
                var respraw = Client.PostAsJsonAsync(url, data).Result;

                if (respraw.IsSuccessStatusCode)
                {
                    var response = respraw.Content.ReadAsAsync<ReturnMessage<U>>().Result;
                    return response;
                }
                else
                {
                    var response = respraw.Content.ReadAsAsync<ReturnErrorMessage>().Result;
                    ReturnMessage<U> returnData = new ReturnMessage<U>();
                    returnData.IsCatched = 1;
                    switch (response.ErrorType)
                    {

                        case 1:
                            returnData.Message = _localizer["There is problem with server, please try again"];
                            returnData.Code = 500;
                            break;
                        case 2:
                            returnData.Message = _localizer["Cannot find this type of data"];
                            returnData.Code = 400;
                            break;
                        case 3:
                            returnData.Message = _localizer["Wrong credentials"];
                            returnData.Code = 400;
                            break;
                        case 4:
                            returnData.Message = _localizer["This credentials are already exists, please try another one"];
                            returnData.Code = 400;
                            break;
                        case 5:
                            returnData.Message = _localizer["Password is wrong"];
                            returnData.Code = 400;
                            break;
                        case 6:
                            returnData.Message = _localizer["There is no such user with this credentials"];
                            returnData.Code = 400;
                            break;
                        case 7:
                            returnData.Message = _localizer["This time has taken by other user, please change time or date"];
                            returnData.Code = 400;
                            break;
                        case 8:
                            returnData.Message = _localizer["You have already unfinished query. Please wait until it will be finished. You will receive email when query finish"];
                            returnData.Code = 400;
                            break;
                        case 9:
                            returnData.Message = _localizer["Please confirm your email adress"];
                            returnData.Code = 400;
                            break;
                        default:
                            returnData.Message = "ERROR_TYPE_UNKNOWN";
                            returnData.Code = 500;
                            break;
                    }
                    return returnData;
                }
            }
            catch (Exception x)
            {
                var errorResp = new ReturnMessage<U>();
                errorResp.Code = 500;
                errorResp.IsCatched = 1;
                errorResp.Message = "Something wrong with server : "+x.Message;
                return errorResp;
            }
            

        }
        public ReturnMessage<U> PutClient(object data, string url, string token = null)
        {
            try
            {

                if (token != null)
                {
                    Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }
                var respraw = Client.PutAsJsonAsync(url, data).Result;

                if (respraw.IsSuccessStatusCode)
                {
                    var response = respraw.Content.ReadAsAsync<ReturnMessage<U>>().Result;
                    return response;
                }
                else
                {
                    var response = respraw.Content.ReadAsAsync<ReturnErrorMessage>().Result;
                    ReturnMessage<U> returnData = new ReturnMessage<U>();
                    returnData.IsCatched = 1;
                    switch (response.ErrorType)
                    {

                        case 1:
                            returnData.Message = _localizer["There is problem with server, please try again"];
                            returnData.Code = 500;
                            break;
                        case 2:
                            returnData.Message = _localizer["Cannot find this type of data"];
                            returnData.Code = 400;
                            break;
                        case 3:
                            returnData.Message = _localizer["Wrong credentials"];
                            returnData.Code = 400;
                            break;
                        case 4:
                            returnData.Message = _localizer["This credentials are already exists, please try another one"];
                            returnData.Code = 400;
                            break;
                        case 5:
                            returnData.Message = _localizer["Password is wrong"];
                            returnData.Code = 400;
                            break;
                        case 6:
                            returnData.Message = _localizer["There is no such user with this credentials"];
                            returnData.Code = 400;
                            break;
                        case 7:
                            returnData.Message = _localizer["This time has taken by other user, please change time or date"];
                            returnData.Code = 400;
                            break;
                        case 8:
                            returnData.Message = _localizer["You have already unfinished query. Please wait until it will be finished. You will receive email when query finish"];
                            returnData.Code = 400;
                            break;
                        case 9:
                            returnData.Message = _localizer["Please confirm your email adress"];
                            returnData.Code = 400;
                            break;
                        default:
                            returnData.Message = "ERROR_TYPE_UNKNOWN";
                            returnData.Code = 500;
                            break;
                    }
                    return returnData;
                }
            }
            catch (Exception x)
            {
                var errorResp = new ReturnMessage<U>();
                errorResp.Code = 500;
                errorResp.IsCatched = 1;
                errorResp.Message = "Something wrong with server : " + x.Message;
                return errorResp;

            }

        }


    }
}
