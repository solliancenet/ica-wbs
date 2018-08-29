# Claims management innovation PoC starter artifacts

These starter artifacts provided by Contoso might help you accelerate your PoC efforts for claims management innovation.

## What the starter contains

Jupyter Notebook starters for summarization, classification, Cognitive Services (Computer Vision, Text Analytics)

## Starter setup

There is no setup required for this starter.

## How to use the starter

### Task 1: Explore the sample claims classification notebook

1.  Navigate to the [Azure Notebooks](https://notebooks.azure.com/Solliance/libraries/claims)

2.  Select clone

3.  Login with your Microsoft Account

4.  Provide a library name and ID as desired

5.  Select clone

6.  Select the file **Claim Classification.ipynb**

7.  Step thru the notebook, running the cells in order from top to bottom


### Task 2: Review the Azure ML Services code

1.  In the library that you previously cloned, navigate to the **_azure ml service folder**

2.  Examine the implementation of claim_class_service.py. This file provides an example implementation of a web service that provides claims classification using the model created in the notebook. It is intended to be deployed using Azure Machine Learning Services.

3.  Examine the Conda configuration in conda_dependencies.yml. This file configures the pre-requisites that need to be installed by Azure Machine Learning when the service is deployed.


### Task 3: Review the Summarization Notebook

1. In the library that you previously cloned, navigate to the root and open **Summarize.ipynb**

2. Read thru the notebook and the run the cells in order from top to bottom to see the result.


### Task 4: Review the Cognitive Services Notebook

1. In the library that you previously cloned, navigate to the root and open **Cognitive Services.ipynb**

2. Read thru the notebook. If you want to run the cells, you will first need to provision the desired Cognitive Service and set the notebook key and location in the appropriate cells of the notebook.

3. Task 4 - Invoking the Azure ML Deployed Services provides and example of how you might integrate the Azure ML Services code if you had used Azure Machine Learning Services to deploy it. If you want to run these cells, you will need to deploy the service and configure the service key and IP address values.