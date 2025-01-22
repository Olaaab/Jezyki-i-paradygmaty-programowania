import random
class Teacher:
    def __init__(self, name, available_hours, subjects):
        self.name = name
        self.available_hours = available_hours
        self.subjects = subjects

    def __str__(self):
        return self.name

    def is_available(self, hour):
        return hour in self.available_hours


class Room:
    def __init__(self, room_number):
        self.room_number = room_number
        self.schedule = {hour: None for hour in range(8, 16)}

    def __str__(self):
        return str(self.room_number)

    def is_available(self, hour):
        return self.schedule.get(hour) is None

    def assign_lesson(self, hour, subject, teacher):
        if self.is_available(hour):
            self.schedule[hour] = (subject, teacher)
            return True
        return False


class Subject:
    def __init__(self, name, duration):
        self.name = name
        self.duration = duration

    def __str__(self):
        return self.name


class SchoolClass:
    def __init__(self, class_name, profile, subjects, preferred_hours=None, avoided_hours=None,
                 lessons_per_day=None):
        self.class_name = class_name
        self.profile = profile
        self.subjects = subjects
        self.preferred_hours = preferred_hours if preferred_hours else []
        self.avoided_hours = avoided_hours if avoided_hours else []
        self.lessons_per_day = lessons_per_day if lessons_per_day else {}

    def __str__(self):
        return f"{self.class_name} ({self.profile})"


def choose_ur_teacher(teachers, hour, subject):
    available_teachers = list(filter(lambda teacher: teacher.is_available(hour) and subject in teacher.subjects, teachers))
    return random.choice(available_teachers) if available_teachers else None


def choose_ur_room(rooms, hour):
    available_rooms = [room for room in rooms if room.is_available(hour)]
    return random.choice(available_rooms) if available_rooms else None


def j_schedule(preferred_hours, avoided_hours):
    sorted_hours = sorted(preferred_hours)
    available_hours = [hour for hour in sorted_hours if hour not in avoided_hours]
    return available_hours


def Harmonogram(teachers, rooms, school_class):
    schedule = dict(map(lambda day: (day, {hour: None for hour in range(8, 16)}), ['Poniedziałek', 'Wtorek', 'Środa', 'Czwartek', 'Piątek']))
    lesson_count = {subject: 0 for subject in school_class.subjects}
    subject_count = {day: {subject: 0 for subject in school_class.subjects} for day in schedule}
    subject_req = school_class.lessons_per_day

    sub_to_assign = {subject: subject_req[subject] for subject in school_class.subjects}
    max_hours = 2

    preferred_hours = j_schedule(school_class.preferred_hours, school_class.avoided_hours)

    def can_assign_sub(subject, day):
        return (
            lesson_count[subject] < subject_req[subject]
            and subject_count[day][subject] < max_hours
        )

    def assign_lesson(schedule, day, hour, subject, teacher, room):
        schedule[day][hour] = (subject, teacher, room)
        lesson_count[subject] += 1
        subject_count[day][subject] += 1
        if lesson_count[subject] >= subject_req[subject]:
            del sub_to_assign[subject]

    for day in schedule:
        for hour in preferred_hours:
            if not sub_to_assign:
                break

            subject = next(filter(lambda subj: can_assign_sub(subj, day), sub_to_assign), None)

            if not subject:
                continue

            teacher = choose_ur_teacher(teachers, hour, subject)
            room = choose_ur_room(rooms, hour)

            if teacher and room:
                assign_lesson(schedule, day, hour, subject, teacher, room)

    return schedule


def print_harmonogram(schedule, school_class):
    print(f"Plan lekcji dla klasy: {school_class}")
    for day, hours in schedule.items():
        print(f"{day}:")
        for hour, lesson in hours.items():
            if lesson:
                subject, teacher, room = lesson
                print(f"  {hour}:00 - {subject} | Nauczyciel: {teacher} | Sala: {room}")
            else:
                print(f"  {hour}:00 - Brak zajęć")

