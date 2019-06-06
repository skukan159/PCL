module Modules

module ExplicitAndImplicitConstruction = 
    open System

    //Example 5-3 - Explicit class construction syntax
    type Point =
        val m_x : float
        val m_y : float

        //Constructor - takes two parameters
        new (x,y) = { m_x = x; m_y = y }

        //Constructor 2 - Takes no parameters
        new () = { m_x = 0.0; m_y = 0.0 }

        member this.Length =
            let sqr x = x*x
            sqrt <| sqr this.m_x + sqr this.m_y

    let p1 = new Point(1.0, 1.0)
    let p2 = new Point()

    //Example 5-4 - Arbitrary execution before explicit constructor
    type Point2 = 
        val m_x : float
        val m_y : float

        //Parse a string e.g. 1.0, 2.0
        new (text : string) as this =
        //Do any required pre processing
        if text = null then
            raise <| new ArgumentException("text")

        let parts = text.Split([| ',' |])
        let (successX, x) = Double.TryParse(parts.[0])
        let (successY, y) = Double.TryParse(parts.[1])

        if not successX || not successY then
            raise <| new ArgumentException("text")
        //Initialize class fields
        { m_x = x; m_y = y }
        then
            //Do any post processing
            printfn
                "Initialized to [%f, %f]"
                this.m_x
                this.m_y
         
    //Example 5-5. Implicit class construction

    type Point3(x:float, y:float) =

        let length =
            let sqr x = x*x
            sqrt <| sqr x + sqr y 
        do printfn "Initialized to [%f, %f]" x y

        member this.X = x
        member this.Y = y
        member this.Length = length

        //Define custom constructors, these must
        //call the 'main' constructor
        new() = new Point3(0.0, 0.0)

        //Define a second constructor
        new(text : string) =
            if text = null then
                raise <| new ArgumentException("text")

            let parts = text.Split([| ',' |])
            let (successX, x) = Double.TryParse(parts.[0])
            let (successY, y) = Double.TryParse(parts.[1])

            if not successX || not successY then
                raise <| new ArgumentException("text")
            //calls the primary constructor
            new Point3(x,y)

module GenericClasses =
    //Example 5-6. Defining generic classes
    type Arrayify<'a>(x : 'a) =
        member this.EmptyArray : 'a[] = [| |]
        member this.ArraySize1 : 'a[] = [| x |]
        member this.ArraySize2 : 'a[] = [| x; x |]
        member this.ArraySize3 : 'a[] = [| x; x; x |]
    
    let arrayifyTuple = new Arrayify<int * int>((10,27))
    arrayifyTuple.ArraySize3

module MethodsAndProperties =
    open System

   (* type FancyMachine() =
        let mutable m_widget = Widget.FromSerialNumber("tuacm-2004")

        member this.GetWidget() = m_widget
        member this.SetWidget(newWidget) =
            //clone newWidget so that it may change after this call to
            //SetWidget without notifying m_widget
            m_widget <- newWidget.Clone() *)
    //Example 5.8. Defining class properties
    //Define a WaterBottle type with two properties
    [<Measure>]
    type ml

    type WaterBottle() =
        let mutable m_amount = 0.0<ml>
        //Read only property
        member this.Empty = (m_amount = 0.0<ml>)
        //Read/Write property
        member this.Amount with get() = m_amount
                           and set newAmt = m_amount <- newAmt

    //Test
    let bottle = new WaterBottle()
    bottle.Empty
    bottle.Amount <- 1000.0<ml>
    bottle.Empty

    //Example 5.12 - Method overloading
    type BitCounter =
        static member CountBits (x : int16) =
            let mutable x' = x
            let mutable numBits = 0
            for i = 0 to 15 do
                numBits <- numBits + int (x' &&& 1s)
                x' <- x' >>> 1
            numBits
        static member CountBits (x : int64) =
            let mutable x' = x
            let mutable numBits = 0
            for i = 0 to 63 do
                numBits <- numBits + int (x' &&& 1L)
                x' <- x' >>> 1
            numBits

    //Example 5.13 Accessibility modifiers
    type internal Ruby private(shininess, carats) =
        let mutable m_size = carats
        let mutable m_shininess = shininess

        //Polishing increases shininess but decreases size
        member this.Polish() =
            this.Size <- this.Size - 0.1
            m_shininess <- m_shininess + 0.1

        //Public getter, private setter
        member public this.Size with get() = m_size
        member public this.Size with set newSize = m_size <- newSize

        member this.Shininess = m_shininess

        public new() =
            let rng = new Random()
            let s = float(rng.Next() % 100) * 0.01
            let c = float (rng.Next() % 16) + 0.1
            new Ruby(s,c)
        public new(carats) =
            let rng = new Random()
            let s = float(rng.Next() % 100) * 0.01
            new Ruby(s,carats)

    //let rubyTest = new Ruby()
            

