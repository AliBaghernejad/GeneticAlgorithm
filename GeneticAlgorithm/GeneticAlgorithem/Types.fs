namespace GenethicAlgorithm

// Type sDefinition
module Types=

    let rnd = System.Random()
    type Chromosome = int[]
    type Individual = 
        {
            Chromosome : Chromosome
            Fitness : int
        }
