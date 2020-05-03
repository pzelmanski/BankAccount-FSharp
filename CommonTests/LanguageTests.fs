namespace CommonTests

open Common.Language
open FsUnit.Xunit

module AsyncResultHelpers =
    let dummy : AsyncResult<int, string> =
        15 |> Ok |> async.Return

open AsyncResultHelpers
(* let updateAccountAsync =
        async {
            account
            |> updateBalance (Credit { Amount = 1.0m })
            |> ignore
        }

    updateAccountAsync
    |> List.replicate 1000
    |> Async.Parallel
    |> Async.RunSynchronously
    |> ignore *)
    
    // TODO: Fix this
module AsyncResultTests =
    ()
//    let ``AsyncResult test`` () =
//        dummy |> Async.RunSynchronously
//        |> should be (Ok 15)
//        
//        let myFunc = async { !dummy
//                             |> should be true
//                              }
//        
//        async { let! result = dummy
//                let ok = (result = (Ok 15))
//                ok |> should be true }
//        |> Async.RunSynchronously
        