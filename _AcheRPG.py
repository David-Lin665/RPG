import pygame
import sys
import random
import tkinter
from pygame.locals import *
from tkinter import filedialog
from tkinter import *

#初始化pygame
pygame.init()

#colors
blue=(0,0,255)
red=(255,0,0)
green=(0,255,0)
white=(255,255,255)
black=(0,0,0)

# Declaring variables
vec = pygame.math.Vector2
HEIGHT = 350
WIDTH = 700
ACC = 0.3
FRIC = -0.10
FPS = 60
FPS_CLOCK = pygame.time.Clock()
COUNT = 0

# window setting
dis = pygame.display.set_mode((WIDTH,HEIGHT))
dis.fill(white)
pygame.display.set_caption('New game')


#classes setting
class Background(pygame.sprite.Sprite):
    def __init__(self):
        super().__init__()
        self.bgimage = pygame.image.load("./Background.png")        
        self.bgY = 0
        self.bgX = 0
 
    def render(self):
        dis.blit(self.bgimage, (self.bgX, self.bgY))     
 
 
class Ground(pygame.sprite.Sprite):
    def __init__(self):
        super().__init__()
        self.image = pygame.image.load("./Ground.png")
        
        self.rect = self.image.get_rect(center = (350, 350))
 
    def render(self):
        dis.blit(self.image, (self.rect.x, self.rect.y))
 
class Player(pygame.sprite.Sprite):
    def __init__(self):
        super().__init__() 
        self.image = pygame.image.load("adventurer_int.png")
        self.rect = self.image.get_rect()
        self.jumping = False
        self.running = False
        self.move_frame = 0
 
        # Position and direction
        self.vx = 0
        self.pos = vec((340, 240))
        self.vel = vec(0,0)
        self.acc = vec(0,0)
        self.direction = "RIGHT"

    def move(self):
        # Keep a constant acceleration of 0.5 in the downwards direction (gravity)
        self.acc = vec(0,0.5)    
        # Will set running to False if the player has slowed down to a certain extent
        if abs(self.vel.x) > 0.3:
            self.running = True
        else:
            self.running = False
        # Returns the current key presses
        pressed_keys = pygame.key.get_pressed()
        # Accelerates the player in the direction of the key press
        if pressed_keys[K_a]:
            self.acc.x = -ACC
        if pressed_keys[K_d]:
            self.acc.x = ACC 
        # Formulas to calculate velocity while accounting for friction
        self.acc.x += self.vel.x * FRIC
        self.vel += self.acc
        self.pos += self.vel + 0.5 * self.acc  # Updates Position with new values
        # This causes character warping from one point of the screen to the other
        if self.pos.x > WIDTH:
            self.pos.x = 0
        if self.pos.x < 0:
            self.pos.x = WIDTH
 
        self.rect.midbottom = self.pos  # Update rect with new pos

    def update(self):
        pass
    def jump(self):
        
        # Check to see if payer is in contact with the ground
        hits = pygame.sprite.spritecollide(self, ground_group, False)
     
        # If touching the ground, and not currently jumping, cause the player to jump.
        if hits and not self.jumping:
            self.jumping = True
            self.vel.y = -10
    def attack(self):
        pass
    def gravity_check(self):
        hits = pygame.sprite.spritecollide(player ,ground_group, False)
        if self.vel.y > 0:
            if hits:
                lowest = hits[0]
                if self.pos.y < lowest.rect.bottom:
                    self.pos.y = lowest.rect.top + 1
                    self.vel.y = 0
                    self.jumping = False
 
class Enemy(pygame.sprite.Sprite):
    def __init__(self):
        super().__init__()
        self.image = pygame.image.load("snake.png")
        pygame.transform.scale(self.image,(5,5))
        self.rect = self.image.get_rect()     
        self.pos = vec(0,0)
        self.vel = vec(0,0)
        self.direction = random.randint(0,1) # 0 for Right, 1 for Left
        self.vel.x = random.randint(2,6) / 2  # Randomized velocity of the generated enemy
        if self.direction == 0:
            self.pos.x = 0
            self.pos.y = 150
        if self.direction == 1:
            self.pos.x = 700
            self.pos.y = 150
        
    def move(self):
        # Causes the enemy to change directions upon reaching the end of screen    
        if self.pos.x >= (WIDTH-20):
            self.direction = 1
        elif self.pos.x <= 0:
            self.direction = 0
        if self.direction == 0:
            self.pos.x += self.vel.x
        if self.direction == 1:
            self.pos.x -= self.vel.x
 
        self.rect.center = self.pos
    def render(self):
            # Displayed the enemy on screen
            dis.blit(self.image, (self.pos.x, self.pos.y))


#creating object

background = Background()
ground = Ground()
ground_group = pygame.sprite.Group()
ground_group.add(ground)
player = Player()
enemy = Enemy()


#main loop

run = True

while run:
    player.gravity_check()
    background.render()
    ground.render()
    player.move()
    dis.blit(player.image,player.rect)
    enemy.render()
    enemy.move()
    pygame.display.update()
    for event in pygame.event.get():
        if event.type == QUIT:
            run = False
            pygame.quit()
            sys.exit()
        if event.type == pygame.KEYDOWN:
            if event.key == pygame.K_w:
                player.jump()
            if event.key == pygame.K_ESCAPE:
                run = False
                pygame.quit()
                sys.exit()    
    FPS_CLOCK.tick(FPS)







