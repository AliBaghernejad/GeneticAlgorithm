
#I "packages/FSharp.Charting"
#I "packages/FSharp.Control.AsyncSeq.2.0.3/lib/net45"
#r "FSharp.Charting.dll" 
#r "system.Windows.Forms.DataVisualization.dll" 
#r "FSharp.Control.AsyncSeq.dll"

#load "EventEx-0.1.fsx"
#load "Types.fs"
#load "Crossover.fs" 
#load "Mutate.fs"
#load "ProblemDefinition.fs"
#load "GASettings.fs"
#load "Program.fs"

open System
open System.Windows.Forms
open System.Drawing
open FSharp.Control
open FSharp.Charting
open GenethicAlgorithm
open GenethicAlgorithm.ProblemDefinition
open GenethicAlgorithm.GASettings
open GenethicAlgorithm.Main

module ChartModule =
    let drawChart()= 
        System.Windows.Forms.Application.EnableVisualStyles()     
        Chart.Line(
            data= [ for i=0 to BestResultSet.Length-1 do yield i, BestResultSet.[i].Fitness],
            Name= "Simple Genetic Algorithm",            
            Title= "Binary GA",
            XTitle= "Iteration",
            YTitle= "Cost").ShowChart()
        System.Windows.Forms.Application.Run()

    drawChart()
    
    
