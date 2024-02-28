﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AppStoreScarpper.Interface
{
    public interface IHttpHelper:IRequestHelper
    {
        Task<IResponseParameter> GetRequestAsync(string url, CancellationToken cancellationToken);

        Task<IResponseParameter> GetRequestAsync(string url, IRequestParameters requestParameters,
            CancellationToken cancellationToken);

        IResponseParameter GetRequest(string url);
        IResponseParameter GetRequest(string url, IRequestParameters requestParameters);
        IResponseParameter PostRequest(string url, string postData);
        IResponseParameter PostRequest(string url, byte[] postData);
        IResponseParameter PostRequest(string url, string postData, IRequestParameters requestParameters);
        Task<IResponseParameter> PostRequestAsync(string url, string postData, CancellationToken cancellationToken);
        Task<IResponseParameter> PostRequestAsync(string url, byte[] postData, CancellationToken cancellationToken);
        IResponseParameter PostApiRequest(string url, byte[] postData);
        HttpWebRequest Request { get; }
        HttpWebResponse Response { get; }
        Task<IResponseParameter> PostApiRequestAsync(string url, string postData);
        Task<IResponseParameter> PostApiRequestAsync(string url, byte[] postData);
        Task<IResponseParameter> GetApiRequestAsync(string url);
    }
}
