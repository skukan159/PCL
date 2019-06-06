module Exercises


    let tdata = ((2,3), 5, (12,3))
    let myFunc =
        let _, _, thirdVal = tdata
        let value,_ = thirdVal
        printf "%d" value


    let rec strListConcat myListOfStrings =
        match myListOfStrings with
        | [] -> ""
        | h::t -> h + strListConcat  t 
    let testConcat = strListConcat ["IT-PCL1X ";"Spring";"2019";"Filip Skukan";"1234";"myItem"]

    //Define an F# function, getSomeItems n alst that returns a list of first n
    //elements from the list alst.Define the function using pattern matching including error handling:

//Test with getSomeItems 2 ["Functional"; "Object-Oriented"; "Imperative"; "Concurrent"]  should return ["Functional"; "Object-Oriented"].

    let rec getSomeItems n ls =
        match ls with
        | [] -> []
        | h :: t -> match n with
                    | 0 -> []
                    | _ -> h :: getSomeItems (n-1) t
    let testGetSome = getSomeItems 2 ["Functional"; "Object-Oriented"; "Imperative"; "Concurrent"]

       // Declare a function strListConcat strlst that concatenates a list of strings (strlst) into a single string using pattern matching


 //     Declare a function getElementAt alst npos that returns an element in position (int:npos) from the list alst.
//Define the function using pattern matching including error handling:
//Test with getElementAt ["Cross Media"; "Data Engineering"; "Embedded Systems"] 2;;  should return "Data Engineering".
    let rec getElementAt alst npos accumulator =
        match accumulator with
        | 0 ->  failwith "Invalid accumulator value. Insert 1"
        | _ ->
            match alst with
            | [] -> failwith "Index out of bounds"
            | h::t -> if npos = accumulator then h else getElementAt t npos (accumulator+1)

    let testgetElementAt = getElementAt ["Cross Media"; "Data Engineering"; "Embedded Systems"] 2 1


    let intsList = [1;2;3;9;7;4;5]
    let testgetElementAt = getElementAt intsList 0






//Example string items in the list: "IT-PCL1X ", " Spring ", " 2019 :", " your name"  and " your number". Ps put items in a list.
//1. Get ("ECTS", 30)

//let sdata = ((1234, "Your Name"), 6, ("ECTS", 30))

 //1.
    let sdata = ((1234, "Your Name"), 6, ("ECTS", 30))
    let _, _, thirds =sdata
 //2. Concat list of strings to a string
    let rec strListConcat myString myListOfStrings =
        match myListOfStrings with
        | [] -> myString
        | h::t -> myString + strListConcat h t 
    let testConcat = strListConcat "Hello" ["IT-PCL1X ";"Spring";"2019";"Filip Skukan";"1234";]
        


 // 3. Get max from a list of ints
    let rec getMax intsList acumulator =
        match intsList with
        | [] -> acumulator
        | h::t -> if h > acumulator then getMax t h else  getMax t acumulator


    let intsList = [1;2;3;9;7;4;5]
    let testGetMax = getMax intsList 0
// 4. Get the first n number of items from a list

    let rec takeSome n ls =
        match ls with
        | [] -> []
        | h :: t -> match n with
                    | 0 -> []
                    | _ -> h :: takeSome (n-1) t

    let testTakeSome = takeSome 3 [1;2;3;4;5]

 //   Given the following value:

//let tdata = ((2,3), 5, (12,3))

//Declare a function to deconstruct the tdata, that prints out only the first element of third element of tdata, that is 12.

 //1.

  //  extract1stOfThird =
  //      let _, _, thirdVal = tdata
        let value = thirdVal
//