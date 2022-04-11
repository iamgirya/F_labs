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

[<AbstractClass>]
type Collection() =
    abstract member searchDoc:(TSpasport)  -> (bool)

type ArrayTS(list:'TSpasport list)=
    inherit Collection()
    member this.Arr = Array.ofList list
    override this.searchDoc(obj) = 
        Array.exists (fun (x:TSpasport)-> x = obj) this.Arr

type ListTS(list:'TSpasport list)=
    inherit Collection()
    member this.list = list
    override this.searchDoc(obj) = 
        List.exists (fun (x:TSpasport)-> x = obj) this.list


type SetTS(list:'TSpasport list)=
    inherit Collection()
    member this.set = Set.ofList list
    override this.searchDoc(obj) = 
        Set.contains obj this.set

    override this.ToString() = "Записей: " + this.set.Count.ToString()

type BinaryListTS(list:'TSpasport list)=
    inherit Collection()
    let rec binSearch (l:'TSpasport list) (el:TSpasport) =
        match (List.length l) with
        |0->false
        |i->
            let mid = i/2
            match sign <| compare el l.[mid] with
            |0->true
            |1->binSearch l.[..mid - 1] el
            |_->binSearch l.[mid + 1..] el     

    member this.binaryList = List.sortBy (fun (x:TSpasport)-> x.Series+x.Number) list 
    override this.searchDoc(obj) = 
        binSearch this.binaryList obj



[<EntryPoint>]
let main argv =
    let p1 = TSpasport(Series="0316", Number="556677", Category='A', EnginePower=104.15, Mass=1375)
    let p2 = TSpasport(Series="0666", Number="111111", Category='G', EnginePower=200.0, Mass=2000)
    
    Console.WriteLine(p1>p2)

    let random = System.Random()
    let listOfP = [ for i in 1 .. 1000000 -> TSpasport(Series=Convert.ToString(random.Next(1000,9999)), Number=Convert.ToString(random.Next(100000,999999)), Category='A', EnginePower=104.15, Mass=1375) ]
    
    let Ap = ArrayTS(listOfP)
    let Lp = ListTS(listOfP)
    let Sp = SetTS(listOfP)
    let BLp = BinaryListTS(listOfP)
    let randomp = TSpasport(Series=Convert.ToString(random.Next(1000,9999)), Number=Convert.ToString(random.Next(100000,999999)), Category='A', EnginePower=104.15, Mass=1375)

    let watch = new Stopwatch()
    watch.Start()
    Ap.searchDoc(randomp)
    watch.Stop()
    Console.WriteLine("Массив: {0}", watch.Elapsed)
    watch.Restart()

    let watch = new Stopwatch()
    watch.Start()
    Lp.searchDoc(randomp)
    watch.Stop()
    Console.WriteLine("Массив: {0}", watch.Elapsed)
    watch.Restart()

    let watch = new Stopwatch()
    watch.Start()
    Sp.searchDoc(randomp)
    watch.Stop()
    Console.WriteLine("Массив: {0}", watch.Elapsed)
    watch.Restart()

    let watch = new Stopwatch()
    watch.Start()
    BLp.searchDoc(randomp)
    watch.Stop()
    Console.WriteLine("Массив: {0}", watch.Elapsed)
    watch.Restart()

    Console.WriteLine("Наиболее эффективен класс Лист")

    0
