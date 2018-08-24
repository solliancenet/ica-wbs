# LAMP lift and shift PoC starter artifacts

These starter artifacts provided by Contoso might help you accelerate your PoC efforts for LAMP lift and shift.

## What the starter contains

- A VM using an ARM template, to act as the on-premises installation of the OsTicket application:
  - Ubuntu Linux 16.04-LTS VM with Apache
  - PHP
  - MySQL
  - Sample data in the application
- Source code for the OsTicket application.

## Starter setup

### Task 1: Create a virtual machine to execute the lab

1.  Launch a browser and navigate to <https://portal.azure.com>. Once prompted, login with your Microsoft Azure credentials. If prompted, choose whether your account is an organization account or just a Microsoft Account.

2.  Click on **+NEW**, and in the search box type in **Visual Studio Community 2017 on Windows Server 2016 (x64)** and press enter. Click the Visual Studio Community 2017 image running on Windows Server 2016 and with the latest update.

3.  In the returned search results, click the image name

    ![In the Everything blade, the search field displays Visual Studio Community 2017 on Windows Server 2016 (x64). Under Results, Visual Studio Community 2017 on Windows Server 2016 (x64) is selected.](./media/setup/image4.png 'Everything blade')

4.  In the Marketplace solution blade, at the bottom of the page keep the deployment model set to **Resource Manager**, and click **Create**

    ![Resource Manager displays in the Select a deployment model field.](./media/setup/image5.png 'Select a deployment model field')

5.  Set the following configuration on the Basics tab and click **OK**:

    - Name: **LABVM**

    - VM disk type: **SSD**

    - User name: **demouser**

    - Password: **demo\@pass123**

    - Subscription: **If you have multiple subscriptions choose the subscription to execute your labs in.**

    - Resource Group: **OPSLABRG**

    - Location: **Choose the closest Azure region to you**

    ![Fields in the Basics blade display with the previously defined settings.](./media/setup/image6.png 'Basics blade')

6.  Choose the **DS1_V2 Standard** or **DS2_V2** instance size on the Size blade

**Note**: You may have to click the **View All** link to see the instance sizes.

![In the Choose a size blade, the DS1_V2 Standard option is selected.](./media/setup/image7.png 'Choose a size blade')

**Note**: If the Azure Subscription you are using is [NOT]{.underline} a trial Azure subscription you may want to chose the DS2_V2 to have more power in this LABMV. If you are using a trial subscription or one that you know has a restriction on the number of cores stick with the DS1_V2.

7.  Click **Configure required settings** to specify a storage account for your virtual machine if a storage account name is not automatically selected for you

    ![In the Settings blade, the Storage account option is selected.](./media/setup/image8.png 'Settings blade')

8.  Click **Create New**

    ![Screenshot of the Create new button.](./media/setup/image9.png 'Create new button')

9.  Specify a unique name for the storage account (all lower letters and alphanumeric characters) and ensure the green checkmark shows the name is valid

    ![Next to the Name field, the Green checkmark icon is selected.](./media/setup/image10.png 'Green checkmark icon')

10. Click **OK** to continue

    ![Screenshot of the OK button.](./media/setup/image11.png 'OK button')

11. Click **Configure required settings** for the Diagnostics storage account if a storage account name is not automatically selected for you. Repeat the previous steps to select a unique storage account name. This storage account will hold diagnostic logs about your virtual machine that you can use for troubleshooting purposes.

    ![Screenshot of the Diagnostics Storage Account option.](./media/setup/image12.png 'Diagnostics Storage Account option')

12. Accept the remaining default values on the Settings blade and click **OK**. On the Summary page click **OK**. The deployment should begin provisioning. It may take 10+ minutes for the virtual machine to complete provisioning.

    ![Screenshot of the Deploying Visual Studio icon.](./media/setup/image13.png 'Deploying Visual Studio icon')

**Note**: Please wait for the LABVM to be provisioned prior to moving to the next step.

13. Move back to the Portal page on your local machine and wait for **LABVM** to show the Status of **Running**. Click **Connect** to establish a new Remote Desktop Session.

    ![The Connect button is selected on the Portal page top menu.](./media/setup/image14.png 'Portal page top menu')

14. Depending on your remote desktop protocol client and browser configuration you will either be prompted to open an RDP file, or you will need to download it and then open it separately to connect

