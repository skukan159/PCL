open Modules

// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
open Exercises
open System

[<EntryPoint>]
let main argv = 
    let testpclCollect = pclCollect ['p';'p';'s';'c';'a';'l';'a';'p';'c';'l';'y']
    printfn "%A" testpclCollect
    Console.ReadLine()
    0 // return an integer exit code
