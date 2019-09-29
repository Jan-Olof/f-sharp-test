namespace Capstone3.Domain

open System

type Transaction =
    {
        Amount : decimal;
        Operation : string;
        Timestamp : DateTime;
        Success : bool
    }