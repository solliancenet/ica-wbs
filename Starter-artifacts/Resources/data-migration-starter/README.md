# Data migration PoC

These starter artifacts provided by Contoso might help you accelerate your PoC efforts for LAMP lift and shift.

## What the starter contains

- ASP.NET Core web application source code
- Oracle scripts
- SQL script
- Instructions for installing SQL Server 2008, SQL Server 2017, and Oracle XE

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

- Install SQL Server 2017 Developer Edition on the VM from <https://www.microsoft.com/sql-server/sql-server-downloads>
  - Ensure the SQL Server Database Engine runs under the demouser Windows account.
  - Enable Mixed Mode Authentication
    - Ensure the SA password is set to Password.1!!
  - Make sure to add the demouser to the SQL Server Administrators group
- Install SQL Server Management Studio (SSMS) 17
- Install SQL Server 2008 R2 Express with Advanced Services on the VM from <https://www.microsoft.com/download/details.aspx?id=30438>
  - Be sure that the SQL Database Engine runs under the demouser Windows account
  - Enable Mixed Mode Authentication
    - Ensure the SA password is set to Password.1!!
  - Ensure the demouser account is added to the SQL Server Administrators group
    -Install the AdventureWorks database in SQL 2008 R2. It will act as the "on-premises" data warehouse database that you will migrate to Azure SQL Database. - Download the AdventureWorks 2008R2 DW script from <https://github.com/Microsoft/sql-server-samples/releases/tag/adventureworks2008r2> - Execute `instawdwdb.sql` against the SQL Server 2008 instance on your VM - Rename the database to WorldWideImporters
- Install Oracle XE on your Lab VM, load a sample database supporting an application, and then migrate the database to SQL Server 2017.
  - Install Oracle XE on your lab VM from: <http://www.oracle.com/technetwork/database/database-technologies/express-edition/downloads/index.html>
  - Be sure to set the SYS and SYSTEM password to Password.1!!
- Install Oracle Data Access Components (ODAC) from <http://www.oracle.com/technetwork/database/windows/downloads/index-090165.html>
  - Be sure the install the 64-bit ODAC components
  - Ensure you configure ODP.NET and Oracle Providers for ASP.NET at machine-wide level
- Install SSMA 7.x from <https://www.microsoft.com/en-us/download/details.aspx?id=54258>
- Install a third-party extension to Visual Studio to enable interaction with, and script execution for, the Oracle database in Visual Studio 2017 Community Edition. This step is necessary because the Oracle Developer Tools extension does not currently work with Visual Studio 2017 Community Edition.
  - Install dbForge Fusion for Oracle Professional trial version from <https://www.devart.com/dbforge/oracle/fusion/download.html>
- Using Database Explorer provided under the Fusion menu installed by dbForge Fusion in Visual Studio, create a connection to the Oracle database
- Run the SQL scripts in order provided under the Oracle Scripts folder of the starter
- Modify the web.config of the NorthwindMVC starter web app so the OracleConnectionString points to your Oracle instance of Northwind
- Run the application and see the Dashboard from Northwind Traders load

  ![This is a screenshot of the Northwind Traders Dashboard.](./media/northwind-traders-dashboard.png 'View the dashboard')

* Modify the NorthwindMVC application, so it targets SQL Server 2017 instead of Oracle.
* Modify the web.config so that SqlServerConnectionString is correct for your environment
* Delete the existing entity model present in the files under the Data folder in Solution explorer
* Connect to the SQL Server database through Server Explorer in Visual Studio
* Create a new Code First model against the SQL Server database
* Change the DataContext to use your SqlServerConnectionString
* Within `HomeController.cs` uncomment the SQL Server specific code and comment out the Oracle specific code
* Modify `SALESBYYEAR.cs` so that `YEAR` is of type int and `SUBTOTAL` is of type decimal
* Modify `SalesByYearViewModel.cs` so that `Year` is of type int
* Run the SALES_BY_YEAR_fix.sql

* Here's a screenshot of the application dashboard showing correctly, this time with data coming from SQL Server:

  ![This is a screenshot of the Northwind Traders Dashboard.](./media/northwind-traders-dashboard.png 'View the dashboard')