teachers = [
    Teacher("Anna Dobrowolska", [8, 9, 10, 11, 12, 14, 15], ["Matematyka", "Informatyka"]),
    Teacher("Karina Trolej", [8, 9, 10, 11, 12], ["Matematyka"]),
    Teacher("Marzena Apostolakis", [8, 9, 10, 11, 12, 13, 15], ["Informatyka"]),
    Teacher("Bartłomiej Wojtan", [9, 10, 11, 12, 13, 15], ["Fizyka", "Matematyka"]),
    Teacher("Arkadiusz Fryc", [8, 10, 11, 12, 14, 15], ["Chemia"]),
    Teacher("Wojtek Szymański", [8, 9, 11, 12, 13, 14], ["Religia", "Historia"]),
    Teacher("Renata Wójcik", [8, 9, 10, 12, 14, 15], ["Historia"]),
    Teacher("Katarzyna Szymańska", [8, 9, 10, 12, 13, 14, 15], ["Religia"]),
    Teacher("Amanda Kuna", [8, 9, 10, 11, 12, 13, 14, 15], ["Język polski", "Wiedza o społeczeństwie"]),
    Teacher("Katarzyna Janowska", [9, 10, 11], ["Biologia"]),
    Teacher("Maja Czyżowska", [9, 10, 11, 12, 13, 15], ["Język angielski", "Język niemiecki"]),
    Teacher("Teresa Nowak", [8, 9, 10, 11, 12, 14, 15], ["Język niemiecki"]),
    Teacher("Patrycja Janowska", [9, 10, 11, 12, 14, 15], ["Chemia"]),
    Teacher("Józef Młynarski", [8, 9, 10, 11, 12, 14, 15], ["Matematyka"]),
    Teacher("Anastazja Kot", [9, 10, 11, 12, 13, 14, 15], ["Język polski"]),
    Teacher("Marek Makaron", [8, 10, 11, 12, 14, 15], ["Język angielski"]),
    Teacher("Łucja Tuńczyk", [8, 9, 10, 11, 12, 13, 14], ["Fizyka"]),
    Teacher("Aleksandra Kolanko", [8, 11, 12, 13, 14, 15], ["Biologia"]),
    Teacher("Wiktoria Hys", [8, 9, 10, 11, 12, 13, 14, 15], ["Podstawy przedsiębiorczości"]),
    Teacher("Wiktoria Karczek", [11, 12, 13, 14, 15], ["Geografia"]),
    Teacher("Jakub Łukasz", [8, 9, 10, 13, 14], ["Geografia"]),
]

rooms = [Room(i) for i in range(101, 130)]

# Przykładowe przedmioty
subjects = [
    Subject("Matematyka", 1),
    Subject("Fizyka", 1),
    Subject("Chemia", 1),
    Subject("Biologia", 1),
    Subject("Informatyka", 1),
    Subject("Podstawy przedsiębiorczości", 1),
    Subject("Religia", 1),
    Subject("Wiedza o społeczeństwie", 1),
    Subject("Historia", 1),
    Subject("Język polski", 1),
    Subject("Język angielski", 1),
    Subject("Język niemiecki", 1),
    Subject("Geografia", 1),
]

classes = [
    SchoolClass("1A", "Matematyczno-fizyczna",
                ["Matematyka", "Informatyka", "Podstawy przedsiębiorczości", "Chemia", "Biologia", "Fizyka", "Religia",
                 "Język polski", "Historia", "Wiedza o społeczeństwie", "Geografia", "Język angielski",
                 "Język niemiecki"],
                preferred_hours=[8, 9, 10, 11, 12, 13, 14], avoided_hours=[15],
                lessons_per_day={"Historia": 2, "Matematyka": 5, "Informatyka": 3, "Religia": 2, "Fizyka": 4, "Język polski": 4, "Język niemiecki": 2, "Język angielski": 2, "Podstawy przedsiębiorczości": 2, "Geografia": 2, "Wiedza o społeczeństwie": 4, "Chemia": 2, "Biologia": 2}),
    SchoolClass("2B", "Humanistyczna",
                ["Matematyka", "Informatyka", "Podstawy przedsiębiorczości", "Religia",
                 "Język polski", "Historia", "Wiedza o społeczeństwie", "Geografia", "Język angielski",
                 "Język niemiecki"],
                preferred_hours=[9, 10, 11, 12, 13, 14, 15], avoided_hours=[8],
                lessons_per_day={"Informatyka": 2, "Religia": 2, "Matematyka": 4, "Język polski": 6, "Historia": 6, "Podstawy przedsiębiorczości": 3, "Geografia": 3, "Wiedza o społeczeństwie": 6, "Język niemiecki": 3, "Język angielski": 4}),
    SchoolClass("3C", "Informatyczna",
                ["Matematyka", "Informatyka", "Religia", "Język polski", "Język angielski", "Język niemiecki",
                 "Fizyka", "Historia"],
                preferred_hours=[8, 10, 11, 12, 13, 15], avoided_hours=[9, 14],
                lessons_per_day={"Informatyka": 8, "Matematyka": 7, "Język angielski": 4, "Fizyka": 4, "Religia": 2, "Język polski": 5, "Język niemiecki": 5, "Historia": 2}),
]

for school_class in classes:
    schedule = Harmonogram(teachers, rooms, school_class)
    print_harmonogram(schedule, school_class)
    print("\n" + "="*90 + "\n")
