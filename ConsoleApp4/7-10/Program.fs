open System
open System.Diagnostics
open System.Text.RegularExpressions

type TSpasport() =
    let mutable number = ""
    let mutable series = ""
    let mutable category = ' '
    let mutable enginePower = 0.0
    let mutable mass = 0
    member this.Mass
        with get() = mass
        and set(value:int) =
            if (Regex.IsMatch (Convert.ToString(value), @"[0-9]+"))
            then mass <- value
            else Console.WriteLine("Ошибка формата ввода")
    member this.EnginePower
        with get() = enginePower
        and set(value:float) = 
            if (Regex.IsMatch (Convert.ToString(value), @"[0-9]+.[0-9]+"))
            then enginePower <- value
            else Console.WriteLine("Ошибка формата ввода")
    member this.Category
        with get() = category
        and set(value:char) =
            if (Regex.IsMatch (Convert.ToString(value), @"(A|B|C|D|E)"))
            then category <- value
            else Console.WriteLine("Ошибка формата ввода")
    member this.Number
        with get() = number
        and set(value) =
            if (Regex.IsMatch (value, @"[0-9]{6}"))
            then number <- value
            else Console.WriteLine("Ошибка формата ввода")
    member this.Series
        with get() = series
        and set(value) =
            if (Regex.IsMatch (value, @"[0-9]{4}"))
            then series <- value
            else Console.WriteLine("Ошибка формата ввода")
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
    let p1 = TSpasport(Series="0316", Number="556677", Category='A', EnginePower=104.15, Mass=1375)
    let p2 = TSpasport(Series="0666", Number="111111", Category='G', EnginePower=200.0, Mass=2000)
    p1.Print()
    Console.WriteLine(p1 > p2)
    0 // return an integer exit code
