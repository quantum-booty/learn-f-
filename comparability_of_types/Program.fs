type Suit =
    | Club
    | Diamond
    | Spade
    | Heart

type Rank =
    | Two
    | Three
    | Four
    | Five
    | Six
    | Seven
    | Eight
    | Nine
    | Ten
    | Jack
    | Queen
    | King
    | Ace

let compareCard card1 card2 =
    if card1 < card2 then
        printfn "%A is greater than %A" card2 card1
    else
        printfn "%A is greater than %A" card1 card2

let hand =
    [ Club, Ace
      Heart, Three
      Heart, Ace
      Spade, Jack
      Diamond, Two
      Diamond, Ace ]

//instant sorting!
List.sort hand
|> printfn "sorted hand is (low to high) %A"

List.max hand |> printfn "high card is %A"
List.min hand |> printfn "low card is %A"
