# LAMP lift and shift PoC starter artifacts

These starter artifacts provided by Contoso might help you accelerate your PoC efforts for LAMP lift and shift.

## What the starter contains

- A VM using an ARM template, to act as the on-premises installation of the OsTicket application:
  - Ubuntu Linux 16.04-LTS VM with Apache
  - PHP
  - MySQL
  - Sample data in the application
- Source code for the OsTicket application.

## Artifacts and getting started

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
