open System

type Animal(noiseMakingStrategy) =
    member this.MakeNoise =
        noiseMakingStrategy ()
        |> printfn "making noise %s"

let meowing () = "Meow"
let cat = Animal(meowing)
cat.MakeNoise

let woofOrBark () =
    if (DateTime.Now.Second % 2 = 0) then
        "woof"
    else
        "bark"

let dog = Animal(woofOrBark)
dog.MakeNoise
