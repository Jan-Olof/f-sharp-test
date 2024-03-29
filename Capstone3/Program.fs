﻿module Capstone3.Program

open System
open Capstone3.Domain
open Capstone3.Operations

let withdrawWithAudit =
    auditAs "withdraw" Auditing.composedLogger withdraw

let depositWithAudit =
    auditAs "deposit" Auditing.composedLogger deposit

let loadAccountFromDisk =
    FileRepository.findTransactionsOnDisk >> Operations.loadAccount

let isStopCommand (command) =
    if command = 'x' then
        true
    else
        false

let isValidCommand (command) =
    if command = 'w' then
        true
    elif command = 'd' then
        true
    elif isStopCommand command then
        true
    else
        false

let getAmountConsole (command) =
    if command = 'x' then
        ('x', 0M)
    else
        Console.Write "\nEnter amount: "
        let money = Console.ReadLine()

        if command = 'd' then
            (command, (Decimal.Parse money))
        elif command = 'w' then
            (command, (Decimal.Parse money))
        else
            (command, 0M)

let processCommand account (command, amount) =
    printfn ""
    let account =
        if command = 'd' then
            account |> depositWithAudit amount
        else
            account |> withdrawWithAudit amount

    printfn "Current balance is €%M" account.Balance
    account

[<EntryPoint>]
let main _ =
    let openingAccount =
        Console.Write "Please enter your name: "
        Console.ReadLine() |> loadAccountFromDisk

    printfn "Current balance is £%M" openingAccount.Balance

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