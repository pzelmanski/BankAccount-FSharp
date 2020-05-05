namespace Persistence

open BankAccountSpecification.Language

type AccountDatabase private () =
    let mutable accounts: Map<string, AllAccount> = Map.empty
    static let instance = AccountDatabase()
    static member Instance = instance

    member this.getAccount identity =
        async {
            return accounts.TryFind identity
                   |> function
                   | Some x -> Ok (Some x)
                   | None -> Ok (None)
        }

    member this.addAccount(account: PreActivatedAccount) =
        async {
            accounts <- accounts.Add(account.Identity.Identity, AllAccount.PreActivated account)
            return Ok()
        }
