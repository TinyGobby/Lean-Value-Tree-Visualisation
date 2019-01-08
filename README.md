# Lean-Value-Tree-Visualisation

This is a tool to create a visualisation of a Lean Value Tree from a json file. It will display a hierarchical tree structure in which nodes represent points in the tree.
It uses Google Charts' [Organization Chart](https://developers.google.com/chart/interactive/docs/gallery/orgchart) to visualise the tree structure and Newtonsoft's [Json.NET Serializer](https://www.newtonsoft.com/json) to parse json files containing the LVT data.
Double-click on a node to collapse / expand.  Internet connection is required for the programme to be able to access Google Chart's Organization Chart.

Our Lean Value Tree creates trees using the following structure:

- one-or-more Goals, have
- zero-or-more Bets, that have
- zero-or-more Initiatives (Experiments), that have
- one-or-more Measures, and/or
- one-or-more Epics

|Name	| Attributes |	Description	| Example |
|-----|------------|--------------|---------|
|Goal	|Title: text | Overall objective/target	| Increase sales by 5% for existing products |
|Bet	|Title: text |A change we can make that we believe should contribute towards achieving the goal	| Train sales staff for upsell to +0.7% per customer |
|Initiative	|Title: text	|A measurable component to achieve the bet	| Sales training for large law team|
|Measure	|Description: text, Amount: Number, Units: Text, Deadline: Date	| A specific measurable amount that means the initiative is on-track	| 30% sales team trained by 1st sept |
|Epic	| Description: text, Deadline: Date	| A piece of work to be delivered by a deadline	| Contractors to be phased out of Large Law by 31st sept|


## Operating instructions
### Console App
The console app produces a .html file containing the LVT visualisation from data provided in a json file.
This is saved to C:\temp\LVT.html and can be viewed in your browser.

1) Clone the project from https://github.com/TinyGobby/Lean-Value-Tree-Visualisation. 
2) On the command line, navigate to the LVT folder within the project.
3) On the command line, type:
> dotnet run (path to json file, eg C:\temp\LVT.json)
4) Follow the instructions on the command line.

	
### WebApp
The WebApp allows you to select and open a .json file from your computer and display the data as a LVT in your browser.
Please note that you need to use **Google Chrome** for the programme to work.

1) Clone the project from https://github.com/TinyGobby/Lean-Value-Tree-Visualisation
2) On the command line, navigate to the LVT.web folder within the project.
3) On the command line, type:
> dotnet run
4) Open Google Chrome and go to
> https://localhost:5001
5) Follow the instructions on the screen.
6) To shut down the server, press:
> Ctrl+C

**NB for the programme to work the JSON file needs to follow a specific format and follow the structure outlined above!**

Please refer to these examples:

[SingleGoalLVT.json](LVT/SingleBranchLVT.json)

This builds a LeanValueTree that contains a single Goal with a single Bet, Initiative, Measure and Epic.

[TwoGoalsTwoBetsLVT.json](LVT/TwoGoalsTwoBetsLVT.json)

This builds a LeanValueTree that contains two Goals with two Bets, with a single Initiative, Measure and Epic each.

Following this format, you can adjust the number of Goals, Bets, Initiatives, Mesaures and Epics your LVT should display.
You cannot skip tiers - for example: if a Bet does not contain an Initiative, this branch cannot contain Measures or Epics. 

## Contributors

- Freya Becker 
- Patrick Harris
- Shweta Patil
- Victor Jefferies
