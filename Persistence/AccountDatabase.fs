namespace Persistence

open BankAccountSpecification.Language

type AccountDatabase private () =
    let mutable accounts: Map<string, AllAccount> = Map.empty
    static let instance = AccountDatabase()
    static member Instance = instance

    member this.get (identity) =
        async {
            return identity
                   |> accounts.TryFind
                   |> function
                       | Some x -> Ok(Some x)
                       | None -> Ok(None)
        }

    member this.upsert(account : AllAccount) =
        async {
            match account with
            | PreActivated a -> accounts <- accounts.Add(a.Identity.Identity, account)
            | Opened a -> accounts <- accounts.Add(a.Identity.Identity, account)
            | Closed a -> accounts <- accounts.Add(a.Identity.Identity, account)
            
            return Ok()
        }
