module Modules

module InClass =
    let rec map f = function
        | [] -> []
        | h :: t -> f h :: map f t

    //List.map List.rev [[1;2;3] [4;5;6]]
    //map List.rev [[1;2;3] [4;5;6]]

    //increment list
    let incListWithMap list =
        list |> List.map (fun x -> x + 1)

    let incListWithMap2 list =
        List.map (fun x -> x + 1) list

    incListWithMap2 [1;2;3]

    let nums = [1;2;3]
    nums |> List.map (fun x -> -x)

    List.map ((+) "SEngr ") ["Tina";"David";"Filip"]

module HomeworkExercises =
    //Exercise 5.1
    //Write an f# function countNumOfVowels to count the
    //number of vowels in a given string. The type is:
    //countNumOfVowels : string -> int * int * int * int * int
    //Consider using List.fold.
    //Test with countNumOfVowels "Higher-order functions can take
    //and return functions of any order"
    let checkIfVowel letter =
        match letter with
        | 'a'| 'e' | 'i' | 'o' |'u' -> true
        | _ -> false

    
    let vowels     = ['a';'e';'i';'o';'u']
    let if_vowel c = vowels |> List.contains c

    let testif_vowel = if_vowel 'e'

    let countNumOfVowels sentence=
        let charList = List.ofSeq sentence
        List.fold (fun acc letter -> if checkIfVowel letter then acc+ 1 else acc ) 0 charList

    //Anatoli's working implementation
    let anatoliCountNumOfVowels word = 
        List.countBy (fun x -> checkIfVowel x) (Seq.toList word) 

    let testSentence = "Higher-order functions can take and return functions of any order"
    //let testAnatoliCountNumOfVowels = anatoliCountNumOfVowels testSentence
        
   //My implementation is not working
    let testCountNumOfVowels = countNumOfVowels testSentence
    
    

    //Exercise 5.2
    //Define a function primesUpTo n to create a list
    //of prime numbers up to a given number. For instance
    //primesUpTo 10 results in [2;3;5;7]

    let rec sieve = function
        | (p::xs) -> p :: sieve [ for x in xs do if x % p > 0 then yield x ]
        | []      -> []

    let primesUpTo n = sieve [2..n]

    let testPrimesTo = primesUpTo 10




    //Exercise 5.3
    //Consider the sequence of Fibonacci numbers defined
    //as follows:
    //  Fib(n) = 0 if n = 0
    //  Fib(n) = 1 if n=1
    //  Fib(n-1) + Fib(n-2) otherwise
    //By definition, Fibonacci numbers have the following
    //sequence, where each number is the sum of the previous
    //two: 0,1,1,2,3,5,8,13,21,.... Define a F# function
    //pclFib n that, when given a number, returns the nth
    //Fibonacci number
    let rec pclFib n =
        match n with
        | 0 -> 0
        | 1 -> 1
        | n -> pclFib (n-1) + pclFib (n-2)

    let testpclFib = pclFib 5

    
    //let fibonacci n = [|1..n|] |> Array.fold (fun (a,b) _ -> b, a + b) (0,1) |> fst
    //let testfibonacci = fibonacci 2

    //Exercise 5.4
    //a) Define two F# functions doubleNum x that multiplies
    //x by 2 and sqrNum x that multiplies x by itself
    let doubleNum x = x * 2
    let sqrNum x = x * x

    //b) Define another F# function pclQuad x that applies
    //the doubleNum function defined above twice
    let pclQuad x = doubleNum <| doubleNum x

    //c) Define another F# function pclFourth x that applies
    //the sqrNum function defined (in a.) above twice
    let pclFourth x = sqrNum <| sqrNum x