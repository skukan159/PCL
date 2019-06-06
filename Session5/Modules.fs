module Modules

let addTwoArgs x y = x+y


let addTwoArgsPC arg1 = 
    let subAdd arg2 = arg1 + arg2
    subAdd

//let add2 = addTwoArgsPC 10
//add2 5

let add23 = addTwoArgs 10
add23 5

let square x = x*x
let toString (x : int) = x.ToString()
let strLen (x : string) = x.Length

let lenOfSquare = square >> toString >> strLen
let testLenOfSquare = lenOfSquare 125
square 125

type PersonRecord = {First: string; Last: string; Age: int}
let filip = {First= "Filip"; Last="Skukan"; Age= 23}

printfn "%s is %d years old" filip.First filip.Age

module Exercises =
    //Exercise 6.1 - Data type declarations
    (*Represent two geometrical shapes as shown below and
    do something with it. You are going to represent 
    rectangles and right triangles. Note that
    two numbers can characterize two shapes. Use float type for it.*)

    //a) Define the data type declaration (PclShape) for Rectangle and RightTriangle
     //b) Create some values to represent both shapes
    type PclShape = | Rectangle of float * float 
                    | RightTriangle of float * float
   

    //c) Define a function pclArea : PclShape -> float that calculates the area of a shape
    let pclArea shape =
        match shape with
        | Rectangle(a,b) -> a * b 
        | RightTriangle(a,b) -> 0.5 * a * b 

    //d) Define a function pclPerimiter to calculate the perimiter of a rectangle
    let pclPerimiter rectangle =
        match rectangle with
        | Rectangle(a,b) -> 2.0*(a+b)
        | _ -> failwith("Not a rectangle")
    //e) Redefine the PclShape to use records instead of tuples(PclShapeR).
    type possibleShapes = | Rectangle | RightTriangle
    type PclShapeR = {Shape:possibleShapes; x:float; y: float; }

    //Exercise 6.2 - Higher-order functions
    //Define a function pclCollect ls that collects consecutive duplicates of list
    //elements (ls) into sublists.
    //Example:
    //pclCollect ['p';'p';'s';'c';'a';'l';'a';'p';'c';'l';'y']
    //returns [['p';'p'];['s'];['c'];['a'];['l']...... ['y']]
    let compare listOfList item = 
        if List.exists ( (=) item) listOfList then true
        else false

    let rec oldpclCollect list =
        let f item acc =
            match acc with
            | [] -> 
                    [[item]]
            | h :: t when compare h item
                ->  printfn "Adding item..."
                    ( item :: h ) :: acc 
               | _ -> [item] :: acc
        List.foldBack f list []

        //let rec check



        //let rec last = function
          //  | hd :: [] -> hd
            //| hd :: tl -> last tl
            //| _ -> failwith "Empty list."
                
       (* let f item acc =
            printfn "%A" item
            match acc with
            | [] -> [[item]]
            | hd :: tl when hd <> item
                -> [item] :: [acc]
            | _ -> [acc]*)
      //  List.foldBack f list []

    let rec pclCollect list acc =
        match list with
        | [] -> acc
        | lh :: lt -> match acc with
            | [] -> pclCollect lt [[lh]]
            | ah :: at -> if compare ah lh = true then pclCollect lt ((lh :: ah) :: acc) else pclCollect lt ([lh] :: ah :: acc)



    let toList ls = [ for item in ls do yield! [[item]]] 

    (*let pclCollectUnited list  =
        //let listOfList = toList list
        let rec myfunc newList =
            match newList with
            | [] -> failwith "Uh....."
            | h :: t -> match t with
                | headOfTail :: tailOfTail -> if compare h headOfTail

        
    
    let testpclCollect = pclCollect ['p';'p';'s';'c';'a';'l';'l';'a';'p';'c';'l';'y';'y';'y';'y'] []

    *)