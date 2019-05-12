import urllib3
import manipula
import shutil

def downloader(url,estadosL,partidosL):
    for partido in partidosL:
        for estado in estadosL:
            urlFinal = url+partido+'_'+estado+'.zip'
            print(urlFinal)
            download(urlFinal,partido,estado)
            
            manipula.unziper()
            manipula.organizaF()

def download(urlFinal,p,e):
    c = urllib3.PoolManager()
    path = manipula.creatFolders('downloads')
    filename = path+'/' +p+'_'+e+'.zip'
    with c.request('GET',urlFinal, preload_content=False) as resp, open(filename, 'wb') as out_file:
        shutil.copyfileobj(resp, out_file)
    resp.release_conn() 
