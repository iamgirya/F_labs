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
    printfn "Какой твой язык любимый?"
    let bestLang ovt = (ovt = "F#" || ovt = "Prolog")
    let ifa condition ovt = if (condition ovt) then "Сударь, Вы - подлиза." else "Не знаю такого."
    System.Console.ReadLine() |> ifa bestLang |> printfn "%s"
    0
*)


(* 3
//хвостовая рекурсия
let rec recmaxn (n, ans) =
    if n = 0 then ans
    else 
        let nd =(n/10)
        let no = (n%10)
        if (no > ans) then recmaxn (nd, no)
        else recmaxn (nd, ans)
//хвостовая рекурсия
let rec recminn (n, ans) =
    if n = 0 then ans
    else
        let nd =(n/10)
        let no = (n%10)
        if (no < ans) then recminn (nd, no)
        else recminn (nd, ans)    
// рекурсия вверх
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
let rec realf4 n f init nown =
    let nnown = nown-1

    if nown = 0 then init
    elif ((n % nown) = 0)
    then
        let ninit = (f init nown)
        realf4 n f ninit nnown
    else realf4 n f init nnown

let f4 n (f : int -> int -> int) init = 
    realf4 n f init n

[<EntryPoint>]
let main argv =
    let num = System.Convert.ToInt32(System.Console.ReadLine())
    printfn "%i" (f4 num (fun x y -> x+y) 0)
    0
*)

(* 5
let rec nod a b =
    if (a > 0 && b > 0)
    then if (a > b)
            then nod (a%b) b
            else nod a (b%a)
    else if (a = 0) 
         then b
         else a
    
let rec realf5 n f init nown =
    let nnown = nown-1
    if (nown = 0) then init
    elif ((nod n nown) = 1) 
    then 
        let ninit = (f init nown)
        realf5 n f ninit nnown
    else realf5 n f init nnown

let f5 n f init = 
    realf5 n f init (n-1)

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
    

let rec realf5 n f init nown =
    let nnown = nown-1
    if (nown = 0) then init
    elif ((nod n nown) = 1) 
    then 
        let ninit = (f init nown)
        realf5 n f ninit nnown
    else realf5 n f init nnown

let f5 n f init = 
    realf5 n f init (n-1)

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

(* 7
let rec nod a b =
    if (a > 0 && b > 0)
    then if (a > b)
            then nod (a%b) b
            else nod a (b%a)
    else if (a = 0) 
         then b
         else a  


let rec realf5 n f init nown condition =
    let nnown = nown-1
    if (nown = 0) then init
    elif (((nod n nown) = 1) && condition nown) 
    then 
        let ninit = (f init nown)
        realf5 n f ninit nnown condition
    else realf5 n f init nnown condition

let f5 n f init condition = 
    realf5 n f init (n-1) condition  


let rec realf4 n f init nown conditional =
    if nown = 0 then init
    elif ((n % nown) = 0 && conditional nown)
    then 
        let ninit = (f init nown)
        realf4 n f ninit (nown-1) conditional
    else realf4 n f init (nown-1) conditional
    
let f4 n (f : int -> int -> int) init conditional = 
    realf4 n f init n conditional


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
(*  8-9
let rec nod a b =
    if (a > 0 && b > 0)
    then if (a > b)
            then nod (a%b) b
            else nod a (b%a)
    else if (a = 0) 
         then b
         else a  

let isMS (a, b) = ((nod a b) = 1)
let isDiv (a,b) = ( a%b )
let constTrue a = true
let count a b = a+1
let div3 a = (0 = (a%3))
let sum a b = a+b

let rec mutSimp init condition func nownum num= 
if nownum <= 0 then init
else 
    if (isMS (nownum, num) && condition (nownum)) 
    then 
        let nint = (func init nownum)
        mutSimp nint condition func (nownum-1) num
    else mutSimp init condition func (nownum-1) num


let rec digOfNum init condition func num =
let nnum = num/10
if num = 0 then init
else 
    if (condition (num%10)) 
    then 
        let nint = (func init (num%10))
        digOfNum nint condition func nnum
    else digOfNum init condition func nnum

let rec divOfNum init condition func nownum num= 
if nownum <= 0 then init
else 
    if (isDiv (num,nownum)  && condition (nownum)) 
    then 
        let nint = (func init nownum)
        divOfNum nint condition func (nownum-1) num
    else divOfNum init condition func (nownum-1) num

let countOfMP (div,count) dig = 
    if (isMS(div, dig)) then (div,count+1) 
    else (div,count)

let mostMPWithDigs (num, oldDiv, oldCount) div = 
    let countOfdiv = snd (digOfNum (div,0) constTrue countOfMP num)
    if (countOfdiv > oldCount) then (num, div, countOfdiv)
    else (num, oldDiv,oldCount)


let metod1 num = mutSimp 0 constTrue count num num
let metod2 num = digOfNum 0 div3 sum num
let metod3 num = 
    let (_,div,_) = (divOfNum (num, 0, 0) constTrue mostMPWithDigs num num)
    div

[<EntryPoint>]
let main argv =
    let num = 10
    printfn "%b" (4 = metod1 num)
    let num = 123456
    printfn "%b" (3+6 = metod2 num)
    let num = 12
    printfn "%b" (3 = metod3 num)
    0
*)

(* 10
let rec nod a b =
    if (a > 0 && b > 0)
    then if (a > b)
            then nod (a%b) b
            else nod a (b%a)
    else if (a = 0) 
         then b
         else a  

let isMS (a, b) = ((nod a b) = 1)
let isDiv (a,b) = ( float (a/b) = ( (float a) / (float b) ) )
let constTrue a = true
let count a b = a+1
let div3 a = (0 = (a%3))
let sum a b = a+b

let rec mutSimp init condition func nownum num= 
    if nownum <= 0 then init
    else 
        if (isMS (nownum, num) && condition (nownum)) 
        then 
            let nint = (func init nownum)
            mutSimp nint condition func (nownum-1) num
        else mutSimp init condition func (nownum-1) num


let rec digOfNum init condition func num =
    let nnum = num/10
    if num = 0 then init
    else 
        if (condition (num%10)) 
        then 
            let nint = (func init (num%10))
            digOfNum nint condition func nnum
        else digOfNum init condition func nnum

let rec divOfNum init condition func nownum num= 
    if nownum <= 0 then init
    else 
        if (isDiv (num,nownum)  && condition (nownum)) 
        then 
            let nint = (func init nownum)
            divOfNum nint condition func (nownum-1) num
        else divOfNum init condition func (nownum-1) num

let countOfMP (div,count) dig = 
    if (isMS(div, dig)) then (div,count+1) 
    else (div,count)

let mostMPWithDigs (num, oldDiv, oldCount) div = 
    let countOfdiv = snd (digOfNum (div,0) constTrue countOfMP num)
    if (countOfdiv > oldCount) then (num, div, countOfdiv)
    else (num, oldDiv,oldCount)


let metod1 num = mutSimp 0 constTrue count num num
let metod2 num = digOfNum 0 div3 sum num
let metod3 num = 
    let (_,div,_) = (divOfNum (num, 0, 0) constTrue mostMPWithDigs num num)
    div


let multimetod num =
    if (num = 1)
    then metod1
    else if (num = 2)
    then metod2
    else metod3

[<EntryPoint>]
let main argv =
    let input = (System.Convert.ToInt32(System.Console.ReadLine()), System.Convert.ToInt32(System.Console.ReadLine()))
    snd input |> (fst input |> multimetod) |> printfn "%i"
    0
*)