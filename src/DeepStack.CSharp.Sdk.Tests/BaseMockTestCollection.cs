using System.Net;
using System.Net.Http;
using Xunit;

namespace DeepStack.Tests
{
    [CollectionDefinition("Globally Paid SDK tests")]
    public class BaseMockTestCollection :
        ICollectionFixture<MockHttpClientFixture>
    {
        // This class has no code, and is never created. Its purpose is simply to be the place to
        // apply [CollectionDefinition] and all the ICollectionFixture<> interfaces.
    }
}
