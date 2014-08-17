﻿module public Problem2
    //Problem 2 : Even Fibonacci numbers
    //Each new term in the Fibonacci sequence is generated by adding the previous two terms. 
    //By starting with 1 and 2, the first 10 terms will be:
    //1, 2, 3, 5, 8, 13, 21, 34, 55, 89, ...
    //By considering the terms in the Fibonacci sequence whose values do not exceed four million, 
    //find the sum of the even-valued terms.

//    let rec fib n = if n <= 2 then 1 else fib (n - 1) + fib (n - 2)
//    let nums = [1..33]
//    let test = nums |> List.map (fun x -> 
//                                        let y = fib x 
//                                        if y < 4000000 && y % 2 = 0 then y
//                                        else 0)
//    let sumList list = List.fold (fun acc elem -> acc + elem) 0 list //function for summing a list
//    let GetAnswer = sumList test
//
    let getNextFibonacciSet (x, y) = (y, x + y)
    let rec sumEvenFibonacciNumbersUnder_4M (x, y) = match y with
                            | y when y > 4000000 -> 0
                            | y ->  let n = snd (getNextFibonacciSet (x, y))
                                    if y % 2 = 0 then
                                        y + sumEvenFibonacciNumbersUnder_4M (y, n)
                                    else 
                                        sumEvenFibonacciNumbersUnder_4M (y, n)
    let GetAnswer = sumEvenFibonacciNumbersUnder_4M (1, 2)