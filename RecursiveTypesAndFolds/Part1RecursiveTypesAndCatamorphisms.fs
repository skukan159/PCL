module Part1RecursiveTypesAndCatamorphisms

module basicRecursiveType =
    type Book = {title: string; price: decimal}

    type ChocolateType = Dark | Milk | SeventyPercent
    type Chocolate = {chocType: ChocolateType ; price: decimal}

    type WrappingPaperStyle = 
        | HappyBirthday
        | HappyHolidays
        | SolidColor

    type Gift =
        | Book of Book
        | Chocolate of Chocolate 
        | Wrapped of Gift * WrappingPaperStyle
        | Boxed of Gift 
        | WithACard of Gift * message:string

    let rec description gift =
        match gift with 
        | Book book -> 
            sprintf "'%s'" book.title 
        | Chocolate choc -> 
            sprintf "%A chocolate" choc.chocType
        | Wrapped (innerGift,style) -> 
            sprintf "%s wrapped in %A paper" (description innerGift) style
        | Boxed innerGift -> 
            sprintf "%s in a box" (description innerGift) 
        | WithACard (innerGift,message) -> 
            sprintf "%s with a card saying '%s'" (description innerGift) message

    let rec totalCost gift =
        match gift with 
        | Book book -> 
            book.price
        | Chocolate choc -> 
            choc.price
        | Wrapped (innerGift,style) -> 
            (totalCost innerGift) + 0.5m
        | Boxed innerGift -> 
            (totalCost innerGift) + 1.0m
        | WithACard (innerGift,message) -> 
            (totalCost innerGift) + 2.0m

    let rec whatsInside gift =
        match gift with 
        | Book book -> 
            "A book"
        | Chocolate choc -> 
            "Some chocolate"
        | Wrapped (innerGift,style) -> 
            whatsInside innerGift
        | Boxed innerGift -> 
            whatsInside innerGift
        | WithACard (innerGift,message) -> 
            whatsInside innerGift

    // a Book
    let wolfHall = {title="Wolf Hall"; price=20m}

    // a Chocolate
    let yummyChoc = {chocType=SeventyPercent; price=5m}

    // A Gift
    let birthdayPresent = WithACard (Wrapped (Book wolfHall, HappyBirthday), "Happy Birthday")
    // WithACard (
    // Wrapped (
    // Book {title = "Wolf Hall"; price = 20M},
    // HappyBirthday),
    // "Happy Birthday")

    // A Gift
    let christmasPresent = Wrapped (Boxed (Chocolate yummyChoc), HappyHolidays)
    // Wrapped (
    // Boxed (
    // Chocolate {chocType = SeventyPercent; price = 5M}),
    // HappyHolidays)