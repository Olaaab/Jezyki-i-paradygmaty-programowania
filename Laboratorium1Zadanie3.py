# Zadanie 3 Optymalizacja Rozmieszczenia Zadań (Proceduralne i Funkcyjne)
# Masz N zadań do wykonania, każde zadanie ma przypisany czas wykonania oraz nagrodę za jego  ukończenie. Twoim celem jest zaplanowanie kolejności wykonywania zadań, aby zminimalizować
# całkowity czas oczekiwania na ich wykonanie i zmaksymalizować zysk. Zaimplementuj rozwiązanie przy użyciu programowania proceduralnego oraz funkcyjnego.
# Wymagania:
# • Proceduralnie: Stwórz listę zadań i użyj pętli do sortowania i optymalizacji ich kolejności, aby
# zminimalizować całkowity czas oczekiwania.
# • Funkcyjnie: Użyj funkcji wyższego rzędu (sorted, map, reduce) do manipulacji listą zadań, aby
# osiągnąć optymalne rozwiązanie.
# • Program powinien zwrócić optymalną kolejność zadań oraz całkowity czas oczekiwania.

def optymalizacja_proceduralnie(zadania):
    zadania.sort(key=lambda x: x[0])
    calkowity_czas_oczekiwania = 0
    calkowita_nagroda = 0
    obecny_czas = 0
    optymalna_kolejnosc = []

    for zadanie in zadania:
        czas_wykonania, nagroda = zadanie
        obecny_czas += czas_wykonania
        calkowity_czas_oczekiwania += obecny_czas
        calkowita_nagroda += nagroda
        optymalna_kolejnosc.append(zadanie)

    return optymalna_kolejnosc, calkowity_czas_oczekiwania, calkowita_nagroda

zadania = [(4, 60), (2, 30), (3, 80), (1, 40), (6, 20)]
kolejnosc, czas_oczekiwania, nagroda = optymalizacja_proceduralnie(zadania)
print("Optymalna kolejność zadań:", kolejnosc)
print("Całkowity czas oczekiwania:", czas_oczekiwania)
print("Całkowita nagroda:", nagroda)
