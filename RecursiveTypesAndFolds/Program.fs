// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
open Part1RecursiveTypesAndCatamorphisms
open basicRecursiveType
open System

[<EntryPoint>]
let main argv = 
    let testBDPresent = birthdayPresent |> description  
    printfn "%A" testBDPresent
    // "'Wolf Hall' wrapped in HappyBirthday paper with a card saying 'Happy Birthday'"

    let testChirstmasPresent = christmasPresent |> description  
    printfn "%A" testChirstmasPresent
    // "SeventyPercent chocolate in a box wrapped in HappyHolidays paper"

    Console.ReadLine()
    printfn "%A" argv
    0 // return an integer exit code
