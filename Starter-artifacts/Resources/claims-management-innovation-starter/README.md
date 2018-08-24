# Claims management innovation PoC starter artifacts

These starter artifacts provided by Contoso might help you accelerate your PoC efforts for claims management innovation.

## What the starter contains

- ARM template that creates the following:
  - One storage account
  - Three virtual networks
  - Three network security groups
  - Three virtual machines (db-1, web-1, paw-1)
    - IIS is installed on web-1 via a DSC script from the GitHub repository
  - One SQL Azure Server
  - One Azure Key Vault
- PortScanner.ps1 file
- Insurance API source code
- Insurance.bacpac file for SQL database

## Starter setup

Setup will take around **30 minutes** to complete. What you need to get started is the following:

- Microsoft Azure subscription must be pay-as-you-go or MSDN
  - Trial subscriptions will not work
  - Subscriptions with access limited to a single resource group will not work. You will need the ability to deploy multiple resource groups.

1.  Navigate to the Azure Portal at <https://portal.azure.com>

2.  Select **Create a resource**

    ![Screenshot of the Create a resource button.](images/Setup/image3.png 'Create a resource button')

3.  Select **Compute** and then select **Windows Server 2016 Datacenter**

    ![In the New blade, Compute is selected.](images/Setup/image4.png 'New blade')

