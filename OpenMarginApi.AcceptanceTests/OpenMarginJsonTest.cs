using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Should.Fluent;
using Should;
using MarkG1968.OpenMargin;
using NodaMoney;

namespace MarkG1968.OpenMarginApi.AcceptanceTests
{
    public class OpenMarginJsonTests
    {
        public void GetReturnsResponseWithCorrectStatusCode()
        {
            using (var client = HttpClientFactory.Create())
            {
                var response = client.GetAsync("").Result;

                response.IsSuccessStatusCode.Should().Equal(true);
            }
        }

        public void GetReturnsResponseWithExpectedType()
        {
            using (var client = HttpClientFactory.Create())
            {
                var response = client.GetAsync("").Result;

                response.Content.Headers.ContentType.MediaType.Should().Equal("application/json");
                ObjectAssertExtensions.ShouldNotBeNull(response.Content.ReadAsJsonAsync().Result);
            }
        }
 
        public void GetReturnsResponseWithExpectedMarginCall()
        {
            using (var client = HttpClientFactory.Create())
            {
                var response = client.GetAsync("").Result;

                var expectedJson = new { MarginCall = Money.PoundSterling(1000) }.ToJObject();
                var result = response.Content.ReadAsJsonAsync().Result;
                ObjectAssertExtensions.ShouldEqual(result, expectedJson);
            }
        }
    }
}
