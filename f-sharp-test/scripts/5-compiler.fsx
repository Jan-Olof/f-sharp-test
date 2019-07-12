let add (a:int, b:int) : int =
    let answer:int = a + b
    answer

let add2 (a, b) =
    let answer = a + b + "hej"
    answer

let x = add2("då", "re")

let sayHello(someValue) =
    let innerFunction(number) =
        if number > 10 then "Isaac"
        elif number > 20 then "Fred"
        else "Sara"

    let resultOfInner =
        if someValue < 10.0 then innerFunction(5)
        else innerFunction(15)

    "Hello " + resultOfInner

let result = sayHello(10.5)