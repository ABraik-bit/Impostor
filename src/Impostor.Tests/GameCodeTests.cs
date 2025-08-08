using Impostor.Api.Innersloth;
using Impostor.Api.Net.Inner;
using Impostor.Api.Net.Inner.Objects;
using Xunit;

namespace Impostor.Tests
{
    public class GameCodeTests
    {
        [Fact]
        public void CodeV1()
        {
            const string code = "ABCD";
            const int codeInt = 0x44434241;

            Assert.Equal(code, GameCodeParser.IntToGameName(codeInt));
            Assert.Equal(codeInt, GameCodeParser.GameNameToInt(code));
        }

        [Fact]
        public void CodeV2()
        {
            const string code = "ABCDEF";
            const int codeInt = -1943683525;

            Assert.Equal(code, GameCodeParser.IntToGameName(codeInt));
            Assert.Equal(codeInt, GameCodeParser.GameNameToInt(code));
        }
    }

    public class InnerPlayerInfoTests
    {
        [Fact]
        public void GetNextRpcSequenceId_IsAccessibleThroughInterface()
        {
            // This test verifies that the GetNextRpcSequenceId method is accessible through the IInnerPlayerInfo interface
            // The method should be available for plugins to use
            var methodInfo = typeof(IInnerPlayerInfo).GetMethod("GetNextRpcSequenceId");
            
            Assert.NotNull(methodInfo);
            Assert.Equal(typeof(byte), methodInfo.ReturnType);
            Assert.Single(methodInfo.GetParameters());
            Assert.Equal(typeof(RpcCalls), methodInfo.GetParameters()[0].ParameterType);
        }
    }
}
