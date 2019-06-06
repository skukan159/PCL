module Module

//Question 1 7%
//1a
let sqrOnlyFirst ls =
    match ls with
        | hd :: _ -> hd * hd
        | _ -> failwith("Incorrect value")

//let rec stringToList (str:string) =
    //let myList = []
    //let sb:StringBuilder
    
    //myList = Seq.iter(fun (x:char) -> myList @ [x]) str
    //match str with
    //| h :: t ->  myList @ h @ stringToList t
//1b
let stringToList s =
    [
        for i in s do
            yield i
    ]

stringToList "Hello, World"


//Question 2 15%
//2a
type Vector =
    | Two of float * float
    | Three of float * float * float
    | Four of float * float * float * float
    | Five of float * float * float * float * float
//2b
let vecLen (vect:Vector) =
    match vect with
    | Two (a,b) -> sqrt( a**2.0 + b **2.0)
    | Three (a,b,c) -> sqrt(a**2.0 + b **2.0 + c **2.0)
    | Four (a,b,c,d) -> sqrt(a**2.0 + b **2.0 + c **2.0 + d **2.0)
    | Five (a,b,c,d,e) -> sqrt(a**2.0 + b **2.0 + c **2.0 + d **2.0 + e **2.0)
    | _ -> failwith("Value not recognized")
//2c
let vectAdd (vect1:Vector) (vect2:Vector) =
    match vect1 with
    | Two (a,b) -> match vect2 with
                    | Two (a2,b2)-> Two(a+a2,b+b2)
                    | _ -> failwith("Vector size mismatch")
    | Three (a,b,c) -> match vect2 with
                    | Three (a2,b2,c2)-> Three (a+a2,b+b2,c+c2)
                    | _ -> failwith("Vector size mismatch")
    | Four (a,b,c,d) -> match vect2 with
                    | Four (a2,b2,c2,d2)-> Four (a+a2,b+b2,c+c2,d+d2)
                    | _ -> failwith("Vector size mismatch")
    | Five (a,b,c,d,e) -> match vect2 with
                    | Five (a2,b2,c2,d2,e2)-> Five (a+a2,b+b2,c+c2,d+d2,e+e2)
                    | _ -> failwith("Vector size mismatch")
    | _ -> failwith("Unfamiliar vector size")

//let vector1 = Two(10.0,10.0)

//Question 3 8%

//3a
let rec rerun (s:string) (n:int) =
    if n < 0 then failwith("Negative number")
    else
        match n with
        | 0 -> ""
        | _ -> s + rerun s (n-1)

//3b
//Needs to do it in a way that prevents stack overflow to be considered tail recursive
let rec rerunTailRec (s:string) (n:int) (acc:string) =
    if n < 0 then failwith("Negative number")
    else
        match n with
        | 0 -> acc
        | _ -> rerunTailRec s (n-1) (acc + s)

            
//Question 4 7%

let f1 i j k =
    seq {
        for x in [0 .. i] do
            for y in [0 .. j] do
                if x+y < k then yield (x,y)
    }

let f2 f p sq =
    seq {
        for x in sq do
            if p x then yield f x
    }

let f3 g sq =
    seq {
        for s in sq do
            yield! g s
    }

//4a - What is the value of List.ofSeq(f1 2 2 3)
//List.ofSeq(f1 2 2 3);;
//val it : (int * int) list = [(0, 0); (0, 1); (0, 2); (1, 0); (1, 1); (2, 0)]
//It returned a list of tuples that, when added are smaller than the last value(number 3)

//4b - Write an alternative declaration of f2 using functions from the Seq library of F#
let alternativef2 f p sq =
    sq |> List.filter(fun x -> p x) |> List.map(fun x -> f x)

let isEven x = x%2 = 0
let multiplyBy2 x = x * 2

//Question 5 15%
type expr = 
    | Const of int
    | BinOpr of expr * string * expr

//5a - Write three different values of type expr
let expr1 = Const(1)
let expr2 = Const(2)
let expr3 = Const(3)
let expr4 = BinOpr(expr2,"*",expr3)
let exprx = BinOpr(expr1,"+",expr4)
let expr5 = BinOpr(expr1, "+", expr2)
let expr6 = BinOpr(expr3, "*", expr3)
let expr7 = BinOpr(expr4, "*", expr4)

//5b Declare a functionTostring: expr -> string that gives a string representation for an
//expression. Put the brackets around every subexpression with operators. For example
//(1+ (2*3)) is a string represantation of the example given above

let rec toString (expression:expr) =
    match expression with
    | Const (x) -> string x
    | BinOpr (exp1, operator, exp2) ->  string "(" + toString exp1 + string operator + toString exp2 + string ")"
    | _ -> failwith("Unknown expression")


//5c - declare a function to extract the set of operators from an expression
let rec extractOperator (expression:expr) =
    match expression with
    | Const (x) -> []
    | BinOpr (exp1, operator, exp2) -> [] @ [operator] @ extractOperator exp1 @ extractOperator exp2  //operator :: acc 


    


    


