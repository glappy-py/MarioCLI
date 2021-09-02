# Importing useful modules
import pathlib
# import datetime
import pyautogui
import pyscreeze 
import pygetwindow as gw
import keyboard
import sys
import numpy as np
from time import sleep , time
import subprocess
import cv2
# ------------------------
startTime = time()
# Declaring the var for id , pass and teacher's name
id = None  
npass = None # Named it npass instead of pass because pass is a reserved word for python
name = ""
# Reading path.txt and extracting the path in which zoom is installed
zoompath = pathlib.Path("txts\\path.txt")
zoompath = zoompath.read_text()
zoompath = pathlib.Path(zoompath,"Zoom.exe")
zoompath = str(zoompath)
zoompath = zoompath.replace("\\","\\\\")
# Reading info.txt and extracting the info about id and passes
info = pathlib.Path("txts\\info.txt")
info = info.read_text()
info = info.split('\n')
# Locating buttons on screen
def locate(img):
    needle = cv2.imread(img)
    haystack = pyscreeze.screenshot()
    haystack =cv2.cvtColor(np.array(haystack),cv2.COLOR_RGB2BGR)
    return has(haystack,needle)

def has(haystack, needle):
    haystack = cv2.cvtColor(haystack, cv2.COLOR_BGR2GRAY)
    needle = cv2.cvtColor(needle, cv2.COLOR_BGR2GRAY)
    w, h = needle.shape[::-1]
    res = cv2.matchTemplate(haystack, needle, cv2.TM_CCOEFF_NORMED)
    threshold = 0.99
    loc = np.where(res >= threshold)
    try:
        assert loc[0][0] > 0
        assert loc[1][0] > 0
        return (loc[1][0] + 60, loc[0][0] + 60)
    except:
        return None

# Takes in the teacher's name and returns their id and pass
def manualJoin(name):
    for i in range(0,len(info)):
        t = info[i].split(':')
        if name == t[0] and t[3] == "zoom":
            id = t[1]
            npass = t[2]
    return id,npass,name
# Reads the time_table.txt and and returns id , pass and teacher's name
# according to the time table
# Experimental code
# def autoJoin():
#     # Checking which day is today 
#     if datetime.date.today().weekday() == 0:
#         cd = "monday"
#     if datetime.date.today().weekday() == 1:
#         cd = "tuesday"
#     if datetime.date.today().weekday() == 2:
#         cd = "wednesday"
#     if datetime.date.today().weekday() == 3:
#         cd = "thursday"
#     if datetime.date.today().weekday() == 4:
#         cd = "friday"
#     if datetime.date.today().weekday() == 5:
#         cd = "saturday"
#     #---------------------------------------
#     ch = datetime.datetime.now().hour # which hour is it now 
#     # Reads the time_table.txt and stores it in the var timetable as an Array
#     timetable = pathlib.Path('txts\\time_table.txt')
#     timetable = timetable.read_text()
#     timetable = timetable.split('\n')
#     # Extracting the id and pass
#     for i in range(0,len(timetable)):
#         r = timetable[i].split(':')
#         if cd == r[0]:
#             if ch == int(r[1]):
#                 name = r[2]
#     for i in range(0,len(info)):
#         t = info[i].split(':')
#         if name == t[0]:
#             id = t[1]
#             npass = t[2]
#         # --------------------------
#     return id,npass,name



# Asking the user for manual join or auto join
userInput = sys.argv[1]
# TODO: make auto command
# if userInput == "auto":
#     try :
#         id , npass , name = autoJoin()
#     except :
#         print("you don't have any class right now")
#         sleep(3)
#         sys.exit()
# else :
try:    
    id , npass , name = manualJoin(userInput)
    subprocess.Popen(zoompath) # launching zoom

    # checking if zoom has launched yet
    print("waiting for zoom to launch")
    while locate("img\\join_button.png") == None and locate("img\\join_a_meeting.png") == None:
        pass
        
    # checking if the user has signed in or not and locate the buttons accordingly
    try:
        join = locate("img\\join_button.png")
        # join = pyautogui.center(join)
        pyautogui.click(join[0],join[1])
    except Exception as e:
        join = locate("img\\join_a_meeting.png")
        # join = pyautogui.center(join)
        pyautogui.click(join[0],join[1])

    # showing class name , id and pass to user for cross correction
    print("joining " + name + " with id " + id + " and pass " + npass)


    # waiting for zoom to load
    while locate('img\\joining.png') == None:
        pass
        

    # entering id and pass 
    keyboard.write(str(id))
    pyautogui.press("enter")
    while locate('img\\passcode.png') == None:
        pass
    keyboard.write(str(npass))
    pyautogui.press("enter")
    # --------------------
    endTime = time()
    print('execution took '+ str(round(endTime - startTime,2)) +'s')
    sleep(3)
    sys.exit() # closing zoom-bot.py
except Exception as e:
    print("no entry found for " + sys.argv[1])
# --------------------------------------------