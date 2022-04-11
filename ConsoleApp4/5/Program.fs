open System

type TSpasport(n:string, s:string, c: char, e: float, m: int) =
    let mutable number = n
    let mutable series = s
    let mutable category = c
    let mutable enginePower = e
    let mutable mass = m
    member this.Mass
        with get() = mass
        and set(value) = mass <- value
    member this.EnginePower
        with get() = enginePower
        and set(value) = enginePower <- value
    member this.Category
        with get() = category
        and set(value) = category <- value
    member this.Number
        with get() = number
        and set(value) = number <- value

[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"
    0 // return an integer exit code
