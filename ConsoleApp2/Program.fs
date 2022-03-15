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
