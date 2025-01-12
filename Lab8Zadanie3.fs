// Napisz funkcjê, która znajduje maksymalny i minimalny element w liœcie liczbowej.

type LinkedList<'T> =
    | Empty
    | Node of 'T * LinkedList<'T>

let rec findMinMax linkedList =
    let rec helper currentMin currentMax list =
        match list with
        | Empty -> (currentMin, currentMax)
        | Node(value, next) ->
            let newMin = if value < currentMin then value else currentMin
            let newMax = if value > currentMax then value else currentMax
            helper newMin newMax next
    match linkedList with
    | Empty -> failwith "Lista jest pusta"
    | Node(value, next) -> helper value value next

let fromList lst =
    List.foldBack (fun x acc -> Node(x, acc)) lst Empty

let lista = [44; 2; 9; 89; 3]
let laczonalista = fromList lista

let (minValue, maxValue) = findMinMax laczonalista
printfn "Minimalny element: %d" minValue 
printfn "Maksymalny element: %d" maxValue 
