using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jwt
{
    /// <summary>
    /// 加密解密接口
    /// </summary>
    public interface IJwt
    {
        string GetToken(IDictionary<string, string> Clims, string OldToken = null);
        bool ValidateToken(string Token, out Dictionary<string, string> Clims);
        bool InvalidateToken(string Token);
    }
}
