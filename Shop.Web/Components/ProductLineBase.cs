using BlazorInputFile;
using E2E.Web.Services;
using Microsoft.AspNetCore.Components;
using Shop.Share;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Aliyun.OSS;
using System.Text;

namespace Shop.Web.Components
{
    public class ProductLineBase : ShopComponentBase
    {
        [Parameter]
        public ProductModel Item { get; set; }
        [Inject]
        protected ProductLinkService ProductLinkService { get; set; }
        protected async Task OnInitializedAsync()
        {
            foreach (var item in Item.ProductLinks)
            {
                //item.Address
            }
        }
       protected void ShowDetail(ProductModel productModel)
        {
            productModel.IsShowDetail = !productModel.IsShowDetail;
        }
        protected IFileListEntry[] selectedFiles;

        protected void HandleSelection(IFileListEntry[] files)
        {
            selectedFiles = files;
        }

        protected async Task LoadFile(IFileListEntry file)
        {
            file.OnDataRead += (sender, eventArgs) => InvokeAsync(StateHasChanged);
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads",file.Name);
            var model = new ProductLinkModel() 
            { 
                Address = file.Name,
                Type=file.Type,
                ProductId=Item.Id
            };
            /*
            var endpoint = "<yourEndpoint>";
            var accessKeyId = "<yourAccessKeyId>";
            var accessKeySecret = "<yourAccessKeySecret>";
            var bucketName = "<yourBucketName>";
            var objectName = "<yourObjectName>";
            var objectContent = "More than just cloud.";
            // Create an OSSClient instance.
            var client = new OssClient(endpoint, accessKeyId, accessKeySecret);
            try
            {
                byte[] binaryData = Encoding.ASCII.GetBytes(objectContent);
                MemoryStream requestContent = new MemoryStream(5);
                // Upload a file.
                client.PutObject(bucketName, objectName, requestContent);
                Console.WriteLine("Put object succeeded");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Put object failed, {0}", ex.Message);
            }
            */

            if ( await ProductLinkService.PostProductLinkAsync(model) != null)
            {
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    var ms = new MemoryStream();

                    await file.Data.CopyToAsync(stream);
                }
                Item.ProductLinks.Add(model);
                GlobalMsg.SetMessage("File "+file.Name+" uploaded.", MessageLevel.Error);
            }
            else
            {
                GlobalMsg.SetMessage("Failed to connect API.", MessageLevel.Error);
            }
        }
        protected void Remove(int id)
        {

        }

    }
}
