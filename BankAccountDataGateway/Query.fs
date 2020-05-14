namespace BankAccountDataGateway

open Persistance
open Persistence

module Query =
    let GetAccount identity =
        identity
        |> AccountHelpers.get AccountDatabase.Instance.get
