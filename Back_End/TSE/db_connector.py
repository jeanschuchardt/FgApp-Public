from sqlalchemy import create_engine
from sqlalchemy.sql import select


def connector():
    engine = create_engine('mysql://root:example@localhost:3308/datastage')
    print(engine)
    # connection = engine.connect()
    # result = connection.execute("select * from tb_estados")
    # # s = select(['tb_estados'])
    # r  = conn.execute(s)

connector()


