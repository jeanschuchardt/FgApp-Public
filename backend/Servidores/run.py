from util import  files_manipulation as f_ma
from downloader import download_files as down_files
from inserter import insert as inst
import yaml

def read_config():
    #ler do arquivo de configuração
    with open("properties.yml", 'r') as ymlfile:
        cfg = yaml.load(ymlfile, Loader=yaml.FullLoader)
    return cfg

def create_folder_structure(properties):
    f_ma.create_folder(properties['folders']['f_zip'])
    f_ma.create_folder(properties['folders']['f_unzip'])
    f_ma.create_folder(properties['folders']['f_inserted'])
    f_ma.create_folder(properties['folders']['f_zip_backup'])
    

    
    return True

def orgaziner_files(properties):
    f_zip = properties['folders']['f_zip']
    f_unzip = properties['folders']['f_unzip']
    f_zip_b = properties['folders']['f_zip_backup']

    list_files = f_ma.list_files(f_zip)
    for file in list_files:
        f_ma.unzip_to(file,f_unzip)
        f_ma.move_file(file,f_zip_b)

def delete_files(properties):
    f_unzip = properties['folders']['f_unzip']
    list_files = f_ma.list_files(f_unzip)
    for file in list_files:
        if ('Cadastro' not in file and 'Remuneracao' not in file):
             f_ma.delete_file(file)

def insert_files(properties):
    f_unzip = properties['folders']['f_unzip']
    f_inserted = properties['folders']['f_inserted']
    list_files = f_ma.list_files(f_unzip)

    result = {}
 
    for file in list_files:
        #print(file)#todo
        x = file.split('/')
        x = x[-1].split('_')
        x = x[0]
        
        if(x not in result.keys()):
            result.update({x:file})        
        else:
            value = result.get(x)
            temp_list  = []
            temp_list.append(value)
            temp_list.append(file)
            d = {x:temp_list}
            result.update(d)
            
    for i, x in enumerate(result.keys()):
        print(result.get(x))
        paths = result.get(x)

        cadastro = ''
        remuneracao = ''
        if 'Cadastro' in paths[0]:
            cadastro = paths[0]
            remuneracao = paths[1]
        else:
            cadastro = paths[1]
            remuneracao = paths[0]
        
        inst.insert_cadastro(cadastro,remuneracao)



    
   
############
properties = read_config()
#create_folder_structure(properties)
#down_files.info_loader(properties)
#orgaziner_files(properties)
#delete_files(properties)

insert_files(properties)










