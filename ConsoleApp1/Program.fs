﻿open System


(*  1
let z1 ovt =
    if ovt = "F#" || ovt = "Prolog"
        then "Сударь, Вы - подлиза."
        else "Не знаю такого."

[<EntryPoint>]
let main argv =
    printfn "Какой твой язык любимый?"
    let s = System.Console.ReadLine()
    printfn "%s" (z1 s)
    0
*)

(*  2
[<EntryPoint>]
let main argv =
    //суперпозиция
    printfn "Какой твой язык любимый?"
    let ifa ovt =if (ovt = "F#" || ovt = "Prolog") then "Сударь, Вы - подлиза." else "Не знаю такого."
    ( ifa  >> printfn "%s")  (System.Console.ReadLine())   

    //каррирование
    printfn "Какой твой язык любимый?"
    let for_true = "Сударь, Вы - подлиза."
    let for_false = "Не знаю такого."
    let ifa ovt t f =if (ovt = "F#" || ovt = "Prolog") then t else f
    let redy = ifa (System.Console.ReadLine())
    printfn "%s" (redy for_true for_false)

    0
*)


(* 3
let rec recmaxn (n, ans) =
    if n = 0 then ans
    else 
        let n1 = n/10
        if (n%10 > ans) then recmaxn (n1, (n%10))
        else recmaxn (n1, ans)

let rec recminn (n, ans) =
    if n = 0 then ans
    else 
        let n1 = n/10
        if (n%10 < ans) then recminn (n1, n%10)
        else recminn (n1, ans)    

let rec proiz n =
    if n = 0 then 1
    else 
        (n%10)*proiz(n/10)

let maxn n = recmaxn (n, (n%10))
let minn n = recminn (n, n%10)

[<EntryPoint>]
let main argv =
    let num = System.Convert.ToInt32(System.Console.ReadLine())
    printfn "%s" ((maxn num).ToString())
    printfn "%s" ((minn num).ToString())
    printfn "%s" ((proiz num).ToString())
    0
*)

(* 4
let f4 n f init = 
    let mutable init = 0
    for i in n .. -1 ..1 do
        let isDel = ( float (n/i) = ( (float n) / (float i) ) )
        init <- if (isDel) then f init i else init
    init


[<EntryPoint>]
let main argv =
    let num = System.Convert.ToInt32(System.Console.ReadLine())
    printfn "%i" (f4 num (fun x y -> x+y) 0)
    0
*)

(*  5
let rec nod a b =
    if (a > 0 && b > 0)
    then if (a > b)
            then nod (a%b) b
            else nod a (b%a)
    else if (a = 0) 
         then b
         else a
    

let f5 n f init = 
    let mutable init = init
    for i in n .. -1 ..1 do
        let isDel = ((nod n i) = 1)
        init <- if (isDel) then f init i else init
    init


[<EntryPoint>]
let main argv =
    let num = System.Convert.ToInt32(System.Console.ReadLine())
    printfn "%i" (f5 num (fun x y -> x+y) 0)
    0
    *)





(*  6
let rec nod a b =
    if (a > 0 && b > 0)
    then if (a > b)
            then nod (a%b) b
            else nod a (b%a)
    else if (a = 0) 
         then b
         else a
    

let f5 n f init = 
    let mutable init = init
    for i in n .. -1 ..1 do
        let isDel = ((nod n i) = 1)
        init <- if (isDel) then f init i else init
    init

let eilerFunc n =
    f5 n (fun x y -> x+1) 0

[<EntryPoint>]
let main argv =
    let num = 10
    printfn "%b" (4 = eilerFunc num)
    printfn "%b" (9+7+3+1 = f5 num (fun x y -> x+y) 0)
    printfn "%b" (9*7*3*1 = f5 num (fun x y -> x*y) 1)
    let num = 11
    printfn "%b" (10 = eilerFunc num)
    printfn "%b" (1+2+3+4+5+6+7+8+9+10 = f5 num (fun x y -> x+y) 0)
    printfn "%b" (1*2*3*4*5*6*7*8*9*10 = f5 num (fun x y -> x*y) 1)
    0
*)