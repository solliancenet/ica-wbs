# Data migration PoC

These starter artifacts provided by Contoso might help you accelerate your PoC efforts for data migration.

## What the starter contains

- ASP.NET Core web application source code
- SQL script
- Instructions for installing SQL Server 2008, and SQL Server 2017

## Starter setup

> IMPORTANT: Most Azure resources require unique names. Throughout this lab you will see the word “SUFFIX” as part of resource names. You should replace this with your Microsoft alias, initials, or another value to ensure the resource is uniquely named.

## Task 1: Provision a resource group

In this task, you will create an Azure resource group for the resources used throughout this lab.

1. In the [Azure portal](https://portal.azure.com), select **Resource groups**, select **+Add**, then enter the following in the Create an empty resource group blade:

   - **Name**: Enter hands-on-lab-SUFFIX

   - **Subscription**: Select the subscription you are using for this hands-on lab

   - **Resource group location**: Select the region you would like to use for resources in this hands-on lab. Remember this location so you can use it for the other resources you'll provision throughout this lab.

     ![Add Resource group Resource groups is highlighted in the navigation pane of the Azure portal, +Add is highlighted in the Resource groups blade, and "hands-on-labs" is entered into the Resource group name box on the Create an empty resource group blade.](./media/create-resource-group.png 'Create resource group')

2. Select **Create**.

## Task 2: Create lab virtual machine

In this task, you will provision a virtual machine (VM) in Azure. The VM image used will have Visual Studio Community 2017 installed.

1. In the [Azure portal](https://portal.azure.com/), select **+Create a resource**, enter "visual studio community" into the Search the Marketplace box, select **Visual Studio Community 2017 (latest release) on Windows Server 2016 (x64)** from the results, and select **Create**.

   ![+Create a resource is selected in the Azure navigation pane, and "visual studio community" is entered into the Search the Marketplace box. Visual Studio Community 2017 (latest release) on Windows Server 2016 (x64) is selected in the results.](./media/create-resource-visual-studio-on-windows-server-2016.png 'Create Windows Server 2016 with Visual Studio Community 2017')

2. Set the following configuration on the Basics tab.

   - **Name**: Enter LabVM

   - **VM disk type**: Select SSD

   - **User name**: Enter demouser

   - **Password**: Enter Password.1!!

   - **Subscription**: Select the same subscription you are using for this hands-on lab

   - **Resource Group**: Choose Use existing, and select the hands-on-lab-SUFFIX resource group

   - **Location**: Select the location you are using for resources in this hands-on lab

     ![Screenshot of the Basics blade, with fields set to the previously mentioned settings.](./media/virtual-machine-basics-blade.png 'Create virtual machine Basics blade')

   - Select **OK** to move to the next step.

3. On the Choose a size blade, select DS2_v3 Standard.

   ![On the Choose a size blade, the D2S_v3 Standard size is selected.](./media/virtual-machine-choose-a-size-blade.png 'Choose a size blade')

4. Select **Select** to move on to the Settings blade.

5. On the Settings blade, select **RDP (3389)** from the Select public inbound ports drop down, then select **OK**.

   ![On the Create virtual machine settings blade, RDP (3389) is selected in the public inbound ports drop down.](media/virtual-machine-settings-inbound-ports.png 'Open RDP on inbound port 3389')

6. Select **Create** on the Create blade to provision the virtual machine.

7. It may take 10+ minutes for the virtual machine to complete provisioning.

8. You can move on to the next task while waiting for the lab VM to provision.

## Task 3: Create SQL Server virtual machine

In this task, you will provision another virtual machine (VM) in Azure which will host your "on-premises" instances of both SQL Server 2008 R2 and SQL Server 2017. The VM will use the Windows Server 2012 R2 Datacenter image.

> Note, an older version of Windows Server is being used because SQL Server 2008 R2 is not supported on Windows Server 2016.

1. In the [Azure portal](https://portal.azure.com/), select **+Create a resource**, enter "windows server 2012" into the Search the Marketplace box, select **Windows Server 2012 R2 Datacenter** from the results, and select **Create**.

   ![+ Create a resource is highlighted on the left side of the Azure portal, and at right, windows server 2012 and Windows Server 2012 R2 Datacenter are highlighted.](./media/create-resource-windows-server-2012-r2-datacenter.png 'Azure portal')

2. On the Create virtual machine blade, enter the following:

   - **Name**: Enter SqlServerDw

   - **VM disk type**: Select SSD

   - **User name**: Enter demouser

   - **Password**: Enter Password.1!!

   - **Subscription**: Select the same subscription you are using for this hands-on lab

   - **Resource Group**: Choose Use existing, and select the hands-on-lab-SUFFIX resource group

   - **Location**: Select the location you are using for resources in this hands-on lab

     ![On the Basics blade, the values above are entered in the boxes.](media/sql-virtual-machine-basics-blade.png 'Create virtual machine Basics blade')

   - Select **OK** to move on to the Size blade.

3. On the Choose a size blade, select DS1_v2 Standard.

   ![On the Choose a size blade, DS1_v2 Standard is selected and highlighted.](media/sql-virtual-machine-choose-a-size-blade.png 'Choose a VM size')

4. Select **Select** to move on to the Settings blade.

5. On the Settings blade, select **RDP (3389)** and **MS SQL (1433)** from the Select public inbound ports drop down, then select **OK**.

   ![On the Create virtual machine settings blade, RDP (3389) and MS SQL (1433) are selected in the public inbound ports drop down.](media/sql-virtual-machine-settings-inbound-ports.png 'Virtual machine settings - Inbound ports')

6. Select **Create** on the Create blade to provision the virtual machine.

7. It may take 10+ minutes for the virtual machine to complete provisioning.

8. You can move on to the next task while waiting for the lab VM to provision.

## Task 4: Connect to the Lab VM

In this task, you will create an RDP connection to your Lab virtual machine (VM), and disable Internet Explorer Enhanced Security Configuration.

1. In the [Azure portal](https://portal.azure.com), select **Resource groups** in the Azure navigation pane, enter your resource group name (hands-on-lab-SUFFIX) into the filter box, and select it from the list.

   ![Resource groups is selected in the Azure navigation pane, "hands" is entered into the filter box, and the "hands-on-lab-SUFFIX" resource group is highlighted.](./media/resource-groups.png 'Resource groups list')

2. In the list of resources for your resource group, select the LabVM Virtual Machine.

   ![The list of resources in the hands-on-lab-SUFFIX resource group are displayed, and LabVM is highlighted.](./media/resource-group-resources-labvm.png 'LabVM in resource group list')

3. On your Lab VM blade, select Connect from the top menu.

   ![The LabVM blade is displayed, with the Connect button highlighted in the top menu.](./media/connect-labvm.png 'Connect to LabVM')

4. Select **Download RDP file**, then open the downloaded RDP file.

   ![The Connect to virtual machine blade is displayed, and the Download RDP file button is highlighted.](./media/connect-to-virtual-machine.png 'Connect to virtual machine')

5. Select **Connect** on the Remote Desktop Connection dialog.

   ![In the Remote Desktop Connection Dialog Box, the Connect button is highlighted.](./media/remote-desktop-connection.png 'Remote Desktop Connection dialog')

6. Enter the following credentials when prompted:

   a. **User name**: demouser

   b. **Password**: Password.1!!

7. Select **Yes** to connect, if prompted that the identity of the remote computer cannot be verified.

   ![In the Remote Desktop Connection dialog box, a warning states that the identity of the remote computer cannot be verified, and asks if you want to continue anyway. At the bottom, the Yes button is circled.](./media/remote-desktop-connection-identity-verification-labvm.png 'Remote Desktop Connection dialog')

8. Once logged in, launch the **Server Manager**. This should start automatically, but you can access it via the Start menu if it does not start.

   ![The Server Manager tile is circled in the Start Menu.](./media/start-menu-server-manager.png 'Server Manager tile in the Start menu')

9. Select **Local Server**, then select **On** next to **IE Enhanced Security Configuration**.

   ![Screenshot of the Server Manager. In the left pane, Local Server is selected. In the right, Properties (For LabVM) pane, the IE Enhanced Security Configuration, which is set to On, is highlighted.](./media/windows-server-manager-ie-enhanced-security-configuration.png 'Server Manager')

10. In the Internet Explorer Enhanced Security Configuration dialog, select **Off under Administrators**, then select **OK**.

    ![Screenshot of the Internet Explorer Enhanced Security Configuration dialog box, with Administrators set to Off.](./media/internet-explorer-enhanced-security-configuration-dialog.png 'Internet Explorer Enhanced Security Configuration dialog box')

11. Close the Server Manager.

## Task 5: Connect to the SqlServerDw VM

In this task, you will create an RDP connection to the SqlServerDw VM, and configure the server to be an application server. This is necessary to install the required .NET components on the server prior to installing SQL Server 2008 R2. You will also disable IE Enhanced Security Configuration, as you did on the Lab VM.

1. In the [Azure portal](https://portal.azure.com), select **Resource groups** in the Azure navigation pane, enter your resource group name (hands-on-lab-SUFFIX) into the filter box, and select it from the list.

   ![Resource groups is selected in the Azure navigation pane, "hands" is entered into the filter box, and the "hands-on-lab-SUFFIX" resource group is highlighted.](./media/resource-groups.png 'Resource groups list')

2. In the list of resources for your resource group, select the SqlServerDw VM.

   ![The list of resources in the hands-on-lab-SUFFIX resource group are displayed, and SqlServerDw is highlighted.](media/resource-group-resources-sqlserverdw.png 'SqlServerDw VM in resource group list')

3. On the SqlServerDw blade, select Connect from the top menu.

   ![The SqlServerDw blade is displayed, with the Connect button highlighted in the top menu.](media/connect-sqlserverdw.png 'Connect to SqlServerDw')

4. Select **Download RDP file**, then open the downloaded RDP file.

   ![The Connect to virtual machine blade is displayed, and the Download RDP file button is highlighted.](./media/connect-to-virtual-machine.png 'Connect to virtual machine')

5. Select **Connect** on the Remote Desktop Connection dialog.

   ![In the Remote Desktop Connection Dialog Box, the Connect button is highlighted.](./media/remote-desktop-connection.png 'Remote Desktop Connection dialog')

6. Enter the following credentials when prompted:

   a. **User name**: demouser

   b. **Password**: Password.1!!

7. Select **Yes** to connect, if prompted that the identity of the remote computer cannot be verified.

   ![In the Remote Desktop Connection dialog box, a warning states that the identity of the remote computer cannot be verified, and asks if you want to continue anyway. At the bottom, the Yes button is circled.](./media/remote-desktop-connection-identity-verification-sqlserverdw.png 'Remote Desktop Connection dialog')

8. Once logged in, launch the **Server Manager**. This should start automatically, but you can access it via the Start menu if it does not start.

   ![The Server Manager tile is circled in the Start Menu.](./media/start-menu-server-manager.png 'Server Manager tile in the Start menu')

9. Select **Local Server**, then select **On** next to **IE Enhanced Security Configuration**.

   ![Screenshot of the Server Manager. In the left pane, Local Server is selected. In the right, Properties (For LabVM) pane, the IE Enhanced Security Configuration, which is set to On, is highlighted.](./media/windows-server-manager-ie-enhanced-security-configuration.png 'Server Manager')

10. In the Internet Explorer Enhanced Security Configuration dialog, select **Off under Administrators**, then select **OK**.

    ![Screenshot of the Internet Explorer Enhanced Security Configuration dialog box, with Administrators set to Off.](./media/internet-explorer-enhanced-security-configuration-dialog.png 'Internet Explorer Enhanced Security Configuration dialog box')

11. Back in the Server Manager, select **Dashboard** on the left-hand menu, then select **Add roles and features**.

    ![Add roles and features is highlighted on the Server Manager dashboard.](media/server-manager-dashboard-add-roles-and-features.png 'Add roles and features')

12. Select **Next** on the Before You Begin screen.

13. Select **Role-based or feature-based installation** for the installation type, and select **Next**.

    ![Role-based or feature-based installation is selected and highlighted under Select installation type.](./media/add-roles-and-features-wizard-select-installation-type.png 'Select Role-based or feature-based installation ')

14. Accept the default selection on the Select destination server screen, and select **Next**.

    ![Select a server from the server pool is selected on the Select a destination server screen, and the default value (SqlServerDW) appears in the Server Pool box.](./media/add-roles-and-features-wizard-select-destination-server.png 'Accept the default selection')

15. On the Select server roles screen, select **Application Server**, and select **Next**.

    ![Application Server is selected and highlighted on the Select server roles screen.](./media/add-roles-and-features-wizard-select-server-roles.png 'Select Application Server')

16. On the Select features screen, select **.NET Framework 3.5 Features**, then select **Next**.

    ![NET Framework 3.5 Features is selected and highlighted on the Select features screen.](./media/add-roles-and-features-wizard-select-features.png 'Select .NET Framework 3.5 Features')

17. Select **Next** on the Application Server screen.

18. Accept the default values on the Select role services screen, and select **Next**.

19. On the Confirm installation selections screen, check the **Restart the destination server automatically if required** check box, and select **Yes** on the restart confirmation dialog.

20. Select **Install**. You may see a message about specifying an alternate source path. This can be ignored.

    ![Restart the destination server automatically if required is selected and highlighted on the Confirm installation selections screen, and Install is highlighted at the bottom.](./media/add-roles-and-features-wizard-confirm-installation-selections.png 'Confirm your installation selections')

21. Close the Add Roles and Features Wizard, once the installation is completed.

22. Close the Server Manager.

## Task 6: Open port 1433 on the Windows Firewall of the SqlServerDw VM

In this task, you will add rules to the SqlServerDw VM's Windows firewall to allow access to SQL Server via port 1433 by other machines.

1. On the SqlServerDw VM, select **Start**.

   ![The Start icon is highlighted on the VM taskbar.](media/windows-2012-r2-datacenter-startbar.png 'Select Start')

2. Then, select the **Search** icon in the top right-hand corner of the screen.

   ![The Search icon is highlighted on the right side.](media/windows-2012-r2-datacenter-search-icon.png 'Select Search')

3. In the Search text box, enter `wf.msc`, then select **wf** from the list of results.

   ![The wf icon is highlighted in the list of search results.](./media/windows-2012-r2-datacenter-search-wf-msc.png 'Search on wf.msc')

4. In the Windows Firewall with Advanced Security dialog, select, then right-click **Inbound Rules** in the left pane, then select **New Rule** in the action pane.

   ![New Rule is highlighted in the submenu for Inbound Rules, which is selected in the left pane of the Windows Firewall with Advanced Security dialog box.](./media/windows-firewall-new-inbound-rule.png 'Create a new Inbound Rule')

5. In the New Inbound Rule Wizard, under Rule Type, select **Port**, then select **Next**.

   ![Rule Type is selected and highlighted on the left side of the New Inbound Rule Wizard, and Port is selected and highlighted on the right.](./media/new-inbound-rule-wizard-rule-type.png 'Select Port')

6. In the Protocol and Ports dialog, use the default **TCP**, and enter **1433** in the Specific local ports text box, the select **Next**.

   ![Protocol and Ports is selected on the left side of the New Inbound Rule Wizard, and 1433 is in the Specific local ports box, which is selected on the right.](./media/new-inbound-rule-wizard-protocol-and-ports.png 'Select a specific local port')

7. In the Action dialog, select **Allow the connection**, and select **Next**.

   ![Action is selected on the left side of the New Inbound Rule Wizard, and Allow the connection is selected on the right.](./media/new-inbound-rule-wizard-action.png 'Specify the action')

8. In the Profile step, check **Domain**, **Private**, and **Public**, then select **Next**.

   ![Profile is selected on the left side of the New Inbound Rule Wizard, and Domain, Private, and Public are selected on the right.](./media/new-inbound-rule-wizard-profile.png 'Select Domain, Private, and Public')

9. In the Name screen, enter **sqlserver**, and select **Finish**.

   ![Profile is selected on the left side of the New Inbound Rule Wizard, and sqlserver is in the Name box on the right.](./media/new-inbound-rule-wizard-name.png 'Specify the name')

10. Close the Windows Firewall with Advanced Security window.

## Task 7: Provision Azure SQL Database

In this task, you will create an Azure SQL Database, which will server as the target database for migration of the on-premises WorldWideImporters database into the cloud. The Premium tier is required to support ColumnStore index creation.

1. In the [Azure portal](https://portal.azure.com/), select **+Create a resource**, enter "sql database" into the Search the Marketplace box, select **SQL Database** from the results, and select **Create**.

   ![+Create a resource is selected in the Azure navigation pane, and "sql database" is entered into the Search the Marketplace box. SQL Database is selected in the results.](media/create-resource-azure-sql-database.png 'Create SQL Server')

2. On the SQL Database blade, enter the following:

   - **Database name**: Enter WorldWideImporters

   - **Subscription**: Select the same subscription you are using for this hands-on lab

   - **Resource Group**: Choose Use existing, and select the hands-on-lab-SUFFIX resource group

   - **Select source**: Select Blank database

   - **Server**: Select this, and select Create a new server, then on the New server blade, enter the following:

     - **Server name**: Enter a unique name, such as wwiSUFFIX
     - **Server admin login**: Enter demouser
     - **Password**: Enter Password.1!!
     - **Location**: Select the location you are using for resources in this hands-on lab
     - Select **OK**

   - Under Want to use SQL elastic pool, select **Not now**

   - **Pricing tier**: Select Premium P1: 125 DTUs, 500 GB, and select **Apply**

     ![The Configure pricing tier for SQL Server is displayed, with Premium selected and highlighted.](media/azure-sql-database-pricing-tier-premium.png 'SQL Pricing tier configuration')

   - **Collation**: Leave set to SQL_Latin1_General_CP1_CI_AS

   ![The SQL Database blade is displayed, with the values specified above entered into the appropriate fields.](media/azure-sql-database-create.png 'Create Azure SQL Database')

3. Select **Create**

   > **NOTE**: The [Azure SQL Database firewall](https://docs.microsoft.com/azure/sql-database/sql-database-firewall-configure) prevents external applications and tools from connecting to the server or any database on the server unless a firewall rule is created to open the firewall for the specific IP address. When creating the new server above, the **Allow azure services to access server** box was checked, which allows any services using an Azure IP address to access this server and databases, so there is no need to create a specific firewall rule for this hands-on lab. To access the SQL server from an on-premises computer or application, you need to [create a server level firewall rule](https://docs.microsoft.com/azure/sql-database/sql-database-get-started-portal#create-a-server-level-firewall-rule) to allow the specific IP addresses to access the server.

## How to use the starter

Duration: 45 minutes

### Task 1: Install SQL Server 2017

In this task, you will install SQL Server 2017 and Microsoft SQL Server Management Studio (SSMS) on the SqlServerDw VM.

> Connect to the SqlServerDw VM following the steps provided in Task 5 of the [Before the hand-on lab](./Before%20the%20HOL%20-%20Data%20Platform%20upgrade%20and%20migration.md) exercises.

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

## Additional tasks you may perform using the starter

![This is a screenshot of the Northwind Traders Dashboard.](./media/northwind-traders-dashboard.png 'View the dashboard')

- Modify the NorthwindMVC application, so it targets SQL Server 2017.
- Modify the web.config so that SqlServerConnectionString is correct for your environment
- Delete the existing entity model present in the files under the Data folder in Solution explorer
- Connect to the SQL Server database through Server Explorer in Visual Studio
- Create a new Code First model against the SQL Server database
- Change the DataContext to use your SqlServerConnectionString
- Within `HomeController.cs` uncomment the SQL Server specific code and comment out the old code
- Modify `SALESBYYEAR.cs` so that `YEAR` is of type int and `SUBTOTAL` is of type decimal
- Modify `SalesByYearViewModel.cs` so that `Year` is of type int
- Run the SALES_BY_YEAR_fix.sql

- Here's a screenshot of the application dashboard showing correctly, this time with data coming from SQL Server:

  ![This is a screenshot of the Northwind Traders Dashboard.](./media/northwind-traders-dashboard.png 'View the dashboard')
