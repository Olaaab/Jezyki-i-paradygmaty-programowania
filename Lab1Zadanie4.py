# Masz ograniczoną pojemność plecaka oraz listę przedmiotów, z których każdy ma określoną wagę i wartość. Celem jest wybranie przedmiotów tak, aby
# zmaksymalizować łączną wartość w plecaku, nie przekraczając jego pojemności. Problem ten wymaga implementacji algorytmu plecakowego (knapsack
# problem) przy użyciu zarówno podejścia proceduralnego, jak i funkcyjnego.
def plecak(waga_max, przedmioty):
    n = len(przedmioty)
    dp = [[0] * (waga_max + 1) for _ in range(n + 1)]

    for i in range(1, n + 1):
        for w in range(1, waga_max + 1):
            if przedmioty[i - 1][1] <= w:
                dp[i][w] = max(dp[i - 1][w], dp[i - 1][w - przedmioty[i - 1][1]] + przedmioty[i - 1][0])
            else:
                dp[i][w] = dp[i - 1][w]

    return dp[n][waga_max]


przedmioty = [(49, 15), (100, 30), (124, 67)]
waga_max = 50
print(plecak(waga_max, przedmioty))

def plecak_fun(waga_max, przedmioty):
    if not przedmioty or waga_max == 0:
        return 0

    wartosc, waga = przedmioty[0]
    if waga > waga_max:
        return plecak_fun(waga_max, przedmioty[1:])
    else:
        return max(
            plecak_fun(waga_max, przedmioty[1:]),
            wartosc + plecak_fun(waga_max - waga, przedmioty[1:])
        )

print(plecak_fun(waga_max, przedmioty))
