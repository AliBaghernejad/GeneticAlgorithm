// Simple Binary Genetic Algorithm
// By Ali Baghernejad

module GenethicAlgorithm.Main

open System
open GenethicAlgorithm
open GenethicAlgorithm.Types
open GenethicAlgorithm.Operators
open GenethicAlgorithm.ProblemDefinition

// Cost function apply problem defined function to given argument.
let costFunc x = bitSum x

// ----------Initialization----------

let makeIndividual () = 
    let newChromosome = Array.init VarLength (fun _ -> rnd.Next(lb,ub+1)) //(0,1)
    let newFitness = costFunc newChromosome
    {Chromosome=newChromosome; Fitness=newFitness}

// Initialize population and sort result set
let mutable population = Array.init GASettings.populationSize (fun x -> 
    makeIndividual ()) 
Array.sortInPlaceBy (fun i -> i.Fitness) population

let BestResultSet = Array.zeroCreate<Individual> GASettings.maxIteration

// ----------Main processing loop-----------

for i=0 to GASettings.maxIteration-1 do
    
    // Crossover
    let crossoverSet = [|  
        for k=0 to (GASettings.nc/2)-1 do   
            // Select two random parent
            let idx1 = rnd.Next(GASettings.populationSize)
            let idx2 = rnd.Next(GASettings.populationSize)
            let parent1 = population.[idx1]
            let parent2 = population.[idx2]

            // Apply singlepoint crossover 
            let newChilds = Crossover.SinglePointCrossover parent1.Chromosome parent2.Chromosome

            // Add new childs to crossover set
            yield {Chromosome=fst newChilds; Fitness= costFunc <| fst newChilds }
            yield {Chromosome=snd newChilds; Fitness= costFunc <| snd newChilds }
        
         |]

    // Mutation
    let mutationSet = [|  
        for k=0 to GASettings.nm-1 do     
            // Select one random parent
            let idx = rnd.Next(GASettings.populationSize)
            let parent = population.[idx]

            // Apply mutation operator 
            let newChromosome = Mutation.Mutate parent.Chromosome 

            // Add new childs to mutation set
            yield {Chromosome=newChromosome; Fitness= costFunc newChromosome }
         |]
    
    // Merge result sets
    population <- Array.append population (Array.append crossoverSet mutationSet)

    // Sort result set
    Array.sortInPlaceBy (fun i -> i.Fitness) population

    // Truncate 
    population <- population.[..GASettings.populationSize]

    let bestResult = population.[0]
    BestResultSet.[i] <- bestResult
    
    // Display iteration information
    printfn "Iteration %d -> Best Fitness=%d " i bestResult.Fitness







