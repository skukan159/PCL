module Modules

open System
open System.IO
open System.IO
open System.IO


module pipedFunctions =
    
    [1 .. 3] |> List.iter (printfn "%d")

    let sizeOfFolderPiped folder =

        let getFiles path =
            Directory.GetFiles(path, "*.*", SearchOption.AllDirectories)

        let totalSize =
            folder
            |> getFiles
            |> Array.map (fun file -> new FileInfo(file))
            |> Array.map (fun info -> info.Length)
            |> Array.sum

        totalSize

    let sizeOfFolderPiped2 folder = 

        let getFiles folder =
            Directory.GetFiles(folder, "*.*", SearchOption.AllDirectories)

        folder
        |> getFiles
        |> Array.map(fun file -> new FileInfo(file))
        |> Array.map(fun info -> info.Length)
        |> Array.sum

module functionComposition = 
    
    //Another function composition example
    //Basic function Composition
    let square x = x * x
    let toString (x : int) = x.ToString()
    let strLen (x: string) = x.Length
    let lenOfSquare = square >> toString >> strLen
    let testSquare = square 128
    let testLenOfSquare = lenOfSquare 128
    
    //Function composition
    let sizeOfFolderComposed (*No parameters!*) =

        let getFiles folder =
            Directory.GetFiles(folder, "*.*",SearchOption.AllDirectories)

        //The result of this expression is a function that takes
        //one parameter, which will be passed to getFiles and piped
        //through the following functions
        getFiles
        >> Array.map(fun file -> new FileInfo(file))
        >> Array.map(fun info -> info.Length)
        >> Array.sum 

    
    //Backwards composition example
    let negate x = -x
    //using >> negates the square
    let negateSquare = (square >> negate) 10
    //but we want to square the negation
    //so we use <<
    let squareNegate = (square << negate) 10
    //Filtering lists
    let list = [ [1]; []; [4;5;6]; [3;4]; []; []; []; [9]; ]
    let testIsEmpty = List.filter(not << List.isEmpty) (list)

module patternMatching =
    
    
    //Pattern matching
    //Simple pattern matching
    let isOdd x = (x % 2 = 1)
    let describeNumber x =
        match isOdd x with
        | true -> printfn "%d is odd " x
        | false -> printfn "%d is even " x
    
    describeNumber 5

    //Truth table example using pattern matching
    let testAnd x y =
        match x,y with
        | true, true -> true
        | true, false -> false
        | false, true -> false
        | false, false -> false
 
    testAnd true true
 
    // _ matches anything
    let testAnd2 x y =
        match x,y with
        | true, true -> true
        | _, _       -> false


    let highLowGame () =
        let rng = new Random()
        let secretNumber = rng.Next() % 100

        let rec highLowGameStep () =
            printfn "Guess the secret number: "
            let guessStr = Console.ReadLine()
            let guess = Int32.Parse(guessStr)

            match guess with
            | _ when guess > secretNumber
                -> printfn "The secret number is lower."
                   highLowGameStep()
            | _ when guess = secretNumber
                -> printfn "You have guessed correctly!"
                   ()
            | _ when guess < secretNumber
                -> printfn "The secret number is higher."
                   highLowGameStep()
        //begin the game
        highLowGameStep()

    //highLowGame()

    //Grouping patterns
    let vowelTest c =
        match c with
        | 'a' | 'e' | 'i' | 'o' | 'u'
            -> true
        | _ -> false

module discriminatedUnions = 
    type Suit =
            | Heart
            | Diamond
            | Spade
            | Club

  (*  type PlayingCard = 
        | Ace of Suit
        | King of Suit
        | Queen of Suit
        | Jack of Suit
        | ValueCard of int * Suit *)

        

    //Discriminated union
   

    let suits = [Heart; Diamond; Spade; Club]

   (* let deckOfCards = 
    [
        for suit in [ Spade; Club; Heart; Diamond ] do
            yield Ace(suit)
            yield King(suit)
            yield Queen(suit)
            yield Jack(suit)
            for value in 2 .. 10 do
                yield ValueCard(value,suit)
    ] *)
    //Binary tree with Discriminated Unions        
    type BinaryTree =
        | Node of int * BinaryTree * BinaryTree
        | Empty

    let rec printInOrder tree =
        match tree with
        | Node (data, left, right)
            -> printInOrder left
               printfn "Node %d" data
               printInOrder right
        | Empty
            -> ()

    let binTree =
        Node(2,
            Node(1, Empty, Empty),
            Node(4,
                Node(3, Empty, Empty),
                Node(5, Empty, Empty)
                )
        )
    printInOrder binTree

    //Methods and properties

    type PlayingCard =
        | Ace of Suit
        | King of Suit
        | Queen of Suit
        | Jack of Suit
        | ValueCard of int * Suit

        member this.Value =
            match this with
            | Ace(_) -> 11
            | King(_) | Queen(_) | Jack(_) -> 10
            | ValueCard(x, _) when x <= 10 && x >= 2
                -> x
            | ValueCard(_) -> failwith "Card has invalid value"

    let highCard = Ace(Spade)
    let highCardVal = highCard.Value

module Records = 
    type Person = 
        { First: string; Last: string; Age: int}
        member this.FullName = this.First + " " + this.Last
    let filip = { First = "filip"; Last = "Skukan"; Age = 22}
    let katarina = { filip with First = "Katarina"}
    //katarina.FullName

