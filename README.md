# Dashboard
A Dashboard webapp using C#, Blazor, and chart.js.

<img src="https://github.com/zalexan1996/Dashboard/blob/main/Dashboard/Screenshots/KB4%20Page%20-%202022-05-09.png?raw=true"></img>

This application will have support for creating graphs for the following services:
- Knowbe4
- On-Prem Active Directory
- Microsoft 365 products
- Sophos Cloud
- Veeam


# DashboardAPI Component
The DashboardAPI is a RestAPI server responsible for fetching the data that the dashboard looks at.
Each data-point (List of unlicensed Exchange users, list of active phishing campaigns, etc) has its own refresh interval.
There's no need to fetch every data-point once a minute, that'd exhaust your API usage way too fast and generate too much redundant traffic.

# Dashboard Component
The Dashboard is a web application that sends GET requests to the DashboardAPI. There are a series of chart/table objects for presenting the data
received from the DashboardAPI. When this request is made, no calls to outside services are made (M365, KB4, etc.) as it's getting the latest data that the DashboardAPI
has stored.

# Todo
- M365, Veeam, and Sophos pages (possibly using PowerShell modules)
- Rethink AuthenticationMethod to better abstract how DashboardAPI authenticates with other APIs
- Update Table component to have multiple pages that you can either manually cycle through, or auto-cycle
- Give the user the ability to filter tables and add/remove columns
- Store the above two settings as preferences in the browser cache
- Require ActiveDirectory authentication before you can view the dashboard
- Color themes
- Modal for settings
- MORE GRAPHS
- Rethink how the Column attribute works, possibly get rid of it because it's kind of stupid
