
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
    
  
    p1 = Process(target=down.downloader, args=(url,estadosL,partifosL,))
    p1.start()
    # p2 = Process(target=readFile, args=())
    # p2.start()
  
    # p1.join()
    # p2.join()
    # #down.downloader(url,estadosL,partifosL)
    
def readFile():
    path = os.getcwd() + "//ok"
    print('start')
    while True:
        files= glob.glob(path +'//*.csv')
        for file in files:
            insere.readProcess(file)
            #print(file)
        
        
    
if __name__ == '__main__':
    manin()


