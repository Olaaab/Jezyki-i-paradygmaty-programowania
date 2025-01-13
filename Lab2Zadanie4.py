# Napisz program, który przyjmuje listę macierzy i łączy je w jedną za pomocą operacji zdefiniowanej
# przez użytkownika (np. suma macierzy, iloczyn), korzystając z reduce(). Program powinien:
# • Dynamicznie wywoływać różne operacje (np. sumowanie, mnożenie) na macierzach.
# • Umożliwiać definiowanie niestandardowych operacji przez użytkownika.

from functools import reduce
import numpy as np

def matrix(macierze, operacja):
    try:
        wynik = reduce(lambda x, y: eval(operacja)(x, y), macierze)
        return wynik
    except Exception as e:
        return str(e)

macierze = [
    np.array([[1, 4], [2, 4]]),
    np.array([[5, 6], [4, 8]]),
    np.array([[3, 15], [21, 12]])
]
print(matrix(macierze, "np.add"))
