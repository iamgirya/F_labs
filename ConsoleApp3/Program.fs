open System


(*  1
1.2
Дан целочисленный массив. Необходимо найти индекс
минимального элемента.

let rec readList n = 
    if n=0 then []
    else
    let Head = System.Convert.ToInt32(System.Console.ReadLine())
    let Tail = readList (n-1)
    Head::Tail

[<EntryPoint>]
let main argv =
    let list1 = System.Convert.ToInt32(System.Console.ReadLine()) |> readList
    let min = List.fold (fun x y -> if (x>y) then y else x) list1.Head list1
    printf "%i" (List.findIndex (fun x -> x = min) list1)
    0
*)

(*  2
1.12
Дан целочисленный массив. Необходимо переставить в обратном
порядке элементы массива, расположенные между его минимальным и
максимальным элементами.

let rec readList n = 
    if n=0 then []
    else
    let Head = System.Convert.ToInt32(System.Console.ReadLine())
    let Tail = readList (n-1)
    Head::Tail

let rec writeList list = 
    match list with
    [] ->
        0
    | (head : int)::tail -> 
        System.Console.WriteLine(head)
        writeList tail  

[<EntryPoint>]
let main argv =
    let list1 = System.Convert.ToInt32(System.Console.ReadLine()) |> readList
    let minInd = 
        let min = (List.fold (fun x y -> if (x>y) then y else x) list1.Head list1)
        List.findIndex (fun x -> x = min) list1 
    let maxInd = 
        let max =List.fold (fun x y -> if (x>y) then x else y) list1.Head list1
        List.findIndex (fun x -> x = max) list1 
    if (minInd < maxInd) 
    then
        let (firstPart,middleLastPart) = List.splitAt (minInd+1) list1
        let (middlePart,lastPart) = List.splitAt (maxInd-minInd-1) middleLastPart
        let finalList = (List.append (List.append firstPart (List.rev middlePart)) lastPart)
        writeList finalList
    else
        let (firstPart,middleLastPart) = List.splitAt (maxInd+1) list1
        let (middlePart,lastPart) = List.splitAt (minInd-maxInd-1) middleLastPart
        let finalList = (List.append (List.append firstPart (List.rev middlePart)) lastPart)
        writeList finalList
*)

(* 3
1.22
Дан целочисленный массив и интервал a..b. Необходимо найти
количество минимальных элементов в этом интервале.

let rec readList n = 
    if n=0 then []
    else
    let Head = System.Convert.ToInt32(System.Console.ReadLine())
    let Tail = readList (n-1)
    Head::Tail

[<EntryPoint>]
let main argv =
    let list1 = System.Convert.ToInt32(System.Console.ReadLine()) |> readList
    let (a,b) = (System.Convert.ToInt32(System.Console.ReadLine()), System.Convert.ToInt32(System.Console.ReadLine()))
    let min = List.fold (fun x y -> if (x>y) then y else x) list1.Head list1

    let (firstPart,middleLastPart) = List.splitAt (a) list1
    let (middlePart,lastPart) = List.splitAt (b-a+1) middleLastPart

    printf "%i" (List.fold (fun x y -> if (y = min) then x+1 else x) 0 middlePart)
    0
*)

(* 4
1.32
Дан целочисленный массив. Найти количество его локальных
максимумов.

let rec readList n = 
    if n=0 then []
    else
    let Head = System.Convert.ToInt32(System.Console.ReadLine())
    let Tail = readList (n-1)
    Head::Tail

[<EntryPoint>]
let main argv =
    let list1 = System.Convert.ToInt32(System.Console.ReadLine()) |> readList
    let min = List.min list1
    let movedBackOne = List.append [min] (List.take (list1.Length-1) list1) 
    let movedNextOne = List.append (List.skip 1 list1) [min]

    let tripleList = List.map3 (fun x y z -> if (x<y && y > z) then 1 else 0) movedBackOne list1 movedNextOne
    printf "%i" (List.fold (fun x y -> if (y=1) then x+1 else x) 0 tripleList)
    0
*)

(* 5
1.42
Дан целочисленный массив. Найти все элементы, которые меньше
среднего арифметического элементов массива.

let rec readList n = 
    if n=0 then []
    else
    let Head = System.Convert.ToDouble(System.Console.ReadLine())
    let Tail = readList (n-1)
    Head::Tail

let rec writeList list = 
    match list with
    [] ->
        0
    | (head:float)::tail -> 
        System.Console.WriteLine(head)
        writeList tail  

[<EntryPoint>]
let main argv =
    let list1 = System.Convert.ToInt32(System.Console.ReadLine()) |> readList
    let avg = List.average list1
    writeList (List.filter (fun x -> if (x < avg) then true else false) list1)
*)

