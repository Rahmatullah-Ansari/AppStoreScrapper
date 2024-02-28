using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStoreScarpper.Requests
{
   public class FileData
    {
        public FileData(NameValueCollection headers, string fileName, byte[] contents)
        {
            Headers = headers;
            FileName = fileName;
            Contents = contents;
        }

        public byte[] Contents { get; }

        public string FileName { get; }

        public NameValueCollection Headers { get; }
    }
}
