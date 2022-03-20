open System

let userTimerWithCallback =
    // create a timer and associated async event
    let timer = new System.Timers.Timer(2000.0)
    let timerEvent = Async.AwaitEvent(timer.Elapsed) |> Async.Ignore

    // start
    printfn "Waiting for timer at %O" DateTime.Now.TimeOfDay
    timer.Start()

    // keep working
    printfn "Doing something useful while waiting for event"

    // block on the timer event now by waiting for the async to complete
    Async.RunSynchronously timerEvent

    // done
    printfn "Timer ticked at %O" DateTime.Now.TimeOfDay

let fileWriteWithAsync =

    // create a stream to write to
    use stream = new System.IO.FileStream("test.txt", System.IO.FileMode.Create)

    // start
    printfn "Starting async write"
    let asyncResult = stream.BeginWrite(Array.empty, 0, 0, null, null)

    // create an async wrapper around an IAsyncResult
    let async =
        Async.AwaitIAsyncResult(asyncResult)
        |> Async.Ignore

    // keep working
    printfn "Doing something useful while waiting for write to complete"

    // block on the timer now by waiting for the async to complete
    Async.RunSynchronously async

    // done
    printfn "Async write completed"
