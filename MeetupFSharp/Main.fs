namespace MySuperMeetup

open Meetup.FSharp.Utils

module Main =
    let myFunction x =
        Meetup.FSharp.Utils.printEven x

    let myFunctionWithOpen x =
        printEven x