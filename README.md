# Azure AI Service with Text
Simple Azure AI Service console application. Using text to define what language of the word given.

# Tech Stack
C#
Azure AI Service

# Pre-Requisite
1. Azure AI Service provisioned.

## Provision an Azure AI Services resource

Azure AI Services are cloud-based services that encapsulate artificial intelligence capabilities you can incorporate into your applications. You can provision individual Azure AI services resources for specific APIs (for example, **Language** or **Vision**), or you can provision a single **Azure AI Services** resource that provides access to multiple Azure AI services APIs through a single endpoint and key. In this case, you'll use a single **Azure AI Services** resource.

1. Open the Azure portal at `https://portal.azure.com`, and sign in using the Microsoft account associated with your Azure subscription.
2. In the top search bar, search for *Azure AI services*, select **Azure AI services multi-service account**, and create a resource with the following settings:
    - **Subscription**: *Your Azure subscription*
    - **Resource group**: *Choose or create a resource group (if you are using a restricted subscription, you may not have permission to create a new resource group - use the one provided)*
    - **Region**: *Choose any available region*
    - **Name**: *Enter a unique name*
    - **Pricing tier**: Standard S0
3. Select the required checkboxes and create the resource.
4. Wait for deployment to complete, and then view the deployment details.
5. Go to the resource and view its **Keys and Endpoint** page. This page contains the information that you will need to connect to your resource and use it from applications you develop. Specifically:
    - An HTTP *endpoint* to which client applications can send requests.
    - Two *keys* that can be used for authentication (client applications can use either key to authenticate).
    - The *location* where the resource is hosted. This is required for requests to some (but not all) APIs.

# Configuration
1. Copy sample.settings.json contents to local.settings.json. Replace endpoint and key values for AIServiceOptions based on Azure AI Service created.

# Run the application
1. Right click on the **azure.ai.service.text** folder, select *Open in Integrated Terminal* and run the following command:

    **C#**

    ```
    dotnet run
    ```