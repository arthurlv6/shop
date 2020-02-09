using E2E.Web.Services;
using Microsoft.AspNetCore.Components;
using Shop.Share;
using Shop.Web.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Web.Pages
{
    public class ProductsBase: ShopComponentBase
    {
        [Inject]
        ProductService service { get; set; }
        public IEnumerable<ProductModel> ProductModels { get; set; }
        protected override async Task OnInitializedAsync()
        {
            var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            UserEmail = authState.User.Identity.Name;
            GlobalMsg.SetMessage();
            ProductModels =await service.GetProductsAsync(0, 20, "");
        }
    }
}
