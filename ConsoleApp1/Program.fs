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


[<EntryPoint>]
let main argv =
    let num = System.Convert.ToInt32(System.Console.ReadLine())
    printfn "%s" ((maxn num).ToString())
    printfn "%s" ((minn num).ToString())
    printfn "%s" ((proiz num).ToString())
    0