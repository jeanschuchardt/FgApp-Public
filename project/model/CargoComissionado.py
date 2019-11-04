from db import db


class CargoComissionado(db.Model):
    def __init__(self, sigla, nivel):
        self.sigla = sigla
        self.nivel = nivel
