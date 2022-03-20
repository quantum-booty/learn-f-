let print x = printfn "%A" x

let rec sum list =
    match list with
    | [] -> 0
    | x :: xs -> x + sum xs

let sumByReduce list = list |> List.reduce (fun a b -> a + b)

[ 1; 2; 3 ] |> sum |> print
[ 1; 2; 3 ] |> sumByReduce |> print

let tryFind predicate vs =
    let rec loop =
        function
        | v :: vs -> if predicate v then Some v else loop vs
        | _ -> None

    loop vs

let rec movingAverages list =
    match list with
    // if input is empty, return an empty list
    | [] -> []
    | [ x ] -> [ x ]
    // otherwise process pairs of items from the input
    | x :: y :: rest ->
        let avg = (x + y) / 2.0
        //build the result by recursing the rest of the list
        avg :: movingAverages (y :: rest)

let rec test i =
    match i with
    | 1 -> 2
    | 2 -> 3
    | n -> test (n - 2) * test (n - 1)

let rec fib i =
    match i with
    | 1 -> 1
    | 2 -> 1
    | n -> fib (n - 1) + fib (n - 2)

let sumNumberUpTo max =
    let rec recursiveSum n sumSoFar =
        match n with
        | 0 -> sumSoFar
        | _ -> recursiveSum (n - 1) (n + sumSoFar)

    recursiveSum max 0

printfn "%A" (sumNumberUpTo 10)
