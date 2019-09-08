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

let getAmountConsole (command) =
    if command = 'x' then ('x', 0M)
    else
        Console.Write "\nEnter amount: "
        let money = Console.ReadLine()

        if command = 'd' then (command, (Decimal.Parse money))
        elif command = 'w' then (command, (Decimal.Parse money))
        else (command, 0M)

let processCommand account (command, amount) =
    printfn ""
    let account =
        if command = 'd' then account |> deposit amount
        else account |> withdraw amount
    printfn "Current balance is £%M" account.Balance
    account

[<EntryPoint>]
let main _ =
    let name =
        Console.Write "Please enter your name: "
        Console.ReadLine()

    // let withdrawWithAudit = auditAs "withdraw" Auditing.composedLogger withdraw
    // let depositWithAudit = auditAs "deposit" Auditing.composedLogger deposit

    let openingAccount = { Owner = { Name = name }; Balance = 0M; AccountId = Guid.Empty }

    // let commands = ['d'; 'w'; 'z'; 'f'; 'd'; 'x'; 'w']

    let consoleCommands =
        seq {
            while true do
            Console.Write "(d)eposit, (w)ithdraw or e(x)it: "
            yield Console.ReadKey().KeyChar }

    let closingAccount =
        consoleCommands
        |> Seq.filter isValidCommand
        |> Seq.takeWhile (not << isStopCommand)
        |> Seq.map getAmountConsole
        |> Seq.fold processCommand openingAccount

    Console.Clear()
    printfn "Closing Balance:\r\n %A" closingAccount
    Console.ReadKey() |> ignore

    0