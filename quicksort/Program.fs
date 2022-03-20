let rec quicksort l =
    match l with
    | [] -> [] // if the list is empty
    | firstElem :: otherElements -> // if the list is not empty,
        let smallerElements =
            otherElements
            |> List.filter (fun e -> e < firstElem)
            |> quicksort

        let largerElements =
            otherElements
            |> List.filter (fun e -> e >= firstElem)
            |> quicksort

        List.concat [ smallerElements
                      [ firstElem ]
                      largerElements ]


let ric quicksort2 =
    function
    | [] -> []
    | first :: rest ->
        let smaller, larger = List.partition ((>=) first) rest

        List.concat [ quicksort2 smaller
                      [ first ]
                      quicksort2 larger ]

printfn "%A" (quicksort [ 1; 5; 23; 18; 9; 1; 3 ])
