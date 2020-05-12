﻿namespace IntegrationTests

open Xunit

module BankAccountViewModelTests =
    // TODO: Replace DataGateway with VM
    [<Fact>]
    let ``When adding to AccountDatabase it should persist`` () =
        async {
            match! DataGateway.createAccount with
            | Ok _ -> match! DataGateway.getAccount "1" with 
                        | Some _ -> ()
                        | None -> failwith "Failed to get account"
            | _ -> failwith "failed to create account"
        }