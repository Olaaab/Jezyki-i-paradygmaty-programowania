# Zadanie 1. Z wykorzystaniem OOP zaproponuj implementację Employees System Project.
# Employees System Project ma być prostym projektem oparty na języku Python, który prezentuje
# wykorzystanie zasad programowania obiektowego (OOP). Obejmować ma trzy główne klasy: Employee,
# EmployeesManager i FrontendManager.
class Employee:
    def __init__(self, name, age, salary):
        self.name = name
        self.age = age
        self.salary = salary

    def __str__(self):
        return f"Imię i nazwisko: {self.name}, Wiek: {self.age}, Wynagrodzenie: {self.salary}"

class EmployeesManager:
    def __init__(self):
        self.employees = []

    def add_employee(self, employee):
        self.employees.append(employee)
        print(f"Pracownik {employee.name} został pomyślnie dodany.")

    def list_employees(self):
        if not self.employees:
            print("Brak pracowników.")
        else:
            print("\nLista pracowników:")
            for emp in self.employees:
                print(emp)

    def remove_employees_by_age_range(self, min_age, max_age):
        initial_count = len(self.employees)
        self.employees = [emp for emp in self.employees if not (min_age <= emp.age <= max_age)]
        removed_count = initial_count - len(self.employees)
        print(f"Usunięto {removed_count} pracowników w wieku od {min_age} do {max_age} lat.")

    def find_employee_by_name(self, name):
        for emp in self.employees:
            if emp.name == name:
                return emp
        return None

    def update_salary(self, name, new_salary):
        employee = self.find_employee_by_name(name)
        if employee:
            employee.salary = new_salary
            print(f"Wynagrodzenie pracownika {name} zostało zaktualizowane do {new_salary}.")
        else:
            print(f"Pracownik o imieniu {name} nie został znaleziony.")

class FrontendManager:
    def __init__(self):
        self.manager = EmployeesManager()

    def display_menu(self):
        while True:
            print("\n-------- System zarządzania pracownikami --------")
            print("1. Dodaj nowego pracownika")
            print("2. Wyświetl listę wszystkich pracowników")
            print("3. Usuń pracowników na podstawie przedziału wiekowego")
            print("4. Zaktualizuj wynagrodzenie pracownika")
            print("5. Wyjdź")

            choice = input("Wybierz opcję: ")

            if choice == "1":
                self.add_employee()
            elif choice == "2":
                self.manager.list_employees()
            elif choice == "3":
                self.remove_employees_by_age_range()
            elif choice == "4":
                self.update_salary()
            elif choice == "5":
                print("Zamykanie systemu. Do widzenia!!")
                break
            else:
                print("Nieprawidłowy wybór. Spróbuj ponownie.")

    def add_employee(self):
        name = input("Podaj imię i nazwisko pracownika: ")
        age = int(input("Podaj wiek pracownika: "))
        salary = float(input("Podaj wynagrodzenie pracownika: "))
        new_employee = Employee(name, age, salary)
        self.manager.add_employee(new_employee)

    def remove_employees_by_age_range(self):
        min_age = int(input("Podaj minimalny wiek: "))
        max_age = int(input("Podaj maksymalny wiek: "))
        self.manager.remove_employees_by_age_range(min_age, max_age)

    def update_salary(self):
        name = input("Podaj imię i nazwisko pracownika: ")
        new_salary = float(input("Podaj nowe wynagrodzenie: "))
        self.manager.update_salary(name, new_salary)


if __name__ == "__main__":
    frontend = FrontendManager()
    frontend.display_menu()
