open System

/// Gets the distance to a given destination
let getDistance (destination) =
    if destination = "Gas" then 10
    elif destination = "Home" then 25
    elif destination = "Office" then 50
    elif destination = "Stadium" then 25
    else failwith "Unknown destination!"

let calcRemainingPetrol(current, distance) =
    if current >= distance then current-distance
    else failwith "Oops! Tou've run out of petrol!"

// Couple of quick tests
getDistance("Home") = 25
getDistance("Office") = 50

calcRemainingPetrol(100, 125)