using NUnit.Framework;

namespace LiveKit.PlayModeTests
{
    public class DataStreamTests
    {
        private const string TOPIC = "test-topic";

        [Test]
        public void Test()
        {
            LiveKit.Internal.NativeMethods.init_tracing();
            Assert.Pass();
        }
    }
}
