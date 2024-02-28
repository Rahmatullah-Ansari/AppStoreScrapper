using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStoreScarpper.Utilities
{
    public class JsonHandler
    {

        private readonly JObject _jObject;
        private static readonly object _lock = new object();
        private static volatile JsonHandler Instance;
        public static JsonHandler GetInstance
        {
            get
            {
                if (Instance == null)
                {
                    lock (_lock)
                    {
                        if (Instance == null)
                            Instance = new JsonHandler("{}");
                    }
                }
                return Instance;
            }
        }
        public JObject ParseJsonToJsonObject(string JsonString, JToken jToken = null)
        {
            try
            {
                if (jToken != null)
                    return (JObject)jToken;
                return JObject.Parse(JsonString);
            }
            catch (Exception ex) { return new JObject(); }
        }
        public JsonHandler(string jsonString)
        {
            _jObject = JObject.Parse(jsonString);
        }

        public JsonHandler(JToken jToken)
        {
            _jObject = (JObject)jToken;
        }

        public string GetElementValue(params object[] elementsNameList)
        {
            try
            {
                var tempToken = _jObject[elementsNameList[0]];
                for (var index = 1; index < elementsNameList.Length; index++)
                    tempToken = tempToken[elementsNameList[index]];

                return tempToken == null ? "" : tempToken.ToString();
            }
            catch (Exception)
            {
                // Ignored  ex.DebugLog();
            }

            return string.Empty;
        }

        public string GetJTokenValue(JToken gotToken, params object[] elementsNameList)
        {
            var elementValue = string.Empty;
            try
            {
                for (var index = 0; index < elementsNameList.Length && gotToken != null; index++)
                {
                    if (index == elementsNameList.Length - 1)
                        return elementValue = gotToken[elementsNameList[index]].ToString();
                    gotToken = gotToken[elementsNameList[index]];
                }
            }
            catch (Exception)
            {
                // Ignored ex.DebugLog();
            }

            return elementValue;
        }

        public JToken GetJToken(params object[] elementsNameList)
        {
            try
            {
                var tempToken = _jObject[elementsNameList[0]];
                for (var index = 1; index < elementsNameList.Length && tempToken != null; index++)
                    tempToken = tempToken[elementsNameList[index]];
                return tempToken ?? new JArray();
            }
            catch (Exception)
            {
                // Ignored  ex.DebugLog();
            }

            return new JArray();
        }

        public JToken GetJTokenOfJToken(JToken gotToken, params object[] elementsNameList)
        {
            try
            {
                var returnToken = gotToken;
                foreach (var element in elementsNameList)
                {
                    if (returnToken == null) break;
                    returnToken = returnToken[element];
                }

                return returnToken ?? new JArray();
            }
            catch (Exception)
            {
                // Ignored ex.DebugLog();
            }

            return new JArray();
        }
    }
}
