open System
// 4 5 6 7

[<AbstractClass>]
type GeometryFigure() =
    abstract member Square: unit -> double
    abstract member Pi: double
    default this.Pi = 3.14

type IPrint = interface
    abstract member Print: unit -> unit
    end

type Rectangle(h:double, w:double) =
    inherit GeometryFigure()
    let mutable heigth = h
    let mutable width = w
    member this.Heigth
        with get() = heigth
        and set(value) = heigth <- value
    member this.Width
        with get() = width
        and set(value) = width <- value
    override this.Square() = (width*heigth)
    override this.ToString() = "Прямоугольник со сторонами " + Convert.ToString(heigth) + " и " + Convert.ToString(width) + " с площадью равной " + Convert.ToString(this.Square())
    interface IPrint with
        member this.Print() = Console.WriteLine(this.ToString())
        end

type Box(a:double, b:double) =
    inherit Rectangle(a,a)
    let mutable side = a
    new(a:double) = Box(a,a)
    override this.ToString() = "Квадрат со стороной " + Convert.ToString(a) + " с площадью равной " + Convert.ToString(this.Square())
    interface IPrint with
        member this.Print() = Console.WriteLine(this.ToString())
        end
                            
type Round(r:double) =
    inherit GeometryFigure()
    let mutable radius = 0.0
    member this.Radius
        with get() = radius
        and set(value) = radius <- value
    override this.Square() = this.Pi*radius*radius
    override this.ToString() = "Круг с радиусом " + Convert.ToString(radius) + " с площадью равной " + Convert.ToString(this.Square())
    interface IPrint with
        member this.Print() = Console.WriteLine(this.ToString())
        end

type Figuries =
 | Rectangle of double * double
 | Box of double
 | Round of double
 
let GetSquare (a: Figuries) =
    match a with
    Rectangle(a,b) -> a*b
    | Box(a) -> a*a
    | Round(r) -> r*r*Math.PI


[<EntryPoint>]
let main argv =
    let rect = new Box(5.0)
    Console.WriteLine(rect.Square())
    Console.WriteLine(rect.ToString())
    let rect2 = Rectangle(5.0,10.0)
    Console.WriteLine(GetSquare(rect2))

    0
