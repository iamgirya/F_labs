open System

// Агент выводит лишь маленькие буквы сообщения
let printerAgent = MailboxProcessor.Start(fun inbox->
    // обработка сообщений
    let rec messageLoop() = async{
        // чтение сообщения
        let! msg = inbox.Receive()
        // печать сообщения
        Console.WriteLine("Новое сообщение: " + String.filter (fun x -> Char.IsLower x) msg)
        return! messageLoop()
        }
        // запуск обработки сообщений
    messageLoop()

    )
[<EntryPoint>]
let main argv =
    let arg1 = printerAgent.Post("КаБы Не БыЛо ЗиМы - а всё время ЛЕТО.")
    let arg2 = printerAgent.Post("Ну что сказать, ну что сказать!")
    Console.ReadKey()
    0 // return an integer exit code