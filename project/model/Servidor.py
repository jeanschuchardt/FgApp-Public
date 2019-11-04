from db import db


class Servidor(db.Model):

    __tablename__ = 'servidores'
    id = db.Column(db.Integer, primary_key=True)
    nome = db.Column(db.String(300))
    id_portal = db.Column(db.Integer)

    def __init__(self, nome, id_portal):
        self.nome = nome
        self.id_portal = id_portal

    @classmethod
    def find_by_name(cls, name):
        return cls.query.filter_by(name=name).first()

    @classmethod
    def find_all(cls):
        return cls.query.all()

    def save_to_db(self):
        db.session.add(self)
        db.session.commit()

    def delete_from_db(self):
        db.session.delete(self)
        db.session.commit()
        