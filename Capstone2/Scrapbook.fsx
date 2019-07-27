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
    { account with Balance = amount }