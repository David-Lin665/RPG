import sys
import pygame as pg
from pygame.locals import *
import random
from tkinter import filedialog
from tkinter import *

sys.path.append('C:\__python\Lib\site-packages\pygame')

pg.init()

#視窗和標題和參數
vec = pg.math.Vector2
WIDTH,HEIGHT = 750,400
ACC = 0.3
FRIC = -0.10
FPS = 60
FPS_CLOCK = pg.time.Clock()
COUNT = 0
win= pg.display.set_mode((WIDTH,HEIGHT))
pg.display.set_caption('New game')


# class 
class Background(pg.sprite.Sprite):
    def __init__(self):
        super().__init__()
        self.bgimage = pg.image.load("Background.png")
        self.bgimage = pg.transform.scale(self.bgimage,(WIDTH,int(round(WIDTH*300/732,0))))        
        self.bgY = 0
        self.bgX = 0
    def render(self):
        self.bgimage.convert()
        win.blit(self.bgimage, (self.bgX, self.bgY)) 
 
 
class Ground(pg.sprite.Sprite):
    def __init__(self):
        super().__init__()
        self.image = pg.image.load('Ground.png')
        self.image = pg.transform.scale(self.image,(WIDTH,int(round(WIDTH*112/902,0)))) 
        self.rect = self.image.get_rect(center = (375,350))
    def render(self):
        win.blit(self.image, (self.rect.x,self.rect.y))
           
 
class Player(pg.sprite.Sprite):
    def __init__(self):
        super().__init__()
        self.image = pg.image.load("adventurer_int.png")
        self.rect = self.image.get_rect()
 
        # Position and direction
        self.vx = 0
        self.pos = vec((340, 240))
        self.vel = vec(0,0)
        self.acc = vec(0,0)
        self.direction = "RIGHT"

        def move(self):
            
            if abs(self.vel.x)>0.3:
                self.running = True
            else:
                self.running = False
        def update(self):
            pass
        def attack(self):
            pass
        def jump(self):
            pass 
     
 
class Enemy(pg.sprite.Sprite):
      def __init__(self):
        super().__init__()


# creating object
background = Background()
ground = Ground()
player = Player()


#主迴圈
running = True
while running:
    background.render()
    ground.render()
    win.blit(player.image,player.rect)

    pg.display.update()
    FPS_CLOCK.tick(FPS)
    
    for event in pg.event.get():
        if event.type == QUIT :
            running = False
        if event.type == pg.MOUSEBUTTONDOWN:
            pass
        if event.type == pg.KEYDOWN:
            pass
pg.quit()
sys.exit()
        
