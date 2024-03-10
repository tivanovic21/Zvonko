# MindMatters

## Model rada na projektu
(3) Rad na projektu u suradnji s industrijom.

## Opis projekta
MindMatters je sofisticirana aplikacija koja olakšava psiholozima upravljanje sesijama i pacijentima. Psiholozi mogu autenticirati korisnike, dodavati i upravljati sesijama te pratiti odgovore na zadatke. Aplikacija omogućuje bilješke o sesijama i pacijentima te pristup zdravstvenim podacima. Korisni materijali se dijele temeljem korisničkih glasova, a notifikacije se šalju pacijentima o nadolazećim terminima. MindMatters također nudi kalendarski prikaz i mogućnost dodavanja pacijenata, olakšavajući rad psiholozima unutar sigurnog okruženja.

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
F01 | Registracija i prijava | Funkcionalnost obuhvaća registraciju, prijavu i odjavu korisika iz aplikacije. Prilikom registracije korisnik će unositi osnovne podatke poput emaila, lozinke, imena, prezime i slično te će postojati limitacija za registraciju korisnika, odnosno neće se bilo tko moći registrirati. Prijaviti će se moći samo registrirani korisnici. Odjaviti će se moći samo prijavljeni korisnici. | Toni Ivanović
F02 | Pregled zahtjeva pacijenta | Psiholozi imaju mogućnost pregleda zahtjeva za sesije, te dodavanje, brisanje i ažuriranje istih, upisuju osnovne podatke poput lokacije, vremena i datuma. Prilikom pregleda zahtjeva korisnika korisnik može odgovoriti pacijentu  | Matea Klement
F03 | Dodavanje zadataka pacijentima | Psiholozi imaju mogućnost dodavanja različitih zadataka pacijentima koji su prije toga imali sesiju kod njih, te čitanje odgovora istih. Prilikom dodavanja zadataka pacijentima pacijent će viditi sve korisnike linkove te povezane članke vezane uz trenutni zadatak | Matea Klement
F04 | Uvid u karton pacijenata | Psiholozi imaju pristup zdravlju pacijenata koji su prije toga imali sesiju kod njih. Ova funkcionalnost obuhvaća pregled čitave povijesti tog pacijenta. | Matea Klement
F05 | Evidencija psihoterapijske sesije| Sustav će omogućiti upis bilježaka u svaku pojedinačnu sesiju koju su držali te neke informacije o pacijentu. | Šime Braica
F06 | Notifikacije | Ova funkcionalnost će biti zasebna komponenta koja omogućuje slanje email-ova te SMS-ova psihologu | Jakov Čivčija
F07 | Uvid u raspored | Aplikacija će omogućiti kalendarski prikaz koji prikazuje dane koji su posebno označeni ovisno o tome je li raspored popunjen/prazan/poluprazan. | Jakov Čivčija
F08 | Upis pacijenata | Psiholozi će biti u mogućnosti dodati svoje pacijente u sustav kako bi mogli koristiti aplikaciju. Dodavaju korisnikov email, s kojim se korisnici kasnije mogu registrirat. | Šime Braica
F09 | Upravljanje rasporedom | Ova funkcionalnost obuhvaća rezerviranje termina pacijenta te otkazivanje istih. | Jakov Čivčija 
F10 | Stvaranja PDF dokumenta | Ova funkcionalnost obuhvaća stvaranje PDF dokumenta prilikom pregleda zahtjeva pacijenta | Toni Ivanović
F11 | Slanje korisnih materijala pacijentu | Ova funkcionalnost omogućuje psihologu slanje korisnih materijala da pacijent prouči  | Šime Braica
F12 | Profil korisnika | Profil korisnika predstavljati će posebnu sekciju u aplikaciji, a korinisk će ovdje moći urediti podatke koje je unio prilikom registracije kao i dodati svoju sliku profila i lokaciju ordinacije koja će se prikazivati preko Google Maps sustava. | Toni Ivanović

## Tehnologije i oprema
Koristit ćemo .Net tehnologije, zajedno sa WPF. Prije izrade same aplikacije koristit će se figma kako bi se utvrdio dizajn za aplikaciju. Naravno za verzioniranje koda, koristit će se git i Github. Također lokalni express server sa SQL bazom podataka.
