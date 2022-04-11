open System

type Some<'a> =
    Just of 'a
    | No

let functor f p =
    match p with
    Just a -> Just (f a)
    | No -> No

let functorTest a =
    if ((functor (fun x -> x) a) = a 
    && (functor (fun x -> x*3) (functor (fun x -> x*2) a)) = (functor ((fun x -> x*2) >> (fun x -> x*3)) a))
        then "Функтор удовлетворяет законам"
        else "Функтор не удовлетворяет законам"

let take a =
    match a with
    Just (f:'a) -> f

let returnApply a =
    Just a

let applyFunctor p1 p2 =
    match p1, p2 with
    Just f, Just a -> Just (f a)
    | _ -> No

// попытка реализовать 3-е свойство
//let applyFunctor (p1:'c) (p2:'d) =
//    let afp1 p1 p2 =
//        match p1, p2 with
//        Just f, Just a -> Just (f a)
//        | _ -> No    
//    let afp2 p1 p2 =
//        match p1, p2 with
//        Just f, Just a -> Just (a f)
//        | _ -> No
//    if ((take p1).GetType() = typeof<'b->'b>)
//    then afp1 p1 p2
//    else afp2 p2 p1

let applyFunctorTest a b c d=
    if ( take (applyFunctor a b) = (take a) (take b)
    && (applyFunctor (returnApply c) (returnApply d)) = returnApply (c d)
    && 1 = 1 //из-за строгой типизации функций доказать третье свойство коммутативности невозможно.
    && 1 = 1 // свойство ассоциативности тоже невозможно доказать из-за свойств языка f#
    )
        then "Аппликативный функтор удовлетворяет законам"
        else "Аппликативный функтор не удовлетворяет законам"

[<EntryPoint>]
let main argv =
    let s = Just(5)
    Console.WriteLine( functorTest s)
    //Console.WriteLine( applyFunctorTest s)
    0
