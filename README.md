![Hackathon Logo](docs/images/hackathon.png?raw=true "Hackathon Logo")
# Sitecore Hackathon 2023

- MUST READ: **[Submission requirements](SUBMISSION_REQUIREMENTS.md)**
- [Entry form template](ENTRYFORM.md)
  
### ⟹ [Insert your documentation here](ENTRYFORM.md) <<


## Team name
⟹ InspirePro

## Category
⟹ Best Enhancement to XM Cloud

## Description
⟹ Write a clear description of your hackathon entry.  

  - Module Purpose - To get Sitecore changed Item (awaiting approval) workflow notification on MS Team and update their workflow state based on action (accept/reject) from MS Teams without Sitecore Login.
  
  - What problem was solved (if any) - With this module, Business will be having a common MS Team channel with all authorized Content Publisher members only. And based on action triggered on Channel for that item - workflow state will be changed - without going and login into Sitecore.
  
    - How does this module solve it - We have created webhook item in Sitecore to trigger on item_saved event with rule - Item must be in awaiting approval state. Based on webhook request from Sitecore - we have written azure function to do push notification on MS Team and on user action (accept/reject) on MS Teams, we are updating Item workflow State using Sitecore Item Rest API. Future Extensibility - This module is not limited to only MS Teams integration, we can also integrate with Slack/WhatsApp or any Professional Communication channel.


## Video link

⟹ [Replace this Video link](#video-link)



## Pre-requisites and Dependencies

⟹ Does your module rely on other Sitecore modules or frameworks?

- List any dependencies
- Sitecore XM Cloud subscription access
- To get push notification configured MS Teams Channel with incoming webhook.



## Installation instructions
⟹ Write a short clear step-wise instruction on how to install your module.  

> Steps to setup XM Cloud Sitecore Project:
> - Deploy a XM cloud using Sitecore base repo. https://github.com/sitecorelabs/xmcloud-foundation-head
> - Download and install the Sitecore package ./docs/Webhook.zip into your Sitecore instance
> 
> Set up MS Teams webbook from Microsoft Official documentation https://www.microsoft.com/en-us/videoplayer/embed/RE4ODcY?postJsllMsg=true
> - Copy and note down incoming webhook URL, we will use in next step
> 
> Set Up azure function
> - Check out the code from main branch and deploy SitecoreHackathon23 project on azure function
> - Go to setting > configuration node in azure function app on Portal and create below highlighted application settings.
![azure-function-application-settings.png](docs/images/azure-function-application-settings.png?raw=true "azure-function-application-settings.png")
> 


### Configuration
⟹ If there are any custom configuration that has to be set manually then remember to add all details here.

_Remove this subsection if your entry does not require any configuration that is not fully covered in the installation instructions already_

## Usage instructions
⟹ Provide documentation about your module, how do the users use your module, where are things located, what do the icons mean, are there any secret shortcuts etc.

![flow-diagram.png](docs/images/flow-diagram.png?raw=true "flow-diagram.png")
![sitecore-to-ms-teams-code-flow.png](docs/images/sitecore-to-ms-teams-code-flow.png?raw=true "sitecore-to-ms-teams-code-flow.png")
![sitecore-webhook-item.png](docs/images/sitecore-webhook-item.png?raw=true "sitecore-webhook-item.png")





## Comments
If you'd like to make additional comments that is important for your module entry.
