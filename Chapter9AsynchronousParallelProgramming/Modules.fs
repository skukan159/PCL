module Modules

//Example 9-1 Creating Threads
open System
open System.Threading

//What will execute on each thread
let threadBody() =
    for i in 1 .. 5 do
        //wait 1/10 of a second
        Thread.Sleep(100)
        printfn "[Thread %d] %d..."
            Thread.CurrentThread.ManagedThreadId
            i

let spawnThread() =
    let thread = new Thread(threadBody)
    thread.Start()
//spawn a coupel of threads at once

spawnThread()
spawnThread()

//Same example using threadPool

ThreadPool.QueueUserWorkItem(fun _ -> for i = 1 to 5 do printfn "%d" i)

//Our thread pool task, note that the delegate's parameter is of type obj
let printNumbers (max : obj) =
    for i = 1 to (max :?> int) do
        printfn "%d" i
  
ThreadPool.QueueUserWorkItem(new WaitCallback(printNumbers), box 5)