import sys
import readConfig as conf
import downloadFiles  as down 


def manin():
    config = conf.readConfig()
    url = config[0]
    anos =  config[1]
    meses = config[2]

    down.downloader(url,anos,meses)
        
    
if __name__ == '__main__':
    manin()


