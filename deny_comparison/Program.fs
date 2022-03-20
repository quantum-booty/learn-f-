[<NoEquality; NoComparison>]
type CustomerAccount = { CustomerAccountId: int }

let x = { CustomerAccountId = 1 }
// x = x // error
x.CustomerAccountId = x.CustomerAccountId // no error
