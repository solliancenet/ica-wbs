![Intelligent Cloud Architect Workshop](../Media/workshop-banner.png)

# Financial Services Modernization

Technology challenge facilitator guide

August 2018

Information in this document, including URL and other Internet Web site references, is subject to change without notice. Unless otherwise noted, the example companies, organizations, products, domain names, e-mail addresses, logos, people, places, and events depicted herein are fictitious, and no association with any real company, organization, product, domain name, e-mail address, logo, person, place or event is intended or should be inferred. Complying with all applicable copyright laws is the responsibility of the user. Without limiting the rights under copyright, no part of this document may be reproduced, stored in or introduced into a retrieval system, or transmitted in any form or by any means (electronic, mechanical, photocopying, recording, or otherwise), or for any purpose, without the express written permission of Microsoft Corporation.

Microsoft may have patents, patent applications, trademarks, copyrights, or other intellectual property rights covering subject matter in this document. Except as expressly provided in any written license agreement from Microsoft, the furnishing of this document does not give you any license to these patents, trademarks, copyrights, or other intellectual property.

The names of manufacturers, products, or URLs are provided for informational purposes only and Microsoft makes no representations and warranties, either expressed, implied, or statutory, regarding these manufacturers or the use of the products with any Microsoft technologies. The inclusion of a manufacturer or product does not imply endorsement of Microsoft of the manufacturer or product. Links may be provided to third party sites. Such sites are not under the control of Microsoft and Microsoft is not responsible for the contents of any linked site or any link contained in a linked site, or any changes or updates to such sites. Microsoft is not responsible for webcasting or any other form of transmission received from any linked site. Microsoft is providing these links to you only as a convenience, and the inclusion of any link does not imply endorsement of Microsoft of the site or the products contained therein.

© 2018 Microsoft Corporation. All rights reserved.

Microsoft and the trademarks listed at <https://www.microsoft.com/en-us/legal/intellectualproperty/Trademarks/Usage/General.aspx> are trademarks of the Microsoft group of companies. All other trademarks are property of their respective owners.

**Contents**

<!-- TOC -->

