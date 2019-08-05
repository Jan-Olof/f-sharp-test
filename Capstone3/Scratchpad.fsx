#load "Domain.fs"
#load "Operations.fs"

open Capstone3.Operations
open Capstone3.Domain
open System

let maria = { Name = "Maria" }

let acc1 = { AccountId = Guid.Parse("7c8e9d1c-1724-4511-8363-84a5576b0100"); Owner = maria; Balance = 0m }

let commands = ['d'; 'w'; 'z'; 'f'; 'd'; 'x'; 'w']

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

commands
|> Seq.filter isValidCommand
|> Seq.takeWhile (not << isStopCommand)
|> Seq.map getAmount
|> Seq.fold processCommand acc1

//let x = isValidCommand 'd'
//let y = isValidCommand 'e'
//let z = isValidCommand 'x'
//let a = getAmount 'e'

//let b = processCommand acc1 ('d', 10M)

//let c = 'd' |> getAmount |> processCommand acc1