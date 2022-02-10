using BinProducts.Core;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace BinProducts.Test
{
    public class OrderTests
    {
        [Fact]
        public void When_Construct_Given_DuplicatedProductType_Then_Throw()
        {
            // arrange

            var someId = Guid.NewGuid();
            int someQuantity = 1;

            var orderItems = new List<OrderItem>() {
                new OrderItem(ProductType.Calendar, someQuantity),
                new OrderItem(ProductType.Calendar, someQuantity) };


            // act

            Action action = () => new Order(someId, orderItems);


            // assert

            action.Should().ThrowExactly<DomainException>();
        }

        [Fact]
        public void When_Construct_Given_Quantities_Then_CalculateRequiredBinWidth()
        {
            // arrange

            var someId = Guid.NewGuid();
            int someQuantity = 1;

            var orderItems = new List<OrderItem>() {
                new OrderItem(ProductType.Calendar, someQuantity),
                new OrderItem(ProductType.Canvas, someQuantity) };

            var expected = (Calendar.Calendar_Width * someQuantity) + (Canvas.Canvas_Width * someQuantity);

            // act

            var sut = new Order(someId, orderItems);


            // assert

            sut.RequiredBinWidth.Should().Be(expected);
        }

        [Fact]
        public void When_Construct_Given_MoreThan4MugQuantitiy_Then_CalculateRequiredBinWidth()
        {
            // arrange

            var someId = Guid.NewGuid();
            int someQuantity = 1;
            int mugQuantity = 5;

            var orderItems = new List<OrderItem>() {
                new OrderItem(ProductType.Calendar, someQuantity),
                new OrderItem(ProductType.Mug, mugQuantity) };

            var expected = (Calendar.Calendar_Width * someQuantity) + (Mug.Mug_Width * 2);

            // act

            var sut = new Order(someId, orderItems);


            // assert

            sut.RequiredBinWidth.Should().Be(expected);
        }

    }
}
