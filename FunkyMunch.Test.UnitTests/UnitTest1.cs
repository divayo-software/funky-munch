using System;
using Xunit;

namespace FunkyMunch.Test.UnitTests
{
    public class UnitTest1
    {
        /// <summary>
        ///     This test should always pass.
        /// </summary>
        [Fact]
        public void Test1()
        {
            var testBool = true;

            Assert.True(testBool);
        }
    }
}
