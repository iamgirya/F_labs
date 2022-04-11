open System
open System.Diagnostics

type TSpasport( s:string, n:string, c: char, e: float, m: int) =
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
    member this.Series
        with get() = series
        and set(value) = series <- value
    override this.ToString() = "Серия и номер: " + series + " "+ number + ", категория: "+ Convert.ToString(category) + ", мощность двигателя: "+ Convert.ToString(enginePower) + ", масса: "+ Convert.ToString(mass)
    member this.Print() = Console.WriteLine(this.ToString())
    override this.Equals(b) =
        match b with
        | :? TSpasport as p -> ((this.Number) = (p.Number) && (this.Series) = (p.Series))
        | _ -> false
    override this.GetHashCode() = (this.Series + this.Number).GetHashCode()
    interface System.IComparable with
        member this.CompareTo (obj:Object) =
            match obj with
              | :? TSpasport as o -> if ((this.Series) > (o.Series)) then 1 else if ((this.Series) = (o.Series) && (this.Number) > (o.Number)) then 1 else 0
              | _ -> invalidArg "obj" "This diferent types" 
        end

[<EntryPoint>]
let main argv =
    let p1 = TSpasport("0316", "556677", 'A', 104.15, 1375)
    let p2 = TSpasport("0366", "111111", 'B', 200.00, 2375)
    p1.Print()
    Console.WriteLine(p1 > p2)
    0 // return an integer exit code
