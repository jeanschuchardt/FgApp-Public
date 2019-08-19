import urllib3
import shutil
import os
from threading import Thread

def info_loader(properties):
    anos = properties['downloads']['anos']
    meses = properties['downloads']['meses']
    
    url = properties['url']['tse']
    threads = []
    for ano in anos:
        for mes in meses:
            if(mes <10):
                url_final = url  + str(ano) + '0'+str(mes)+'_Servidores'
                print(url_final)
                download(url_final,ano,mes)
 #               threads.append(Thread(target=download, args=(url_final,ano,mes)))
            else:
                url_final = url  + str(ano) + str(mes)+'_Servidores'
                print(url_final)
                download(url_final,ano,mes)
#                threads.append(Thread(target=download, args=(url_final,ano,mes)))
    # for thread in threads()
    #     thread.start()

    # for thread in threads:
    #     thread.join()

           
           
def download(url_final,ano,mes):
    c = urllib3.PoolManager()
    path = 'data/unziped_files'
    filename = path+'/' +str(ano)+'_'+str(mes)+'.zip'
    with c.request('GET',url_final, preload_content=False) as resp, open(filename, 'wb') as out_file:
        shutil.copyfileobj(resp, out_file)
    resp.release_conn() 

