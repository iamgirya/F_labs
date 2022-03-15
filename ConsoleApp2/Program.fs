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

*)

(* 14

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