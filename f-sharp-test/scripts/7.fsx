open System
let describeAge(age) =
    let ageDescription =
        if age < 18 then "Child"
        elif age < 65 then "Adult"
        else "OAP"

    let greeting = "Hello"
    Console.WriteLine("{0}! You are a '{1}'", greeting, ageDescription)

let x = describeAge 20

let u = ()

if x = u then Console.WriteLine("equal") else Console.WriteLine("not")