let printerAgent =
    MailboxProcessor.Start (fun inbox ->
        let rec messageLoop () =
            async {
                let! msg = inbox.Receive()
                printfn "message is: %s" msg
                return! messageLoop ()
            }

        messageLoop ())

printerAgent.Post "hello"
printerAgent.Post "hello again"
printerAgent.Post "hello hello hello hello"
