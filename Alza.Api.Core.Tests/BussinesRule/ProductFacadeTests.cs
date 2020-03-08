using Alza.Api.Core.BussinessRule;
using Alza.Api.Core.DomainModel;
using Alza.Api.Core.Repository;
using KellermanSoftware.CompareNetObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Alza.Api.Core.Tests.BussinesRule
{
    [TestClass]
    public class ProductFacadeTests
    {
        private Mock<IProductRepository> mockProductRepository;
        private Mock<IUnitOfWork> mockUnitOfWork;
        [TestInitialize]
        public void InitTest()
        {
            mockProductRepository = new Mock<IProductRepository>();
            mockUnitOfWork = new Mock<IUnitOfWork>();
            //mockProductRepository.Setup(x=> x.FindAll)
        }

        [TestMethod]
        public async Task GetProductsCollection_ShouldReturnSomeProducts()
        {
            mockProductRepository.Setup(x => x.FindAllAsync())
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

            var expectedResult = new List<Product>
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
                                 };

            var productFacade = new ProductFacade(mockProductRepository.Object, mockUnitOfWork.Object);

            var actualResult = await productFacade.GetProductsCollection();

            CompareLogic compareLogic = new CompareLogic();
            ComparisonResult comapreResult = compareLogic.Compare(expectedResult, actualResult);

            Assert.IsTrue(comapreResult.AreEqual);
        }

        [TestMethod]
        public void GetProductById_ShouldReturnOnlyOneProduct()
        {
            var inputValue = 1;
            mockProductRepository.Setup(x => x.FindById(inputValue))
                     .Returns(new Product
                     {
                         Id = 1,
                         Description = "desc1",
                         ImgUri = "/test1/test1/test1.png",
                         Name = "name1",
                         Price = 1.1M
                     });

            var expectedResult = new Product
            {
                Id = 1,
                Description = "desc1",
                ImgUri = "/test1/test1/test1.png",
                Name = "name1",
                Price = 1.1M
            };

            var productFacade = new ProductFacade(mockProductRepository.Object, mockUnitOfWork.Object);
            var actualResult = productFacade.GetProductById(inputValue);

            CompareLogic compareLogic = new CompareLogic();
            ComparisonResult comapreResult = compareLogic.Compare(expectedResult, actualResult);

            Assert.IsTrue(comapreResult.AreEqual);

        }

        [TestMethod]
        public async Task GetById_ShouldBeUpdateProductDescription_ReturnTrue()
        {
            var inputProductId = 1;
            var inputDesc = "test";

            mockProductRepository.Setup(x => x.FindById(inputProductId))
                                 .Returns(new Product
                                 {
                                     Id = 1,
                                     Description = "desc1",
                                     ImgUri = "/test1/test1/test1.png",
                                     Name = "name1",
                                     Price = 1.1M
                                 });

            var expectedProduct = new Product
            {
                Id = 1,
                Description = inputDesc,
                ImgUri = "/test1/test1/test1.png",
                Name = "name1",
                Price = 1.1M
            };

            var productFacade = new ProductFacade(mockProductRepository.Object, mockUnitOfWork.Object);

            var actualResult = await productFacade.UpdateProductDescription(inputProductId, inputDesc);

            var actualProduct = mockProductRepository.Object.FindById(inputProductId);

            
            CompareLogic compareLogic = new CompareLogic();
            ComparisonResult comapreResult = compareLogic.Compare(expectedProduct, actualProduct);

            Assert.IsTrue(comapreResult.AreEqual);
            Assert.IsTrue(actualResult);
            mockUnitOfWork.Verify(x => x.SaveChangesAsync(), Times.Once);
        }
    }
}
