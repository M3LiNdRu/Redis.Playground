using System;
using Xunit;
using System.Threading.Tasks;

namespace Redis.Playground.UnitTest
{
    public class RedisTests
    {
        private readonly IRedisRepository _repository;

        public RedisTests()
        {
            _repository = new RedisRepository();
        }

        [Theory]
        [InlineData("key", "value")]
        public async Task Test_GetString_Success(string key, string value)
        {
            //Arrange
            await _repository.SetString(key, value);

            //Act
            var result = await _repository.GetString(key);

            //Assert
            Assert.True(result == value);
        }
    }
}
