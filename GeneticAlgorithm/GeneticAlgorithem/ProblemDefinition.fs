namespace GenethicAlgorithm

module ProblemDefinition = 
    let bitSum (x: int[]) =                        // Cost function for problem
        Array.sum x

    let VarLength = 80                             // Length of Variables in problem
    let lb, ub = 0, 1                              // Lower bound and upper bound value for variables (Binary)