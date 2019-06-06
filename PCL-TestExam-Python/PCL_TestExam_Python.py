


#Question 6
#6a
data = [1,2,3,4,5]

def add10ToEach(lst):
   return list(map(lambda x: x + 10 ,lst))

#6b
def printEvenNumbers(lst):
    evenNumbers = list(filter(lambda x: x%2 == 0,lst))
    print(evenNumbers)

#7 10%
#7a
import datetime

class Notebook():
    def __init__(self, courseNotes):
        self.courseNotes = courseNotes

    def search(self,fltr):
         return list(filter(lambda x: x.isAMatch(fltr) == True,self.courseNotes))

    def addNote(self,jotting,keywords):
        addedNote = CourseNote(jotting,datetime.datetime.now(),keywords)
        self.courseNotes.append(addedNote)

class CourseNote():
    def __init__(self, jotting,creationDate,keywords):
        self.jotting = jotting
        self.creationDate = creationDate
        self.keywords = keywords
    def isAMatch(self,searchFilter):
        if searchFilter in self.keywords: return True
        if searchFilter in self.jotting: return True
        return False
        #TODO - returns a bool
    
now = datetime.datetime.now()
testCourseNote1 = CourseNote("Joseph sucks!",now,["Joseph","lame"])
testCourseNote2 = CourseNote("This exam sucks!",now,["Python","Exam","Lame"])
testCourseNote3 = CourseNote("I hope this works!",now,["works","Python","Hope"])

testNotebook = Notebook([testCourseNote1,testCourseNote2,testCourseNote3])
