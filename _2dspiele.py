import sys
import pygame
from pygame.locals import*
import random

#初始化

pygame.init()

#視窗和標題
win= pygame.display.set_mode((600,400))
pygame.display.set_caption('New game')

#角色參數
x=200
y=200
width = 30
height= 30
v=6
isjump=False
jumpvel=10

#jump function

def jump():
    global jumpvel,isjump
    isjump=True
    if jumpvel>=0:
       y-=jumpvel**2
       jumpvel-=1


#主迴圈
while True:
    pygame.time.delay(60)
    win.fill((0,0,0))
    pygame.draw.rect(win, (0,0,255),(x,y,width,height))
    
    keys=pygame.key.get_pressed()
    if isjump==False:
        if keys[pygame.K_UP] and y>0:
            y-=v
        if keys[pygame.K_DOWN] and y<400-height:
            y+=v    
        if keys[pygame.K_RIGHT] and x<600-width:
            x+=v
        if keys[pygame.K_LEFT] and x>0:
            x-=v
        if keys[pygame.K_SPACE]:
            isjump=True
    else:
        if jumpvel>0:
            y-=jumpvel
            jumpvel-=1 
        else:
            isjump=False
            jumpvel=10
    pygame.display.update()
    for event in pygame.event.get():
        if event.type==QUIT:
            pygame.quit()
            sys.exit()


