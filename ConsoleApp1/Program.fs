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
    
