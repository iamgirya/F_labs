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
    override this.ToString() = "Серия и номер: " + series + " "+ number + ", категория: "+ Convert.ToString(category) + ", мощность двигателя: "+ Convert.ToString(enginePower) + ", масса: "+ Convert.ToString(mass)
    member this.Print() = Console.WriteLine(this.ToString())

[<EntryPoint>]
let main argv =
    let p1 = TSpasport("0316", "556677", 'A', 104.15, 1375)
    p1.Print()
    0 // return an integer exit code
