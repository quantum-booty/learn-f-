open System

let (|Int|_|) str =
    match Int32.TryParse(str: string) with
    | (true, int) -> Some(int)
    | _ -> None

let (|Bool|_|) str =
    match Boolean.TryParse(str: string) with
    | (true, bool) -> Some(bool)
    | _ -> None

let testParse str =
    match str with
    | Int i -> printfn "The value is an int '%i'" i
    | Bool b -> printfn "The value is an bool '%b'" b
    | _ -> printfn "The value '%s' is something eles" str

testParse "12"
testParse "true"
testParse "abc"

open System.Text.RegularExpressions

let (|FirstRegexGroup|_|) pattern input =
    let m = Regex.Match(input, pattern)

    if (m.Success) then
        Some m.Groups[1].Value
    else
        None

let testRegex str =
    match str with
    | FirstRegexGroup "http://(.*?)/(.*)" host -> printfn "The value is a url and the host is %s" host
    | FirstRegexGroup ".*?@(.*)" host -> printfn "The value is an email and the host is %s" host
    | _ -> printfn "The value '%s' is something else" str

testRegex "http://google.com/test"
testRegex "alice@hotmail.com"


// Parameterised active patterns

let (|DivisibleBy|_|) by i =
    if i % 3 = 0 then Some DivisibleBy else None

let fizzBuzz i =
    match i with
    | DivisibleBy 3 & DivisibleBy 5 -> printfn "FizzBuzz"
    | DivisibleBy 3 -> printfn "Fizz"
    | DivisibleBy 5 -> printfn "Buzz"
    | _ -> printfn "%i" i

[ 1..1000 ] |> List.iter fizzBuzz


// Complete active patterns
let (|Even|Odd|) i =
    if i % 2 = 0 then Even else Odd
