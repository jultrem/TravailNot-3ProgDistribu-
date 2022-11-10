from typing import List
from fastapi import FastAPI, HTTPException
from pydantic import BaseModel
import mariadb
import os
import sys


try:
    conn = mariadb.connect(
        user="root",
        password="toor",
        host="mariadb",
        port=3306,
        database="fleuron"
    )
except mariadb.Error as e:
    print(f"Zut, Error connecting to MariaDB Platform: {e}")
    sys.exit(1)

cursor = conn.cursor()

#path = os.environ.get("PATH")
app = FastAPI(root_path="/production/")

class SiteBD(BaseModel):
    id: int
    nom_site: str

class projetBD(BaseModel):
    projet_id: int
    nom_site: str
    site_id: int

@app.get("/")
def root():
    return {"message": "Bienvenue sur Fleuron insdustrie"}

@app.get("production/sites", response_model=List[SiteBD])
def recuperer_sites():
    cursor.execute("SELECT SiteID, Nom FROM sites")
    tuples_projet = cursor.fetchall()
    projets = [SiteBD(id=t[0], nom_site=t[1]) for t in tuples_projet]
    return projets


@app.get("production/sites/{id_site}/projets", response_model=List[projetBD])
def recuperer_projes_en_fonction_de_site(id_site: int):
    cursor.execute("SELECT SiteID, Nom, ProjetID FROM projets WHERE SiteID = ?", (id_site,))
    tuples_projet = cursor.fetchall()               
    if tuples_projet is None:
        raise HTTPException(status_code=404, detail=f"Une site ayant l'identifiant {id_site} n'a pu être trouvée")
    projets = [projetBD(projet_id=t[2], nom_site=t[1], site_id=t[0]) for t in tuples_projet]
    return projets