4.  On the **Basics** blade provide the following inputs:

    a. **Name**: enter labvm

    b. **VM disk type**: select HDD. This will enable you to use a GPU based machine if you choose to in the subsequent step.

    c. **User name**: enter demouser

    d. **Password and Confirm Password:** enter Abc!1234567890

    e. **Subscription**: select your Azure subscription

    f. **Resource group**: select Create new and provide the name mcw-ai-lab

    g. **Location**: select either South Central US or East US (or any of the regions in which the NC-series VM's are currently available, see the [regions service page](https://azure.microsoft.com/en-us/global-infrastructure/services/) for an up to date listing).

    ![The Basics blade fields are set to the previously defined settings.](images/Setup/image5.png 'Basics blade')

5.  Select **OK**

6.  On the **Choose a size** blade, select **D4s_v3** and choose **Select**

7.  Leave all values on the Settings blade at their defaults and select OK

    ![Fields in the settings blade are set to the default settings.](images/Setup/image7.png 'Settings blade')

8.  On the Create blade, review the summary and then select Create

    ![Screenshot of the Create blade.](images/Setup/image8.png 'Create blade')

9.  The VM should take 10 minutes to provision

#### Task 2: Verify Remote Desktop access to Data Science VM

1.  When the VM is ready, you should see a notification. Select **Go to resource** to view the deployed VM in the Portal.

    ![The Notification window has the message that Deployment succeeded.](images/Setup/image9.png 'Notification window')

2.  On the blade for the VM, select **Connect**. This will download a Remote Desktop (RDP) file.

    ![Screenshot of the Connect button.](images/Setup/image10.png 'Connect button')

3.  Open the downloaded RDP file

4.  At the prompt, ensure **Clipboard** is checked and select **Continue**

    ![The Warning prompts you to ensure that you trust the remote computer prior to connecting. The Clipboard checkbox is selected.](images/Setup/image11.png 'Warning prompt')

5.  Enter the **username** (demouser) and **password** (Abc!1234567890) and select **Connect** to login

    ![Screenshot of the Log in page.](images/Setup/image12.png 'Log in page')

6.  Select **Connect** on the dialog that follows

    ![Screenshot of the Accept certificate and connect dialog box.](images/Setup/image13.png 'Accept certificate and connect dialog box')

7.  Within a few moments, you should see the desktop for your new Data Science Virtual Machine

#### Task 3: Initialize Azure Machine Learning Workbench

Before using the Azure Machine Learning Workbench on the VM, you will need to take the one-time action of AzureML Workbench Setup to install your instance of the workbench.

1.  Within the RDP session to the VM, open Server Manager

2.  Select Local server

    ![Screenshot showing selecting Local Server within Server Manager.](images/Setup/image14.png 'Server Manager')

3.  In the Properties area, look for IE Enhanced Security Configuration and select On

    ![Screenshot showing the IE Enhanced Configuration link in Server Manager.](images/Setup/image15.png 'IE Enhanced Security Configuation set to On')

4.  In the dialog, set both options to Off and select OK

    ![Screenshot showing the Internet Explorer Enhanced Security Configuration dialog box with the Administrators and Users options both set to off.](images/Setup/image19.png 'Internet Explorer Enhanced Security Configuration dialog box')

5.  Using Internet Explorer on the VM, download the Azure Machine Learning Workbench from:
    https://aka.ms/azureml-wb-msi

6.  At the prompt, choose Save and when finished downloading choose Run

7.  Step through all the prompts leaving all values at their defaults to complete the Workbench installation. Installation will take about 25 minutes. Use the **X** to close the install when it is finished.

    ![The Azure Machine Learning Workbench Installer screen displays the message, Installation successful.](images/Setup/image17.png 'Azure Machine Learning Workbench Installer screen')

8.  Next, download Visual Studio Code from the following location:
    https://code.visualstudio.com/download

9.  Select to download the Windows version:\
    ![Screenshot showing the download tile for the Windows version of Visual Studio Code](images/Setup/image20.png 'Download the Windows version')

10. Save the download and Run it when completed

11. Step thru the Visual Studio Code installation, leaving all values at their defaults

#### Task 4: Stop the Lab VM

If you are performing this setup the night before the hands-on lab, you can optionally Stop the VM to save on costs overnight, and resume it when you are ready to start on the lab. Follow these steps to Stop the VM:

1.  Return to the Azure Portal

2.  Navigate to the blade of your labvm

3.  Select the **Stop** button

    ![Screenshot of the Stop button.](images/Setup/image18.png 'Stop button')

> **NOTE:** When you are ready to resume the VM, simply follow the previous steps and instead of selecting Stop, select **Start**. You VM will take about 5 minutes to start up, after which you can use the **Connect** button in the VM blade to RDP into the VM as before.

## How to use the starter

Set up and configure the database and web app for testing:

- Setup the PAW-1 Virtual Machine with JIT Access
- Submit a request to activate the JIT
- Login to the PAW-1 VM via RDP
- Restore the Insurance.bacpac file (Insurance database) to the Azure SQL Server setup in your Azure tenant
- Create a user called agent that has db_reader access to the Insurance database
- Open the InsuranceAPI solution
- Modify the web.config file to point to your new Insurance database
- Run the web application, navigation to [http://localhost:portno/api/Users](http://localhost:portno/api/Users). You should see unmasked data displayed.

Use the PortScanner.ps1 file to check allowed ports:

- Connect to the PAW-1 machine over RDP
- Using the PortScanner.ps1 file, check the allowed ports between the PAW-1, DB-1 and WEB-1 machines
- Configure the DbTrafficOnly NSG to allow 1433 traffic from the WEB-1 Virtual Machine
- Configure the WebTrafficOnly NSG to allow 80,443 traffic from any where
- Configure the DbTrafficOnly and WebTrafficOnly NSG to allow RDP access from the PAW-1 virtual machine

The result should be:

- RDP traffic should only be able to come from the PAW-1 machine for WEB-1 and DB-1
- Web Traffic is allowed to WEB-1
- SQL Traffic is allowed from WEB-1 to DB-1

- Execute a Port Scan from PAW-1 using the PortScanner.ps1 script. This can also be used to test your port configurations.

- Install the Network Watcher VM Extension on DB-1
- Setup a Network Packet Capture on DB-1
- Execute a port scan from PAW-1 to both WEB-1 and DB-1
  - You'll want at least 400 different ports scanned across both machines
- Create a custom alert called PortScans that will monitor for all inbound blocking operations on the WebTrafficOnly NSG. The period should be one hour, evaluated every 30 minutes with a threshold of 100.
- Create a RunBook based on the alert that will send an email on alert
- Export a log analytics query from the Log Analytics portal
- Import the query into Power BI
- Open the Microsoft Service Trust web site
- Create a new assessment for Azure and GDPR
- Find the FedRamp security assessment on the Service Trust site
