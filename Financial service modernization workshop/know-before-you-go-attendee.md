## Requirements

1. Attendees will need to bring their own Wi-Fi enabled laptops to the event. The laptop can be running Windows, Linux or macOS so long as:

    - The system supports a modern web browser (Chrome, Safari, Firefox, etc.)

    - The system has an up to date RDP client installed or the attendees must be able to install additional software (such as Remote Desktop Clients or x2GO clients) for access to remote virtual machines running in Azure.

    - Windows machines need to be running Windows 10 or later.


2. Attendees need to bring their own Azure subscription as Microsoft will not be providing subscriptions to use for the event. Microsoft Azure subscription must be pay-as-you-go or MSDN.

    - Trial subscriptions will *not* work. If you convert a trial subscription to a Pay-as-you-go, make sure to request a core quota increase so you have 20 cores available.

    - You must have rights to create a service principal in Azure Active Directory. This typically requires a user in the subscription owner role. You may have to ask another subscription owner to login to the portal and execute that step ahead of time if you do not have the rights.

    - You must have enough cores available in your subscription. We suggest having at least 20 cores available. For example to create a build agent VM and Azure Kurbernetes Service cluster,  you'll need eight cores. You'll need more if you choose additional agents or larger VM sizes.  

    - You should be prepared to spend up to $100 USD in your subscription.



2. A VisualStudio.com account

3. Local machine or a virtual machine configured with:

    - A browser, preferably Chrome  

    - Command prompt

        i.  On Windows, you can use Bash on Ubuntu on Windows, hereon referred to as WSL

        ii. On Mac, execute using bash in Terminal

4. A virtual machine configured with:
    - Visual Studio Community 2017 or later

    - Azure SDK 2.9 or later (Included with Visual Studio 2017)

5. A virtual machine configured with:
    - Visual Studio 2017

    - SQL Management Studio 2017

    - Power BI Desktop


6. You must bring your own laptop:
    - You must have an up to date RDP client installed on your laptop.

4. You will be asked to install other tools throughout the exercises