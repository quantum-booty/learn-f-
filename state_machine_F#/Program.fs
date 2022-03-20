type CartItem = string

type EmptyState = NoItems
type ActiveState = { UnpaidItems: CartItem list }

type PaidForState =
    { PaidItems: CartItem list
      Payment: decimal }

// the Card is a union of three states
type Cart =
    | Empty of EmptyState
    | Active of ActiveState
    | PaidFor of PaidForState


// operations on empty state
let addToEmptyState item =
    // returns a new Active Cart
    Cart.Active { UnpaidItems = [ item ] }

// operations on active state
let addToActiveState state itemToAdd =
    let newList = itemToAdd :: state.UnpaidItems
    Cart.Active { state with UnpaidItems = newList }

let removeFromActiveState state itemToRemove =
    let newList =
        state.UnpaidItems
        |> List.filter (fun i -> i <> itemToRemove)

    match newList with
    | [] -> Cart.Empty NoItems
    | _ -> Cart.Active { state with UnpaidItems = newList }

let payForActiveState state amount =
    Cart.PaidFor
        { PaidItems = state.UnpaidItems
          Payment = amount }

// attach these functions to the states as methods
type EmptyState with
    member this.Add = addToEmptyState

type ActiveState with
    member this.Add = addToActiveState this
    member this.Remove = removeFromActiveState this
    member this.Pay = payForActiveState this

// cart level functions
let addItemToCart cart item =
    match cart with
    | Empty state -> state.Add item
    | Active state -> state.Add item
    | PaidFor state ->
        printfn "Error: The cartis paid for"
        cart

let removeItemFromCart cart item =
    match cart with
    | Empty state ->
        printfn "Error: The cart is empty"
        cart
    | Active state -> state.Remove item
    | PaidFor state ->
        printfn "Error: The cart is faid for"
        cart

let displayCart cart =
    match cart with
    | Empty state -> printfn "The cart is empty"
    | Active state -> printfn "%A" state.UnpaidItems
    | PaidFor state -> printfn "%A %f" state.PaidItems state.Payment

// attach to Cart
type Cart with
    static member NewCart = Cart.Empty NoItems
    member this.Add = addItemToCart this
    member this.Remove = removeItemFromCart this
    member this.Display = displayCart this

// test codes
let emptyCart = Cart.NewCart
printf "emptyCart="
emptyCart.Display

let cartA = emptyCart.Add "A"
printf "cartA="
cartA.Display

let cartAB = cartA.Add "B"
printf "cartAB="
cartAB.Display

let cartB = cartAB.Remove "A"
printf "cartB="
cartB.Display

let emptyCart2 = cartB.Remove "B"
printf "emptyCart2="
emptyCart2.Display

let emptyCart3 = emptyCart2.Remove "B"
printf "emptyCart3="
emptyCart3.Display

// client side logic
let payCart cart amount =
    match cart with
    | Empty _
    | PaidFor _ -> cart
    | Active state -> state.Pay amount

printf "cartABPaid="
let cartABPaid = payCart cartAB 100m
(cartABPaid).Display

// pay a cart thats been already been paid does nothing
// payment is still 100.0
printf "cartABPaid="
(payCart cartABPaid 100000m).Display

// forcing payment
// The client can never for example pay for an empty cart, as the method does not exist
let forcingPayment =
    match cartABPaid with
    | Empty state -> state.Pay 100m // wont compile, because method simply do not exist
    | PaidFor state -> state.Pay 100m // wont compile, because method simply do not exist
    | Active state -> state.Pay 100m
