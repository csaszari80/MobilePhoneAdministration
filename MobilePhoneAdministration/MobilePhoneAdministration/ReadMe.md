# Mobiltelefon nyilvántartó alkalmazás
## Specifikáció:
### Bevezetés
A Borsodchem Zrt. számos mobiltelefon készülékkel rendelkezik melyeket azon munkavállalóinak rendelkezésére bocsát,
akiknek munkakörükből adódóan szükségük van rá. A kiadott mobiltelefonokkal kapcsolatosan a teljes körű ügyintézést
(Szerződéskötés, SIM kártyák beszerzése; Telefonkészülékek beszerzése; Telefonkészülékek kiadása,
szükség esetén cseréje; garanciális ügyintézés; és az ezekkel kapcsolatos adminisztráció) a Borsodchem Zrt. végzi.
E feladatok elvégzéséhez szükséges egy olyan alkalmazás amely nyilvántartja a BC tulajdonában lévő 
telefonkészülékeket, a szerződésekhez tartozó SIM kártyákat, és a kiadott telefonokat. A nyilvántartás céljára
szolgáló korábbi alkalmazás elavult, már kivezetésre váró szervereken fut, a felhasználói adatokat a már leállított
HR rendszerből venné, továbbá a dokumentációja sem áll rendelkezésre, így migrációja, és továbbfejlesztése 
nem megoldható, ezért új alkalmazás fejlesztésére van szükség.
### Az alkalmazás célja:
Az alkalmazás a Borsodchem Zrt. tulajdonában lévő mobiltelefonok, a hozzájuk tartozó SIM kártyák, és a készülékeket
használó munkavállalók nyilvántartására szolgál. Az alkalmazás támogatja a mobiltelefonokkal kapcsolatos költségek 
kiterhelésének folyamatát. A jelenleg kiadott telefonokkal kapcsolatos adatok az alkalmazás üzembe helyezésekor egy
iniciális feltöltés keretén belül az új alkalmazás adatbázisába is átkerülnek ugyanakkor **az alkalmazásnak nem célja**
a kiadott telefonok korábbi alkalmazásban tárolt teljes történetének nyilvántartása. 
## Képernyőkép vázlatok:
Később

## Szereplők és adataik:
- Kiadásra jogosultak
  - Név
  - CPID
  - AD login
- *Készülék típusok*
  - *Gyártó*
  - *Típusjel*
  - *Készülék kategória(telefon, okostelefon)*
- *Készülékkategóriák*
  - *Megnevezés*
- Telefonkészülékek:
  - *Eszközszám**
  - *Típus(gyártó és típusjel)*
  - Készülék IMEI szám
  - Megjegyzés
- SIM kártya kategóriák
  - Megnevezés 
- SIM kártyák:
  - *Szerződésszám*
  - Eszközszám
  - Szerződés kelte
  - Kártya IMEI szám
  - *Telefonszám*
  - *Kategória(telefon, internet, belső adatforgalom)*
  - PIN1
  - PIN2
  - PUK1
  - PUK2
  - Megjegyzés

- Költséghelyek(CostPlace): A költéghelyek adatbázisa automatikusan lesz karbantartva azonban lehetőség lesz kézzel is felvinni adatokat
  - CostCode: Költésghelykód
  - CostName: Költséghely név
  - OrganizationCode: Szervezeti egység kód
  - OrganizationName: Szervezeti egység név
  - ForwardedBill: Igaz, ha a szervezeti egység számára nem közvetlenül kerülnek kiterhelésre a költségek, hanem továbbszámlázzuk őket

- Felhasználók(User): A lehetséges felhasználók adatai két forrásból kerülnek feltöltésre az egyik csoport 
  adatait a SAPHR-ből kapott adatok alapján tölti fel és tartja karban egy ütemezett SQL job (editable 0) 
  a másik csoport tagjait kézzel visszük fel és tartjuk karban(editable 1) az alkalmazáson keresztül ezen felhasználók
  esetében Elegendő a Név a CPID(ha van) és a Költséghely megadása
  - Name: Név kötelező
  - CPID: Dokszám
  - ADLogin: ADLogin
  - CostPlace: hivatkozás a költséghelyre
  - Active: A felhasználónak van e élő munkaszerződése
  - Editable: Igaz, ha a felhasználóról nem jön automatikusan adat a SAP HR-ből
  - Hidden: Rejtett szám a szám megjelenjen-e a telefonkönyv export-okban
- Készülékkiadások
  - *SIM kártya*
  - *Készülék*
  - *Felhasználó*
  - *Kiadás kelte*
  - *Költséghely*
  - Kiadta
  - Megjegyzés


## Forgatókönyvek
### Egy telefonkészülék kiadása:
A felhasználó aki jogosult vállalati mobiltelefon használatára átveszi a telefonját a Hálózati és telekommunikációs 
csoport készülékkiadásra jogosult tagjától. A kiadást végző személy kiválaszt egyet a még kiadható készülékek közül
egyet választ, hozzé egy szabad SIM kártyát(telefonszámot), és átadja a felhasználónak, az átadást rögzíti 
az alkalmazásban.

 