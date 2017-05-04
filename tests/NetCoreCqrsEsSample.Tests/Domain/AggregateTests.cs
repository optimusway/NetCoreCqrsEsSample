using FluentAssertions;
using NetCoreCqrsEsSample.Domain.Models;
using Xunit;

namespace NetCoreCqrsEsSample.Tests.Domain
{
    public class AggregateTests
    {
        [Fact]
        public void Should_load_aggregate_from_events_correctly()
        {
            // arrange
            var counter = new Counter();
            var newCounter = new Counter();

            // act
            counter.Increment();
            counter.Increment();
            counter.Decrement();
            counter.Increment();
            newCounter.LoadFromHistory(counter.GetUncommittedChanges());

            // assert
            counter.Value.Should().Be(2);
            newCounter.Value.Should().Be(2);
        }
    }
}