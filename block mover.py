# -*- coding: utf-8 -*-
"""
Created on Sat Jul  4 16:37:19 2020

@author: Sam
"""
import os
os.chdir("C:\\Users\\Sam\\Desktop\\gameScriptsPy")

level = []
with open('levels.txt') as file:
    for line in file:
        row = line.split(',')
        newRow = []
        for item in row:
            newRow.append(int(item))
        level.append(newRow)
            

 
class Block():
    def __init__(self, x, y):
        self._x = x
        self._y = y
        self._blocked_left = False
        self._blocked_right = False
        self._blocked_up = False
        self._blocked_down = False
        self._immovable = False

class Player(Block):
    def __init__(self, player):
        self._block = player
    def moveRight(self):
        if level[self._x+1][self._y] != 1 or self._immovable != True:
            self._block._x += 1
    def moveLeft(self):
        if level[self._x-1][self._y] != 1 or self._immovable != True:
            self._block._x -= 1
    def moveUp(self):
        if level[self._x][self._y+1] != 1 or self._immovable != True:
            self._block._y += 1
    def moveDown(self):
        if level[self._x][self._y-1] != 1 or self._immovable != True:
            self._block._y -= 1

class Wall(Block):
    def __init__(self, wall):
        self._block = wall
        self._immovable = True
        
        

for row in range(len(level)):
    for block in range(len(level[row])):
        if level[row][block] == 9:
            level[row][block] = Player(Block(row,block))
        elif level[row][block] == 1:
            level[row][block] = Wall(Block(row,block))
for line in level:
    print(line)

        