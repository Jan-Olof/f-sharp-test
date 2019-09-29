namespace Capstone3.Domain

open System

type Account =
    {
        AccountId : Guid;
        Owner : Customer;
        Balance : decimal
    }