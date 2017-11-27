namespace Meetup.FSharp

module Utils =
    // 1 - Values
    let a = 10
    let b = 20.2
    let hello = "hello"

    // 2 - Records
    type Person = 
        { 
            FirstName: string
            LastName: string
            Age: int
        }

    let jdoe = { FirstName = "John"; LastName = "Doe"; Age = 25 }
    let janedoe = { jdoe with FirstName = "Jane"; Age = 35 }
    let alphonse = { FirstName = "Alphonse"; LastName = "Doh"; Age = 55 }

    // 3 - LINQ
    let computeAverageAgeOfFamily lastName list =
        list |> List.filter (fun x -> x.LastName = lastName)
             |> List.averageBy (fun x -> float x.Age)

    let people = [ jdoe; janedoe; alphonse ]
    let averageAge = computeAverageAgeOfFamily "Doe" people

    // 4 - Partial application / Currying
    let computeAverageAgeOfDoe = computeAverageAgeOfFamily "Doe"
    let averageDoeAge = people |> computeAverageAgeOfDoe

    // 5 - Combine
    let computeAverageAgeOfDoh =
        List.filter (fun x -> x.LastName = "Doh")
        >> List.averageBy (fun x -> float x.Age)

    // 6 - Imperative
    let printEven i =
        if i % 2 = 0 then
            printfn "Even"
        else
            ()

    // 7 - Pattern matching
    // 7.1 - List
    let sum list =
        match list with
        | [] -> "No items"
        | [x] -> "One value = " + (string x)
        | [x;y] -> "1st value = " + (string x) + "; 2nd value = " + (string y)
        | _ -> "Too many values"

    // 7.2 - Option
    type Order = { Date: System.DateTime }
    let tryFindOrder id =
        if id % 2 = 0 then
            Some { Date = System.DateTime.Now }
        else
            None

    let printOrderDate option =
        match option with
        | Some order -> printfn "Order date %s" (order.Date.ToShortDateString())
        | None -> printfn "No order found" 

    // 7.3 - Discriminated Unions
    type Temp =
        | DegreesC of float
        | DegreesF of int

    let convertToC degree =
        match degree with
        | DegreesC celsius -> DegreesC celsius
        | DegreesF fahrenheit -> DegreesC (float (fahrenheit - 32) / 1.8)

    let convertToF degree =
        match degree with
        | DegreesC celsius -> DegreesF (int (celsius * 1.8) + 32)
        | DegreesF fahrenheit -> DegreesF fahrenheit

    