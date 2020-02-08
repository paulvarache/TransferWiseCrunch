# Transferwise.Services.Api.DefaultApi

All URIs are relative to *https://api.sandbox.transferwise.tech/v1*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GetTransferById**](DefaultApi.md#gettransferbyid) | **GET** /transfers/{transferId} | Get a specific transfer


<a name="gettransferbyid"></a>
# **GetTransferById**
> Transfer GetTransferById (decimal transferId)

Get a specific transfer

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Transferwise.Services.Api;
using Transferwise.Services.Client;
using Transferwise.Services.Model;

namespace Example
{
    public class GetTransferByIdExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://api.sandbox.transferwise.tech/v1";
            // Configure API key authorization: bearerAuth
            Configuration.Default.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new DefaultApi(Configuration.Default);
            var transferId = 8.14;  // decimal | The id of the transfer to retrieve

            try
            {
                // Get a specific transfer
                Transfer result = apiInstance.GetTransferById(transferId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling DefaultApi.GetTransferById: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **transferId** | **decimal**| The id of the transfer to retrieve | 

### Return type

[**Transfer**](Transfer.md)

### Authorization

[bearerAuth](../README.md#bearerAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Expected response to a valid request |  -  |
| **0** | unexpected error |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

