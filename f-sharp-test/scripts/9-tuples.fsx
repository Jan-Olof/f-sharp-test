let parse(person:string) =
    let parts = person.Split(' ')
    parts.[0], parts.[1], int(parts.[2])

let x,y,z = parse "Mary Asteroids 2500"