(*  6
1.52. Для введенного числа построить список всех его простых делителей,
причем если введенное число делится на простое число p в степени α , то в
итоговом списке число p должно повторятся α раз. Результирующий список
должен быть упорядочен по возрастанию.


let allDelToList number =
    let rec delFounder num del =
        if num <= 1 then []
        else 
            let new_del = del+1
            if num % del =0 then del::(delFounder (num/del) del)                        
            else delFounder num new_del  
    delFounder number 2

let rec writeList list = 
    match list with
    [] ->
        0
    | (head:int)::tail -> 
        System.Console.WriteLine(head)
        writeList tail  

[<EntryPoint>]
let main argv =
    let number = System.Convert.ToInt32(System.Console.ReadLine())
    writeList (allDelToList number)
*)

(* 7
2 Дан список, построить кортеж, содержащий пять списков, при этом
- первый список содержит результат деления на два только четных
элементов исходного,
- второй список содержит результат деления на три только тех элементов
первого, которые делятся на три,
- третий список содержит квадраты значений второго списка,
- четвертый список содержит только те элементы третьего, которые
встречаются в первом,
- пятый список содержит все элементы второго, третьего и четвертого
списков.

let rec readList n = 
    if n=0 then 
        System.Console.WriteLine()
        []
    else
    let Head = System.Convert.ToInt32(System.Console.ReadLine())
    let Tail = readList (n-1)
    Head::Tail

let rec writeList list = 
    match list with
    [] ->
        System.Console.WriteLine()
        0
    | (head:int)::tail -> 
        System.Console.WriteLine(head)
        writeList tail  


let buildCort list =
    let fslist = List.map (fun x -> x/2) (List.filter (fun x -> x%2 = 0) list)
    let twlist = List.map (fun x -> x/3) (List.filter (fun x -> x%3 = 0) list)
    let thlist = List.map (fun x -> x*x) twlist
    let folist = List.filter (fun x -> (List.tryFind (fun y -> x = y) fslist).IsSome ) thlist
    let filist = List.append (List.append twlist thlist) folist
    (fslist, twlist,thlist,folist,filist)

[<EntryPoint>]
let main argv =
    let list1 = System.Convert.ToInt32(System.Console.ReadLine()) |> readList
    let finalCort = buildCort list1
    let (l1, l2,l3,l4,l5) = finalCort
    ignore (writeList l1)
    ignore (writeList l2)
    ignore (writeList l3)
    ignore (writeList l4)
    writeList l5
*)

(*  8
2 Дан массив А [1; 2; 3;] и массив B [4; 5; 7] скопировать
последний элемент массива В в массив А.

let writeArray arr = 
    let rec realWriteArray (arr : 'T [] ) (ind : int)=
        if (ind = arr.Length) then ()
        else
            let nextind = ind+1
            System.Console.WriteLine( arr.[ind] )
            realWriteArray arr nextind
    realWriteArray arr 0

[<EntryPoint>]
let main argv =
    let А = [|1; 2; 3;|]
    let B = [|4; 5; 7|]
    let C = Array.append А ([| B.[0] |])
    writeArray C
    0
*)

(*  9
2 
Дана строка, состоящая из символов латиницы. Необходимо
проверить, упорядочены ли строчные символы этой строки по
возрастанию.
10
Дана строка. Необходимо подсчитать количество букв "А" в этой
строке.
17
Дана строка в которой записан путь к файлу. Необходимо найти
имя файла без расширения.

*)

(* 10
2
В порядке увеличения среднего веса ASCII-кода символа строки
5
В порядке увеличения квадратичного отклонения частоты встре-
чаемости самого часто встречаемого в строке символа от частоты его встре-
чаемости в текстах на этом алфавите

*)
let metod1 str =
    let justLower = String.filter (fun x -> Char.IsLower x) str
    let rec isOrder (str: string) ind =
        if (ind = str.Length-1) then true
        else
            if (str.[ind] <= str.[ind+1]) then isOrder str (ind+1)
            else false
    isOrder justLower 0

let metod2 str =
    let justA = String.filter (fun x -> x = 'A') str
    justA.Length

let metod3 str =
    let rec takeBackWhile (str: string) separator ind =
        if (ind = -1) then str
        else
            if (str.[ind] = separator) then str.[(ind+1)..]
            else takeBackWhile str separator (ind-1)
    let rec takeWhile (str: string) separator ind =
        if (ind = str.Length) then str
        else
            if (str.[ind] = separator) then str.[..(ind-1)]
            else takeWhile str separator (ind+11)

    let justFile = takeBackWhile str '\\' (str.Length-1)
    takeWhile justFile '.' 0

[<EntryPoint>]
let main argv =
    0