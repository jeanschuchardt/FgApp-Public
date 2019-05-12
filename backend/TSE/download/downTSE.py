import readConfig as conf
import downloadFiles  as down 

def manin():
    config = conf.readConfig()
    url = config[0]
    estadosL =  config[1]
    partifosL = config[2]
    
    down.downloader(url,estadosL,partifosL,)
          
    
if __name__ == '__main__':
    manin()


