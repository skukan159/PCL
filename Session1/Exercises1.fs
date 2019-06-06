#light
module Exercises1
open System
//Exercise 1
let addToBeggining = 1 :: [2;5;3;7]
let listLength = List.length [2;5;3;7]
let ex1Result = [2;5;3;7] @ [4]

//Exercise 2.1

let x = 23
let myName = "Bobby"
let age = 25
let country = "Canada"
let y = 6+6

//2.2
let addNum1 x = x + 1
let addNum10 x = x + 10
let addNum20 x = addNum10 <| addNum10 x



//2.3
let max2 x y =
    if x > y then
        x
    else
        y


let isOdd x = (x % 2 = 1)
let evenOrOdd x =
    match isOdd x with
    | true -> "Value is odd"
    | false -> "Value is even"

let addXY x y =
    printfn "Adding %d and %d" x y
    x + y



let rec addNum_j j k =
    if k <= 0 then
       j
    else
       addNum10 <| addNum_j 0 k-1    
       
let testAddNum_j = addNum_j 1 2
        
    
    
let testadd20 = addNum20 10
let testAddXY = addXY 10 5