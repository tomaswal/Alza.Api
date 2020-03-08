using Alza.Api.Core.BussinessRule;
using Alza.Api.Core.DomainModel;
using Alza.Api.Core.Repository;
using KellermanSoftware.CompareNetObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

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
        public void GetProductsCollection_ShouldReturnSomeProducts()
        {
            mockProductRepository.Setup(x => x.FindAll())
                                 .Returns(new List<Product>
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
                                 });

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

            var actualResult = productFacade.GetProductsCollection();

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

        //[TestMethod]
        //public void GetById_ShouldBeUpdateProductInRepository_ReturnTrue()
        //{
        //    var inputValue = 1;

        //    mockProductRepository.Setup(x => x.FindById(inputValue))
        //                         .Returns(new Product
        //                         {
        //                             Id = 1,
        //                             Description = "desc1",
        //                             ImgUri = "/test1/test1/test1.png",
        //                             Name = "name1",
        //                             Price = 1.1M
        //                         });

        //    var inputProduct = new Product
        //    {
        //        Id = 1,
        //        Description = "desc3",
        //        ImgUri = "/test1/test1/test3.png",
        //        Name = "name3",
        //        Price = 3.3M
        //    };

        //    var productFacade = new ProductFacade(mockProductRepository.Object, mockUnitOfWork.Object);

        //    var actualResult = productFacade.UpdateProductDescription(inputProduct);

        //    var resulttt = mockProductRepository.Object.FindById(inputValue);

        //    Assert.IsTrue(true);
        //}
    }
}
