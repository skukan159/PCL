open Modules
open System
open WebScraperModule

[<EntryPoint>]
let main argv = 
    printfn "Testing describe string:"
    describeString "3.141"
    printfn "Testing parse time:"
    let testParseTime = (parseTime "1996-3-15").ToString()
    printfn "%s" testParseTime
    f "this is lOWERCASE"

    testWebScraper.SaveImagesToDisk imagesPath
    Console.ReadLine()
    0 // return an integer exit code
