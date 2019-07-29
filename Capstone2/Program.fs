// Learn more about F# at http://fsharp.org

open System
open Capstone2.Domain
open Capstone2.Operations
open Capstone2.Auditing

[<EntryPoint>]
let main argv =

    printfn "Tell me your name:"
    let name = Console.ReadLine()

    printfn "Tell me your balance:"
    let balance = Console.ReadLine()

    let cus = { Id = Guid.NewGuid(); Name = name; Age = 21 }
    let mutable acc = { Id = Guid.NewGuid(); Owner = cus; Balance = Decimal.Parse balance }

    let dep = deposit |> auditAs "deposit" console
    let wit = withdraw |> auditAs "withdraw" console

    let mutable x = 0
    while x = 0 do
        printfn "What action to take? (d/w/esc)"
        let action = Console.ReadKey()

        if action.Key = ConsoleKey.Escape then x <- 1
        else
            Console.WriteLine()
            printfn "How much?"
            let amount = Console.ReadLine()

            // TODO: Do not use mutable value.
            acc <-
                if action.Key = ConsoleKey.D then
                    acc |> dep (Decimal.Parse amount)
                elif action.Key = ConsoleKey.W then
                    acc |> wit (Decimal.Parse amount)
                else acc

        ()

    0 // return an integer exit code