module Modules

let rec sumList lst = 
    match lst with
    | [] -> 0
    | hd :: tl -> hd + sumList tl

let sumListTR ls =
    let rec sumListHelper (ls, total) =
        match ls with
        | [] -> total
        | hd :: tl ->   
            let ntotal = hd + total
            sumListHelper(tl,ntotal)
    sumListHelper(ls,0)

let result = sumListTR [1 .. 10]

let someHolidays2019 =
    [
        ("Maundy Thursday", "April 18");
        ("Good Friday", "April 19");
        ("Easter Monday", "April 27");
        ("Penticost", "June 10");
    ]
    |> Map.ofList

someHolidays2019.["Good Friday"]

module Homework =
    //Redefine pclArea to use pclShapeR
    type possibleShapes = | Rectangle | RightTriangle
    type PclShapeR = {Shape:possibleShapes; x:float; y: float; }

    //c) Define a function pclArea : PclShape -> float that calculates the area of a shape
    let pclAreaR shape =
        match shape.Shape with
        | Rectangle -> shape.x * shape.y 
        | RightTriangle -> 0.5 * shape.x * shape.y
    //d) Define a function pclPerimiter to calculate the perimiter of a rectangle
    let pclPerimiterR rectangle =
        match rectangle.Shape with
        | Rectangle -> 2.0*(rectangle.x+rectangle.y)
        | _ -> failwith("Not a rectangle")

    let testPclShape = {Shape = possibleShapes.Rectangle; x = 10.0; y = 10.0}
    let testpclArea = pclAreaR testPclShape

