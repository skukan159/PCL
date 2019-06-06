module Topics

module mutability =
    let showMutability =
        let mutable message = "World"
        printfn "Hello %s" message
        message <- "universe"
        printfn "Hello %s" message

    //Reference calls
    let showReferenceCalls =
        let planets =
            ref [
                "Mercury"; "Venus"; "Earth";
                "Mars"; "Jupiter"; "Saturn";
                "Uranus"; "Neptune"; "Pluto";
            ]
        //Filter all planets not equal to Pluto
        //Get the value of the planets ref cell using (!)
        //then assign the new value using (:=)
        planets := !planets |> List.filter (fun p -> p <> "Pluto")
        printfn "%A" planets
        //planets |> List.iter |> printfn "%s"
    
module unitsOfMeasure =
    open System.Runtime.Remoting.Metadata.W3cXsd2001
    
    [<Measure>]
    type fahrenheit

    let printTemperature (temp : float<fahrenheit>) =
        if temp < 32.0<_> then
            printfn "Below freezing!"
        elif temp < 65.0<_> then
            printfn "Cold"
        elif temp < 75.0<_> then
            printfn "Just right!"
        elif temp < 100.0<_> then
            printfn "Hot!"
        else 
            printfn "Scorching!"
        
    //Defining units of measure
    [<Measure>]
    type s
    [<Measure>]
    type Hz = s ^-1

    //Adding methods to units of measure
    [<Measure>]
    type far =
        static member ConvertToCel(x : float<far>) =
            (5.0<cel> / 9.0<far>) * (x - 32.0<far>)

    and [<Measure>] cel =
        static member ConvertToFar(x : float<cel>) =
            (9.0<far> / 5.0<cel> * x) + 32.0<far> 

    let testConvertToCel = far.ConvertToCel(100.0<far>)

    [<Measure>]
    type m
    
    type Point< [<Measure>] 'u >(x : float <'u>,y : float<'u>) =
        member this.X = x
        member this.Y = y

        member this.UnitlessX = float x
        member this.UnitlessY = float y

        member this.Length =
            let sqr x = x*x
            sqrt <| sqr this.X + sqr this.Y

        override this.ToString() =
            sprintf
                "{%f, %f}"
                this.UnitlessX
                this.UnitlessY
    
    let testPoint =
        let point = new Point<m>(10.0<m>,10.0<m>)
        point.Length
        point.ToString
        point

module arrays =
    open System

    let rot13Encrypt (letter : char) = 
    //Move the letter forward 13 places in the alphabet (looping around)
    //otherwise ignore
        if Char.IsLetter(letter) then
            let newLetter =
                (int letter)
                |> (fun letterIdx -> letterIdx - (int 'A'))
                |> (fun letterIdx -> (letterIdx + 13) % 26 )
                |> (fun letterIdx -> letterIdx + (int 'A'))
                |> char
            newLetter
        else
            letter

    //Loop through each array element, encrypting each letter
    let encryptText (text : char[]) =

        for idx = 0 to text.Length - 1 do
            let letter = text.[idx]
            text.[idx] <- rot13Encrypt letter

    let testText =
        Array.ofSeq "I LOVE MY MAU"

    //Array slices
    let daysOfWeek = Enum.GetNames( typeof<DayOfWeek> )
    //standard array slice, elements 2 through 4
    daysOfWeek.[2..4]
    //just specify the lower bound. elements 4 to the end
    daysOfWeek.[4..]
    //Just specify the upper bound
    daysOfWeek.[..2]
    daysOfWeek.[*]

    //initialize an array of sin-wave elements
    let divisions = 4.0
    let twoPi = 2.0 * Math.PI

    Array.init (int divisions) (fun i -> float i * float twoPi / divisions)

    //Pattern matching against arrays
    let describeArray arr =
        match arr with
        | null -> "The array is null"
        | [| |] -> "The array is empty"
        | [| x |] -> sprintf "The array has one element, %A" x
        | [| x; y |] -> sprintf "The array has two elements, %A and %A" x y
        | a -> sprintf "The array has %d elements, %A" a.Length a

    //multidimensional arrays
    //3 X 3 array
    let identityMatrix : float[,] = Array2D.zeroCreate 3 3
    identityMatrix.[0,0] <- 1.0
    identityMatrix.[1,1] <- 1.0
    identityMatrix.[2,2] <- 1.0




                        

        
        
