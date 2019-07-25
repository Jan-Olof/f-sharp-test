let text = "Hello, world"
text.Length

let greetPerson name age =
    sprintf "Hello, %s. You are %d years old" name age

let greeting = greetPerson "Fred" 25

let int2String (x: int) = string x

open System.IO
let countWords (text:string) =
    let x = text.Split ' '
    File.WriteAllText(@"d:\test.txt", "Text: " + text + ". Words: " +  int2String x.Length)
    x.Length

let cw = countWords "kalle och musse"

File.WriteAllText(@"d:\test.txt", "Hello There\n Welcome to:\n Tutorials Point")
let msg = File.ReadAllText(@"d:\test.txt")
printfn "%s" msg