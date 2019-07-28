namespace Capstone2.Domain

open System

type Customer =
    { Id : Guid
      Name : string
      Age : int }

type Account =
    { Id : Guid
      Owner : Customer
      Balance : decimal }