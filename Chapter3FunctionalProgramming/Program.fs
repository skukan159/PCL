// Learn more about F# at http://fsharp.org
open System
open System.IO
open System.IO
open System.IO
open Modules
open pipedFunctions
open functionComposition


[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"
    //Pipe forward operator


 
    
    let path = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)

    let resultPiped = sizeOfFolderPiped2(path)
    let resultComposed = sizeOfFolderComposed (path)

    printfn "Piped result: %d bytes" resultPiped
    printfn "Composed result: %d bytes" resultComposed

    printfn "Result of test square: %d, Result of test length of square: %d" testSquare testLenOfSquare

    Console.ReadLine();
    
    0 // return an integer exit code