15. Log in with the credentials specified during creation:

    - User: **demouser**

    - Password: **demo\@pass123**

16. You will be presented with a Remote Desktop Connection warning because of a certificate trust issue. Click **Yes** to continue with the connection.

    ![The Remote Desktop Connection dialog box displays.](./media/setup/image15.png 'Remote Desktop Connection dialog box')

17. When logging on for the first time you will see a prompt on the right asking about network discovery. Click **No**.

    ![A Network Diagnostics prompt displays, asking if you want to find PCs, devices, and content on this network and automatically connect.](./media/setup/image16.png 'Network Diagnostics prompt')

18. Notice that Server Manager opens by default. On the left, click **Local Server**.

    ![On the Server Manager menu, Local Server is selected.](./media/setup/image17.png 'Server Manager menu')

19. On the right side of the pane, click **On** by **IE Enhanced Security Configuration**

    ![In the Essentials section, IE Enhanced Security Configuration is selected, and set to On.](./media/setup/image18.png 'Essentials section')

20. Change to **Off** for Administrators and click **OK**

    ![In the Internet Explorer Enhanced Security Configuration dialog box, Administrators is set to Off.](./media/setup/image19.png 'Internet Explorer Enhanced Security Configuration dialog box')

### Task 2: Install the MySQL Workbench

1.  While logged into **LABVM** via remote desktop, open Internet Explorer and navigate to <https://dev.mysql.com/get/Downloads/MySQLGUITools/mysql-workbench-community-6.3.10-winx64.msi> this will download an executable. After the download is finished, click **Run** to execute it.

2.  Follow the directions of the installer to complete the installation of MySQL Workbench

3.  After the installation is complete, **reboot** the machine

## How to use the starter

ARM template:

```bash
    az group deployment create --name OsTicketOnPremRG --resource-group OsTicketOnPremRG --template-uri "https://cloudworkshop.blob.core.windows.net/linux-lift-shift/onpremvmdeploy.json"
```

Once deployed, use the public IP address created in the resource group to browse to the site.

![On the Microsoft Cloud Workshop tab, the Support Center displays.](./media/image22.png 'Microsoft Cloud Workshop tab')

Use the **Sign in** link in the upper-right hand corner of the screen to go to the log in page, then locate **I'm an agent** and click the corresponding **sign in here** link.

![On the Sign in to Microsoft Cloud Workshop Registration page, the Sign in here link was selected.](./media/image24.png 'Sign in to Microsoft Cloud Workshop Registration page')

You can use the following credentials:

    -  Username: ***demouser***

    -  Password: ***demo@pass123***

![The osTicket log in webpage displays.](./media/image25.png 'osTicket log in webpage')

Once logged into the OsTicket system, click **My Tickets**

![On the osTicket system page, on the Tickets tab, My Tickets is selected.](./media/image26.png 'osTicket system page')

On the **My Tickets** screen, click through to one of the tickets

![On the osTicket system page, on the Tickets tab, details for a specific ticket display.](./media/image27.png 'osTicket system page')

Next, click the **Users** tab and notice the users that are entered into the system

![On the osTicket system page, the Users tab is selected.](./media/image28.png 'osTicket system page')

Feel free to create new tickets or new users to add to your dataset.

You'll need to connect to the MySQL database to view its information and to export the data. Here are the steps to connect to it:

Enter the following information to configure to connect to your **OnPremVM**:

    -   Connection Name: **OnPremVM**

    -   Connection Method: **Standard TCP/IP over SSH**

    -   SSH Hostname: **\<enter the Public ip address\>**

    -   SSH Username: **demouser**

    -   SSH Password: **Click Store in Vault: demo@pass123**

    -   MySQL Hostname: **127.0.0.1**

    -   MySQL Server Port: **3306**

    -   Username: **osticket**

    -   Password: **Click Store in Vault: demo@pass123**

![The Setup New Connection page displays with fields set to the previously defined settings.](./media/image33.png 'Setup New Connection page')

### OsTicket source code for deploying to Azure

Contoso has the most up-to-date source code they would like you to use to deploy to PaaS. First, you will need to fork this repo and update the [./osticket-master/include/ost-config.php](./osticket-master/include/ost-config.php) file to configure the new **DBHOST** and **DBUSER** values for the new MySQL Cluster you provision in Azure. After making the changes, and committing them, you can deploy to Azure using the deployment options in App Services, or however you wish to do it.
