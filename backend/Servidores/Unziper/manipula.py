import zipfile  
import glob
import os
import shutil

def creatFolders(folderName):
    path = os.getcwd() + '/' + folderName
    if not os.path.exists(path):
         os.mkdir(path)
    return path

def unziper(path):
    #path = os.getcwd() + '/downloads'
    files = path+'/*.zip'
    fileToUnzip = glob.glob(files)
    path = creatFolders('../readtoinsert')
    for fileX in fileToUnzip:
        try: 
            zip_ref = zipfile.ZipFile(fileX,'r')
            zip_ref.extractall(path)
            zip_ref.close()
            print(path)
            moveFile(fileX,'/../ok2')
        except Exception as e:
            
            print('>>>>')
            print(e)
            print(fileX)
           # moveFile(fileX,'/../ok2')
            print('<<<')

def organizaF():
    path = os.getcwd() + "//readtoinsert"
    
    for (dirpath, dirs, files) in os.walk(path):
        for file in files:
            if file.endswith('.csv'):
                moveFile(dirpath+'\\'+file,'ok')
            else:
                removeFile(dirpath+'\\'+file)

def removeFile(file):
    try: 
        os.remove(file)
        print('arquivo removido ',file)
    except Exception as e:
        print('>>>>')
        print('not deleted '+ file)
        print(e)
        print('<<<')

def removeFileContains(path,contains):
    files = glob.glob(path)
    for file in files:
        if(contains in file):
            try: 
                os.remove(file)
            except Exception as e:
                print('>>>>')
                print('not deleted '+ file)
                print(e)
                print('<<<')

def moveFile(scr,dst):
    newpath  = creatFolders(dst)
    try:
        base=os.path.basename(scr)
        shutil.move(scr, newpath+'/'+base)
    except Exception as e:
        print('>>>>>>\n MoveError: \n', e)