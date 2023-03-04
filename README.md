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

  - Module Purpose - To get Sitecore changed Item workflow notification on MS Team and update their workflow state based on action (accept/reject) without Sitecore Login.
  
  - What problem was solved (if any) - With this module, Business will be having a common MS Team channel with all authorized Content Team members. And Based on action triggered on Channel for that item - workflow state will be changed - without going and login into Sitecore.
  
    - How does this module solve it - We have created webhook item in Sitecore on ItemSaved Event. Based on incoming webhook request from Sitecore - we have written azure function to push notification on MS Team and on user action (accept/reject) on MS Team, we are updating Item workflow State using Sitecore Item Rest API.

_You can alternately paste a [link here](#docs) to a document within this repo containing the description._

## Video link

⟹ [Replace this Video link](#video-link)



## Pre-requisites and Dependencies

⟹ Does your module rely on other Sitecore modules or frameworks?

- List any dependencies
- Azure function to get incoming sitecore webhook request.
- MS Teams Channel with webhook configured to get Push notification.
- Sitecore Item Restful API to update workflow state.



## Installation instructions
⟹ Write a short clear step-wise instruction on how to install your module.  

> _A simple well-described installation process is required to win the Hackathon._  
> Feel free to use any of the following tools/formats as part of the installation:
> - Sitecore Package files
> - Docker image builds
> - Sitecore CLI
> - msbuild
> - npm / yarn
> 
> _Do not use_
> - TDS
> - Unicorn
 
for example:

1. Use the Sitecore Installation wizard to install the [package](#link-to-package)
2. ...
3. profit

### Configuration
⟹ If there are any custom configuration that has to be set manually then remember to add all details here.

_Remove this subsection if your entry does not require any configuration that is not fully covered in the installation instructions already_

## Usage instructions
⟹ Provide documentation about your module, how do the users use your module, where are things located, what do the icons mean, are there any secret shortcuts etc.

Include screenshots where necessary. You can add images to the `./images` folder and then link to them from your documentation:

![Hackathon Logo](docs/images/hackathon.png?raw=true "Hackathon Logo")

You can embed images of different formats too:

![Deal With It](docs/images/deal-with-it.gif?raw=true "Deal With It")

And you can embed external images too:

![Random](https://thiscatdoesnotexist.com/)

## Comments
If you'd like to make additional comments that is important for your module entry.
