open System
open System.IO
let writeToFile (date:DateTime) filename text =
    let path = sprintf "D:\\tmp\\%s-%s.txt" (date.ToString "yyyyMMdd") filename
    //let path = "D:\\tmp\\" + date.ToString("yyMMdd") + "-" + filename + ".txt"
    File.WriteAllText(path, text)

let writeToToday = writeToFile DateTime.Now.Date
let writeToTomorrow = writeToFile (DateTime.Now.Date.AddDays 1.)

let x = writeToToday "hello-world"

x "some text"