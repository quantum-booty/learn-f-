// a record represent an aggregate of named values
type Person = { Name: string; Age: int }
// can augment a record to have 
type Person with
    member x.Info = (x.Name, x.Age)
    member x.happpyBirthday() =
        let new_age = x.Age + 1
        { Name = x.Name; Age = new_age }

let henry = { Name = "Henry"; Age = 18 }
let henryVIII = {henry with Name = "Henry VIII"}

printfn "%A" henry.Info
printfn "%A" (henry.happpyBirthday())
