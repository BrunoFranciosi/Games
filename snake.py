'''
    Autor:    Bruno Franciosi
    Programa: Snake Game.
            Jogo da Cobrinha bem simples 🐍
'''

import pygame
import time
import random

pygame.init()

dis_widht = 800
dis_height = 600

dis = pygame.display.set_mode((dis_widht, dis_height))
pygame.display.update()
pygame.display.set_caption('Snake Game by Bruno - V.0.0.1')

black = (0, 0, 0)
red = (255, 0, 0)
blue = (0, 0, 255)
green = (0, 255, 0)
yellow = (255, 255, 102)

snake_speed = 20
snake_block = 10

clock = pygame.time.Clock()

font_style = pygame.font.SysFont("Calibri", 25)
score_font = pygame.font.SysFont("Calibri", 35)

def Placar(score):
    value = score_font.render("Score: " + str(score), True, yellow)
    dis.blit(value, [0, 0])

def att_snake(snake_block, snake_list):
    for x in snake_list:
        pygame.draw.rect(dis, blue, [x[0], x[1], snake_block, snake_block])

def message(msg, color):
    mesg = font_style.render(msg, True, color)
    dis.blit(mesg, [dis_widht/4.5, dis_height/3])

def gameLoop():
    game_over = False
    game_close = False

    x_snake = dis_widht/2
    y_snake = dis_height/2
    x_change = 0
    y_change = 0

    snake_List = []
    Lenght_of_snake = 1

    foodx = round(random.randrange(0, dis_widht - snake_block)/10) * 10
    foody = round(random.randrange(0, dis_height - snake_block)/10) * 10

    while not game_over:
        while game_close == True:
            dis.fill(black)
            message("Game Over! Press R-Restart or Q-Quit", red)
            pygame.display.update()

            for event in pygame.event.get():
                if event.type == pygame.KEYDOWN:
                    if event.key == pygame.K_q:
                        game_over == True
                        game_close == False
                        pygame.quit()
                    if event.key == pygame.K_r:
                        gameLoop()

        for event in pygame.event.get():
            if event.type == pygame.QUIT:
                game_over = True
            if event.type == pygame.KEYDOWN:
                if event.key == pygame.K_LEFT:
                    x_change = -snake_block
                    y_change = 0
                elif event.key == pygame.K_RIGHT:
                    x_change = snake_block
                    y_change = 0
                elif event.key == pygame.K_UP:
                    x_change = 0
                    y_change = -snake_block
                elif event.key == pygame.K_DOWN:
                    x_change = 0
                    y_change = snake_block

        if x_snake >= dis_widht or x_snake < 0 or y_snake >= dis_height or y_snake < 0:
            game_close = True
                
        x_snake = x_snake + x_change
        y_snake = y_snake + y_change
        dis.fill(black)
        pygame.draw.rect(dis, green, [foodx, foody, snake_block, snake_block])
        
        snake_Head = []
        snake_Head.append(x_snake)
        snake_Head.append(y_snake)
        snake_List.append(snake_Head)
        if len(snake_List) > Lenght_of_snake:
            del snake_List[0]

        for x in snake_List[:-1]:
            if x == snake_Head:
                game_close = True

        att_snake(snake_block, snake_List)
        Placar(Lenght_of_snake - 1)

        pygame.display.update()

        if x_snake == foodx and y_snake == foody:
            foodx = round(random.randrange(0, dis_widht - snake_block)/10) * 10
            foody = round(random.randrange(0, dis_height - snake_block)/10) * 10
            Lenght_of_snake = Lenght_of_snake + 1

        clock.tick(snake_speed)
    
    pygame.quit()
    quit()

gameLoop()