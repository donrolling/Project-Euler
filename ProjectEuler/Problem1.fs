module public Problem1
    //Problem 1: http://projecteuler.net/problem=1
    //Multiples of 3 and 5
    //If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.
    //Find the sum of all the multiples of 3 or 5 below 1000.
    let range = [1 .. 999] //the range of numbers to travers
    let divisors = [3;5] //the values which the summable numbers must be divisable by
    let multiples = [for r in range do
                            for d in divisors do
                                if r % d = 0 
                                then yield (r) ]; //the values which are multiples of the divisor list
    let distinctList = multiples |> Seq.distinct |> Seq.toList //those multiples are supposed to be distinct, so I'm fixing that here
    let sumList list = List.fold (fun acc elem -> acc + elem) 0 list //function for summing a list
    let GetAnswer = (sumList distinctList)//sum the distinct list to get the value