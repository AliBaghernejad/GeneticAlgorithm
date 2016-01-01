namespace GenethicAlgorithm.Operators
open GenethicAlgorithm.Types

module Mutation = 

    let Mutate (c:Chromosome) =
        // Get chromosome length
        let cLength = Array.length c

        // Select random index
        let index = rnd.Next(cLength-1)

        // Apply mutation
        let newChromosome = c
        newChromosome.[index] <- 1 - c.[index]

        // Return new chromosome
        newChromosome
        



