import glob

class Person:
    def __init__(self, nome, idade):
        self.nome = nome
        self.idade = idade

    def myfunc(self):
        print("oi meu nome é "+self.nome)
        print(self.idade)

p1 = Person("jean",26)
p1.myfunc()