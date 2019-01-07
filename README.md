# Lean-Value-Tree-Visualisation

This is a tool to create a visualisation of a Lean Value Tree from a json file. It will display a hierarchical tree structure in which nodes represent points in the tree. Our Lean Value Tree creates trees using the following structure:


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
This is saved to C:\temp\LVT.html.

1) Clone the project from https://github.com/TinyGobby/Lean-Value-Tree-Visualisation. 
2) On the command line, navigate to the LVT folder within the project.
3) On the command line, type:
> dotnet run (path to json file, eg C:\temp\LVT.json)
4) Follow the instructions on the command line.

	
### WebApp
The WebApp allows you to select and open a .json file from your computer and display the data as a LVT in your browser.
Please note that you need to use _Google Chrome_ for the programme to work.

1) Clone the project from https://github.com/TinyGobby/Lean-Value-Tree-Visualisation
2) On the command line, navigate to the LVT.web folder within the project.
3) On the command line, type:
> dotnet run
4) Open Google Chrome and go to
> https://localhost:5001
5) Follow the instructions on the screen.
6) To shut down the server, press:
> Ctrl+C

*NB for the programme to work the JSON file needs to follow a specific structure.*
Please consult these examples:
[SingleGoalLVT.json](LVT/SingleBranchLVT.json)
[TwoGoalsTwoBetsLVT.json](LVT/TwoGoalsTwoBetsLVT.json)

## Contributers

- Freya Becker 
- Patrick Harris
- Shweta Patil
- Victor Jefferies
