let numbers = [ 3; 8; 36; 69; 5; 27; 68; 7]

let sum inputs =
    Seq.fold
        (fun state input -> state + input)
        0
        inputs

sum [ 1 .. 5 ]
sum numbers

let sum2 inputs2 =
    Seq.fold
        (fun state input ->
            let newState = state + input
            printfn
                "Current state is %d, input is %d, new state value is %d"
                state
                input
                newState
            newState)
        0
        inputs2

sum2 [ 1 .. 5 ]
sum2 numbers

let length inputs =
    Seq.fold
        (fun state _ -> state + 1)
        0
        inputs

length [ 0 .. 6 ]
length numbers

let max inputs =
    Seq.fold
        (fun state input -> if input > state then input else state)
        0
        inputs

max [ 0 .. 6 ]
max numbers