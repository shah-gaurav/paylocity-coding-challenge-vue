﻿using FakeItEasy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Paylocity.CodingChallenge.Web.Code;
using Paylocity.CodingChallenge.Web.Pages;
using Paylocity.CodingChallenge.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Paylocity.CodingChallenge.Web.Tests.Pages
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class ResultsModelTests
    {
        [TestMethod]
        public void verify_return_to_index_if_tempdata_is_null()
        {
            // Arrange
            var httpContext = new DefaultHttpContext();
            var modelState = new ModelStateDictionary();
            var actionContext = new ActionContext(httpContext, new RouteData(), new PageActionDescriptor(), modelState);
            var modelMetadataProvider = new EmptyModelMetadataProvider();
            var viewData = new ViewDataDictionary(modelMetadataProvider, modelState);
            var tempData = new TempDataDictionary(httpContext, A.Fake<ITempDataProvider>());
            var pageContext = new PageContext(actionContext)
            {
                ViewData = viewData
            };
            var objectUnderTest = new ResultsModel()
            {
                PageContext = pageContext,
                TempData = tempData,
                Url = new UrlHelper(actionContext)
            };

            // Act
            var result = objectUnderTest.OnGet();

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToPageResult));
            Assert.IsTrue(((RedirectToPageResult)result).PageName == Paylocity.CodingChallenge.Web.Code.Constants.INDEX_PAGE);
        }

        [TestMethod]
        public void verify_page_displayed_when_calculation_results_are_in_tempdata()
        {
            // Arrange
            var httpContext = new DefaultHttpContext();
            var modelState = new ModelStateDictionary();
            var actionContext = new ActionContext(httpContext, new RouteData(), new PageActionDescriptor(), modelState);
            var modelMetadataProvider = new EmptyModelMetadataProvider();
            var viewData = new ViewDataDictionary(modelMetadataProvider, modelState);
            var tempData = new TempDataDictionary(httpContext, A.Fake<ITempDataProvider>());
            var pageContext = new PageContext(actionContext)
            {
                ViewData = viewData
            };
            var objectUnderTest = new ResultsModel()
            {
                PageContext = pageContext,
                TempData = tempData,
                Url = new UrlHelper(actionContext)
            };
            objectUnderTest.TempData.Set(Web.Code.Constants.RESULTS_TEMP_DATA_KEY, new DeductionCalculationResults());

            // Act
            var result = objectUnderTest.OnGet();

            // Assert
            Assert.IsInstanceOfType(result, typeof(PageResult));
        }
    }
}
