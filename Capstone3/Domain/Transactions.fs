module Capstone3.Domain.Transactions

open System
open Capstone3.Domain

/// Serialize a transaction.
let serialized transaction =
    sprintf "%O***%s***%M***%b"
        transaction.Timestamp
        transaction.Operation
        transaction.Amount
        transaction.Success

/// Deserializes a transaction
let deserialize (fileContents:string) =
    let parts = fileContents.Split([|"***"|], StringSplitOptions.None)

    {
        Timestamp = DateTime.Parse parts.[0]
        Operation = parts.[1]
        Amount = Decimal.Parse parts.[2]
        Success = Boolean.Parse parts.[3]
    }