using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TestAutomationStockCount.StockCount.Tests;

namespace StockCount.Tests
{
    [Binding]
    public class ProductsSteps
    {
		private FourthLoginPage FourthLoginPage;
		private FourthHomePage FourthHomePage;
		private SCLocationPage SCLocationPage;
		private SCHomePage SCHomePage;
        private ProductsPage ProductsPage;

		public ProductsSteps(FourthLoginPage login, FourthHomePage fourthHomePage, SCLocationPage scLocationPage, SCHomePage scHomePage, ProductsPage productsPage)
		{
			FourthLoginPage = login;
			FourthHomePage = fourthHomePage;
			SCLocationPage = scLocationPage;
			SCHomePage = scHomePage;
            ProductsPage = productsPage;
		}

		[When(@"they navigate to a Stock list screen for area ""(.*)""")]
		public void WhenTheyNavigateToAStockListScreenForArea(string area)
        {
            SCHomePage.OpenArea(area);
		}

		[Then(@"they are presented with all the products returned from the API for the users current location")]

		public void ThenTheyArePresentedWithAllTheProductsReturnedFromTheAPIForTheUsersCurrentLocation()
		{
			var expectedProducts = new List<string>
			{
				"Almonds Ground",
				"Guinness",
				"Cheese: Taleggio",
				"Red Bull",
			};
			var actualProducts = ProductsPage.Products.Select(x => x.Name).ToList();

			Assert.That(expectedProducts, Is.EqualTo(actualProducts));
		}

		[Then(@"underneath every product there is a list of all UOMs returned from the API for the specific product")]

		public void ThenUnderneathEveryProductThereIsAListOfAllUOMsReturnedFromTheAPIForTheSpecificProduct()
		{
            var expectedUOMs = new List<string>
			{
				"1KG",
				"1GAL",
				"1KG",
				"1EA",
			};
            var actualProducts = ProductsPage.Products.Select(x => x.UOM).ToList();

			Assert.That(expectedUOMs, Is.EqualTo(actualProducts));
		}

		[When(@"user enters area ""(.*)""")]
		public void WhenUserEntersAnArea(string area)
		{
			SCHomePage.OpenArea(area);
		}

		[Then(@"the correct list of products associated with the given location is displayed")]
		public void ThenTheCorrectListOfProductsAssociatedWithTheGivenLocationIsDisplayedR()
		{
			var expectedProducts = new List<string>
			{
				"Almonds Ground",
				"Guinness",
				"Cheese: Taleggio",
				"Red Bull",
			};
			var actualProducts = ProductsPage.Products.Select(x => x.Name).ToList();

			Assert.That(expectedProducts, Is.EqualTo(actualProducts));
		}

		[Then(@"the correct quantity for a product is displayed")]
		public void ThenTheCorrectQuantityForAProductIsDisplayed()
		{
			ProductsPage.Products[0].SetQuanitity(25);
			ProductsPage.ClickHomeIcon();
			SCHomePage.OpenArea("Kitchen");
			ProductsPage.Out_ProductDetails(ProductsPage.Products[0]);
		}
    }
}