let makeResource name =
   { new System.IDisposable
     with member this.Dispose() = printfn "%s disposed" name }

let yourmom = makeResource "your mom is"
printfn "%A" yourmom
