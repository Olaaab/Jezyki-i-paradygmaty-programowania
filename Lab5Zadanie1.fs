// Funkcja rekurencyjna
let rec fibonacci n =
    if n <= 0 then 0
    elif n = 1 then 1
    else fibonacci (n - 1) + fibonacci (n - 2)

printfn "21 wyraz ci¹gu Fibonacciego: %d" (fibonacci 21)

// Funkcja z rekurencj¹ ogonow¹
let fibonacciTailRec n =
    let rec aux n a b =
        if n <= 0 then a
        elif n = 1 then b
        else aux (n - 1) b (a + b)
    aux n 0 1

printfn "21 wyraz ci¹gu Fibonacciego (rekurencja ogonowa): %d" (fibonacciTailRec 21)
