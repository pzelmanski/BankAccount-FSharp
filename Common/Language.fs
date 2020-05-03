namespace Common

module Language =
    type AsyncResult<'a, 'b> = Async<Result<'a, 'b>>
