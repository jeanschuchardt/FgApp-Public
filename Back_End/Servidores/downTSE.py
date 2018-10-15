import os
import glob
from multiprocessing import Process
import sys
import readConfig as conf
import downloadFiles  as down 
import manipula
import insere
import _thread

def manin():
    config = conf.readConfig()
    url = config[0]
    estadosL =  config[1]
    partifosL = config[2]
    
  
    #p1 = Process(target=down.downloader, args=(url,estadosL,partifosL,))
    #p1.start()
    #p2 = Process(target=readFile, args=())
    #p2.start()
    p3 = Process(target=readFile2, args=())
    p3.start()
  
    #p1.join()
    #p2.join()
    p3.join()
    #down.downloader(url,estadosL,partifosL)
    
def readFile():
    path = os.getcwd() + "//ok"
    print('start')
    while True:
        files= glob.glob(path +'//*.csv')
        for file in files:
            insere.readProcess(file)
            manipula.moveFile(path, 'inseridos')
            #print(file)

def readFile2():
    path = os.getcwd() + "//unzip"
    print('start')
    while True:
        files= glob.glob(path +'//*Remuneracao.csv')
        for file in files:
            insere.readProcess2(file)
            manipula.moveFile(path, 'inseridos_remuneracao')
            #print(file)
        
        
    
if __name__ == '__main__':
    manin()


