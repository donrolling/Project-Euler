module public Problem3
    //Problem 3: Largest prime factor
    //The prime factors of 13195 are 5, 7, 13 and 29.
    //What is the largest prime factor of the number 600851475143 ?
    let limit = 600851475143L
    let odds limit = Seq.unfold (fun n -> if n > limit then None else Some(n, n + 2L)) 3L

    let isPrime n = let limit = int64 (sqrt (float n))
                    odds limit |> Seq.forall (fun x -> n % x <> 0L)

    let primes = seq { 
                        yield 2L 
                        yield! odds limit |> Seq.filter isPrime 
                     }
    let GetAnswer = primes |> Seq.max
