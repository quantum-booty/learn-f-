// throw exception
let divideFailwith x y =
    if y = 0 then
        failwith "Division by zero"
    else
        x / y

// custom exception
exception InnerError of string
exception OuterError of string

let handleErrors x y =
    try
        try
            if x = y then
                raise (InnerError("inner"))
            else
                raise (OuterError("outer"))
        with
        | InnerError (str) -> printfn "Error1 %s" str
    finally
        printfn "Always print this."
