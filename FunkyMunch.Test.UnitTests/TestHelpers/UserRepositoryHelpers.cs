using FunkyMunch.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FunkyMunch.Test.UnitTests.TestHelpers
{
    public class UserRepositoryHelpers
    {
        public static User GetTestUserWithId(long id)
        {
            return new User
            {
                Id = id,
                CreatedAt = DateTimeOffset.UtcNow,
                CreatedBy = "Unit Test",
                DisplayName = "Unit_Tester",
                EmailAddress = "unit@test.test",
                Password = "AQAAAAEAACcQAAAAEDqZhLz7TLMMzJBnuYR6ikMvdIoyv6VWCS1ohFu99kM/U1pLwRY+OvOexL4vktBPxg==" // hashed version of password
            };
        }
    }
}
