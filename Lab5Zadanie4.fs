// Zaimplementuj funkcjê rekurencyjn¹ do rozwi¹zania problemu wie¿ Hanoi i napisz funkcjê iteracyjn¹, która symuluje ten proces bez u¿ycia stosu. 

let rec hanoi n source target auxiliary =
    if n = 1 then
        printfn "Move disk from %s to %s" source target
    else
        hanoi (n - 1) source auxiliary target
        printfn "Move disk from %s to %s" source target
        hanoi (n - 1) auxiliary target source

hanoi 4 "C" "D" "E" 
