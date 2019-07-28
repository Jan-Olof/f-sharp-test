module Capstone2.Auditing

open System.IO
open Capstone2.Domain

/// Log in a file.
let fileSystemAudit account message =

    let path = sprintf "d:\\tmp\\%s.txt" (account.Id.ToString())
    let msg = sprintf "\n%s" message
    File.AppendAllText(path, msg)

/// Log in the console.
let console account message =

    printfn "Account %s: %s" (account.Id.ToString()) message