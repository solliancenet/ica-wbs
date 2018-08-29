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

Setup will take around **45 minutes** to complete. Consider starting with this section on day one, then the following section (How to use the starter) on day two.

What you need to get started is the following:

- Microsoft Azure subscription must be pay-as-you-go or MSDN
  - Trial subscriptions will not work
- A virtual machine configured with:
  - Visual Studio Community 2017 or later
  - Azure SDK 2.9 or later (Included with Visual Studio 2017)

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

> **Note:** Below is a summary of steps you can follow to use the starter files. Detailed step-by-step instructions follow within the **How to use the starter step-by-step** section.

1.  ARM template:

```bash
    az group deployment create --name OsTicketOnPremRG --resource-group OsTicketOnPremRG --template-uri "https://cloudworkshop.blob.core.windows.net/linux-lift-shift/onpremvmdeploy.json"
```

2.  Once deployed, use the public IP address created in the resource group to browse to the site.

    ![On the Microsoft Cloud Workshop tab, the Support Center displays.](./media/image22.png 'Microsoft Cloud Workshop tab')

3.  Use the **Sign in** link in the upper-right hand corner of the screen to go to the log in page, then locate **I'm an agent** and click the corresponding **sign in here** link.

    ![On the Sign in to Microsoft Cloud Workshop Registration page, the Sign in here link was selected.](./media/image24.png 'Sign in to Microsoft Cloud Workshop Registration page')

4.  You can use the following credentials:

    - Username: **_demouser_**

    - Password: **_demo@pass123_**

    ![The osTicket log in webpage displays.](./media/image25.png 'osTicket log in webpage')

5.  Once logged into the OsTicket system, click **My Tickets**

    ![On the osTicket system page, on the Tickets tab, My Tickets is selected.](./media/image26.png 'osTicket system page')

6.  On the **My Tickets** screen, click through to one of the tickets

    ![On the osTicket system page, on the Tickets tab, details for a specific ticket display.](./media/image27.png 'osTicket system page')

7.  Next, click the **Users** tab and notice the users that are entered into the system

    ![On the osTicket system page, the Users tab is selected.](./media/image28.png 'osTicket system page')

8.  Feel free to create new tickets or new users to add to your dataset. You'll need to connect to the MySQL database to view its information and to export the data. Here are the steps to connect to it:

    - Enter the following information to configure to connect to your **OnPremVM**:

      - Connection Name: **OnPremVM**

      - Connection Method: **Standard TCP/IP over SSH**

      - SSH Hostname: **\<enter the Public ip address\>**

      - SSH Username: **demouser**

      - SSH Password: **Click Store in Vault: demo@pass123**

      - MySQL Hostname: **127.0.0.1**

      - MySQL Server Port: **3306**

      - Username: **osticket**

      - Password: **Click Store in Vault: demo@pass123**

    ![The Setup New Connection page displays with fields set to the previously defined settings.](./media/image33.png 'Setup New Connection page')

### OsTicket source code for deploying to Azure

Contoso has the most up-to-date source code they would like you to use to deploy to PaaS. First, you will need to fork this repo and update the [./osticket-master/include/ost-config.php](./osticket-master/include/ost-config.php) file to configure the new **DBHOST** and **DBUSER** values for the new MySQL Cluster you provision in Azure. After making the changes, and committing them, you can deploy to Azure using the deployment options in App Services, or however you wish to do it.

## How to use the starter step-by-step

Duration: 60 minutes

In this exercise, you will install and configure SQL Server 2017 and SQL Server 2008 R2 on the SqlServerDw VM. The databases on this VM will act as the "on-premises" databases for the starter project.

### Task 1: Install SQL Server 2017

In this task, you will install SQL Server 2017 and Microsoft SQL Server Management Studio (SSMS) on the SqlServerDw VM.

> Connect to the SqlServerDw VM following the steps provided in the **Starter setup** section.

