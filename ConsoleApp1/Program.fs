open System


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


(*  7
let rec nod a b =
    if (a > 0 && b > 0)
    then if (a > b)
            then nod (a%b) b
            else nod a (b%a)
    else if (a = 0) 
         then b
         else a  

let f5 n f init condition = 
    let mutable init = init
    for i in n .. -1 ..1 do
        let isVP = ((nod n i) = 1)
        init <- if (isVP && condition i) then f init i else init
    init

let f4 n f init condition = 
    let mutable init = 0
    for i in n .. -1 ..1 do
        let isDel = ( float (n/i) = ( (float n) / (float i) ) )
        init <- if (isDel && condition i) then f init i else init
    init

[<EntryPoint>]
let main argv =
    let num = 10
    printfn "%b" (9+7 = f5 num (fun x y -> x+y) 0 (fun x -> x > 5))
    printfn "%b" (3*1 = f5 num (fun x y -> x*y) 1 (fun x -> x < 5))
    let num = 11
    printfn "%b" (1+3+5+7+9 = f5 num (fun x y -> x+y) 0 (fun x -> x%2 = 1))
    printfn "%b" (2*4*6*8*10 = f5 num (fun x y -> x*y) 1 (fun x -> x%2 = 0))
    0
    *)

let rec nod a b =
    if (a > 0 && b > 0)
    then if (a > b)
            then nod (a%b) b
            else nod a (b%a)
    else if (a = 0) 
         then b
         else a  

let rec mutSimp init condition func nownum num= 
    if nownum <= 0 then init
    else 
        let isMP = ((nod nownum num) = 1)
        if (isMP && condition (nownum)) 
        then mutSimp (func init nownum) condition func (nownum-1) num
        else mutSimp init condition func (nownum-1) num

let constTrue a = true
let count a b = a+1
let metod1 num = mutSimp 0 constTrue count num num

let rec digOfNum init condition func num =
    if num = 0 then init
    else 
        if (condition (num%10)) 
        then digOfNum (func init (num%10)) condition func (num/10)
        else digOfNum init condition func (num/10)

let div3 a = (0 = (a%3))
let sum a b = a+b
let metod2 num = digOfNum 0 div3 sum num

[<EntryPoint>]
let main argv =
    let num = 10
    printfn "%b" (9+7 = f5 num (fun x y -> x+y) 0 (fun x -> x > 5))
    printfn "%b" (3*1 = f5 num (fun x y -> x*y) 1 (fun x -> x < 5))
    let num = 11
    printfn "%b" (1+3+5+7+9 = f5 num (fun x y -> x+y) 0 (fun x -> x%2 = 1))
    printfn "%b" (2*4*6*8*10 = f5 num (fun x y -> x*y) 1 (fun x -> x%2 = 0))
    0