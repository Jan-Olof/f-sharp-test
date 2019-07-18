type Car =
    { Manufacturer : string
      EngineSize : string
      NumberOfDoors : int }

let car1 =
    { Manufacturer = "Skoda"
      EngineSize = "small"
      NumberOfDoors = 4}

let car2 =
    { Manufacturer = "Skoda"
      EngineSize = "small"
      NumberOfDoors = 4}

open System

let x = car1.Equals(car2)
let y = Object.ReferenceEquals(car1,car2)

let r = Random()

let newCar =
    let rCar =
        { car1 with
            NumberOfDoors = r.Next(18,45)}

    Console.WriteLine( "Old car {0}. New car {1}", car1.NumberOfDoors, rCar.NumberOfDoors)
    rCar

//let g() = r.Next 10
//let h(min,max) = r.Next(min,max)