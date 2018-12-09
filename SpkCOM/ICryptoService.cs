using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SpkCOM
{
    [Guid("83e6e0f8-492e-48ca-8b68-f175afdd5453")]
    public interface ICryptoService
    {
        [DispId(1)]
        string Encrypt(string input, string key);
        [DispId(2)]
        string Decrypt(string input, string key);
    }
}
