module Capstone3.Auditing

open Capstone3.Domain.Transactions

/// Logs to the console
let printTransaction _ accountId transaction =
    serialized transaction
    |> printfn "Account %O: %s" accountId

/// Logs to both console and file system
let composedLogger =
    let loggers =
        [ FileRepository.writeTransaction
          printTransaction ]
    fun accountId owner transaction ->
        loggers
        |> List.iter(fun logger -> logger accountId owner transaction)