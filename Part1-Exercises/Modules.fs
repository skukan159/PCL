module Modules

module Exercises01 =
    let exercise1 = 1 :: [2; 5; 3; 7]
    let exercise2 = List.length [2;5;3;7]
    let exercise3 = [2;5;3;7] @ [4]

module Exercises02 =
    //Exercise 2.2 - Function Declaration
    let addNum1 x = 1 + x
    let addNum10 x = 10 + x
    let addNum20 x = addNum10(addNum10 x)

    //Exercise 2.3
    let max2 x y = if x > y then x else y
    let evenOrOdd x =
        match x % 2 with
        | 0 -> printf("It's an even number. ")
        | _ -> printf("It's an odd number. ")
    let addXY x y = x + y
    //Exercise 2.4
    let rec addNum_jk j k= 
        match k with
        | 0 -> j
        | _ -> j + addNum_jk (addNum10 0) (k-1)


module Exercises03 =
    //Exercise 3.1
    let patternMatchVowel vowel:char =
        match vowel with
        | 'a'|'A' -> 'A' 
        | 'e'|'E' -> 'E'
        | 'i'|'I' -> 'I'
        | 'o'|'O' -> 'O'
        | 'u'|'U' -> 'U'
        | _ -> vowel

    let vowelToUpper c:string =
        let vowels = ['a';'e';'i';'o';'u']
        let newString = ""


        let rec turnStringToUpper (comparedString:string) (returnedString:string) (acc:int) =
            if acc = comparedString.Length then returnedString
            else 
                let temp = returnedString + patternMatchVowel(comparedString.[acc]).ToString() 
                turnStringToUpper comparedString temp (acc + 1)

        let returnedVal = turnStringToUpper c newString 0
        returnedVal
     
    //Exercise 3.2 - Some List Functions
    //a
    let rec pmLength ls =
        match ls with
        | [] -> 0
        | h :: t -> 1 + pmLength t 

    let rec pclSum ls =
        match ls with
        | [] -> 0
        | h :: t -> h + pclSum t

    //Exercise 3.3 - Lists
    let rec takeSome n ls = 
        match ls with
        | [] -> []
        | h :: t -> 
            match n with
            | 0 -> []
            | _ -> [h] @ takeSome (n-1) t

module Exercise04 =
    //Exercise 4.1 - List functions
    let rec pclFold operation ls acc:int =
        match ls with
        | [] -> acc
        | h :: t -> pclFold operation t (operation acc h)

    let pclSumWithFold list = pclFold (+) list 0

    //Exercise 4.2 - List Function
    let rec pclFoldBack operation ls acc=
       match ls with
        | [] -> 0
        | h :: t -> operation h (pclFoldBack operation t 0)

    // 4.3
    let rec pclIncList list =
        match list with
        | [] -> []
        | h :: t -> 1 + h :: pclIncList t

    //4.4
    let rec pclMap operation list =
        match list with
        | [] -> []
        | h :: t -> operation h :: pclMap operation t
    let incVal x = x+1

    let pclIncListWithMap list = pclMap incVal list

    //4.5
    let rec pclFilter list condition =
        match list with
        | [] -> []
        | h :: t -> if condition h then h :: pclFilter t condition else  pclFilter t condition 

    let pclEven number = if number % 2 = 0 then true else false

module Exercises05 =
    //Exercise 5.1
    let checkIfVowel letter =
        match letter with
        | 'a'| 'e' | 'i' | 'o' |'u' -> true
        | _ -> false
    
    let countNumOfVowels sentence=
          let charList = List.ofSeq sentence
          List.fold (fun acc letter -> if checkIfVowel letter then acc+ 1 else acc ) 0 charList

    //Exercise 5.2
    //let primesUpTo n =


    //Exercise 5.3
    let rec pclFib n =
        match n with
        | 0 -> 0
        | 1 -> 1
        | _ -> pclFib(n-1) + pclFib(n-2)

    let doubleNum x = x * 2
    let squareNum x = x * x
    let pclQuad x = doubleNum(doubleNum x)
    let pclFourth x = squareNum(squareNum x)

module Exercises06 =

    type pclShape = 
        | Rectangle of float * float
        | RightTriangle of float * float


    let pclArea shape =
        match shape with
        | Rectangle(a,b) -> a * b
        | RightTriangle(a,b) -> a * b * 0.5
        | _ -> failwith("Unfamiliar shape")

    let pclPerimiter shape =
        match shape with
        | Rectangle(a,b) -> a+b
        | _ -> failwith("I only like rectangles")



module Exercises07 =
    type shapes = | Rectangle | RightTriangle
    type pclShapeR = { Shape:shapes; x:float; y:float; }

    let pclAreaR shape = 
        match shape.Shape with
        | Rectangle -> shape.x * shape.y
        | RightTriangle -> shape.x * shape.y * 0.5
        | _ -> failwith("This shape sucks")

    let testShape = {Shape = shapes.Rectangle; x = 10.0; y =10.0;}


    let isLeap (y : int) =
        if (y % 400 = 0 || (y % 4 = 0  &&  y % 100 <> 0)) then true
        else false
    
    
    let rec daysToEndYear (y : int) acc =
            match y with
            |1 -> acc
            |_ -> if (isLeap y) then daysToEndYear (y-1) acc+366
                  else daysToEndYear (y-1) acc+365  
    

    
    let rec daysToEndMonth (m:int, y: int) acc =
            match y with
            |1 -> acc
            |_ -> if m = 1 then daysToEndMonth (m, y-1)(367*m+5)/12 - 0
                  else if (isLeap y  && m>1) then daysToEndMonth (m, y-1)(367*m+5)/12 - 1
                  else daysToEndMonth (m, y-1)(367*m+5)/12 - 2

    daysToEndYear 1792 365
    daysToEndMonth (9, 1792) 0
    
module Exercises08 =
    type IntegerTree = 
        | Node of int * IntegerTree * IntegerTree 
        | Empty

    let rec sumIntegerTree tree =
        match tree with
        | Node (data,left,right) -> (sumIntegerTree left) + (sumIntegerTree right) + (data)
        | Empty -> 0

    let testIntegerTree = 
                    Node(2,
                        Node(1,Empty,Empty),
                        Node(4,
                          Node(3,Empty,Empty),
                          Node(5,Empty,Empty)
                            )
                        )
                            
               




   
   


