// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
open Topics
open mutability
open unitsOfMeasure
open System
open arrays
open System.Windows.Forms

[<EntryPoint>]
let main argv = 
    let f1 = new Form(Text = "Window Title",
                    TopMost = true,
                    Width = 640,
                    Height = 480)
    f1.ShowDialog()
    (*printfn "%A" argv

    showMutability
    showReferenceCalls
    printTemperature 10.0<fahrenheit>
    *)
    //testListFold

    let point = new Point<m>(10.0<m>,10.0<m>)
    printfn "%f" point.Length
    point.ToString

    printfn "Testing encryption..."

    //printfn "Original = %s" <| new String(testText)
    encryptText(testText)
    printfn "Encrypted = %s" <| new String(testText)
    //encryptText(testText)
    //printfn "Decripted = %s" <| new String(testText)

    Console.ReadLine()
    0 // return an integer exit code
