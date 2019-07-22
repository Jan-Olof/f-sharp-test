let drive distance petrol =
    if distance = "far" then petrol / 2.0
    elif distance = "medium" then petrol - 10.0
    else petrol - 1.0

let petrol = 100.0

petrol
|> drive "far"
|> drive "medium"
|> drive "short"