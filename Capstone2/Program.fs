// Learn more about F# at http://fsharp.org

open System
open Capstone2.Domain

[<EntryPoint>]
let main argv =

    printfn "Tell me your name:"
    let name = Console.ReadLine()

    printfn "Tell me your balance:"
    let balance = Console.ReadLine()

    let cus = { Id = Guid.NewGuid(); Name = name; Age = 21 }
    let acc = { Id = Guid.NewGuid(); Owner = cus; Balance = Decimal.Parse balance }

    0 // return an integer exit code