namespace BankAccountDataGateway

open Persistance
open Persistence

module Query =
    let GetAccount =
        AccountHelpers.get AccountDatabase.Instance.get
