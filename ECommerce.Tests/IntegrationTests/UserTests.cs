using Ecommerce.DOMAIN.DTOs.Response;
using Ecommerce.DOMAIN.Models;
using ECommerce.Tests.Config;
using ECommerce.Tests.Config.Mocks;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Testing;
//using Microsoft.VisualStudio.TestPlatform.TestHost;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Tests.IntegrationTests
{
    public class UserTests
    {
        [Test]
        public async Task GET_Return_User_By_Email()
        {
            await using var application = new DatabaseApiApplication();

            await UserMockData.CreateUsers(application, true);
            var user1mail = "user1@mail.com";
            var url = $"/api/User/{user1mail}";

            var client = application.CreateClient();

            var result = await client.GetAsync($"/api/User/user1@mail.com/");
            //var receivedUser = await client.GetFromJsonAsync<IActionResult>($"/api/User/{user1mail}") as OkObjectResult;
            var receivedUser = result.Content;

            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            Assert.IsNotNull(receivedUser);
        }

    }
}
