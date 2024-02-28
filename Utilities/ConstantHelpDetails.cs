using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AppStoreScarpper.Utilities
{
   public class ConstantHelpDetails
    {
        public static Random ObjRandom { get; } = new Random(Guid.NewGuid().GetHashCode());
        public static string GetUtilityBetween(string strsource, string str1, string str2)
        {
            try
            {
                if (string.IsNullOrEmpty(str1) || string.IsNullOrEmpty(str2)) return string.Empty;
                var start = strsource.IndexOf(str1, 0, StringComparison.Ordinal) + str1.Length;
                var end = strsource.IndexOf(str2, 0, StringComparison.Ordinal);
                if (end < 0 || start < 0) return string.Empty;
                return strsource.Substring(start, end - start);

            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
        public static string GetGuid(bool isDashesNeed = true)
        {
            // Generate the GUID 
            var getGuid = Guid.NewGuid().ToString();
            // return the GUID without dashes if isDashesNeed is true 
            return !isDashesNeed ? getGuid.Replace('-', char.MinValue) : getGuid;
        }
        public static int GetRandomNumber(int maxValue, int minValue = 0)
        {
            // increase the maxValue for getting a chance for select a last item as random number
            ++maxValue;
            // Collect the random value from min and max value
            return ObjRandom.Next(minValue, maxValue);
        }
        public static string GetDecodedResponseOfJson(string response)
        {
            string decodedResponse = "";
            if (!response.IsValidJson() && response.Contains("}}csrf :") && !response.EndsWith("}}"))
                decodedResponse = Regex.Replace(response, "}}csrf :(.*)?", "") + "}}";
            if (!response.IsValidJson() && response.Contains("window['___INITIAL_STATE___'] =") && response.Contains("</script>"))
                decodedResponse =GetUtilityBetween(WebUtility.HtmlDecode(response), "window['___INITIAL_STATE___'] =", "</script>")?.Trim()?.TrimEnd(';');
            if (!decodedResponse.IsValidJson())
            {
                try
                {
                    decodedResponse = Regex.Replace(response, "\\\\([^u])", "\\\\$1").Replace("\\", "");
                    decodedResponse = WebUtility.HtmlDecode(decodedResponse).Replace("u003C", "<").Replace("u00252C", ",");

                }
                catch (Exception ex)
                {
                    decodedResponse = response;
                    decodedResponse = WebUtility.HtmlDecode(decodedResponse).Replace("u003C", "<").Replace("u00252C", ",");
                }
            }
            if (!decodedResponse.IsValidJson() && decodedResponse.Contains("<!--"))
            {
                decodedResponse = decodedResponse.Replace("<!--", string.Empty).Replace("--!>", string.Empty);
            }
            return decodedResponse;

        }
    }
}
