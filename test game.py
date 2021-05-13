import pygame,sys
from pygame.locals import *
#初始化pygame
pygame.init()

FPS=30
Framepersec=pygame.time.Clock()

blue=(0,0,255)
red=(255,0,0)
green=(0,255,0)
white=(255,255,255)
black=(0,0,0)

dis=pygame.display.set_mode((300,300))
dis.fill(white)
pygame.display.set_caption('example')


pygame.draw.line(dis, blue,(150,130),(130,170))
pygame.draw.line(dis, blue,(150,130),(170,170))
pygame.draw.line(dis, green,(130,170),(170,170))
pygame.draw.circle(dis, black,(100,50),30)
pygame.draw.circle(dis, black,(200,50),30)
pygame.draw.rect(dis, red,(100,200,100,50),2)
pygame.draw.rect(dis, black,(110,260,80,5))

while True:
    pygame.display.update()
    for event in pygame.event.get():
        if event.type == QUIT:
            pygame.quit()
            sys.exit()
    Framepersec.tick(FPS)


