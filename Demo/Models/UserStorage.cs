using System;
using System.Collections.Generic;

namespace dotnet_wms_ef.Demo
{
    public static class UserStorage
    {
        public static List<User> Users { get; set; } = new List<User> {
        new User {ID=Guid.NewGuid(),Username="user1",Password = "user1psd" },
        new User {ID=Guid.NewGuid(),Username="user2",Password = "user2psd" },
        new User {ID=Guid.NewGuid(),Username="user3",Password = "user3psd" }
    };
    }
}