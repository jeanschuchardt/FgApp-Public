import os    
import zipfile
import shutil

def unzip_to(source_dir,dest_dir):
    try: 
        zip_ref = zipfile.ZipFile(source_dir,'r')
        zip_ref.extractall(dest_dir)
        zip_ref.close()
    # os.remove(fileX)
    except:
        print('FILE NOT UNZIPED '+ source_dir)

def unzip_here(source_dir):
    try: 
        zip_ref = zipfile.ZipFile(source_dir,'r')
        zip_ref.extractall(source_dir)
        zip_ref.close()
    # os.remove(fileX)
    except:
        print('FILE NOT UNZIPED '+ source_dir)

def create_folder(path):
    try:
        if not os.path.exists(path):
            os.makedirs(path)
        if  os.path.exists(path):
            print('folder exists')
    except:
        print('PATH NOT CREATED '+ path)

def unzip_move(source_dir,dest_dir,dest_zip):
    try: 
        zip_ref = zipfile.ZipFile(source_dir,'r')
        zip_ref.extractall(dest_dir)
        zip_ref.close()
        try:
            shutil.move(source_dir, dest_zip)
        except:
            print('ZIP DO NOT MOVED '+ source_dir)    
    except:
        print('FILE NOW UNZIPED '+ source_dir)

# def organize_folder(path,new_folder):
#     for (dirpath, dirs, files) in os.walk(path):
#         for file in files:
#             if file.endswith('.csv'):
#                 moveFile(dirpath+'\\'+file,new_folder)
#             else:
#                 removeFile(dirpath+'\\'+file)

def list_files(path):
    files_r = []
    print(path)
    for (dirpath, dirs, files) in os.walk(path):
        for file in files:
            files_r.append(dirpath+'/'+file)
    return  files_r   
        

            
def move_file(source_dir,dest_zip):   
    try:
        shutil.move(source_dir, dest_zip)
    except Exception as e:
        print('ZIP DO NOT MOVED '+ source_dir)    
        print(e)    

def delete_file(source_dir):   
    try:
        os.remove(source_dir)
    except Exception as e:
        print('ZIP DO NOT DELETED '+ source_dir)    
        print(e)    