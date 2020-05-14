namespace BankAccountDataGateway

open Persistance
open Persistence

module Query =
    let getAccount identity =
        identity
        |> AccountDatabase.Instance.get
