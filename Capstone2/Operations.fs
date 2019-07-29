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

    audit account (sprintf "Performing a %s operation for %.2M..." operationName amount)
    let newAccount = operation amount account

    if account.Balance = newAccount.Balance then
        audit account (sprintf "Transaction %s rejected!" operationName)
    else
        audit account (sprintf "Transaction accepted! Balance is now %.2M." newAccount.Balance)

    newAccount