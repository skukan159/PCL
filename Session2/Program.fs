open System
open System.Numerics

// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

[<EntryPoint>]
let main argv = 
    printfn "%A" argv

    //let testvadd = (1.0,1.0) (2.0,2.0)
    //testvadd

    let myList = [1;2;3]
    let listHead = myList.Head
    let listTail = myList.Tail
    //sum the list elements
   // let sumList list =
     //   list match wth
       // |
 //   let printRange list =
 //       let rng = new Random()
 //       let number = rng.Next() % List.length list

    Console.ReadLine();
    0 // return an integer exit code
