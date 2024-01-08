using ASPUnitTest.Controllers;
using ASPUnitTest.Models;
using ASPUnitTest.Services;
using Microsoft.AspNetCore.Mvc;

namespace ASPTesting
{
    public class BeerTesting
    {
        private readonly BeerController _controller;
        private readonly IBeerService _service;

        public BeerTesting()
        {
            _service = new BeerService();
            _controller = new BeerController(_service);
        }

        [Fact]
        public void Get_Ok()
        {
            var result = _controller.Get();
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Get_Quantity()
        {
            var result = (OkObjectResult)_controller.Get();
            var beers =Assert.IsType<List<Beer>>(result.Value);

            Assert.True(beers.Count > 0);
        }

        [Fact]
        public void GetById_Ok()
        {

            // Arrange
            int id = 1;

            // Act
            var result = _controller.GetById(id);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void GetById_Exists()
        {
            // Arrange
            int id = 1;

            // Act
            var result = (OkObjectResult)_controller.GetById(id);

            // Assert
            var beer = Assert.IsType<Beer>(result?.Value);
            Assert.True(beer != null);
            Assert.Equal(beer?.Id, id);

        }

        [Fact]
        public void GetById_NotFound()
        {
            // Arrange
            int id = 11;

            // Act
            var result =_controller.GetById(id);

            // Assert
            var beer = Assert.IsType<NotFoundResult>(result);

        }
    }
}