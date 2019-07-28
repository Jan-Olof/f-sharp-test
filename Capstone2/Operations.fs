module Capstone2.Operations

open Capstone2.Domain

/// Deposits an amount into an account
let deposit amount account : Account =

    { account with
        Balance = account.Balance + amount }

/// Withdraws an amount into out of an account
let withdraw amount account : Account =

    if amount > account.Balance then
        account
    else
        { account with
            Balance = account.Balance - amount }

/// Runs some account operation such as withdraw or deposit with auditing.
let auditAs operationName audit operation amount account =

    let newAccount = operation amount account

    if account.Balance = newAccount.Balance then
        audit account (sprintf "%s failed" operationName)
    else
        audit account (sprintf "%s %.2M" operationName amount)

    newAccount