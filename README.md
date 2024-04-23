# Zvonko

## Model rada na projektu
Ovaj projekt se temelji na radu projekta u suradnji s nastavnicima.

## Opis projekta
Zvonko aplikacija služi kao pomoć školama u određivanju i upravljanju zvučnim signalima i sigurnosnim obavijestima putem zvučnih signala. Tehnologije korištene za izradu projekta su Windows Presentation Foundation (WPF), C#, SQL, .NET. Dorada i testiranje ovog projekta je započeto na kolegiju Testiranje i kvaliteta programskih proizvoda. Problemska domena koju ovaj projekt obuhvaća jest označavanje kraja i početka školskog sata u školi. Dodavanjem rasporeda se raspoređuje točno vrijeme zvonjenja koje obavještava nastavnike i učenike.

## Projektni tim

Ime i prezime | E-mail adresa (FOI) | JMBAG | Github korisničko ime
------------  | ------------------- | ----- | ---------------------
Toni Ivanović | tivanovic21@foi.hr | 0016152212 | tivanovic21
Matea Klement | mklement21@foi.hr | 0016154451 | mklement21
Šime Braica   | sbraica21@foi.hr  | 0016155261 | SimeBraica

## Specifikacija projekta
Ovdje navedite funkcionalne i nefunkcionalne zahtjeve koje je vaš projekt do sada obuhvaćao:

Oznaka | Naziv | Kratki opis | Odgovorni član tima
------ | ----- | ----------- | -------------------
F01 | Registracija i prijava | Funkcionalnost obuhvaća registraciju, prijavu i odjavu korisika iz aplikacije. Prilikom registracije korisnik će unositi osnovne podatke poput korisničkog imena, lozinke i naziva škole. Prilikom registracije podaci korisnika biti će zaštićeni hashiranom lozinkom i solju. Postojati limitacija za registraciju korisnika, odnosno neće se bilo tko moći registrirati. Prijaviti će se moći samo registrirani korisnici. Odjaviti će se moći samo prijavljeni korisnici. | Toni Ivanović
F02 | Sinkronizacija s bazom podataka | Sustav će omogućiti preuzimanje svih postojanih zapisa u bazi za prijavljenog korisnika. Biti će omogućena sinkronizacija Entity Framework modela i baze podataka.  | 
F03 | Hitna evakuacija | Sustav će omogućiti pokretanje posebnog zvuka na gumb za hitnu evakuaciju. | 
F04 | Dodavanje zvučnog zapisa | Sustav će omogućiti dodavanje novih zvučnih zapisa u bazu. Ta će se funkcionalnost odvijati na način da se uveze spremljeni zvuk s računala ili snimanjem. Sustav će omogućiti dodavanje više zvučnih oblika; WAV, MP3 | 
F05 | Prijenos govora uživo | Sustav će omogućiti korisniku prijenos govora uživo.  | 
F06 | Upravljanje rasporedom sati | Sustav će omogućiti dodavanje rasporeda sati koji će označavati kada će zvono zvoniti, raspored je moguće urediti za svaki dan u tjednu. Unutar svakog termina u danu moguće je odrediti događaj temeljem kojeg će zvoniti.  | 
F07 | Upravljanje zapisima | Sustav će omogućiti ručno pokretanje zvona kao i pauziranje i zaustavljanje.  |
F08 | Dodavanje slike | Sustav će korisniku omogućiti da postavi sliku (logo škole). Sliku će biti moguće dodavati, obrisati, zamijeniti.  |
F09 | Upravljanje događajima | Sustav će omogućiti dodavanje novih zvučnih zapisa u bazu te ih pohraniti u obliku događaja; mali odmor, veliki odmor. Funkcionalnost će se odvijati na način da se uveze spremljeni zvuk, odabere vrsta događaja, vrijeme trajanja.  |



## Tehnologije i oprema
Koristit ćemo .Net tehnologije, zajedno sa WPF. Prije izrade same aplikacije koristit će se figma kako bi se utvrdio dizajn za aplikaciju. Naravno za verzioniranje koda, koristit će se git i Github. Također lokalni express server sa SQL bazom podataka.