- [Financial Services Modernization Technology Challenge Attendee Guide](#financial-services-modernization-technology-challenge-attendee-guide)
  - [Starter artifacts](#starter-artifacts)
    - [LAMP Lift and Shift PoC Starter](#lamp-lift-and-shift-poc-starter)
    - [Containerization PoC Starter](#containerization-poc-starter)
    - [Data Migration PoC Starter](#data-migration-poc-starter)
    - [Secure Data PoC Starter](#secure-data-poc-starter)
    - [Secure Infra PoC Starter](#secure-infra-poc-starter)
    - [Claims Management Innovation PoC Starter](#claims-management-innovation-poc-starter)
  - [Additional References](#additional-references)
<!-- /TOC -->

# Financial Services Modernization Technology Challenge Attendee Guide

The technology challenge is your opportunity to show Contoso Ltd. how you might approach their solution and address their concerns by delivering a PoC. 

Your goal for the technology challenge is to create customer confidence in your proposed solution and ultimately to ask you for a statement of work (SOW) to proceed. 

Tomorrow, you will have the opportunity to meet with Contoso Ltd. and present back your solution. You should come prepared with the following artifacts:

* Overall solution diagram in PowerPoint or Visio
* Solution diagram of PoC 
* Demo of working PoC
* Be prepared to provide a summary of what the PoC proves out and demonstrates


## Starter artifacts

Contoso Ltd. has prepared a set of artifacts they felt may help to accelerate your PoC efforts. They have expressed that you are not required to use these at all if the do not benefit the PoC you have identified. Also, they are very much open to you starting your PoC from scratch or leveraging other materials you already have.

The following table summarizes each of the available PoC resources. The detailed documentation on what each starter includes, where to get the starter and how to use each PoC starter follows the table.

| PoC                              | Starter Artifacts                                                                  
| -------------------------------- | ----------------------------------------------------------------------------------------------------------------- | 
| LAMP Lift and Shift PoC          | Sample help desk app, OsTicket LAMP stack starter VM                                                                                          |             
| Containerization PoC             | Starter code for api/website and Mongo DB database                                                                |             
| Data Migration PoC               | Sample DW in SQL 2008 R2 format                                                                                   |             
| Secure Data PoC                  | Starter web app and db, start ARM template                                                                        |             
| Secure Infra PoC                 | Starter ARM templates                                                                                             |             
| Claims Management Innovation PoC | Jupyter Notebook starters for summarization, classification, Cognitive Services (Computer Vision, Text Analytics) |     

### LAMP Lift and Shift PoC Starter

Artifacts provided include a dev version of the LAMP-based OsTicket help desk application and database you can use to kick-start your lift and shift PoC.

- A VM using an ARM template, to act as the on-premises installation of the OsTicket application:
  - Ubuntu Linux 16.04-LTS VM with Apache
  - PHP
  - MySQL
  - Sample data in the application
- Source code for the OsTicket application.

**Where to find the artifacts**: [LAMP-lift-and-shift-starter](../Starter-artifacts/Resources/LAMP-lift-and-shift-starter/README.md)

### Containerization PoC Starter

Artifacts provided include a PoC of a white-label portal using Docker images, which can be used as a starter for your PoC.

- Artifacts include the following 3 Docker containers and Node.js project source files:
  - content-api
  - content-init
  - content-web
- Mongo DB

**Where to find the artifacts**: [containerization-starter](../Starter-artifacts/Resources/containerization-starter/README.md)

### Data Migration PoC Starter

Artifacts provided include a web application that is configured to connect to Oracle with some placeholders within its code to connect to SQL. All references to configure the Oracle and SQL environments, as well as to install the required software for the starter project are included.

- ASP.NET Core web application source code
- Oracle scripts
- SQL script
- Instructions for installing SQL Server 2008, SQL Server 2017, and Oracle XE

**Where to find the artifacts**: [data-migration-starter](../Starter-artifacts/Resources/data-migration-starter/README.md)

### Secure Data PoC Starter

Artifacts provided include an ARM template for creating your environment that hosts the insurance web application and database, which can be used to kick-start your PoC.

- ARM template that creates the following:
  - One storage account
  - Three virtual networks
  - Three network security groups
  - Three virtual machines (db-1, web-1, paw-1)
    - IIS is installed on web-1 via a DSC script from the GitHub repository
  - One SQL Azure Server
  - One Azure Key Vault
- Insurance API source code
- Insurance.bacpac file for SQL database

**Where to find the artifacts**: [secure-data-starter](../Starter-artifacts/Resources/secure-data-starter/secure-data-starter.md)

### Secure Infra PoC Starter

Artifacts provided include an ARM template for creating your environment that hosts the insurance web application and database, as well as a script you can use for port scanning.

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

**Where to find the artifacts**: [secure-infra-starter](../Starter-artifacts/Resources/secure-data-starter/secure-infra-starter.md)

### Claims Management Innovation PoC Starter

The following artifacts will help you quickly get up and running for the claims management PoC:

Jupyter Notebook starters for summarization, classification, Cognitive Services (Computer Vision, Text Analytics)

**Where to find the artifacts**: [claims-management-innovation-starter](../Starter-artifacts/Resources/claims-management-innovation-starter/README.md)


## Additional References

The following tables lists some reference materials that may be helpful to your PoC.

|    |            |
|----------|:-------------:|
| **Description** | **Links** |
| Azure Virtual Machines | <https://docs.microsoft.com/en-us/azure/virtual-machines/windows/>   |
| Azure Virtual Networks | <https://docs.microsoft.com/en-us/azure/virtual-network/virtual-networks-overview>   |
| Network Security Groups | <https://docs.microsoft.com/en-us/azure/virtual-network/virtual-networks-nsg>  |
| Azure VPN Gateway   |  <https://docs.microsoft.com/en-us/azure/vpn-gateway/vpn-gateway-howto-site-to-site-resource-manager-portal>  |
| Azure Web Apps   | <https://docs.microsoft.com/en-us/azure/app-service/>   |
| Azure SQL Database  | <https://docs.microsoft.com/en-us/azure/sql-database/>     |
| Azure SQL documentation, TDE, data masking and encryption at rest   |  <https://docs.microsoft.com/en-us/azure/sql-database/sql-database-always-encrypted-azure-key-vault>   |
| Express Route   | <https://docs.microsoft.com/en-us/azure/expressroute/expressroute-introduction>  |
| Azure Storage Encryption  | <https://docs.microsoft.com/en-us/azure/storage/common/storage-service-encryption>  |
| SQL Server (IaaS)   | <https://docs.microsoft.com/en-us/azure/virtual-machines/windows/sql/virtual-machines-windows-sql-server-iaas-overview>  |
| Azure Identity Access Management (IAM)  | <https://docs.microsoft.com/en-us/azure/active-directory/role-based-access-control-configure>  |
| Azure Monitor and Log Analytics   | <https://docs.microsoft.com/en-us/azure/monitoring-and-diagnostics/monitoring-overview>   |
| Azure Key Vault   |  <https://docs.microsoft.com/en-us/azure/key-vault/>  |
| Microsoft Azure Active Directory Connect  | <https://docs.microsoft.com/en-us/azure/active-directory/connect/active-directory-aadconnectsync-whatis>  |
| Lift and Shift (IaaS)  |  <https://docs.microsoft.com/en-us/dotnet/standard/modernize-with-azure-and-containers/lift-and-shift-existing-apps-azure-iaas> |
| Microsoft Intune  | <https://docs.microsoft.com/en-us/intune>   |
| Conditional Access  | <https://docs.microsoft.com/en-us/azure/active-directory/active-directory-conditional-access-azure-portal>    |
| Azure, Office 365, Azure SQL and Cloud App references   | <https://docs.microsoft.com/en-us/azure/active-directory/active-directory-conditional-access-no-modern-authentication>  |
| SQL Database Conditional Access  | <https://docs.microsoft.com/en-us/azure/sql-database/sql-database-conditional-access>  |
| Azure AD Conditional Access Technical Reference  | <https://docs.microsoft.com/en-us/azure/active-directory/active-directory-conditional-access-technical-reference>   |
| Advanced Threat Analytics  | <https://docs.microsoft.com/en-us/advanced-threat-analytics>   |
| Microsoft Cloud App Security  | <https://docs.microsoft.com/en-us/cloud-app-security>   |
| Compliance Commitments   |  <http://azure.microsoft.com/en-us/support/trust-center/services/>  |
| Azure Trust Center  | <http://azure.microsoft.com/en-us/support/trust-center/>     |
| Azure and Linux | <https://docs.microsoft.com/en-us/azure/virtual-machines/linux/overview/> |
| Linux on distributions endorsed by Azure | <https://docs.microsoft.com/en-us/azure/virtual-machines/linux/endorsed-distros/> |
| What are Azure Virtual Machine Scale Sets | <https://docs.microsoft.com/en-us/azure/virtual-machine-scale-sets/virtual-machine-scale-sets-overview/> |
| Deploy your application on Virtual Machine Scale Sets | <https://docs.microsoft.com/en-us/azure/virtual-machine-scale-sets/virtual-machine-scale-sets-deploy-app/> |
| Azure Database for MySQL Documentation | <https://docs.microsoft.com/en-us/azure/mysql/> |
| Create and manage Azure Database for MySQL server using Azure portal | <https://docs.microsoft.com/en-us/azure/mysql/howto-create-manage-server-portal/> |
| Create and manage Azure Database for MySQL firewall rules by using the Azure portal | <https://docs.microsoft.com/en-us/azure/mysql/howto-manage-firewall-using-portal/> |
| Connect Azure Web App to Azure Database for MySQL | <https://docs.microsoft.com/en-us/azure/mysql/howto-connect-webapp/> |
| Azure Database for MySQL: Use MySQL Workbench to connect and query data | <https://docs.microsoft.com/en-us/azure/mysql/connect-workbench/> |
| Download MySQL Workbench | <https://dev.mysql.com/downloads/workbench/> |
| App Service for Linux | <https://docs.microsoft.com/en-us/azure/app-service/containers/app-service-linux-intro/> |
| Azure Migration Center  | <https://azure.microsoft.com/en-us/migration/>  |
| Azure Hybrid Benefit  | <https://azure.microsoft.com/en-us/pricing/hybrid-benefit/>  |
| Azure Migrate  | <https://docs.microsoft.com/en-us/azure/migrate/migrate-overview>   |
| Azure TCO Calculator  | https://azure.microsoft.com/en-us/pricing/tco/calculator/  |
| Azure Site Recovery | <https://docs.microsoft.com/en-us/azure/site-recovery/>    |
| Database Migration Guide   | <https://datamigration.microsoft.com/>      |
| Data Migration Assistant   | <https://docs.microsoft.com/en-us/sql/dma/dma-overview?view=sql-server-2017>      |
| Database Experimentation Assistant   | https://blogs.msdn.microsoft.com/datamigration/2017/07/25/dea-2-1-general-availability-release-overview-database-experimentation-assistant/      |
| Azure Cost Management   | <https://docs.microsoft.com/en-us/azure/cost-management/overview>   |
| SQL Server Stretch Database | <https://azure.microsoft.com/services/sql-server-stretch-database> |
| Azure Database Migration Service Overview | <https://docs.microsoft.com/azure/dms/dms-overview> |
| SQL Server database migration to Azure SQL Database | <https://docs.microsoft.com/en-us/azure/sql-database/sql-database-cloud-migrate> |
| Differentiating Microsoft's database migration tools | <https://blogs.msdn.microsoft.com/datamigration/2017/10/13/differentiating-microsofts-database-migration-tools-and-services/> |
| Azure Kubernetes Services (AKS) | <https://docs.microsoft.com/en-us/azure/aks/intro-kubernetes/> |
| Kubernetes | <https://kubernetes.io/docs/home/> |
| Azure Machine Learning services | <https://docs.microsoft.com/en-us/azure/machine-learning/preview/overview-what-is-azure-ml>  |   |
| Deploying Web Services  |  <https://docs.microsoft.com/en-us/azure/machine-learning/preview/model-management-service-deploy> |
| Overview of TFLearn   | <http://tflearn.org/>   |
| Overview of TensorFlow  | <https://www.tensorflow.org/>    |
| Overview of gensim library    | <https://radimrehurek.com/gensim/>   |
| Overview of the Computer Vision API Cognitive Service    |  <https://docs.microsoft.com/en-us/azure/cognitive-services/computer-vision/home>   |
| Overview of the Text Analytics API Cognitive Service  | <https://docs.microsoft.com/en-us/azure/cognitive-services/text-analytics/overview>    |
