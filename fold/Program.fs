open System

let print x = printfn "%A" x

let product n =
    let initialValue = 1
    let action productSoFar x = productSoFar * x
    [ 1..n ] |> List.fold action initialValue

let sumOfOdds n =
    let initialValue = 0

    let action sumSoFar x =
        if x % 2 = 1 then
            sumSoFar + x
        else
            sumSoFar

    [ 1..n ] |> List.fold action initialValue


let alternatingSum n =
    let initialValue = (true, 0) // a tuple

    let action (isNeg, sumSoFar) x =
        if isNeg then
            (false, sumSoFar - x)
        else
            (true, sumSoFar + x)

    [ 1..n ] |> List.fold action initialValue |> snd


type NameAndSize = { Name: string; Size: int }

let maxNameAndSize l =
    let innerMaxNameAndSize initialValue rest =
        let action maxSoFar x =
            if maxSoFar.Size < x.Size then
                x
            else
                maxSoFar

        rest |> List.fold action initialValue

    // handle empty lists
    match l with
    | [] -> None
    | first :: rest ->
        let max = innerMaxNameAndSize first rest
        Some max

// F# already has maxBy function
let maxNameAndSizeBuiltIn l =
    match l with
    | [] -> None
    | _ ->
        let max = l |> List.maxBy (fun x -> x.Size)
        Some max

print (maxNameAndSize [])

let test_list =
    [ { Name = "henry"; Size = 69 }
      { Name = "henryVIII"; Size = 5111 } ]

print (maxNameAndSize test_list)

print (maxNameAndSizeBuiltIn test_list)
print (maxNameAndSizeBuiltIn [])
