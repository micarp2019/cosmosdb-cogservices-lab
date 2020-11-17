# End to End Scenario to analyse pictures via Azure computer vision and azure cognitive search, and leverage CosmosDB and Azure Functions to enable event-driven use cases.
This is a hands on lab guide for Azure. In this lab you will deploy a serverless application which uses Azure Cognitive Services to analyze photos gathered from twitter. An Azure Logic App drives the process and carries out most of the tasks. 

# Scope
- Showcase the interplay of CosmosDB with Cog Services to enable real-time scenarios, across industries
- Cosmos + Azure Search integration – “better together” to show the potential of full text and case insensitive search (Push mode to Index, with serverless functions)
- Cosmos + Computer Vision – “better together” to show how real time unstructured data can be transformed in semi-structured and become the basis for event-driven scenarios

# Illustrative Scenarios
- Object detection in real time – applications in manufact e.g. safety
- Scanned (OCR) and annotated documents (via CreateCognitiveSkillset from the Cog Service SDK) are saved on Cosmos and added to the Index Service. This helps automate clerical    duties e.g. in Finance like claims digitalization and data mining

# The Logic App flow is:
- Calls the Twitter API and searches for tweets containing a certain hashtag
- Calls the Azure cognitive service API for each photo and gets the result which is a description of the contents of the photo
- Stores the result in Azure Cosmos DB
This is a hands on lab guide for Azure. In this lab you will deploy a serverless application which uses Azure Cognitive Services to analyze photos gathered from twitter. An Azure Logic App drives the process and carries out most of the tasks.

# The data from Cosmos is then consumed by three consumers, in push and poll mode. Specifically:

PUSH: Azure Search is a cognitive service to index documents. It works in push and pull mode. In this lab we will show both
PUSH: Notification Hub is an Azure Service that captures notifications to send to mobile apps
PULL: A simple web app, written in Node.js. This web app is hosted in Azure as an Web App Service, it connects to Cosmos DB and displays the photo analysis results as a simple web page.

The guide steps through deploying and configuring the complete end to end solution in Azure.
# Solution Architecture
![arch](arch.png)
