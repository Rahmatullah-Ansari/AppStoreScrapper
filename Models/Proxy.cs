using AppStoreScarpper.Utilities;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AppStoreScarpper.Models
{
    public class Proxy
    {
        private static readonly Regex ProxyPortValidationRegex =
           new Regex("^([0-9]{1,4}$|[1-5][0-9]{4}$|6[0-4][0-9]{3}$|65[0-4][0-9]{2}$|655[0-2][0-9]$|6553[0-5])$");

        private string _proxyIp;
        private string _proxyPort;
        private string _proxyUsername;
        private string _proxyPassword;

        public Proxy()
        {
            HasCredentials = false;
            HasProxy = false;
            ProxyId = ConstantHelpDetails.GetGuid();
        }

        #region Properties

        [ProtoMember(10)] public string ProxyId { get; set; }
        [ProtoMember(5)] public bool HasCredentials { get; set; }

        [ProtoMember(6)] public bool HasProxy { get; }

        [ProtoMember(1)]
        public string ProxyIp
        {
            get => _proxyIp;
            set => _proxyIp = value;
        }

        [ProtoMember(2)]
        public string ProxyPort
        {
            get => _proxyPort;
            set => _proxyPort = value;
        }

        [ProtoMember(4)]
        public string ProxyPassword
        {
            get => _proxyPassword;
            set => _proxyPassword = value;
        }

        [ProtoMember(3)]
        public string ProxyUsername
        {
            get => _proxyUsername;
            set => _proxyUsername = value;
        }

        private string _proxyName;

        [ProtoMember(7)]
        public string ProxyName
        {
            get => _proxyName;
            set => _proxyName = value;
        }

        private string _proxyGroup = "UnGroup";

        [ProtoMember(8)]
        public string ProxyGroup
        {
            get => _proxyGroup;
            set => _proxyGroup = value;
        }

        #endregion

        #region Methods

        public string GetProxy()
        {
            if (!string.IsNullOrWhiteSpace(ProxyIp))
                return ProxyIp + ":" + ProxyPort;

            return "No Proxy Found";
        }

        public static bool IsValidProxy(string ip, string port)
        {
            return Regex.IsMatch(ip + ":" + port, "^\\d{1,3}(\\.\\d{1,3}){3}:\\d{1,5}$");
        }

        public static bool IsValidProxyIp(string proxyAddress)
        {
            return true;// ProxyIpValidationRegex.IsMatch(proxyAddress) || IsLuminatiProxy(proxyAddress);
        }

        public static bool IsLuminatiProxy(string proxyAddress)
        {
            return proxyAddress.Contains("zproxy.lum-superproxy.io") || proxyAddress.Contains("proxy.iproyal.com");
        }

        public static bool IsValidProxyPort(string proxyPort)
        {
            return ProxyPortValidationRegex.IsMatch(proxyPort);
        }

        #endregion
    }
}
