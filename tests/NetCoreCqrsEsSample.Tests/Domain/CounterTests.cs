using FluentAssertions;
using NetCoreCqrsEsSample.Domain.Models;
using Xunit;

namespace NetCoreCqrsEsSample.Tests.Domain
{
    public class CounterTests
    {

        [Fact]
        public void Should_increment_correctly()
        {
            //Given
            var counter = new Counter();
            var counter2 = new Counter(12);

            //When
            counter.Increment();
            counter2.Increment();

            //Then
            counter.Value.Should().Be(1);
            counter2.Value.Should().Be(13);
        }

        [Fact]
        public void Should_decrement_correctly()
        {
            //arrange
            var counter = new Counter();
            var counter2 = new Counter(43);

            //act
            counter.Decrement();
            counter2.Decrement();

            //assert
            counter.Value.Should().Be(-1);
            counter2.Value.Should().Be(42);
        }

        [Fact]
        public void Should_apply_multiple_operations_correctly()
        {
            //arrange
            var counter = new Counter(5);

            //act
            for (var i = 0; i < 3; i++)
            {
                counter.Increment();
            }
            counter.Decrement();

            //assert
            counter.Value.Should().Be(7);
        }
    }
}