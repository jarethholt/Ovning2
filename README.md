# C# �vning 2 - Fl�de via loopar och str�ngmanipulation
---

## Huvudmeny

Skapa en huvudmeny f�r programmet som h�ller det vid liv och informerar anv�ndaren. F�r att skapa programmets huvudmeny ska ni g�ra f�ljande:

1. Ber�tta f�r anv�ndaren att de har kommit till huvudmenyn och de kommer navigera genom att skriva in siffror f�r att testa olika funktioner.
2. Skapa skalet till en Switch-sats som till en b�rjan har Tv� Cases. Ett f�r �0� som st�nger ner programmet och ett default som ber�ttar att det �r felaktig input.
3. Skapa en _o�ndlig iteration_, allts� n�got som inte tar slut innan vi s�ger till att den ska ta slut. Detta l�ser ni med att skapa en egen bool med tillh�rande while-loop.
4. Bygg ut menyn med val att exekvera de �vriga �vningarna.


## Menyval 1: Ungdom eller pension�r

F�r att exemplifiera _if-satser_ skall ni implementera, p� uppdrag av en teoretisk lokal bio, ett program som kollar om en person �r pension�r eller ungdom vid angiven �lder. F�r att komma till denna funktion skall ett _case_ i huvudmenyn skapas f�r �1�, detta skall �ven framg� i texten som f�rklarar menyn. F�r att g�ra detta skall ni anv�nda er av en _n�stlad if-sats_. Det skall ske enligt f�ljande f�rlopp:

1. Anv�ndaren anger en �lder i siffror
2. Programmet konverterar detta fr�n en _str�ng_ till en _int_
3. Programmet ser om personen �r ungdom (_under_ 20 �r)
4. Om det ovanst�ende �r sant skall programmet skriva ut: Ungdomspris: 80kr
5. Annars kollar programmet om personen �r en pension�r (_�ver_ 64 �r)
6. Om ovanst�ende �r sant skall programmet skruva ut: Pension�rspris: 90kr
7. Annars skall programmet skriva ut: Standardpris: 120kr

Vi vill �ven f� m�jlighet att kunna r�kna ut priset f�r ett helt s�llskap. L�gg till det alternativet i huvudmenyn (ett case �2�). Det �r �ven ok att ha alternativet i en undermeny. Vi anger d� f�rst hur m�nga vi �r som ska g� p� bio. Fr�gar sedan efter �lder p� var och en och skriver sedan ut en sammanfattning i konsolen som ska inneh�lla f�ljande:

- Antal personer
- Samt totalkostnad f�r hela s�llskapet


## Menyval 2: Upprepa tio g�nger

F�r att anv�nda en annan typ av iteration skall ni h�r implementera en for-loop. Detta ska ni skapa f�r att upprepa n�got en anv�ndare skriver in tio g�nger. Det ska allts� inte skrivas via tio stycken `Console.Write(Input);` utan via en loop som g�r detta tio g�nger. F�r att komma till den h�r funktionen skall ni l�gga till ett `case` f�r �3� i er huvudmeny samt text som f�rklarar detta.

H�ndelsef�rloppet visas nedan:

1. Anv�ndaren anger en godtycklig text
2. Programmet sparar texten som en variabel
3. Programmet skriver, via en _for-loop_ ut denna text tio g�nger p� rad, allts� **UTAN radbrott**. Exempel p� output: 1. Input, 2. Input, 3. Input osv.


## Menyval 3: Det tredje ordet

Ni har tidigare l�rt er hur vi omvandlar _str�ngar_ till _integers_ (tex `int.Parse`, `int.TryParse`) men nu ska vi dela upp en str�ng. Anv�ndaren skall ange en mening, som programmet delar upp i ord via str�ngens `.Split(char)`-metod. Ni skall dela str�ngen p� varje mellanslag. F�r att enkelt lagra detta b�r input sparas som en _var_, d� ni kommer f� tillbaka mer �n en _str�ng_. F�r att testa det h�r skall ni skapa _case_ �4� i er huvudmeny samt skriva en f�rklaring i texten.

H�ndelsef�rloppet f�rklaras nedan:

1. Anv�ndaren anger en mening med minst 3 ord
2. Programmet delar upp str�ngen med split-metoden p� varje mellanslag
3. Programmet plockar ut den tredje str�ngen (ordet) ur input
4. Programmet skriver ut den tredje str�ngen(ordet)


## Dokumentera

Gl�m inte att kommentera er kod noga s� att ni eller andra enkelt kan f�rst� den i framtiden.

Extra uppgifter f�r de som har tid �ver:

1. Validera alla inputs fr�n anv�ndaren. Se till att programmet inte kraschar vid felaktig input.
2. Barn under fem och pension�rer �ver 100 g�r gratis.
3. Hantera flera mellanslag i rad i del 3.
4. Vad du tycker verkar vara intressant att f� med eller vill tr�na p�!
