using System;
using System.Net;

namespace CLI.IA.Utils;

public static class ApiVerify
{
    public static void VerifyResponse(HttpResponseMessage apiUrl)
    {
      switch (apiUrl.StatusCode)
      {
        case HttpStatusCode.NotFound:
          Console.WriteLine("User not found");
          return;
        case HttpStatusCode.InternalServerError:
          Console.WriteLine("Error internal server");
          return;
        default:
            return;
      }  
    }
}
