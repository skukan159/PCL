module Modules

module someShit =

    let returnFirstVal tuple =
        match tuple with
        | (a,b) ->  a
    let returnSecondVal tuple =
        match tuple with
        | (a,b) -> b

    let testTuple = (1,"Hello")
    returnFirstVal testTuple
    returnSecondVal testTuple

    let mylist = [1;2;3]
    mylist @ [5]

module listComprehensions =

    let numbersNear x =
        [
            yield x - 1
            yield x
            yield x + 1
        ]
    let testNumbersNear = numbersNear 10

    let x = [ 
        let negate x = -x
        for i in 1 .. 10 do
            if i % 2 = 0 then
                yield negate i
            else
                yield i ]

    [for a in 1 .. 5 do
    match a with
        | 3 -> yield! ["p";"c";"i"]
        | _ -> yield a.ToString()
    ]

module ErrorHandling = 
    open System
 
    let rec rFactorial x =
        match x with
        | 0 -> 1
        | _ -> if x > 0 then
                x * rFactorial(x-1)
               else failwith "A non natural number"
            

    let testFac = rFactorial 5

    let vowel x =
        match x with
        | 'a' -> 'A'
        | 'e' -> 'E'
        | 'i' -> 'I'
        | 'o' -> 'O'
        | 'u' -> 'U'
        | _ -> x

    let testVowel = vowel 'e'




module homework = 
    //3.1 a - Define a function vowelToUpper that converts
    //characters a,e,i,o,u to uppercase. all other characters
    //should return unchanged. you can use substring()
    let vowelToUpper v =
        match v with
        | 'a' -> 'A'
        | 'e' -> 'E'
        | 'i' -> 'I'
        | 'o' -> 'O'
        | 'u' -> 'U'
        | _ -> v

    //b - define another function to convert all occurencies
    // of a,e,i,o,u in a string to capitals. write a function
    //to use recursion and the vowelToUpper in 3.1a above
   
    let rec recUpVowelStr str =
        match str with
        | "" -> ""
        | str -> (vowelToUpper str.[0]).ToString() + recUpVowelStr str.[1 ..]

    let testRecUpVowelStr = recUpVowelStr "Hello World!"
         


    //3.2 - Some list functions
    //a - Define a function pmLength that computes the length
    //of a list. Use pattern matching.
    let rec pmLength list  =
        match list with
        | [] -> 0
        | h :: t -> 1 +  pmLength t
    pmLength [1;2;3;4;1;2;3]

    //b - Define a function pclSum that sums all the numbers
    //in a list. 
    let rec pclSum list accumulator =
        match list with
        | [] -> accumulator
        | h :: t -> accumulator + pclSum t h 

    let testpclSum = pclSum [1;2;3] 0

    let rec pclSum2 list =
        match list with
        | [] -> 0
        | h :: t -> h + pclSum2 t
    let testList2 = [1;2;3]
    let testpclSum2 = pclSum2 testList2

    //3.3 Define a function takeSome n ls that returns list
    //of first n elements from the list ls. Define the function
    //using pattern matching
    let rec takeSome n ls =
        match ls with
        | [] -> []
        | h :: t -> match n with
                    | 0 -> []
                    | _ -> h :: takeSome (n-1) t

    let testTakeSome = takeSome 3 [1;2;3;4;5]


module codingWithAluna =
    let testListFold =
        let myAccumulator = 0
        let mylist = [5;10;15;]
        let testFunction acc i =
            printfn "adding %d and %d" acc i
            acc + i
        
        let testFold = List.fold testFunction myAccumulator mylist 
        testFold

    let rec myOwnListFold myFunction myAccumulator list =
        match list with
        | [] -> myAccumulator
        | h :: t -> myAccumulator =  myFunction myAccumulator h


    //Exercise 4.3 List Function
    //List that adds one to each element in a list of integers.
    //You are allowed to use the standard F# functions
    //Use recursion and pattern matching
    // pclIntList 2;3;1;4 should return 3;4;2;5
    let rec pclIncList list =
        match list with
        | [] -> []
        | h :: t -> h + 1 :: pclIncList t
        
    let myList = [1;2;3]
    let testRec = pclIncList  myList 


    let betterIncList list =
        [for x in list -> x+1]

    let testRec2 = betterIncList myList

    //Exercise 4.4 a) pclMap that applies an arbitrary
    // function f to the elements in a list
    let arbitraryFunc x =
        printfn "Incrementing %d" x
        x+1

    let pclMapGood list f =
        [for x in list -> f x]

    let rec pclMapShitty list f =
        match list with
        | [] -> []
        | h :: t -> f h :: pclMapShitty t f

    pclMapShitty [1;2;3] arbitraryFunc

    //b) Define a function plcListWithMap that changes the pclIncList
    //You defined previously in 4.3 to use pclMap defined above
    


    //4.5 Define a function pclFilter that removes all elements
    //From a list that do not satisfy a given predicate
    let rec pclFilter list condition =
        match list with
        |[] -> []
        | h :: t -> if condition h then h :: pclFilter t condition
                    else pclFilter t condition

    let isEven x = x % 2 = 0

    let myTestList = [0;1;2;3;4;5;6;7;8;9]
    let testPclFilter = pclFilter myTestList isEven
    let printMyList list = 
        list |> List.iter (printfn "Value %d")
    printMyList testPclFilter


                        
                  