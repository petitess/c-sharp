using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager;
using Microsoft.Azure;

namespace azure01
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            AccessToken token =
                await new DefaultAzureCredential()
                .GetTokenAsync(
                    new TokenRequestContext(
            new[] { "https://management.azure.com/.default" }
        ));
            Console.WriteLine(token.Token);

            string subscriptionId = "2d9f44ea-e3df-4ea1-b956-8c7a43b119a0";
            string resourceGroupName = "rg-owner";

            //WORKS
            var credentials = new TokenCloudCredentials(subscriptionId, token.Token);

            Console.WriteLine(credentials);

            ArmClient client = new ArmClient(new DefaultAzureCredential());
            SubscriptionResource subscription = client.GetDefaultSubscription();
            ResourceGroupResource resourceGroup =
                client.GetDefaultSubscription().GetResourceGroup(resourceGroupName);

            Console.WriteLine(resourceGroup.Id);

            ResourceGroupResource resourceGroupX = await subscription.GetResourceGroupAsync(resourceGroupName);
            resourceGroup = await resourceGroup.AddTagAsync("Group", "A");

        }
    }
}
