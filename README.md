# SpaceShooter1337
Space Shooter 1337 Game (Visual Programming Project)



##1.	Опис на апликацијата 

Апликацијата што ја развиваме е едноставна 2D Shooter игра. 
Целта на апликацијата е да се имплементира едноставна 2D Shooter игра. 
//ова не // Апликацијава, т.е. играта ги има сите функционалности на една 2D игра. 

Целта е да ги преживеете нападите на непријателите и што е можно повеќе да уништите од нив, како и да го уништите главните непријатели кои се појавуваат, притоа собирајќи парички. Начинот на играње е едноставен. 

Целта е да уништите што е можно повеќе непријатели и да ги преживеете нивните напади.

SpaceShooter1337 претставува едноставна 2Д игра во која целта е да уништиме што е можно повеќе чудовишта кои ке ни се најдат на патот т.е не смееме да дозволиме да се судриме со нив бидејки со тоа ние го губиме животот. Единствено ниво, бескрајна игра каде играчот пука непријатели и собира парички, се додека не се удри во непријател или е погоден од ласер, што е крај на играта. 

Играчот претставува/има вселенски борд, со кој може да се движи лево и десно, а константно пукаме. 
Има чудовишта кои доаѓаат во бранови. И непријателите може да ме пукаат. 
Ако се допрам до непријател или ме пукнат, ќе умре играчот и играта завршува. 



##3. Упатство за користењe

Има четири сцени. 


##3.1 Прва сцена

Првата сцена и тоа што се појавува веднаш при отворање на апликацијата е Main Menu сцената. 
При уклучување на играта, се појавува Првата сцена. 

На почетниот прозорец (слика 1) при стартување на апликацијата имаме можност: 
да се избере за почеток на играта (СТАРТ), 
да прочитаме упатство/добиеме помош како се игра играта (ПОМОШ) и, се разбира, 
копче за исклучување на играта (ИЗЛЕЗ). 

При кликнување на ИЗЛЕЗ, играта се исклучува.


##3.2 ВТОРА СЦЕНА
При кликнување на ПОМОШ се отвора нова сцена каде е дадено кратко упатсво за играње на играта. Правила на играта и команди за користење при играта може да се прочитаат во оваа сцена. На оваа сцена има копче за ИЗЛЕЗ, при кое се враќаме на почетниот прозорец (сцена 3.1). 


##3.3 ТРЕТА СЦЕНА
Доколку кликнеме на копчето СТАРТ се започнува играта и ќе се вчита третата сцена, односно сцената каде што се игра играта. 
Контролите за играње се едноставни и ограничени, исто како и можностите што може да ги правите. Начинот на играње е едноставен. 
Во играта играчот има функционалности на движење лево и десно со цел пукање кон чудовиштата и избегнување на куршуми од главните непријатели. 
Играчот може да го движи леталото и да пука кон чудовиштата.
На сцената, во горниот десен агол, може да се забележи колку парички играчот собрал. //Идна функционалност// и колкав е резултатот при уништувања на чудовиштата. 


##3.4 ЧЕТВРТА СЦЕНА
Четвртата сцена се појавува кога играчот умира во играта. 
После секоја игра завршена (секое умирање на играчот) на играчот му се прикажува колку парички освоил. 
Тука може да се види колку парички има собрано играчот и има две копчиња (ЗАПОЧНИ ОДНОВО) каде можеш да избереш да се вратиш на почетната сцена(сцена 3.1) или (ИЗЛЕЗ) да ја исклучиш играта. 


##4 Правила 

Правилата на играта се следни:

	Играчот има еден живот
	При судар со чудовиште играчот го губи животот ///и играта завршува
	Играчот го губи животот доколку е погоден од некој од главните непријатели ///, со што, повторно, играта завршува
	Ако го изгубите животот ... вие сте изгубиле !

	Чудовиштата кои имаат стандарден health, доколку не се убиени едноставно заминуваат од екранот
	Откако ќе ги испукате чудовиштата (health==0), тие експлодираат во парички
	Паричките треба сам да ги собере играчот (можност за идна функционалност: да се освојува магнет за автоматско собирање на паричките) 

	Главните непријатели имаат поголем health и не си заминуваат се додека не се убиени

	После секој убиен главен непријател се зголемува "нивото"
	Паричките кои се појавуваат при експлозија/убивање на чудовиште, се зголемуваат за едно, после секое "ниво"
	Побрзо доаѓаат чудовиштата после секое "ниво"

	(можност за идна функционалност: да се чува резултат кој ќе се зголемува со секое убиено чудовиште)



##2.	Контроли за игра:
Контролите за играње се едноставни, движењата се ограничени.

Контроли за игра:
Left Arrow - движење на лево со леталото.
Right Arrow - движење на десно со леталото.

