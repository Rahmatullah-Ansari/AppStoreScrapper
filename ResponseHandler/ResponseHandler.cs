using AppStoreScarpper.Interface;
using AppStoreScarpper.Requests;
using AppStoreScarpper.Utilities;
using Newtonsoft.Json.Linq;
using System;
using System.Net;

namespace AppStoreScarpper.ResponseHandler
{
    public  class ResponseHandler
    {
        protected readonly IResponseParameter Response;
        protected readonly JObject RespJ;
        public readonly JsonParser parser = JsonParser.GetInstance;
        public bool Success { get; protected set; }

        public override string ToString()
        {
            if (!string.IsNullOrEmpty(Response.Response))
                return Response.Response;
            return string.Empty;
        }
        public ResponseHandler()
        {

        }
        public ResponseHandler(IResponseParameter responeParameter)
        {
            try
            {
                Response = responeParameter;
                if (Response.HasError)
                {
                    WebHelper.WebExceptionIssue errorMsgWebrequest;

                    try
                    {
                        errorMsgWebrequest = ((WebException)Response.Exception).GetErrorMsgWebrequest();
                    }
                    catch (Exception)
                    {
                        errorMsgWebrequest = new WebHelper.WebExceptionIssue
                        {
                            MessageLong = Response.Exception.Message
                        };
                    }

                    Success = false;
                }
                else
                {
                    try
                    {

                        if (!Response.Response.IsValidJson())
                        {
                            var decodedResponse = ConstantHelpDetails.GetDecodedResponseOfJson(Response.Response);
                            RespJ = parser.ParseJsonToJObject(decodedResponse);
                        }
                        else
                            RespJ = parser.ParseJsonToJObject(Response.Response);
                    }
                    catch (Exception ex)
                    {
                        // ignored
                    }
                }
            }
            catch (Exception ex)
            {
            }

        }
    }
}
