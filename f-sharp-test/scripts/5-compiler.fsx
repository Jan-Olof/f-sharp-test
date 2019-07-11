let add (a:int, b:int) : int =
    let answer:int = a + b
    answer

let add2 (a, b) =
    let answer = a + b + "hej"
    answer

let x = add2("då", "re")