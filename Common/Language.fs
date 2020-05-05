namespace Common

module Language =
    type AsyncResult<'a, 'e> = Async<Result<'a, 'e>>
