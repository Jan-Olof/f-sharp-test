open System

type Customer =
    { Id : Guid
      FirstName : string
      LastName : string
      Age : int }

type Account =
    { Id : Guid
      Owner : Customer
      Balance : decimal }

let don = { Id = Guid.Parse("98f69d6b-5f07-49cd-a19f-731a335561f5"); FirstName = "Donald"; LastName = "Duck"; Age = 21 }

let acc1 = { Id = Guid.Parse("7c8e9d1c-1724-4511-8363-84a5576b0100"); Owner = don; Balance = 0m }

/// Deposits an amount into an account
let deposit amount account : Account =
    { account with Balance = account.Balance + amount }

let acc1a = deposit 100m acc1
let acc1b = deposit 101m acc1a

/// Withdraws an amount into out of an account
let withdraw amount account : Account =
    if amount > account.Balance then account
    else { account with Balance = account.Balance - amount }

let acc1c = acc1 |> withdraw 100m
let acc1d = acc1b |> withdraw 100m

let acc2 = acc1 |> deposit 100m |> withdraw 55m

open System.IO

///
let fileSystemAudit account message =
    let path = sprintf "d:\\tmp\\%s.txt" (account.Id.ToString())
    let msg = sprintf "\n%s" message
    File.AppendAllText(path, msg)

fileSystemAudit acc1 "Buu"
fileSystemAudit acc1 "Buu2"

///
let console account message =
    printfn "Account %s: %s" (account.Id.ToString()) message

console acc1 "Testing without meaning"