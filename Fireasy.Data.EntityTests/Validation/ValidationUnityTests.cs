// -----------------------------------------------------------------------
// <copyright company="Fireasy"
//      email="faib920@126.com"
//      qq="55570729">
//   (c) Copyright Fireasy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Fireasy.Data.Entity.Test.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Fireasy.Data.Entity.Validation.Test
{
    [TestClass()]
    public class ValidationUnityTests
    {
        [TestMethod()]
        public void ValidateTest()
        {
            var p = new Products();
            ValidationUnity.Validate(p);
        }

        /// <summary>
        /// 使用自定义验证测试Validate方法。
        /// </summary>
        [TestMethod()]
        public void ValidateWithCustomAttributeTest()
        {
            ValidationUnity.RegisterValidation(typeof(Products), new ProductQuantityValidateAttribute());
            var p = new Products { ProductID = 1, ProductName = "111111111111111", Discontinued = true };
            ValidationUnity.Validate(p);
        }

        /// <summary>
        /// 使用自定义验证测试Validate方法。
        /// </summary>
        [TestMethod()]
        public void ValidateWithCustomAttributeTest1()
        {
            var p = PropertyUnity.GetProperty(typeof(Orders), "CustomerID");
            ValidationUnity.RegisterValidation(p, new AnyValidateAttribute());
            var o = new Orders { CustomerID = "AA" };
            ValidationUnity.Validate(o);
        }

        /// <summary>
        /// 使用自定义验证测试Validate方法。
        /// </summary>
        [TestMethod()]
        public void ValidateWithCustomAttributeTest2()
        {
            var p = new Products { ProductID = 1, ProductName = "1111111d11111111", Discontinued = true };
            ValidationUnity.Validate(p);
        }

        /// <summary>
        /// 测试GetValidations方法。
        /// </summary>
        [TestMethod()]
        public void GetValidationsTest()
        {
            ValidationUnity.RegisterValidation(typeof(Products), new ProductQuantityValidateAttribute());
            var validations = ValidationUnity.GetValidations(typeof(Products));
            Console.WriteLine(validations.Count());
        }

        /// <summary>
        /// 测试GetValidations方法。
        /// </summary>
        [TestMethod()]
        public void GetPropertyValidationsTest()
        {
            var p = PropertyUnity.GetProperty(typeof(Orders), "CustomerID");
            ValidationUnity.RegisterValidation(p, new ProductQuantityValidateAttribute());
            var validations = ValidationUnity.GetValidations(p);
            Console.WriteLine(validations.Count());
        }

        /// <summary>
        /// 测试并行情况下GetValidations方法。
        /// </summary>
        [TestMethod()]
        public void GetValidationsParallelTest()
        {
            ValidationUnity.RegisterValidation(typeof(Products), new ProductQuantityValidateAttribute());
            Parallel.For(0, 100, (i) =>
                {
                    var validations = ValidationUnity.GetValidations(typeof(Products));
                    Console.WriteLine(validations.Count());
                });
        }

        /// <summary>
        /// 针对某一个属性测试GetValidations方法。
        /// </summary>
        [TestMethod()]
        public void GetValidationsForPropertyTest()
        {
            var p = PropertyUnity.GetProperty(typeof(Products), "ProductName");
            var validations = ValidationUnity.GetValidations(p);
            Console.WriteLine(validations.Count());
        }

        /// <summary>
        /// 并行情况下针对某一个属性测试GetValidations方法。
        /// </summary>
        [TestMethod()]
        public void GetValidationsForPropertyParallelTest()
        {
            Parallel.For(0, 100, (i) =>
                {
                    var p = PropertyUnity.GetProperty(typeof(Products), "ProductName");
                    var validations = ValidationUnity.GetValidations(p);
                    Console.WriteLine(validations.Count());
                });
        }

        /// <summary>
        /// 测试RegisterValidationT方法。
        /// </summary>
        [TestMethod()]
        public void RegisterValidationTest()
        {
            ValidationUnity.RegisterValidation(typeof(Products), new ProductQuantityValidateAttribute());
        }

        /// <summary>
        /// 测试并行情况下RegisterValidationT方法。
        /// </summary>
        [TestMethod()]
        public void RegisterValidationParallelTest()
        {
            Parallel.For(0, 100, (i) =>
                {
                    ValidationUnity.RegisterValidation(typeof(Products), new ProductQuantityValidateAttribute());
                });
        }

        private class ProductQuantityValidateAttribute : ValidationAttribute
        {
            public override bool IsValid(object value)
            {
                var p = value as Products;
                if (p.UnitsOnOrder > p.UnitsInStock)
                {
                    ErrorMessage = "订单量超出库存量。";
                    return false;
                }

                return true;
            }
        }

        private class AnyValidateAttribute : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                return new ValidationResult("error");
            }
        }

    }
}
