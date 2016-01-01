namespace GenethicAlgorithm

module GASettings =
    let populationSize = 50                                         // Population size
    let maxIteration = 100;                                         // End condition
    let pm = 0.3                                                    // Probability of mutation
    let nm = int <| round(pm*(float) populationSize)                // Number of mutations
    let pc= 0.8                                                     // Probability of crossover
    let nc = 2 * int (round(pc * (float populationSize) / 2.0 ));   // Number of crossovers
