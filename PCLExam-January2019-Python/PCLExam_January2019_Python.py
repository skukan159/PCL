#Question 6 - Multi paradigm programming in Python
#Define functions that take a list of int as an argument and returns the sum of all the positive numbers in the list.
# For example summing: [2, -3, 4, -5, 6] should give 12

# 6 a) Using the imperative paradigm of programming in Python, define a function sumPositiveImp(intList)

# 6 b) Using the functional paradigm in Python, define a function sumPositivesFun(intList).

# 6 c) Given the following list: traitPoints = [('Caring', 9), ('Kind', 6), ('Social', 5), ('Innovative', 7), ('Programming', 8)]
# Write a Python code to find the highest trait point


# Question 7
# 7 a) Given the following list:
itrCities = ["Copenhagen", "Aarhus", "Aalborg", "Horsens", "Odense"]
#Define a Python function usingFilter() to filter cities that starts with 'Aa'.

# 7 b) Recall from the lessons that Python supports multiple inheritance. Implement the following UML diagram in Python and show test runs with examples of your choice.
# Decide for yourself what the salary will be given the number of hours worked and print out the salary.
class Student():
    def __init__(self, studentName, studentNumber, department):
        self.studentName = studentName
        self.studentNumber = studentNumber
        self.department = department
    def display(self):
        # Todo - It is a void method
        print(self.studentName + " " + self.studentNumber + " " + self.department + " ")

class Worker():
    def getSalary(self,hoursWorked):
        # Todo - It is a void method. Calculate the salary, decide for yourself.
        salary = hoursWorked * 115.0
        print(salary)

class StudentWorker(Worker,Student):
    def __init__(self, studentName, studentNumber, department):
        super().__init__(studentName, studentNumber, department)

testStudentWorker = StudentWorker("Filip",123,"Software Engineering")
