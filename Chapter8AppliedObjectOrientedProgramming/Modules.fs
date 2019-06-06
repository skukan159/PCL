module Modules

//Example 8-1 Operator overloading
[<Measure>]
type ml

type Bottle(capacity:float<ml>) =
    new() = new Bottle(0.0<ml>)

    member this.Volume = capacity
    static member (+) ((lhs : Bottle), rhs) = 
        new Bottle(lhs.Volume + rhs)

    static member (-) ((lhs : Bottle), rhs) =
        new Bottle(lhs.Volume - rhs)

    static member (~-) (rhs : Bottle) =
        new Bottle(rhs.Volume * -1.0<1>)

    override this.ToString() =
        sprintf "Bottle(%.1fml)" (float capacity)

let half = new Bottle(500.0<ml>)

type Person =
    | Boy of string
    | Girl of string
    | Couple of Person * Person
    static member (+) (lhs,rhs) =
        match lhs,rhs with
        | Couple(_), _
        | _, Couple(_)
            ->failwith "Three's not a crowd!"
        | _ -> Couple(lhs,rhs)

let testCouple = Boy("Filip") + Girl("Tatiana")
 
//Indexers

//Example 8.2 - Adding an indexer to a class
module Indexers =
    open System
    
    type Year(year : int) =
        member this.Item (idx : int) =
            if idx < 1 || idx > 365 then
                failwith "Invalid day range"

            let dateStr = sprintf "1-1-%d" year
            DateTime.Parse(dateStr).AddDays(float (idx - 1))

    let eightyTwo = new Year(1982)
    let specialDay = eightyTwo.[171]


//Delegates and events
