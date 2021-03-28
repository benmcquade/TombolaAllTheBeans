using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using TombolaAllTheBeans.Controllers;
using TombolaAllTheBeans.Models;
using TombolaAllTheBeans.Repositories;

namespace TombolaAllTheBeansTests
{
    // obvioulsy not extensive testing, would include more in time and also theres no services to test given the lack of data manipulation
    [TestClass]
    public class BeansRepoTests
    {
        Mock<BeansRepository>_mockBeansRepository = new Mock<BeansRepository>();

        [TestMethod]
        public void GetAllBeans_ReturnsMultipleBeans_NoArguements()
        {
            // Arrange
            var exampleBeans = this.FakeData();

            // this is obviously not a very well covered test, normally i wouldnt be using a json file as a database
            // and i would be mocking the actual db call, not really feasible when its using a file read.
            _mockBeansRepository.Setup(x => x.GetAllBeans()).Returns(exampleBeans);

            // Act
            var result = _mockBeansRepository.Object.GetAllBeans();

            // Assert
            Assert.AreEqual(exampleBeans, result);
        }

        // doing this manually, but would use a library to generate data
        private List<Bean> FakeData()
        {
            return new List<Bean>
            {
                new Bean
                {
                    Name = "test one"
                },
                new Bean
                {
                    Name = "test two"
                }
            };
        }
    }
}
