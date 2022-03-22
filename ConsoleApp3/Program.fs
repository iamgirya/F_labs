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

*)

(* 4
1.32
Дан целочисленный массив. Найти количество его локальных
максимумов.

*)

(* 5
1.42
Дан целочисленный массив. Найти все элементы, которые меньше
среднего арифметического элементов массива.

*)

(*  6
1.52. Для введенного числа построить список всех его простых делителей,
причем если введенное число делится на простое число p в степени α , то в
итоговом списке число p должно повторятся α раз. Результирующий список
должен быть упорядочен по возрастанию.

*)

(* 7

*)

(*  8

*)

(*  9

*)

(* 10

*)

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