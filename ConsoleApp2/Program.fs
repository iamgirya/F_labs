open System

(* 11

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

let rec funcTri list (f : int -> int -> int -> int)=
    match list with
    [] ->
        []
    | head1 :: head2:: head3:: tail -> 
        (f head1 head2 head3) :: (funcTri tail f)
    | head1 :: head2 :: tail -> 
        (f head1 head2 1) :: (funcTri tail f)
    | head1 :: tail -> 
        (f head1 1 1) :: (funcTri tail f)


[<EntryPoint>]
let main argv =
    let testList = System.Convert.ToInt32(System.Console.ReadLine()) |> readList
    let newTestList = funcTri testList (fun x y z -> x+y+z)
    System.Console.WriteLine()
    writeList newTestList

*)

(* 12

let rec inputList n =
    if n=0 then []
    else  
    System.Convert.ToInt32(System.Console.ReadLine()) :: (inputList (n-1))

let rec funcAcc list (f : int -> int -> int) (p: int-> bool) acc =
    match list with
    [] ->
        acc
    | (head : int)::tail -> 
        if (p head) then funcAcc tail f p (f acc head) 
        else funcAcc tail f p acc

let foundMax list =
    funcAcc list (fun x y -> if (y>x) then y else x) (fun x -> true) Int32.MinValue

let foundCountAfterMax list =
    let max =  foundMax list
    funcAcc list (fun x y -> if (y = max) then 0 elif (x <> -1) then (x+1) else -1) (fun x -> true) -1

[<EntryPoint>]
let main argv =
//1.1 Дан целочисленный массив. Необходимо найти количество элементов, расположенных после последнего максимального.
    let testList = System.Convert.ToInt32(System.Console.ReadLine()) |> inputList 
    printfn "%i" (foundCountAfterMax testList)
    0

*)


(* 13

let rec inputList n =
    if n=0 then []
    else  
    System.Convert.ToInt32(System.Console.ReadLine()) :: (inputList (n-1))

let rec outList list = 
    match list with
    [] ->   
        let z = System.Console.ReadKey()
        0
    | (head : int)::tail -> 
        System.Console.WriteLine(head)
        outList tail  

let rec funcAcc list f  (p: int-> bool) acc =
    match list with
    [] ->
        acc
    | (head : int)::tail -> 
        if (p head) then funcAcc tail f p (f acc head) 
        else funcAcc tail f p acc

let foundMax list =
    funcAcc list (fun x y -> if (y>x) then y else x) (fun x -> true) Int32.MinValue
let foundMin list =
    funcAcc list (fun x y -> if (y<x) then y else x) (fun x -> true) Int32.MaxValue

let rec foundIndOfElem list elem index =
    match list with
    [] ->
        -1
    | (head : int)::tail -> 
        if (head = elem) then index 
        else foundIndOfElem tail elem (index+1)
    

let rec foundPart listik stopIndex nowIndex=
    match listik with
    [] ->
        []
    | (head : int)::tail -> 
        if (nowIndex = stopIndex) then 
            []
        else head :: (foundPart tail stopIndex (nowIndex+1))

let rec foundEnd listik stopIndex nowIndex=
    match listik with
    [] ->
        []
    | (head : int)::tail -> 
        if (nowIndex = stopIndex) then 
            head :: tail
        else (foundEnd tail stopIndex (nowIndex+1))



let rec reverseListFromTo list indexFrom indexTo nowIndex=
    match list with
    [] ->
        []
    | (head : int)::tail -> 
        if (nowIndex = indexFrom) then 
            let reversePart = foundPart tail indexTo (nowIndex+1) 
            let reversePart = List.rev reversePart
            let endPart = foundEnd tail indexTo (nowIndex+1) 
            head :: (List.append reversePart endPart)
             
        else head :: (reverseListFromTo tail indexFrom indexTo (nowIndex+1))



let reversePartBetweenMinAndMax list =
    let minI = foundIndOfElem list (foundMin list) 0
    let maxI = foundIndOfElem list (foundMax list) 0
    if (minI > maxI) then
        reverseListFromTo list maxI minI 0
    else
        reverseListFromTo list minI maxI 0
    
[<EntryPoint>]
let main argv =
//1.12 Дан целочисленный массив. Необходимо переставить в обратном 
//порядке элементы массива, расположенные между его минимальным и
//максимальным элементами.
    let testList = System.Convert.ToInt32(System.Console.ReadLine()) |> inputList 
    outList (reversePartBetweenMinAndMax testList)
    0

*)

(* 14

let rec inputList n =
    if n=0 then []
    else  
    System.Convert.ToInt32(System.Console.ReadLine()) :: (inputList (n-1))

let rec outList list = 
    match list with
    [] ->   
        let z = System.Console.ReadKey()
        0
    | (head : int)::tail -> 
        System.Console.WriteLine(head)
        outList tail  

let rec funcAcc list f  (p: int-> bool) (acc:int) =
    match list with
    [] ->
        acc
    | (head : int)::tail -> 
        if (p head) then funcAcc tail f p (f acc head) 
        else funcAcc tail f p acc

let countBetweensAB list a b=
    funcAcc list (fun x y -> x+1) (fun x -> x > a && x < b) 0
    
[<EntryPoint>]
let main argv =
//1.14
//Дан целочисленный массив и интервал a..b. Необходимо найти
//количество элементов в этом интервале.
    let (a,b) = System.Convert.ToInt32(System.Console.ReadLine()) ,System.Convert.ToInt32(System.Console.ReadLine())
    let testList = System.Convert.ToInt32(System.Console.ReadLine()) |> inputList 
    printfn "%i" (countBetweensAB testList a b)
    0

*)

(* 15

*)

(* 16

*)

(* 17

*)

(* 18

*)

(* 19

*)

(* 20

*)

let rec inputList n =
    if n=0 then []
    else  
    System.Convert.ToInt32(System.Console.ReadLine()) :: (inputList (n-1))

let rec outList list = 
    match list with
    [] ->   
        let z = System.Console.ReadKey()
        0
    | (head : int)::tail -> 
        System.Console.WriteLine(head)
        outList tail  

let rec funcAcc list f  (p: int-> bool) (acc:int) =
    match list with
    [] ->
        acc
    | (head : int)::tail -> 
        if (p head) then funcAcc tail f p (f acc head) 
        else funcAcc tail f p acc

let countBetweensAB list a b=
    funcAcc list (fun x y -> x+1) (fun x -> x > a && x < b) 0
    
[<EntryPoint>]
let main argv =
//1.14
//Дан целочисленный массив и интервал a..b. Необходимо найти
//количество элементов в этом интервале.
    let (a,b) = System.Convert.ToInt32(System.Console.ReadLine()) ,System.Convert.ToInt32(System.Console.ReadLine())
    let testList = System.Convert.ToInt32(System.Console.ReadLine()) |> inputList 
    printfn "%i" (countBetweensAB testList a b)
    0