module ExamExercises

open Microsoft.FSharp.Core

//10%
module Question1 =
    //a) Declare a function stringListToCharList that takes a string as an argument and returns
    // the corresponding list of characters.
    // You must not use build in conversion features
    let stringToCharList s =
        [
            for i in s do
                yield i
        ]
        
    stringToCharList "Hello, World"

    // b) Declare a function displayList that takes a list as an argument and as a side effect, prints
    // the elements in the list one by one in a new row followed
    // by the position in the list as well as a colon and a space. Your solution should use recursion/
    // For example: displayList ["JavaScript"; "Java"; "Python"; "FSharp"];;
    // prints out the following:
    // 1: "JavaScript"
    // 2: "Java"
    // 3: "Python"
    // 4: "FSharp"
    // val it : unit = ()
    let rec displayList lst =
        match lst with
        | hd :: tl -> printfn "%s" hd
                      displayList tl
        | _ -> ()

    let testDisplayList = displayList ["JavaScript"; "Java"; "Python"; "FSharp"]

    // c) The F# list module contains a List.partition function: ('a -> bool) -> 'a list -> ('a list * 'a list).
    // It takes a predicate p and a list l as arguments
    // and returns a pair of lists, where the first list contains all elements in l for which the predicate p is true
    // and the other list contains elements in l for which p is false
    // Define your own declaration of List.partition function myPartition
    // For example:
    // myPartition (fun n -> n > 0) [2;-3;4;-5;6] = ([2,4,6], [-3,-5])


    //let myPartition p l 
        

    let pclPartition p l =
        let rec partitionHelper pred lst resultTuple =
            match lst with 
            | [] -> resultTuple
            | h::t -> if pred h then partitionHelper pred t (h::(fst resultTuple), snd resultTuple)
                      else partitionHelper pred t (fst resultTuple, h::(snd resultTuple))

        let rec myReverseList lst newLst =
           match lst with 
           |[]->newLst
           |h::t->myReverseList t (h::newLst)

        let reveresedList = myReverseList l []
        partitionHelper p reveresedList ([],[])




    let testPredicate x = x % 2 = 0
    let testList = [1;2;3;4;5;6;7;8;9]
    let testPartition = pclPartition testPredicate testList

module Question2 =
    // 2a) Declare a function replicate with the type int -> string -> string. 
    // The value of replicate n str is the string obtained by concatenating n copies of str.
    //  The function should raise an exception when the integer argument n is negative.
    // For example: replicate 3 "fun" gives "funfunfun" while replicate 0 "fly" gives "".
    let rec replicate (num:int) (str:string)  =
        if num < 0 then failwith("Number should not be smaller than 0")
        else
            match num with
                | 0 -> ""
                | _ -> str + replicate (num-1) str

    let testReciplicaticusMaximus = replicate 3 "fun"

    //b Declare a function incListBy1: lst:int list -> int list to increment list of integer
    // using List.map Eg.; incListBy1 [0;1;2;3;4];;
    // gives int list = [1;2;3;4;5].
    let incListBy1 lst =
        lst |> List.map(fun x -> x+1)
    incListBy1 [1;2;3]

    //c Tail recursive func using pattern matching returning the last element of a list. Do not use any build it higher order 
    // features and list comprehensions
    let rec lastElement lst acc =
        match lst with
        | [] -> acc
        | hd :: tl -> lastElement tl hd

module Question3 =
    // 3 a) Declare a record type to represent Meal with unique fields representing name of the meal, 
    // when served(for example breakfast,lunch,dinner) and form of serving(Hot,Cold). 
    type WhenServed =
        | Breakfast
        | Lunch
        | Dinner

    type FormOfServing =
        | Cold
        | Warm
    type Meal = { mealName:string; whenServed:WhenServed; formOfServing:FormOfServing}

    //3.b) Create 3 instances of the Meal record declared above
    let oatmeal = {mealName = "Oatmeal"; whenServed = Breakfast; formOfServing = Cold}
    let pizza =  {mealName = "Pizza"; whenServed = Dinner; formOfServing = Warm}
    let cake =  {mealName = "Cake"; whenServed = Lunch; formOfServing = Cold}

    // 3c) Print out the names of the 3 instances of Meal by accesing only the name field.
    printf "%s %s %s" oatmeal.mealName pizza.mealName cake.mealName

module Question4=
    //Given the following f# declaration:
    type Size = | L | M | S
    // a) Declare a function sizeToString: Size -> string, where the string representation of L is "Large",
    // the string reprentation of M is "Medium" and the string
    // representation of S is small
    let sizeToString (size:Size) =
        match size with
        | L -> "Large"
        | M ->  "Medium"
        | S -> "Small"

    //4b The following declaration can be used in shops to get the prices of flower pots given a size:
    //What is the result of this getFlowerPotPrice() above and why? Rewrite the function to fix the issue
    let getFlowerPotPrice size = 
        let price =
            if size = "small" || size = "Small" then 10.0f
            elif size = "medium" || size = "Medium" then 20.0f
            else failwith("Size not recognized")
        printfn "The price is %.2f" price

module Question5 =
    //Question 5a - Consider the following type of messages for the agent that represents the daily fluid intake
    type FluidQuantity =
        | Water of int
        | Milk of int
        | Tea of int
        | Coffee of int
        | Soda of int
    with
    // get the value as a string
        override qty.ToString() =
            match qty with
            | Water qty -> Printf.sprintf "%i cup(s)/glass(es) of Water" qty
            | Milk qty -> Printf.sprintf "%i can(s)/bottle(s) of Milk" qty
            | Tea qty -> Printf.sprintf "%i can(s)/bottle(s) of Tea" qty
            | Coffee qty -> Printf.sprintf "%i cup(s) of Coffee" qty
            | Soda qty -> Printf.sprintf "%i cup(s) of Soda" qty
    // Write an f# agent or actor, fluidIntakeAgent that waits for the above messages and responds with whether
    // the number of cups/glasses/bottles is too much or reasonable.
    // Decide for yourself how much is too much and how much is reasonable.
    // For example, posting "Coffee 10" message could result in "10 cup(s) of Coffee in a day is bit too much."


    // 5 b) Post 3 messages for the different FluidQuantity and iclude your test run results.







    


        
