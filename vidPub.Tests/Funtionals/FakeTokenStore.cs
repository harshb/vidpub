using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VidPub.Web.Infrastructure;

namespace VidPub.Tests.Funtionals
{
    class FakeTokenStore: ITokenHandler
    {
        string _token;
        public string GetToken()
        {
            return _token;
        }

        public void RemoveClientAccess()
        {
            _token = "";
        }

        public void SetClientAccess(string token)
        {
            _token = token;
        }
    }
}
