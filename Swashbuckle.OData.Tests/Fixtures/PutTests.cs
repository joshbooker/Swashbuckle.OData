﻿using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Owin.Hosting;
using NUnit.Framework;
using Swashbuckle.OData.Tests.WebHost;
using Swashbuckle.Swagger;

namespace Swashbuckle.OData.Tests
{
    [TestFixture]
    public class PutTests
    {
        [Test]
        public async Task It_includes_a_put_operation()
        {
            using (WebApp.Start(TestWebApiStartup.BaseAddress, appBuilder => new TestWebApiStartup().Configuration(appBuilder)))
            {
                // Arrange
                var httpClient = HttpClientUtils.GetHttpClient();

                // Act
                var swaggerDocument = await httpClient.GetAsync<SwaggerDocument>("swagger/docs/v1");

                // Assert
                PathItem pathItem;
                swaggerDocument.paths.TryGetValue("/Customers({Id})", out pathItem);
                pathItem.Should().NotBeNull();
                pathItem.put.Should().NotBeNull();
            }
        }
    }
}