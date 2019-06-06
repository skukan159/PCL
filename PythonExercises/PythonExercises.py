
def printName(name, studentNumber):
    for count in range(5):
        print(name + " " + studentNumber)

def givePresent():
    present = input("What would you like for your birthday?")
    numTimes = input("How many of those would you like?")
    for count in range(int(numTimes)):
        print(" You get " + present)

def sumImperative(inputList):
    sum = 0
    for count in range(len(inputList)):
        sum += inputList[count]
    return sum

def printEvenNumbers(inputList):
    evenNumbers = []
    for count in range(len(inputList)):
        if (inputList[count] % 2 == 0):
            evenNumbers.append(inputList[count])
            print(inputList[count])
    return evenNumbers

#def groupList(inputList,glength):
#    listOfLists = []
#    listInList = []
#    for count in range(len(inputList)):
#        
#    return evenNumbers

def checkIfInString(character,string):
    for count in range(len(string)):
        if(character == string[count]): 
            return True
    return False;

#Exercises 11

class MyRecipe():
    def __init__(self, calories, cookTime,name):
        self.calories = calories
        self.cookTime = cookTime
        self.name = name


favRecipes = []
favRecipes.append(MyRecipe(100,500,"pizza"))
favRecipes.append(MyRecipe(200,600,"ice cream"))
favRecipes.append(MyRecipe(300,700,"bread"))
favRecipes.append(MyRecipe(400,800,"pizda"))
favRecipes.append(MyRecipe(500,900,"tofu"))

for count in favRecipes:
    print(count.name)

class Singer():
    @staticmethod
    def sing():
        print("La la la LAAAAAAA")

class SongWriter():
    @staticmethod
    def compose():
        print("I am composing the best song in the universe")

class SingerSongwriter(Singer,SongWriter):
    @staticmethod
    def strum():
        print("Strum strum")
    @staticmethod
    def actSensitive():
        print("You hurt my feelings!")

testSingerSongwriter = SingerSongwriter().sing()

class Fish():
    def eat():
        print("Nom nom nom like a fish")
    def swim():
        print("Swim swim swim like ze fish")

class Shark(Fish):
    def __init__(self, name,placeFound):
        self.name = name
        self.placeFound = placeFound
    def swim(self):
        print("I am a shark and I am swimming")
    def eat(self):
        print("I am ze shark and I am eating stuff")

class Dolphin(Fish):
    def __init__(self, name):
        self.name = name
    def swim(self):
        print("I am a dolphin and I am swimming")
    def eat(self):
        print("I am ze dolphin and I am eating stuff")

testDolphin = Dolphin("Cute Dolphin")
testDolphin.eat()

#Exercises 12
numList = [1,2,3,4,5]

def sumFunctional(list):
    sum = 0
    for val in list:
        sum += val
    return sum

def factorialR(n):
    if(n == 0):
       return 1
    elif(n > 0):
       return n *(factorialR(n - 1))

def factorialI(n):
    num = 1
    while n >= 1:
        num = num * n
        n = n - 1
    return num

#Exercise 12.3
naturalNumbers = [0,1,2,3,4,5,6,7,8,9]
def printEvenNumbers(numList):
    return list(filter(lambda n: n%2==0,numList))