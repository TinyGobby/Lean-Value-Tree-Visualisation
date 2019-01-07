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

1) Clone the project from https://github.com/TinyGobby/Lean-Value-Tree-Visualisation. 
2) In the command line navigate to the LVT file within the project.
3) To build the tree with a json type:
    dotnet run (path to json file)
  
NB for this to work it is vital that the tree you are building is formatted in the order outlined above.

## Contributers

- Freya Becker 
- Patrick Harris
- Shweta Patil
- Victor Jefferies
