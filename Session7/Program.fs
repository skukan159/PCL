
// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

[<EntryPoint>]
let main argv = 
    printfn "%A" argv

    let isPrimeNumber x =
        let mutable i = 2
        let mutable isFactorFound = false
        while not isFactorFound && i < x do
            if x % i = 0 then
                isFactorFound <- true
            i <- i + 1
        not isFactorFound

    let testIsPrime = isPrimeNumber 17

    let sw = new System.Diagnostics.Stopwatch()
    let ResetStopWatch() = sw.Reset();sw.Start()
    let ShowTime() = printfn "Took me %d ms" sw.ElapsedMilliseconds

    let intArray = [| for i in 10000000 .. 1004000 -> i|]
    ResetStopWatch()
    let primeDetails1 =
        intArray
        |> Array.map (fun x -> (x, isPrimeNumber x))
    ShowTime()


    ResetStopWatch()
    let primeDetails3 =
        intArray
            |> Array.Parallel.map (fun x -> (x, isPrimeNumber x))
    ShowTime()




    let printAgent =
        MailboxProcessor.Start(fun inbox ->
            let rec msgLoop = async{
                let! msg = inbox.Receive()
                printfn "Message is: %s" msg 
                return! msgLoop
            }
            msgLoop)
    
    printAgent.Post("Hello World")


    let actor = 
        MailboxProcessor.Start(fun inbox ->
            let rec processMessage state =
                async {
                    let! msg = inbox.Receive()
                    printfn "\n received ==>> %A" msg
                    let newState = msg + " (processed)"
                    printfn "Processed ==>> \"%s\""(newState.ToUpper())
                    return! processMessage newState
                }
            processMessage "initialState")

    actor.Post("Hello World")

    printf "%b" testIsPrime

    0 // return an integer exit code
