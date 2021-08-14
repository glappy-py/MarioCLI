# import sys

# if sys.argv[1] == "readtodolist":
counter = 1
# middleware = open('middleware.txt','w')
todolist = ['ok','nice']
for element in todolist:
    todolist.append(str(counter) + ". " + element)
    counter = counter + 1
print(todolist)
    