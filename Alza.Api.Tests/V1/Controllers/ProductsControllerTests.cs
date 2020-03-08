using Alza.Api.Core.BussinessRule;
using Alza.Api.Core.DomainModel;
using Alza.Api.v1.Controllers;
using Alza.Api.v1.DTO;
using Alza.Api.v1.Mapper;
using AutoMapper;
using KellermanSoftware.CompareNetObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alza.Api.Tests.V1.Controllers
{
    [TestClass]
    public class ProductsControllerTests
    {
        private Mock<IProductFacade> mockProductFacade;
        private Mapper mapper;

        [TestInitialize]
        public void InitTest()
        {
            mockProductFacade = new Mock<IProductFacade>();

            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new ProductProfile()));
            mapper = new AutoMapper.Mapper(configuration);
        }

        [TestMethod]
        public async Task GetCollection_ShouldReturnCollectionOfProducts()
        {
            mockProductFacade.Setup(x => x.GetProductsCollection())
                     .Returns(Task.FromResult(new List<Product>
                     {
                                    new Product
                                    {
                                        Id = 1,
                                        Description = "desc1",
                                        ImgUri = "/test1/test1/test1.png",
                                        Name = "name1",
                                        Price = 1.1M
                                    },
                                    new Product
                                    {
                                        Id = 2,
                                        Description = "desc2",
                                        ImgUri = "/test2/test2/test2.png",
                                        Name = "name2",
                                        Price = 2.2M
                                    },
                     }));

            var expectedResult = new List<ProductDTO>
                                 {
                                    new ProductDTO
                                    {
                                        Id = 1,
                                        Description = "desc1",
                                        ImgUri = "/test1/test1/test1.png",
                                        Name = "name1",
                                        Price = 1.1M
                                    },
                                    new ProductDTO
                                    {
                                        Id = 2,
                                        Description = "desc2",
                                        ImgUri = "/test2/test2/test2.png",
                                        Name = "name2",
                                        Price = 2.2M
                                    },
                                 };

            var controller = new ProductsController(mockProductFacade.Object, mapper);
            var controllerResult = await controller.Get();

            var actualResult = ObjectConvert.GetOkObject<IEnumerable<ProductDTO>>(controllerResult.Result);

            CompareLogic compareLogic = new CompareLogic();
            ComparisonResult comapreResult = compareLogic.Compare(expectedResult.AsEnumerable(), actualResult);

            Assert.IsTrue(comapreResult.AreEqual);

        }

        [TestMethod]
        public void GetById_ShouldReturnCollectionOfProducts()
        {
            var inputId = 1;
            mockProductFacade.Setup(x => x.GetProductById(inputId))
                             .Returns(new Product
                             {
                                 Id = 1,
                                 Description = "desc1",
                                 ImgUri = "/test1/test1/test1.png",
                                 Name = "name1",
                                 Price = 1.1M
                             });

            var expectedResult = new ProductDTO
            {
                Id = 1,
                Description = "desc1",
                ImgUri = "/test1/test1/test1.png",
                Name = "name1",
                Price = 1.1M
            };

            var controller = new ProductsController(mockProductFacade.Object, mapper);
            var controllerResult = controller.Get(inputId);

            var actualResult = ObjectConvert.GetOkObject<ProductDTO>(controllerResult.Result);

            CompareLogic compareLogic = new CompareLogic();
            ComparisonResult comapreResult = compareLogic.Compare(expectedResult, actualResult);

            Assert.IsTrue(comapreResult.AreEqual);
        }

        [TestMethod]
        public async Task Patch_ShouldReturnCollectionOfProducts()
        {
            var inputId = 1;
            var inputDesc = "test";
            var controller = new ProductsController(mockProductFacade.Object, mapper);
            await controller.Patch(inputId, new ProductPartialDTO { Description = inputDesc });

            mockProductFacade.Verify(x => x.UpdateProductDescription(inputId, inputDesc), Times.Once);
        }
    }

}
