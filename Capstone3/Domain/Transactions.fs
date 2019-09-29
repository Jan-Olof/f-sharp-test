module Capstone3.Domain.Transactions

/// Serialize a transaction.
let serialized transaction =
    sprintf "%O***%s***%M***%b"
        transaction.Timestamp
        transaction.Operation
        transaction.Amount
        transaction.Success