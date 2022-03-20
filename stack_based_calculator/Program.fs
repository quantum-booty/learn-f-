type Stack = StackContents of float list

let push x (StackContents contents) = StackContents(x :: contents)

let EMPTY = StackContents []
let ZERO = push 0.0
let ONE = push 1.0
let TWO = push 2.0
let THREE = push 3.0
let FOUR = push 4.0
let FIVE = push 5.0
let SIX = push 6.0
let SEVEN = push 7.0
let EIGHT = push 8.0
let NINE = push 9.0

let pop (StackContents content) =
    match content with
    | top :: rest ->
        let newStack = StackContents rest
        (top, newStack)
    | [] -> failwith "Stack underflow"

let binary mathFn stack =
    let x, stack' = pop stack
    let y, stack'' = pop stack'
    let result = mathFn x y
    push result stack''

let ADD aStack = binary (+) aStack
let MUL aStack = binary (*) aStack
let DIV aStack = binary (/) aStack

let unary f stack =
    let x, stack' = pop stack
    push (f x) stack'

let NEG = unary (fun x -> -x)
let SQUARE = unary (fun x -> x * x)

let SHOW stack =
    let x, _ = pop stack
    printfn "The answer is %f" x
    stack

EMPTY
|> ONE
|> THREE
|> ADD
|> TWO
|> MUL
|> SHOW
|> ignore // (1+3)*2 = 8
