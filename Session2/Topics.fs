module Topics
let list = [1;2;] @ [3]

let rec rFactorial x =
    match x with
    | 1 -> 1
    | _ -> x * rFactorial(x-1)

let testFac = rFactorial 5

let myTuple = (254177, "filip")
let my3Tuple = (254177, "Anatoli", "Lemon")
let printTupleFName = printf "my tuple: %s" (snd myTuple)
let printTuple3dVal tuple =
    match tuple with
    | (a,b,c) -> printfn "%s" c
printTupleFName
printTuple3dVal my3Tuple



module exercises =
    //Vector exercises
    let myVectorPoint1 = (5.0,1.0)
    let myVectorPoint2 = (1.0,5.0)

    let myVectorPoint3 = (6.0,7.0)
    let myVectorPoint4 = (8.0,9.0)

    let createVectorFromPoints (x1 : float,y1 : float) (x2 : float,y2 : float) = 
        (x1-x2),(y1-y2)
    
    let vadd (x1 : float,y1 : float) (x2 : float,y2 : float) =
        (x1+x2),(y1+y2)

    

    let testCalculateVector = createVectorFromPoints myVectorPoint1 myVectorPoint2
    let printTestCalculateVector = printfn "%A" testCalculateVector
