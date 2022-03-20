// modules are static classes under the hooooood
// good practice to add top level module declaration to the top of the file
module AllTheThings

let doStuff x = x

// nested modules
module MathStuff =
    let add x y = x + y

    // can have nested modules
    module FloatLib =
        let add x y : float = x + y

module OtherStuff =
    let add1 x = MathStuff.add x 1

    // in order to access nested modules, can use full name or open keyword
    open MathStuff
    let a = FloatLib.add 2.0 2.0
    let b = MathStuff.FloatLib.add 2.0 2.0

// need to add the new file to fsproj to be compiled
TheThing.doTheThing()

// using namespace
printfn "%A" Namespace.Module.a
printfn "%A" Namespace.SubNamespace.Module.a
