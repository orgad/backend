using System;

namespace dotnet_wms_ef.Auth
{
    public class User
    {
      public Guid ID { get; set; }
      public string Username { get; set; }
      public string Password { get; set; }
    }
}