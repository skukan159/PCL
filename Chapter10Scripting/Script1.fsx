#r "stdole.dll"
#r "Microsoft.Office.Interop.Word"

open Microsoft.Office.Interop.Word

let private m_word : ApplicationClass option ref = ref None

let openWord() = m_word := Some(new ApplicationClass())
let getWordInstance() = Option.get !m_word
let closeWord() = (getWordInstance()).Quit()

//COM objects expect byref<obj>, ref cells will be
//converted to byref<obj> by the compiler.
let comarg x = ref (box x)

let openDocument filePath =
    printfn "Opening %s..." filePath
    getWordInstance().Documents.Open(comarg filePath)

let printDocument (doc : Document) =
    printfn "Printing %s..." doc.Name

    doc.PrintOut(
    Background = comarg true,
    Range = comarg WdPrintOutRange.wdPrintAllDocument,
    Copies = comarg 1,
    PageType = comarg WdPrintOutPages.wdPrintAllPages,
    PrintToFile = comarg false,
    Collate = comarg true,
    ManualDuplexPrint = comarg false,
    PrintZoomColumn = comarg 2, //Pages 'across'
    PrintZoomRow = comarg 2) //Pages 'up down'

let closeDocument (doc : Document) =
    printfn "Closing %s..." doc.Name
    doc.Close(SaveChanges = comarg false)

// ------------------------------------------

open System
open System.IO

try
    openWord

    printfn "Printing all files in [%s]..." __SOURCE_DIRECTORY__

    Directory.GetFiles(__SOURCE_DIRECTORY__, "*.docx")
    |> Array.iter
        (fun filePath ->
            let doc = openDocument filePath
            printDocument doc
            closeDocument doc)
finally
    closeWord()

printfn "Press any key..."
Console.ReadKey(true) |> ignore
