module Capstone3.Program

open System
open Capstone3.Domain
open Capstone3.Operations

let isStopCommand (command) =
    if command = 'x' then true
    else false

let isValidCommand (command) =
    if command = 'w' then true
    elif command = 'd' then true
    elif isStopCommand command then true
    else false

let getAmount (command) =
    if command = 'd' then ('d', 50M)
    elif command = 'w' then ('w', 25M)
    else ('x', 0M)

let processCommand (account) (command, amount) =
    if command = 'w' then account |> withdraw amount
    elif command = 'd' then account |> deposit amount
    else account

[<EntryPoint>]
let main _ =
    let name =
        Console.Write "Please enter your name: "
        Console.ReadLine()

    let withdrawWithAudit = auditAs "withdraw" Auditing.composedLogger withdraw
    let depositWithAudit = auditAs "deposit" Auditing.composedLogger deposit

    let openingAccount = { Owner = { Name = name }; Balance = 0M; AccountId = Guid.Empty }

    let commands = ['d'; 'w'; 'z'; 'f'; 'd'; 'x'; 'w']

    let closingAccount =
        commands
        |> Seq.filter isValidCommand
        |> Seq.takeWhile (not << isStopCommand)
        |> Seq.map getAmount
        |> Seq.fold processCommand openingAccount

    //let closingAccount =
    //    // Fill in the main loop here...
    //    openingAccount

    Console.Clear()
    printfn "Closing Balance:\r\n %A" closingAccount
    Console.ReadKey() |> ignore

    0