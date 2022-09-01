using Xunit.Abstractions;
using Xunit;
using TesteAPINuri.Services;

namespace TesteAPINuri.Tests
{
    public class StoreTest
    {
        private readonly ITestOutputHelper output;

        public StoreTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact(DisplayName = "Post New Store Order")]
        [Trait("category", "store")]
        public void Post_NewStoreOrder()
        {
            new StoreServiceWorkFlow(output).Validate_NewStoreOrder(CustomConfigurationProvider.GetSection("PlaceOrderPet"));
        }

        [Theory(DisplayName = "Get Store Order By OrderId")]
        [InlineData(1)]
        [InlineData(4)]
        [Trait("category", "store")]
        public void Get_StoreOrderByOrderId(int id)
        {
            new StoreServiceWorkFlow(output).Validate_GetStoreOrderByOrderId(id);
        }

        [Fact(DisplayName = "Delete Store Order By OrderId")]
        [Trait("category", "store")]
        public void Delete_StoreOrderByOrderId()
        {
            new StoreServiceWorkFlow(output).Validate_DeleteStoreOrderByOrderId(4);
        }

        [Fact(DisplayName = "GET All Store Inventory")]
        [Trait("category", "store")]
        public void Get_StoreIventory()
        {
            new StoreServiceWorkFlow(output).Validate_GetAllStoreInventory();
        }
    }
}