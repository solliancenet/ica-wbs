# Secure infra PoC starter artifacts

> **TODO:** the ARM template contains the following path: https://github.com/givenscj/mcw-azure-security/blob/master/Scripts/Install_IIS.zip?raw=true. This needs to be updated to the path to [./Scripts/Install_IIS.zip](./Scripts/Install_IIS.zip) once this repo has been set up in its final location on GitHub.

These starter artifacts provided by Contoso might help you accelerate your PoC efforts for secure infra.

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
- A machine with the following software installed:
  - Visual Studio 2017
  - SQL Management Studio 2017
  - Power BI Desktop

### Task 1: Download GitHub resources

1.  Open a browser window to the GitHub repository that contains the starter artifacts

2.  Select **Clone or download**, then select **Download Zip**

    ![Clone or download and Download ZIP are highlighted in this screenshot of the cloud workshop GitHub repository.](./media/image3.png)

3.  Extract the zip file to your local machine. Browse to the `\Starter-artifacts\resources\secure-data-starter\` directory. You should now see a set of folders:

    ![A set of extracted folders and files are visible in File Explorer: .vs, AzureTemplate, Database, Scripts, WebApp, README.md.](./media/image4.png 'Extract the zip file')

### Task 2: Deploy resources to Azure

1.  Open your Azure Portal

2.  Select **Resource groups**

3.  Select **+Add**

4.  Type a resource group name, such as **azsecurity-\[your initials or first name\]**

5.  Select **Create**

6.  Select **Refresh** to see your new resource group displayed and select it

7.  Select **Automation Script**, and then select **Deploy**

    ![Automation script is highlighted under Settings on the left side of the Azure portal, and Deploy is highlighted on the top-right side.](./media/image5.png 'Select Deploy')

8.  Select **Build your own template in the editor**

9.  In the extracted folder, open the **\\Scripts\\template.json**

10. Copy and paste it into the window

11. Select **Save**, you will see the dialog with the input parameters. Fill out the form:

    a. Subscription: select your **subscription**

    b. Resource group: Use an existing Resource group, or create a new one by entering a unique name, such as **azsecurity-\[your initials or first name\]**

    c. Location: Select a **location** for the Resource group. Recommend using East US, East US 2, West Central US, or West US 2.

    d. Modify the **sqlservername** to be something unique such as "azsecurity-\[your initials or first name\]"

    e. Fill in the remaining parameters, but if you change anything, be sure to note it for future reference

    NOTE: User Object Id is meant to be the object id of a user that will be added as an administrator to an Azure Key Vault instance. You can type anything here but the permission assignment with fail in the ARM template later unless it is a valid Azure Active Directory User Object Id. You can find your object id by opening a new Azure portal window and navigating to the Azure Active Directory blade, select **Users**, search for your user account, select it, in the window you will see the **Object ID** field. Click the copy link, then paste the value into the template object user id text box.

    f. Check the **I agree to the terms and conditions stated above** checkbox

    g. Select **Purchase**

        ![The above information is entered in the form, and I agree to the terms and conditions stated above and Purchase are selected and highlighted at the bottom.](./media/image6.png "Fill out the form")

12. The deployment will take 15-30 minutes to complete. To view the progress, select the **Deployments** link, then select the **Microsoft.Template** deployment.

    ![Deployments is highlighted under Settings on the left side of the Azure portal, and Microsoft.Template is highlighted under Deployment Name on the right side.](./media/image7.png 'Select the Deployments link')

    h. As part of the deployment, you will see the following items created:

        -   One storage account

        -   Three virtual networks

        -   Three network security groups

        -   Three virtual machines (db-1, web-1, paw-1)

            -   IIS is installed on web-1 via a DSC script from the GitHub repository

        -   One SQL Azure Server

        -   One Azure Key Vault

            ![Created items list This screenshot is a list of the items that were created, including the items listed above. ](./media/image8.png)

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