1. On the SqlServerDw VM, open a web browser and navigate to the [SQL Server 2017 Developer edition download](https://www.microsoft.com/sql-server/sql-server-downloads) page, then select the **Download now** link under Developer in the free specialized edition section

   ![The Download now link is highlighted under Developer edition at https://www.microsoft.com/sql-server/sql-server-downloads.](media/sql-server-2017-developer-edition-download.png 'Download SQL Server 2017 Developer Edition')

2. Run the downloaded installer

3. In the install dialog, select **Custom** as the installation type on the first screen

   ![In the installation dialog box, Custom is selected and highlighted under Select an installation type.](./media/sql-server-2017-install-type.png 'Select Custom')

4. On the next screen, leave the Media Location set to the default value, and select **Install**

   ![The default value (C:\SQLServer2017Media) is listed under Media Location, and Install is highlighted at the bottom.](./media/sql-server-2017-install-location.png 'Install with the default value')

5. Once the necessary components are downloaded, the SQL Server Installation Center will open. Select **Installation** on the left-hand menu, then select **New SQL Server stand-alone installation or add features to an existing installation**.

   ![Installation is highlighted on the left side of the SQL Server Installation Center dialog box. At right, New SQL Server stand-alone installation or add features to an existing installation is highlighted.](./media/sql-server-2017-installation-center-installation-new-sql-server.png 'Choose your installation')

6. On the Product Key screen, select **Developer** under Specify a free edition, and select **Next**

   ![Developer displays under Specify a free edition.](./media/sql-server-2017-installation-center-installation-new-sql-server-free-edition.png 'Specify the edition')

7. On the License Terms screen, check the box to **accept the license terms**, and select **Next**

8. Select **Next** on each the following screens to accept the defaults, until you get to the Feature Selection screen

9. On the **Feature Selection** screen, check the box next to **Database Engine Services**, and select **Next**

   ![Database Engine Services is selected and highlighted under Instance Features on the Feature Selection screen.](./media/sql-server-2017-installation-center-feature-selection.png 'Select Database Engine Services')

10. On the **Instance Configuration** screen, leave **Default instance** selected, and select **Next**

11. Accept the default values on the **Server Configuration** screen, and select **Next**

12. On the **Database Engine Configuration** screen:

    - Select **Mixed Mode** for the Authentication Mode

    - Enter **Password.1!!** for the sa password

    - Click the **Add Current User** button to make the **demouser** windows account a SQL Server administrator

    ![The information above is highlighted on the Database Engine Configuration screen, including the Add Current User button under Specify SQL Server administrators.](./media/sql-server-2017-installation-center-database-engine-configuration.png 'Specify Database Engine Configuration settings')

    - Select **Next**

13. Select **Install** on the Ready to Install screen to start the installation

14. Select **Close** when the installation is complete

15. Back in the SQL Server Installation Center dialog, select **Install SQL Server Management Tools** on the Installation tab

    ![Installation is highlighted on the left side of the SQL Server Installation Center dialog box. At right, Install SQL Server Management Tools is highlighted.](./media/sql-server-2017-installation-center-installation-ssms.png 'Select Install SQL Server Management Tools')

16. In the browser window that opens, scroll down and select the **Download SQL Server Management Studio 17.x** link, then run the installer

    ![Download SQL Server Management Studio 17.7 is highlighted.](media/ssms-dowload.png 'SSMS Download link')

17. In the install window that appears, select Install to complete the installation

    ![Install is highlighted at the bottom of the Microsoft SQL Server Management Studio installation window.](media/ssms-install.png 'Microsoft SQL Server Management Studio Install Welcome page')

18. Close the SQL Server Management Studio (SSMS) installer once setup is completed

19. Close the SQL Server Installation Center dialog

### Task 2: Install SQL Server 2008 R2

In this task, you will install SQL Server 2008 R2 as a Named Instance on the SqlServerDw VM.

1. On the SqlServerDw VM, open a web browser, and navigate to <https://www.microsoft.com/download/details.aspx?id=30438>, and select the **Download** link on the page

   ![Download is selected and highlighted on the https://www.microsoft.com/download/details.aspx?id=30438 page under Microsoft SQL Server 2008 R2 SP2 * Express Edition.](./media/sql-server-2008-r2-express-edition-download.png 'Download link')

2. Download SQL Server 2008 R2 Express with Advanced Services by selecting **SQLEXPRADV_x64_ENU.exe**, then selecting **Next**

   ![SQLEXPRADV_x64_ENU.exe is highlighted in the list under Choose the download you want.](./media/sql-server-2008-r2-express-edition-download-files.png 'Download SQL Server 2008 R2 Express with Advanced Services')

3. Run the installer

4. In the SQL Server Installation Center window, select **New installation or add features to an existing installation**

   ![New installation or add features to an existing installation is highlighted in the SQL Server Installation Center window.](./media/sql-server-2008-installation-center-installation-new-installation.png 'Select New installation or add features to an existing installation')

5. In the SQL Server 2008 R2 Setup dialog, accept the license terms on the License Terms screen, and select **Next**

6. Accept the default values on each screen by selecting **Next**, until you get to the Instance Configuration screen

7. On the **Installation Configuration** screen, select **Named Instance**, and enter **SQLServer2008** for the instance name, then select **Next**

   ![Instance Configuration is highlighted on the left side of the SQL Server 2008 R2 Setup dialog box. At right, Named instance: SQLServer2008 is highlighted.](./media/sql-server-2008-installation-center-instance-configuration.png 'Enter the instance name')

8. On the **Server Configuration** screen, select **Use the same account for all SQL Server services**

   ![Server Configuration is highlighted on the left side of the SQL Server 2008 R2 Setup dialog box. At right, SQL Server Database Engine is selected on the Service Accounts tab, and Use the same account for all SQL Server services is highlighted at the bottom.](./media/sql-server-2008-installation-center-server-configuration.png 'Select Use the same account for all SQL Server services')

9. Select **Browse**, and enter **demouser**. Select the **demouser** account you created when you provisioned the VM, then enter the password, **Password.1!!**, and select **OK**

   ![The credentials above are entered in the Use the same account for all SQL Server 2008 R2 services dialog box.](media/sql-server-2008-installation-center-service-account.png 'Service account credentials')

10. Select Next on the Server Configuration screen

11. On the Database Engine Configuration screen:

    - Select **Mixed Mode**

    - Enter **Password.1!!** for the sa password

    - Click the **Add Current User** button to specify the demouser Windows account as a SQL Server Administrator

      ![Database Engine Configuration is highlighted on the left side of the SQL Server 2008 R2 Setup dialog box. The information above is highlighted at right, including the Add Current User button under Specify SQL Server administrators.](media/sql-server-2008-installation-center-database-engine-configuration.png 'Specify Database Engine Configuration settings')

    - Select **Next**

12. Select **Next** to accept the default values on the remaining screens to complete the installation

13. Select **Close** on the SQL Server 2008 R2 Setup dialog when the installation is complete

14. Close the SQL Server 2008 R2 Installation Center window

### Task 3: Install AdventureWorks sample database

In this task, you will install the AdventureWorks database in SQL 2008 R2. It will act as the "on-premises" data warehouse database that you will migrate to Azure SQL Database.

1. On the SqlServerDw VM, open a web browser, and navigate to the GitHub site containing the sample AdventureWorks 2008 R2 database at <https://github.com/Microsoft/sql-server-samples/releases/tag/adventureworks2008r2>

2. Scroll down under Assets, and select `adventure-works-2008r2-dw.script.zip`

   ![The adventure-works-2008r2-dw-script.zip download link is highlighted under Assets for the sample database.](./media/adventure-works-2008-r2-sample-download.png 'Assets list')

3. Save the file, and unzip the downloaded file to a folder you create, called `C:\AdventureWorksSample`

4. Launch **SQL Server Management Studio 17** (SSMS), found under Start->Apps->Microsoft SQL Server Tools 17.

   > Note: There are two version of SSMS installed, so make sure you open SSMS 17.

   ![SQL Server Management Studio 17 (SSMS) is highlighted under Microsoft SQL Server Tools 17.](./media/ssms-start-menu.png 'Open SQL Server Management Studio 17 (SSMS)')

5. In the Connect to Server dialog, enter **SqlServerDw\SQLSERVER2008** in the Server name box, leave Authentication set to **Windows Authentication**, and select **Connect**

   ![In the Connect to Server dialog box, SqlServerDw\SQLSERVER2008 is highlighted in the Server name box.](./media/ssms-connect-to-sqlserver2008.png 'Connect to SqlServerDw\SQLSERVER2008')

6. In SSMS, select the **Open File** icon in SSMS menu bar

   ![The File icon is highlighted on the SSMS menu bar.](./media/ssms-toolbar-open-file.png 'Select Open File')

7. In the Open File dialog, browse to the `C:\AdventureWorksSample\AdventureWorks 2008R2 Data Warehouse\` folder, select the file named `instawdwdb.sql`, and then select **Open**

   ![Local Disk (C:) is selected on the left side of the Open File dialog box, and instawdwdb.sql is selected and highlighted on the right.](./media/ssms-open-file-dialog.png 'Select instawdwdb.sql')

8. Next, select **Tools** in the SSMS menu, then select **Options**

   ![Tools is highlighted on the SSMS menu bar, and Options is highlighted at the bottom.](./media/ssms-tools-options-dialog.png 'Select Options')

9. In the Options dialog, expand **Text Editor** in the tree view on the left, then expand **Transact-SQL**, select **General**, then check the box next to **Line numbers**. This will display line numbers in the query editor window, to make finding the lines specified below easier.

   ![On the left side of the Options dialog box, Text Editor is highlighted, Transact-SQL is highlighted below that, and General is selected and highlighted below that. At right, Line numbers is selected and highlighted.](./media/ssms-tools-options-text-editor-tsql-general.png 'Display line numbers in the query editor')

10. Select **OK** to close the Options dialog

11. In the SSMS query editor for `instawdwdb.sql`, uncomment the `SETVAR` lines (lines 36 and 37) by removing the double hyphen "--" from the beginning of each line

12. Next, edit the file path for each variable so they point to the following (remember to include a trailing backslash "\" on each path):

    - SqlSamplesDatabasePath: `C:\AdventureWorksSample\`

    - SqlSamplesSourceDataPath: `C:\AdventureWorksSample\AdventureWorks 2008R2 Data Warehouse\`

      ![The variables and file paths specified above are highlighted in the SSMS query editor.](./media/ssms-query-editor-instawdwdb.png 'Edit the variable file paths')

13. Place SSMS into **SQLCMD mode** by selecting it from the **Query** menu

    ![SQLCMD Mode is highlighted in the Query menu.](./media/ssms-query-menu-sqlcmd-mode.png 'Select SQLCMD Mode')

14. Execute the script by selecting the **Execute** button on the toolbar in SSMS

    ![Execute is highlighted on the SSMS toolbar.](./media/ssms-toolbar-execute.png 'Run the script')

15. This will create the `AdventureWorksDW2008R2` database. When the script is done running, you will see output similar to the following in the results pane.

    ![Output is displayed in the results pane. At this time, we are unable to capture all of the information in the window. Future versions of this course should address this.](./media/ssms-query-instawdwdb-script-output.png 'View the script output')

16. Expand **Databases** in Object Explorer, right-click the `AdventureWorksDW2008R2` database, and select **Rename**

    ![On the left side of Object Explorer, Databases is highlighted, AdventureWorksDW2008R2 is highlighted below that, and Rename is selected and highlighted in the submenu.](./media/ssms-databases-rename.png 'Select Rename')

17. Set the name of the database to `WorldWideImporters`

    ![WorldWideImporters is highlighted under Databases in Object Explorer.](./media/ssms-databases-worldwideimporters.png 'Name the database')

### Task 4: Update SQL Server settings using Configuration Manager

In this task, you will update the SQL Server service accounts and other settings associated with the SQL Server instances installed on the VM.

1. From the Start Menu on your SqlServerDw VM, search for **SQL Server 2017 Configuration Manager**, then select it from the search results

   ![SQL Server 2017 Configuration Manager is selected and highlighted in the Search results.](./media/windows-2012-search-sql-server-2017-configuration-manager.png 'Select SQL Server 2017 Configuration Manager')

2. From the tree on the left of the Configuration Manager window, select **SQL Server Services**

   ![SQL Server Services is highlighted on the left side of SQL Server 2017 Configuration Manager.](./media/sql-server-2017-configuration-manager-sql-server-services.png 'Select SQL Server Services')

3. In the list of services, double-click **SQL Server (MSSQLSERVER)** to open its properties dialog

   ![SQL Server (MSSQLSERVER) is highlighted in the list on the right side of SQL Server 2017 Configuration Manager.](media/sql-server-2017-configuration-manager-sql-server-mssqlserver.png 'Select SQL Server (MSSQLSERVER)')

4. In the SQL Server (MSSQLSERVER) Properties dialog, change the **Log On user** to use the demouser account, by entering **demouser** into the Account Name box, then entering the password, **Password.1!!**, into the Password and Confirm password boxes

   ![The above credentials are highlighted in the SQL Server (MSSQLSERVER) Properties dialog box.](media/sql-server-2017-configuration-manager-sql-server-mssqlserver-properties.png 'Enter demouser credentials')

5. Select **OK**

6. Select **Yes** to restart the service in the **Confirm Account Change** dialog

7. Repeat steps 3 - 6 above to set the server account to demouser for the **SQL Server (SQLSERVER2008)** instance as well, if it is not already using the demouser account

8. While still in the SQL Server 2017 Configuration Manager, expand **SQL Server Network Configuration**, select **Protocols for MSSQLSERVER**, and double-click **TCP/IP** to open the properties dialog

   ![Protocols for MSSQLSERVER is highlighted on the left side of SQL Server 2017 Configuration Manager, and TCP/IP is highlighted in the Protocol Name list on the right.](./media/sql-server-2017-configuration-manager-protocols-for-mssqlserver.png 'Select TCP/IP')

9. On the TCP/IP Properties dialog, set **Enabled** to **Yes**, and select **OK**

   ![Enabled is selected on the Protocol tab of the TCP/IP Properties dialog box.](./media/sql-server-2017-configuration-manager-protocols-tcp-ip-properties.png 'Enable TCP/IP')

10. When prompted that the changes will not take effect until the service is restarted, select **OK**. You will restart the service later.

11. Now, select **Protocols for SQLSERVER2008**, double-click **TCP/IP** to open the properties dialog

12. As you did above, set **Enabled** to **Yes**

13. Next, select the **IP Addresses** tab within the TCP/IP Properties dialog

14. On the IP Addresses tab, scroll down to the IPAll section, and note the port number assigned in the **TCP Dynamic Ports** field. Copy the value into a text editor, such as Notepad, for later use. SQL Server 2008 R2 was installed as a Named Instance, so it was assigned a dynamic port number, different than 1433 which is typically assigned to SQL Server instances. You will need this port number to create an inbound port rule for the SqlServerDw VM to allow the Azure Database Migration Service to access the database.

    ![The IP Addresses tab of the TCP/IP Properties dialog is displayed, with TCP Dynamic Ports highlighted under the IPAll section.](media/tcp-ip-properties-ip-addresses-tab.png 'TCP/IP Properties IP Addresses tab')

15. Select **OK** to close the TCP/IP Properties dialog. When prompted that the changes will not take effect until the service is restarted, select **OK**. You will restart the service later.

16. As done previously, select **SQL Server Services** in the tree on the left, then right-click **SQL Server (MSSQLSERVER)** in the services pane, and select **Restart**

    ![SQL Server Services is highlighted on the left side of SQL Server 2017 Configuration Manager, SQL Server (MSSQLSERVER) is highlighted on the right, and Restart is highlighted in the submenu.](./media/sql-server-2017-configuration-manager-sql-server-services-sql-server-restart.png 'Select Restart')

17. Repeat the previous step for the **SQL Server (SQLSERVER2008)** service

18. Repeat the previous step for the **SQL Server Agent (MSSQLSERVER)** service, this time selecting **Start** from the menu

    ![SQL Server Services is highlighted on the left side of SQL Server 2017 Configuration Manager, SQL Server Agent (MSSQLSERVER) is highlighted on the right, and Start is highlighted in the submenu.](./media/sql-server-2017-configuration-manager-sql-server-services-sql-server-agent-restart.png 'Select Start')

19. Close the SQL Server 2017 Configuration Manager

### Task 5: Add inbound port rule

In this task, you will add an inbound port rule for the SqlServerDw VM, to allow the dynamic port used by the SQL Server 2008 R2 Named Instance.

1. In the [Azure portal](https://portal.azure.com), navigate to your SqlServerDw VM

2. On the SqlServerDw blade, select **Networking** in the left-hand menu, under Settings, and then select **Add inbound port rule**

   ![On the SqlServerDw VM blade, Networking is selected and highlighted under Settings in the left-hand menu, and the Add inbound port rule button is highlighted on the Networking blade.](media/sql-virtual-machine-add-inbound-port-rule.png 'Virutal Machine Networking blade')

3. In the Add inbound security rule dialog, enter the following:

   - **Destination port ranges**: Enter the dynamic port you noted and copied for your SQL Server 2008 instance

   - **Name**: Enter Port\_[DYNAMIC-PORT-NUMBER], such as Port_49700

   - Leave all other settings set to the default values, and select **Add**

     ![In the Add inbound security rule dialog, the values specified above are entered into the appropriate fields.](media/sql-virtual-machine-networking-add-inbound-security-rule.png 'Add inbound security rule')

### Task 6: Copy the SqlServerDw VM IP address

In this task, you will copy the IP address for later reference.

1. In the [Azure portal](https://portal.azure.com), navigate to your SqlServerDw VM

2. On the SqlServerDw overview blade, select the copy button next to the Public IP address value, and paste the value into a text editor, such as Notepad, for later reference

   ![On the SqlServerDw VM Overview blade, the Public IP address is highlighted.](media/sql-virtual-machine-overview-blade-ip-address.png 'Virtual machine Overview')
