// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

open System

(*
This is a multi
line comment
*)
/// The simplest value ever
let nameday = "A string value"



[<EntryPoint>]
let main argv = 
    printfn "%A" argv
    let myarr = [|1;2;3;|]
    let mylist = [1;2;3;]

    let simple x y z =  x*(y+z)
    let result = simple 1 2 3
    printfn "Result is %d" result


    printfn "My array: %A" myarr
    printfn "My list: %A" mylist
    printfn "My string: %s" nameday


    let square x = x * x
    let root x = x / x
    let value = 5
    let sqareresult = square value

    printfn "Result of sqaring %d is %d" value sqareresult

    (*
    trying to implement piping functions
    let sqareAndThenRootResult x = square x |> root 
    printfn sqareAndThenRootResult value
    *)

    (* Recursive function *)
    let rec rFactorial x =
        if x <= 1 then
            1
        else
            x * rFactorial(x - 1)

    let factorialOfVal = rFactorial 5
    printfn "Result of factorial calculation: %d"factorialOfVal

    let mutable mutableVal = 5
    mutableVal <- 3
    printfn "Testing mutable value %d" mutableVal

    let tupleExample = (2, "Hello World", [|1;2;3;|])
    printfn "My tuple: %A" tupleExample

    let swapPoint (a,b) = (b,a)
    printfn "Swap tuple function example: %A" (swapPoint (5,3))

    //Lists
    let emptyList = []
    let listOdd = [1;3;5;7;9;]
    printfn "My odd list: %A" listOdd

    let newList = 0 :: listOdd
    printfn "My new list: %A" newList

    
    let changedEmptyList = 'a' :: 'b' :: 'c' :: emptyList
    printfn "%A" changedEmptyList

    let stringList = ["Mon";"Tue"; "Wed";]
    printfn "%A" stringList

    let numbers = [1 .. 10]

    for i in numbers do
        printfn "%d" (i*i)

    let squareList list = [for i in list -> i*i]
    let squareTo10 = squareList [1..10]



      
    
    0 // return an integer exit code
