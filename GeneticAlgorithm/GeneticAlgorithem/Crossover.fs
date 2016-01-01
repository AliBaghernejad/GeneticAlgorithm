namespace GenethicAlgorithm.Operators
open GenethicAlgorithm.Types

module Crossover=
    let SinglePointCrossover (p1:Chromosome) (p2:Chromosome) = 
        let pLength = Array.length p1
        let index = rnd.Next(pLength-1)
        let child1 = Array.append p1.[..index] p2.[index+1..]
        let child2 = Array.append p2.[..index] p1.[index+1..]
        (child1, child2)


