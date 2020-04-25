When type has a unit, it needs an underscore even when there are no arguments provided

```fsharp
type CreateBankAccount = unit -> Account
```

```fsharp
let createBankAccount : CreateBankAccount =
    fun _ ->
            { Balance = 0.0m
            IsOpen = false }
```

To specify that there is no argument, I could use `()` instead:
```fsharp
let createBankAccount : CreateBankAccount =
    fun () ->
            { Balance = 0.0m
            IsOpen = false }
```
This two above implementations are the same



single case DU deconstruction
```fsharp
let openAccount : OpenAccount =
        fun (PreActivatedAccount account) ->
            { Account = account
              Balance = 0.0m }
```

thrundi: Treat it the same way as you deconstruct DU cases when you do match type of DU = | A of int | B of string
thrundi: match du with | A x -> x.ToString() // x is int | B y -> y // y is string
