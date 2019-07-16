module Car

open System

/// Gets the distance to a given destination
let getDistance (destination) =
    if destination = "Gas" then 10
    elif destination = "Home" then 25
    elif destination = "Office" then 50
    elif destination = "Stadium" then 25
    else failwith "Unknown destination!"

/// Calculate remaining petrol
let calcRemainingPetrol(current, distance) =
    if current >= distance then current-distance
    else failwith "Oops! Tou've run out of petrol!"

/// Fill some petrol
let fill(destination) =
    if destination = "Gas" then 50
    else 0

/// Drives to a given destination given a starting amount of petrol
let driveTo(petrol, destination) =
    let distance = getDistance destination
    calcRemainingPetrol(petrol, distance) + fill(destination)