import urllib3
import shutil
import os

def downloader(url,meses,anos):
    for ano in anos:
        for mes in meses:
            urlFinal = url+mes+ano+'_Servidores'
            print(urlFinal)
            download(urlFinal,ano,mes)
           
           
def download(urlFinal,p,e):
    c = urllib3.PoolManager()
    path = creatFolders('../downloads')
    filename = path+'/' +p+'_'+e+'.zip'
    with c.request('GET',urlFinal, preload_content=False) as resp, open(filename, 'wb') as out_file:
        shutil.copyfileobj(resp, out_file)
    resp.release_conn() 

#TODO
# import create_folder from files_manipulation.py ##






# def creatFolders(folderName):
#     path = os.getcwd() + '/' + folderName
#     if not os.path.exists(path):
#          os.mkdir(path)
#     return path

    