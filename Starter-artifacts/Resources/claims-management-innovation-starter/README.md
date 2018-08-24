# Claims management innovation PoC starter artifacts

These starter artifacts provided by Contoso might help you accelerate your PoC efforts for claims management innovation.

## What the starter contains

Jupyter Notebook starters for summarization, classification, Cognitive Services (Computer Vision, Text Analytics)

## Starter setup

Setup will take around **30 minutes** to complete. What you need to get started is the following:

- Microsoft Azure subscription must be pay-as-you-go or MSDN
  - Trial subscriptions will not work
  - Subscriptions with access limited to a single resource group will not work. You will need the ability to deploy multiple resource groups.

1.  Navigate to the Azure Portal at <https://portal.azure.com>

2.  Select **Create a resource**

    ![Screenshot of the Create a resource button.](./media/image3.png 'Create a resource button')

3.  Select **Compute** and then select **Windows Server 2016 Datacenter**

    ![In the New blade, Compute is selected.](./media/image4.png 'New blade')

4.  On the **Basics** blade provide the following inputs:

    a. **Name**: enter labvm

    b. **VM disk type**: select HDD. This will enable you to use a GPU based machine if you choose to in the subsequent step.

    c. **User name**: enter demouser

    d. **Password and Confirm Password:** enter Abc!1234567890

    e. **Subscription**: select your Azure subscription

    f. **Resource group**: select Create new and provide the name mcw-ai-lab

    g. **Location**: select either South Central US or East US (or any of the regions in which the NC-series VM's are currently available, see the [regions service page](https://azure.microsoft.com/en-us/global-infrastructure/services/) for an up to date listing).

    ![The Basics blade fields are set to the previously defined settings.](./media/image5.png 'Basics blade')

5.  Select **OK**

6.  On the **Choose a size** blade, select **D4s_v3** and choose **Select**

7.  Leave all values on the Settings blade at their defaults and select OK

    ![Fields in the settings blade are set to the default settings.](./media/image7.png 'Settings blade')

8.  On the Create blade, review the summary and then select Create

    ![Screenshot of the Create blade.](./media/image8.png 'Create blade')

9.  The VM should take 10 minutes to provision

#### Task 2: Verify Remote Desktop access to Data Science VM

1.  When the VM is ready, you should see a notification. Select **Go to resource** to view the deployed VM in the Portal.

    ![The Notification window has the message that Deployment succeeded.](./media/image9.png 'Notification window')

2.  On the blade for the VM, select **Connect**. This will download a Remote Desktop (RDP) file.

    ![Screenshot of the Connect button.](./media/image10.png 'Connect button')

3.  Open the downloaded RDP file

4.  At the prompt, ensure **Clipboard** is checked and select **Continue**

    ![The Warning prompts you to ensure that you trust the remote computer prior to connecting. The Clipboard checkbox is selected.](./media/image11.png 'Warning prompt')

5.  Enter the **username** (demouser) and **password** (Abc!1234567890) and select **Connect** to login

    ![Screenshot of the Log in page.](./media/image12.png 'Log in page')

6.  Select **Connect** on the dialog that follows

    ![Screenshot of the Accept certificate and connect dialog box.](./media/image13.png 'Accept certificate and connect dialog box')

7.  Within a few moments, you should see the desktop for your new Data Science Virtual Machine

#### Task 3: Initialize Azure Machine Learning Workbench

Before using the Azure Machine Learning Workbench on the VM, you will need to take the one-time action of AzureML Workbench Setup to install your instance of the workbench.

1.  Within the RDP session to the VM, open Server Manager

2.  Select Local server

    ![Screenshot showing selecting Local Server within Server Manager.](./media/image14.png 'Server Manager')

3.  In the Properties area, look for IE Enhanced Security Configuration and select On

    ![Screenshot showing the IE Enhanced Configuration link in Server Manager.](./media/image15.png 'IE Enhanced Security Configuation set to On')

4.  In the dialog, set both options to Off and select OK

    ![Screenshot showing the Internet Explorer Enhanced Security Configuration dialog box with the Administrators and Users options both set to off.](./media/image19.png 'Internet Explorer Enhanced Security Configuration dialog box')

5.  Using Internet Explorer on the VM, download the Azure Machine Learning Workbench from:
    https://aka.ms/azureml-wb-msi

6.  At the prompt, choose Save and when finished downloading choose Run

7.  Step through all the prompts leaving all values at their defaults to complete the Workbench installation. Installation will take about 25 minutes. Use the **X** to close the install when it is finished.

    ![The Azure Machine Learning Workbench Installer screen displays the message, Installation successful.](./media/image17.png 'Azure Machine Learning Workbench Installer screen')

8.  Next, download Visual Studio Code from the following location:
    https://code.visualstudio.com/download

9.  Select to download the Windows version:\
    ![Screenshot showing the download tile for the Windows version of Visual Studio Code](./media/image20.png 'Download the Windows version')

10. Save the download and Run it when completed

11. Step thru the Visual Studio Code installation, leaving all values at their defaults

#### Task 4: Stop the Lab VM

If you are performing this setup the night before the hands-on lab, you can optionally Stop the VM to save on costs overnight, and resume it when you are ready to start on the lab. Follow these steps to Stop the VM:

1.  Return to the Azure Portal

2.  Navigate to the blade of your labvm

3.  Select the **Stop** button

    ![Screenshot of the Stop button.](./media/image18.png 'Stop button')

> **NOTE:** When you are ready to resume the VM, simply follow the previous steps and instead of selecting Stop, select **Start**. You VM will take about 5 minutes to start up, after which you can use the **Connect** button in the VM blade to RDP into the VM as before.

## How to use the starter

### Task 1: Provision Azure Machine Learning Experimentation service

1.  Navigate to the Azure Portal

2.  Select **Create a resource**

    ![Screenshot of the Create a resource button.](media/azure-portal-create-a-resource.png 'Create a resource button')

3.  Select **AI + Machine Learning** and then select **Machine Learning Experimentation**

    ![In the New blade, AI + Machine Learning is selected.](./media/image119.png 'New blade')

4.  On the **ML Experimentation** blade, provide the following:

    a. **Experimentation account name**: provide a name for your experimentation account

    b. **Subscription:** select your Azure subscription

    c. **Resource group**: select the mcw-ai-lab resource group you previously created

    d. **Location**: select the region nearest to where you deployed your lab VM. It's OK if they are not exactly in the same region, but try to select a region that is close to minimize latency.

    e. **Number of seats**: leave at 2

    f. **Storage account**: select create new and provide a unique name for the new storage account

    g. **Workspace for Experimentation account**: provide a unique name for the workspace

    h. **Assign owner for the workspace**: leave the owner assigned to you

    i. **Create Model Management account**: leave checked

    j. **Account name**: provide a name for your model management account

    k. **Model Management pricing tier**: select the S1 pricing tier

    ![The ML Experimentation blade fields are set to the previously defined settings.](./media/image120.png 'ML Experimentation blade')

5.  Select **Create** to provision the Experimentation and Model Management Service. The deployment should take about 2 minutes.

6.  When the deployment completes, navigate to your mcw-ai-lab resource group and confirm that you see an instance of Machine Learning Experimentation and Machine Learning Model Management

    ![Both Machine Learning Experimentation and Machine Learning Model Management are called out in the Resource group list.](./media/image21.png 'Resource group')

### Task 2: Create the Azure Machine Learning project

1.  Connect to the labvm via RDP. If you stopped the VM, remember to Start it up again before attempting to connect.

2.  From the **Start** menu, launch **Azure Machine Learning Workbench**

3.  Select **Sign in with Microsoft**\
    ![Screenshot of the Azure Machine Learning Workbench Start menu icon.](./media/image22.png 'Azure Machine Learning Workbench Start menu icon')

4.  Sign in with the credentials you used when creating the Experimentation Service in the Azure Portal\
    ![Screenshot of the Microsoft Azure sign in screen.](./media/image23.png 'Microsoft Azure sign in screen')

5.  After successfully signing in, the Workbench interface should appear and list the experimentation workspace that you created\
    ![Screenshot of the Workbench window.](./media/image24.png 'Workbench window')

6.  From the **File** Menu, select **New Project...**\
    ![In the Workbench File menu, New Project is selected.](./media/image25.png 'Workbench File menu')

7.  In the **New Project** blade that appears, provide the following:

    a. **Project name**: mcw-ai-lab

    b. **Project directory**: C:\HOL

    c. **Project description**: leave blank

    d. **Vistualstudio.com GIT Repository URL**: leave blank

    e. **Selected workspace**: select the ML Experimentation Workspace you created\
     ![Fields in the New Project blade display the previously defined settings.](./media/image26.png 'New Project blade')

8.  In the Search Project Templates, enter **TDSP** and select the item called **TDSP Template**\
    ![Screenshot of the TDSP Tile.](./media/image27.png 'TDSP Tile')

9.  Select **Create**

10. The template will download and in a few moments you should see the TDSP project dashboard\
    ![Screenshot of the TDSP project dashboard.](./media/image28.png 'TDSP project dashboard')

### Task 3: Deploy your ACS cluster

1. Navigate to the Azure Portal

2. Select All Services, Subscriptions and then select your subscription from the list

3. Under the Settings grouping, select Resource Providers\
   ![Screenshot of the Settings tabs for a selected subscription in the Azure Portal](./media/image74.png 'Settings')

4. Search for “container,” and in the list that appears, verify that all resource providers related to containers are registered. If not, select the Register link next to the items that are not registered.
   ![Screenshot showing the search results for providers with the name container](./media/image75.png 'Search resource providers')

5. Within Workbench, from the **File** menu, select **Open Command Prompt**

6. Create the cluster environment by running the following command and replace the values indicated in angle brackets with the appropriate values. This will create new resources groups for the cluster.

   a. For \<environment name\> enter mcwailabenv, or something similar. This value can only contain lowercase alphanumeric characters.

   b. For location, use eastus2, westcentralus, australiaeast, westeurope, or southeastasia, as those are the only acceptable values at this time

   ```sh
   az ml env setup -c -n <environment name> --location <e.g. eastus2>
   ```

7. If prompted, copy the URL presented and sign in using your web browser

8. Enter the code provided in the command prompt
   ![Screenshot of the Device Login page](./media/image34.png 'Device Login page')

9. Select **Continue**\
   ![The Device Login page now displays the code.](./media/image35.png 'Device Login page')

10. Sign in with your Azure Credentials\
    ![The Microsoft Azure sign in page displays.](./media/image36.png 'Microsoft Azure sign in page')

11. Return to the command prompt, which should automatically update after you log in

12. At the "Subscription set to <subscription name>" prompt, enter **Y** if the subscription name is correct, or **N** to select the subscription to use from a list
    ![In the Command Prompt window, the updates display. At this time, we are unable to capture all of the information in the command prompt window. Future versions of this course should address this.](./media/image37.png 'Command prompt window')

13. It will take 10-20 minutes for your ACS cluster to be ready. You can periodically check on the status by running the command shown in the output to the previous step, which is of the form:

    ```sh
    az ml env show -g <resourceGroupName> -n <clusterName>
    ```

14. **Continue on with the lab while your ACS cluster provisions**

### Task 4: Install dependencies

The tasks that follow depend on Python libraries, like nltk and gensim. The following steps ensure you have these installed in your environment.

1.  From the **File** menu of Workbench, select **Open Command Prompt**

2.  Run the following command to install nltk:

    ```sh
    pip install nltk
    ```

3.  NLTK should install, with a message similar to the following:
    ![In the Command Prompt window, the previous commands and their output display. At this time, we are unable to capture all of the information in the command prompt window. Future versions of this course should address this.](./media/image29.png 'Command Prompt window')

4.  NLTK is a rich toolkit with modular components, many of which are not installed by default. To install all the components, run the python shell by entering **python** at the command prompt:

    ```sh
    python
    ```

5.  Within the python shell, run the following two lines:

    ```sh
    import nltk
    nltk.download('all')
    ```

6.  The downloader will take about 5 minutes to complete. Once it is finished, exit the python shell by entering:

    ```sh
    exit()
    ```

7.  Run the following command to install gensim:

    ```sh
    pip install gensim
    ```

    ![In the Command Prompt window, the previous command and its output display. At this time, we are unable to capture all of the information in the command prompt window. Future versions of this course should address this.](./media/image30.png 'Command Prompt window')

8.  Next, download a pre-built Jupyter Notebook that you will step through to understand the process used to summarize the text of the claims documents. In the browser on your VM, navigate to the following (note that the URL is case sensitive). Note, if using IE, you will need to modify the default security settings, which prevent files from being downloaded.

    <http://bit.ly/2G4hAQz>

9.  In the command prompt, enter the following and press enter to launch the Jupyter Notebook:

    ```sh
    jupyter notebook
    ```

    ![In the Command Prompt window, the command to launch the Jupyter Notebook displays. At this time, we are unable to capture all of the information in the command prompt window. Future versions of this course should address this.](./media/image31.png 'Command Prompt window')

10. In a few moments, you should be prompted for which browser to use to open the link

11. The Jupyter Notebook interface should appear in the browser, listing the contents of your project folder\
    ![The Jupyter Notebook interface displays the contents of the project folder.](./media/image32.png 'Jupyter Notebook interface')

12. Select the **code** folder

13. Select **01_data_acquisition_and_understanding**\
    ![Screenshot of the Code folder contents.](./media/image33.png 'Code folder')

14. Select the **Upload** button

15. Open the **Summarize.ipynb** notebook and follow the instructions within it

### Task 5: Set Visual Studio Code as the project IDE in Workbench

1.  Within Workbench, from the **File** menu, select **Configure Project IDE**\
    ![In the Workbench File menu, Configure Project IDE is selected.](./media/image39.png 'Workbench, File menu')

2.  In the **Configure IDE** blade that appears, set the following properties:

    a. **Name**: Visual Studio Code

    b. **Executable Path**: C:\\Program Files\\Microsoft VS Code\\Code.exe\
     ![The Configure IDE blade displays the previously defined settings.](./media/image40.png 'Configure IDE blade')

3.  Select **OK**

4.  Launch Visual Studio Code for the project by selecting **Open Project (Visual Studio Code)** from the **File** menu\
    ![In the File menu, Open Project (Visual Studio Code) is selected.](./media/image41.png 'File menu')

5.  You are now ready to author service script

### Task 6: Create the Summarization service

1.  Visual Studio Code will open against the project directory

2.  In the tree view, expand **code** and then right-click **03_deployment** and select **New File**\
    ![The previously defined options are selected in the Visual Studio Code tree view.](./media/image42.png 'Visual Studio Code tree view')

3.  For the file name, enter summarizer_service.py and press **Enter**

4.  In a browser, navigate to <http://bit.ly/2FLJn8Y> and copy the contents of the file

5.  Paste the contents of this script into your summarizer_service.py. Take a moment to review the script, as it is effectively the same code you were running in the Jupyter notebook, except that is has been modified to follow the format required by services in Azure Machine Learning. The init method is called once per container by the Azure Machine Learning infrastructure when the service is deployed. It is here that we need to load all of the modules required by NLTK in the call to nltk.download. The run method is where any scoring (or in our case summarization) activity takes place.\
    ![In the Command Prompt window, the script that you copied displays. At this time, we are unable to capture all of the information in the command prompt window. Future versions of this course should address this.](./media/image43.png 'Command Prompt window')

6.  Next, we need to capture the dependencies for the modules used by the script. These are declared in a conda environment file, which you can generate from an environment or create by hand. In this case, we will edit the default conda environment provided by the TDSP project by hand, and add a configuration that will pip install gensim as required by our script. To do this, in Visual Studio Code, expand, aml_config and open conda_dependencies.yml.\
    ![In Visual Studio Code, MCW-AI-LAB is expanded, aml_config is expanded, and conda_dependencies.yml is selected.](./media/image44.png 'Visual Studio Code')

7.  At the last line, under azure-ml-api-sdk add another line with -gensim to the pip configuration. You should also add entries for tensorflow and tflearn, which we will need later in the lab. Your final configuration should look as follows:

    ```sh
    name: project_environment

    dependencies:
    - python=3.5.2
    - scikit-learn
    - pip:
    # The API for Azure Machine Learning Model Management Service.
    # Details: https://github.com/Azure/Machine-Learning-Operationalization
    - azure-ml-api-sdk==0.1.0a11
    - azureml.datacollector==0.1.0a13
    - gensim
    - tensorflow
    - tflearn
    ```

8.  Save the file. When we go to create the image in a later step, this file will be included with command.

9.  Next, create an empty file called dummy_model.bin in the 03_deployment folder. In this case, we don't have a model to deploy with this service, but we still need to provide one to the CLI as we will see in a moment. An empty file will do.

### Task 7: Deploy the Summarization service

1. Return to the Workbench and use the File menu to open another command prompt.

2. Wait for your ACS cluster to be ready. You can periodically check on the status by running the command shown in the output to the previous step, which is of the form:

   ```sh
   az ml env show -g <resourceGroupName> -n <clusterName>
   ```

3. Once the environment has successfully provisioned (the Provisioning State in the above command will read "Succeeded"), set your default environment with a command of the form:

   ```sh
   az ml env set -g \<resourceGroupName\> -n \<clusterName\>
   ```

   ![In the Command Prompt window, the previous commands and their output display. At this time, we are unable to capture all of the information in the command prompt window. Future versions of this course should address this.](./media/image38.png 'Command prompt window')

4. This will set the context of the command line to target this environment.

5. Finally, set the model management account, to be used by the command line, to be the one you created previously (mcw-ai-lab-model-mgmt). Run the following command, replacing the values indicated in angle brackets with appropriate values:

   a. For \<acctname\>, enter the name of the Machine Learning Model Management resource in your mcw-ai-lab resource group.

   b. For \<resourcegroupname\>, use your mcw-ai-lab resource group name.

   ```sh
   az ml account modelmanagement set -n <acctname> -g <resourcegroupname>
   ```

6. At the command prompt, change directories to the code\\03_deployment directory by executing the following command:

   ```sh
   cd code\03_deployment
   ```

7. You can deploy the service using a single command (which orchestrates the multiple steps of creating a docker manifest, creating a docker image, and deploying a container instance from the image). The command needs to refer to all the components required for the service, including the dummy model file, the service script, the conda dependencies, and the runtime to use (python in this case). Run the following command to deploy the summarizer service:

   ```sh
   az ml service create realtime -n summarizer -c ..\..\aml_config\conda_dependencies.yml -m dummy_model.bin -f summarizer_service.py -r python
   ```

   ![In the Command Prompt window, the previous command and its output display. At this time, we are unable to capture all of the information in the command prompt window. Future versions of this course should address this.](./media/image45.png 'Command Prompt window')

8. Notice in the output of the preceding command, you are provided with instructions (third line from last) on how you can invoke the deployed service using the CLI. Try executing the following command (modify the Service ID of you service as indicated in the previous command output):

   ```sh
   az ml service run realtime -i summarizer.[mcwailab-xyz.location] -d "I was driving down El Camino and stopped at a red light. It was about 3pm in the afternoon. The sun was bright and shining just behind the stoplight. This made it hard to see the lights. There was a car on my left in the left turn lane. A few moments later another car, a black sedan pulled up behind me. When the left turn light changed green, the black sedan hit me thinking that the light had changed for us, but I had not moved because the light was still red. After hitting my car, the black sedan backed up and then sped past me. I did manage to catch its license plate. The license plate of the black sedan was ABC123."
   ```

   ![In the Command Prompt window, the previous text displays.](./media/image46.png 'Command Prompt window')

9. If you get a summary back, your service is working! Try calling the service with other text and observe the summary returned. Note that the service tries to build a summary of about 30 words, so if you provide too short a text, an empty summary will be returned.

10. Finally, in a notepad or other location take note of the full Service ID (e.g., summarizer.mcwailab-xyz.location) and the authorization key, which you will need later in the lab. To get the authorization key for your deployed service, run the following command and take note of the PrimaryKey value in the output:

    ```sh
    az ml service keys realtime -i summarizer.[mcwailab-xyz.location]
    ```

    ![In the Command Prompt window, the previous command and its output display. At this time, we are unable to capture all of the information in the command prompt window. Future versions of this course should address this.](./media/image47.png 'Command Prompt window')

### Task 8: Prepare TensorFlow

1.  Return to your RDP session to the Lab VM

2.  Switch to the command prompt that is running the Jupyter Notebook command and press **Control + Break**. This will stop the Jupyter Notebook process while you update TensorFlow.

3.  From the command line run:

    ```sh
    pip install tensorflow
    ```

4.  In a few moments, the install should complete, and you should see output ending similar to the following:\
    \
    ![In the Command Prompt window, output indicates that the file was successfully installed. At this time, we are unable to capture all of the information in the command prompt window. Future versions of this course should address this.](./media/image48.png 'Command Prompt window')

5.  We will be using the TFLearn library which sits atop TensorFlow. To install it run:

    ```sh
    pip install tflearn
    ```

    ![In the Command Prompt window, the installation progress and the success message displays. At this time, we are unable to capture all of the information in the command prompt window. Future versions of this course should address this.](./media/image49.png 'Command Prompt window')

6.  Run "Jupyter Notebook" to re-start the process

7.  You should now be ready to use TensorFlow on your lab VM

### Download the starter files to the Data Science VM

- TensorFlow notebook, text analytics helper module and sample data: <http://bit.ly/2pucpje>
  - Extract this zip and copy the contents to C:\\HOL\\mcw-ai-lab\\code\\02_modeling
- download the supporting files for the claim_class_service from: <http://bit.ly/2u5DoGH>
  - Extract the files and copy them into C:\\HOL\\mcw-ai-lab\\code\\03_deployment\\claim_class_service
- Download the deployment starter files: <http://bit.ly/2puj7oL>
  - Extract the contents of this zip file to C:\\HOL\\mcw-ai-lab\\code\\03_deployment
