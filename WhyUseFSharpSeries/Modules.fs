module Modules

open System


// some "record" types
type Person = {FirstName:string; LastName:string; Dob:DateTime}
type Coord = {Lat:float; Long:float}

// some "union" (choice) types
type TimePeriod = Hour | Day | Week | Year
type Temperature = C of int | F of int
type Appointment = OneTime of DateTime 
                   | Recurring of DateTime list

module extractingBoilerplate =
    let product n = 
        let initialValue = 1
        let action productSoFar x = productSoFar * x
        [1..n] |> List.fold action initialValue

    //test
    let testProduct = product 10

    let sumOfOdds n =
        let initialValue = 0
        let action sumSoFar x = if x%2=0 then sumSoFar else sumSoFar + x
        [1..n] |> List.fold action initialValue
    
    //test 
    let testSumOfOdds = sumOfOdds 10

    let alternatingSum n =
        let initialValue = (true,0)
        let action (isNeg,sumSoFar) x = if isNeg then (false,sumSoFar-x)
                                                 else (true,sumSoFar+x)
        [1..n] |> List.fold action initialValue |> snd

    //test
    let testAlternatingSum = alternatingSum 100