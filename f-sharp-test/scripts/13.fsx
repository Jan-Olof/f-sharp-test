type Customer =
    { FirstName : string
      LastName : string
      Age : int }

open System

let printCustomerAge writer customer =
    let age =
        if customer.Age < 13 then "Child"
        elif customer.Age < 20 then "Teenager"
        elif customer.Age < 65 then "Adult"
        else "OAP"

    writer age

let cus1 = { FirstName = "Veronika"; LastName = "Jonson"; Age = 14 }
printCustomerAge Console.WriteLine cus1

let printToConsole = printCustomerAge Console.WriteLine
printToConsole cus1

open System.IO
//

let writeToFile text =
    File.WriteAllText(@"d:\tmp\test11.txt", text)

let printToFile =
    printCustomerAge writeToFile

printToFile cus1