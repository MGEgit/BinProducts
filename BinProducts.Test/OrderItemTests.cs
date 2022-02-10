using BinProducts.Core;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace BinProducts.Test
{
    public class OrderItemTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(101)]
        public void When_Construct_Given_QuantityLessThanOneOrMoreThan100_Then_Throw(int lessThanOneQuantity)
        {
            // arrange

            
            // act

            Action action = () => new OrderItem(ProductType.Canvas, lessThanOneQuantity);


            // assert

            action.Should().ThrowExactly<DomainException>();
        }

        [Fact]
        public void When_Construct_Given_InvalidProductType_Then_Throw()
        {
            // arrange

            ProductType invalidProductType = (ProductType)100;
            int someQuantity = 1;

            // act

            Action action = () => new OrderItem(invalidProductType, someQuantity);


            // assert

            action.Should().ThrowExactly<DomainException>();
        }
    }
}
