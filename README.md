# BA Data Augmentation via Game Engine

## Anleitung zum Aufbau der Umgebung

Hier eine kurze Veranschaulichung, wie die Daten verarbeitet werden:
- Unity Export: Erstellt File "KeypointsExport(Nicht)Kompensiert"
- Jupyter Notebook Pipeline: Liest File "KeypointsExport(Nicht)Kompensiert" ein und exportiert File "KeypointsBereinigt(Nicht)Kompensiert"
- Jupyter Notebook Datenanalse: Liest File "KeypointsBereinigt(Nicht)Kompensiert" ein

------------------------------------------------------------------------------------------------------------------------

1. GitHub Projekt in Ordner kopieren

   <img width="600" alt="image" src="https://github.com/kollesal/VR-Quest/assets/106104526/bbe7b2fe-76e4-428a-ae57-5801d97c21cd">

2. Das Projekt "VR-Quest" folgendermassen öffnen:

   <img width="600" alt="image" src="https://github.com/kollesal/VR-Quest/assets/106104526/7772920f-7850-4a47-9ae4-044cefa796d8">

3. Scene "AvatarExport" öffnen (im Assets/AvatarDataAugmentation/Scenes und NICHT Assets/Scenes)

   <img width="600" alt="image" src="https://github.com/kollesal/VR-Quest/assets/106104526/2faa822c-2cfc-4751-ba4d-8294045e3663">

4. Fehler Beheben:

- 4.1 GameObject: Script 'AvatarManager' hinzufügen
   
    <img width="600" alt="image" src="https://github.com/kollesal/VR-Quest/assets/106104526/d86cc75c-0843-4bfc-ab1e-9f5f27bf6353">

- 4.2 Avatars ersetzen: Mit GameObject 'x' 2 Avatare hinzufügen. Name + Tag ergänzen:

    <img width="600" alt="image" src="https://github.com/kollesal/VR-Quest/assets/106104526/0f4bb417-f7b7-4327-a0ce-30abcaff1b4c">

      !Wichtig! Bei beiden die Tags 'Kompensiert' und 'Nicht Kompensiert' setzen!

5. Den Code laufen lassen. Das 1. Mal wird es fehlschlagen, beim 2. Mal läuft es durch.
   Manchmal läuft es ein bisschen lange. Solange es nicht in T-Pose ist, wird es laufen.

6. Bei der Ausführung der Unity Umgebung werden die zwei CSV Dateien befüllt
   
   <img width="600" alt="image" src="https://github.com/kollesal/VR-Quest/assets/106104526/a7d38f80-6ccb-4e86-9452-6f6874f84f0a">

8. Diese Files werden dann vom Jupyter Notebook "Drinking Task Pipeline Augmented" eingelesen

   <img width="600" alt="image" src="https://github.com/kollesal/VR-Quest/assets/106104526/7f2fbb94-a3a4-4866-b046-0923d390ee22">

9. In diesem Notebook werden die Files bereinigt und danach erneut für die Datenanalyse exportiert

   <img width="600" alt="image" src="https://github.com/kollesal/VR-Quest/assets/106104526/27a9551a-fef0-4312-b90e-7a143daf58e0">

10. Im Jupyter Notebook "01_ Datenanalyse Kompensiert und nicht Kompensiert" werdeb die bereinigten Files eingelesen
    
   <img width="600" alt="image" src="https://github.com/kollesal/VR-Quest/assets/106104526/5263a75c-2cbb-4476-919c-f3a38af14ca2">



------------------------------------------------------------------------------------------------------------------------
Durch diese Schritte wurden die Daten generiert, exportiert, bereinigt und analysiert.
------------------------------------------------------------------------------------------------------------------------

### Wo können die 5 Ziele der BA gefunden werden?
- Dokumentation: https://zhaw.sharepoint.com/:f:/r/sites/DataAugmentationviaGameEngine/Freigegebene%20Dokumente/General/Bachelorarbeit?csf=1&web=1&e=yo0ug7
- Projektmanagement: https://github.zhaw.ch/users/kollesal/projects/3/views/1
- Veränderung der Animationen gemäss den Einstellungsveränderungen von DeepMotion: Assets/AvatarDataAugmentation/01 Collecting Data: DeepMotion Animation
- Bestehendes Modell wird verglichen: Assets/AvatarDataAugmentation/02 Data Augmentation: Modellerweiterung
- Export von Körperkoordinaten in Unity mit Datenanalyse MediaPipe und DeepMotion (wie gleich/unterschiedlich die Werte sind): Assets/AvatarDataAugmentation/03 Data Analysis: DeepMotion and MediaPipe

- VR Umgebung erstellt: In Projekt und Dokumentation enthalten


------------------------------------------------------------------------------------------------------------------------
  
## Übergeordnetes Ziel:
- Wie kann ich aus 1 Video verschiedene Videos/Animationen erstellen

## 5 Ziele für BA
- Dokumentation
- Projektmanagement
- Veränderung der Animationen gemäss den Einstellungsveränderungen von DeepMotion
- Export von Körperkoordinaten in Unity mit Datenanalyse MediaPipe und DeepMotion (wie gleich/unterschiedlich die Werte sind)
- Bestehendes Modell wird verglichen

- VR Umgebung erstellt -> Zusatzpunkt

## Ziel:
- Recherche: Gibt es eine Lösung, welche die Bewegungn eines Video/Camera auf einem Avatar überträgt
- Dies könnte auch als Baseline für unsere Lösung dienen.
- Bewegungen von einem Video via Keypoints Extraktion zu einem Avatar übertragen. (dies wäre die BA)

## 16.05.2024
- Dokumentation
- Projektmanagement
- Veränderung der Animationen gemäss den Einstellungsveränderungen von DeepMotion
  Sitting ist schlechter als T-Pose, deswegen wird T-Pose verwendet
- Export von Körperkoordinaten in Unity mit Datenanlyse MediaPipe und DeepMotion (wie gleich/unterschiedlich die Werte sind)
  Datenbereinigung zusammen anschauen -> Modell Nils
  
- Bestehendes Modell wird verglichen
  Vergleich wurde mit X_train und y_train vorgenommen:
   - Performance besprechen. Gemäss BA Nils wird folgendes Modell verwendet: RNN 5 Frames und 64  Neurons
   - Performance nur Originaldaten: 93% (in BA: 89%)
   - Performance Originaldaten + augmentierte Daten: 91%
   - Performance Originaldaten + augmentierte Daten ohne Nullpunkte: 97%
   - Performance Originaldaten + augmentierte Daten ohne Nullpunkte und X_train, y_train: 99%

### Nächste Schritte:
- Dokumentation
  
## 02.05.2024
- Veränderung der Animationen gemäss den Einstellungsveränderungen von DeepMotion
   - Erledigt 
- Export von Körperkoordinaten in Unity mit Vergleich MediaPipe und DeepMotion (wie gleich/unterschiedlich die Werte sind)
   - Erledigt -> Erkenntnisse anschauen
   - Auswirkungen von verschiedenen Einstellungen in DeepMotion wird noch geprüft
   - RPA Stand
- Bestehendes Modell wird verglichen
   - Erledigt 
   - Performance besprechen. Gemäss BA Nils wird folgendes Modell verwendet: RNN 5 Frames und 64  Neurons
   - Performance nur Originaldaten: 93% (in BA: 89%)
   - Performance Originaldaten + augmentierte Daten: 91%
   - Performance Originaldaten + augmentierte Daten ohne Nullpunkte: 97%

### Nächste Schritte
- "Hauptteil" ist durch und habe Erkenntnisse. -> Falls diese so i.O. sind -> Start Dokumentation 2.0
- VR Brille in VR Umgebung anfügen
- Zusätzliche Analysen von Daten (verschiedene Einstellungen DeepMotion)
- API Stand // RPA -> Wird nicht umgesetzt

- Schulter Distanz aller Bewegungen ausrechnen -> Gewichtung verwenden DeepMotion hat 5x Gewichtung und MediaPipe 1x nehmen
  - Alle Zahlen durch diesen Wert Teilen
  - Kompensiert / Nicht Kompensiert bei Analyse ergänzen
  - Nicht bewegte Hand analysieren. Funktioniert es dort?

## 18.04.2024: 2. Zwischenbesprechung - BA
Protokoll wird auf MoLeNa hochgeladen

- Dokumentation
-> Einblick in BA? Nein
- Projektmanagement
-> Führen von Project
- Veränderung der Animationen gemäss den Einstellungsveränderungen von DeepMotion
-> API zu teuer -> RPA? keine Prio
- Export von Körperkoordinaten in Unity mit Vergleich MediaPipe und DeepMotion (wie gleich/unterschiedlich die Werte sind)
-> Zuerst Bereinigung von Unity Daten vornehmen vor Analyse
-> Verschiedene Settings von DeepMotion performen besser / schlechter und kann analysiert werden
-> Tracking von Kopf vorgenommen -> Lieber rechte Hand Y-Koordinaten Kompensation?
-> For Kopf und Arm X und Y Koordinaten vergleichen
-> Z-Koordinaten ebenfalls miteinbeziehen
-> Analyse, warum die Bewegung etwa um 25 Frames verzögert ist

- Bestehendes Modell wird vergleicht
-> Welches bestehende Modell soll verwendet werden?

- VR Umgebung erstellt
-> Gibt es ein Update? Nein

## 04.04.2024 - Verschiedene offene Themen
- Bis anhin habe ich für die Erstellung des Animationsclips in DeepMotion die 3 Videos aus dem GitHub verwendet. Kannst du mir mehr Aufnahmen zur Verfügung stellen, oder soll ich mich einfach auf diese 3 konzentrieren? 
-> Gibt es einen automatischen Teil von Erstellung der Animationsclips aus Videos?
-> Die 3 Videos von GitHub verwenden anhand Proof of Concept
-> Patientendaten und dadurch nicht möglich
- Der Frame (Zeilen in CSV pro Aufnahme) von Unity ist viel länger als der Frame in MediaPipe. Soll ich in Unity einfach einen Average von etwa 200 Frames definieren? Ich kann auch eine Random Variable ergänzen in einem Range. Soweit ich das Modell von Nils verstehe, hat er dieses Problem auch und hat sich einfach darauf konzentriert, die "wichtigen" Teile des Videos herauszuschneiden.
-> Lösung passt mit jeder 1/10 Sekunde
- Ich wäre froh um ein paar Auszüge von den bereinigten CSV-Dateien aus dem von Nils erstellten Modell. Meine Einstellungen sollten nun den Einstellungen von ihm übereinstimmen, aber ich habe bis jetzt die CSV Datei aus dem GitHub benutzt. Diese ist ja nicht eine der bereinigten Dateien. Die Dateien brauche ich, um genau evaluieren zu können, wie genau DeepMotion ist, und dann auch für die Performance
-> Schauen, wo X-Achse ist, und entsprechend Avatar schieben.
-> Skalierung anhand der Schulter und dann auf den ganzen Körper Schlüsse ziehen. Durchschschnitt ausrechnen des Abstandes zwischen Schultern
- Die Testumgebung für VR ist aufgesetzt. Gibt es eine Möglichkeit, dass ich eine VR Brille anschliessen kann? Oder soll die neue Klassifizierung einfach in Unity ohne VR vorgenommen werden?
-> wird besorgt in 2-3 Wochen
- Umgang mit Emote SDK -> soll ich das auch in der BA dokumentieren?


## 14.03.2024: 1. Zwischenbesprechung - Dispostion
Protokoll wird auf MoLeNa hochgeladen

[X] DeepMotion als Basis von Bewegung machen -> XYZ Koordinaten extrahieren. Animation Rigging machen und neu XYZ Koordinaten extrahieren. Haben sie die XYZ Koordinaten verändert?




### Abklärungen Disposition
Hypothese: (Wie) kann Unity durch synthetisch hergestellte Bewegungsaufnahmen mittels Data Augmentation bestehende Modelle positiv beeinflussen?
2. Hypothese: VR Umgebung in Unity bauen (braucht wenig Zeit) -> Physio bewertet 5 synthetisch bewegte Videos: Kompensation / Nicht Kompenation. 
   Wird eine ursprünglich "Kompensierte" Bewegung nach synthetischer Veränderung immernoch als "Kompensiert" gekennzeichnet?


Forschungsmethode: 
- Erhebungsmethode: Qualitativ + Fallstudie
- Erhebungsdesign: Einzelfall
- Ausrichtung: umfassende Analyse
- Ziel: Entwicklung neuer Theorien
- Messung: Explorative Untersuchung
- Studienobjekte: Einzelfälle
- Auswertung: interpretativ
- Qualitätskriterien: Transparenz, Intersubjektivität und Reichweite

- Induktives Vorgehen: Reale Welt als Ausgangslage und führt zu theoretischen Erkenntnissen (Avatare erstellen, um zu Testen, ob dies eine Alternative sein kann)

## 29.02.2024
### Use Cases

#### DeepMotion + Custom Scripting

1. Video von Bewegung wird in DeepMotion hochgeladen
2. DeepMotion erstellt ein Animation Clip von Bewegung
3. Animation wird in Unity hochgeladen und Avatar zugewiesen
4. Animation wird anhand der Veränderung von Keypoints verändert -> entweder manuell / UMotion Package / Scripting
6. Neuer Animation Clip der Bewegung wird gespeichert
7. Neuer Animation Clip kann anderen Avatars zugewiesen werden (Proj. 2)

UMotion:

https://github.zhaw.ch/storage/user/6024/files/8517aab5-3ad3-4f74-ab11-c69f1e19f810

#### DeepMotion + In DeepMotion andere Einstellungen machen

#### DeepMotion + Animation in Unity an Avatar übergeben -> KeyPoints extrahieren -> sind diese anders, als diese vom Originalen Video?
Start: Überprüfung DeepMotion Animation vs Video
Mediapipe Nase ist 0,0,0 -> Avatar hat Nase 0,0,0
Skalierung ist wichtig von Video

#### DeepMotion + Animation Rigging

1. Video von Bewegung wird in DeepMotion hochgeladen
2. DeepMotion erstellt ein Animation Clip von Bewegung
3. Animation wird in Unity hochgeladen und Avatar zugewiesen
5. Positionen von Gliedmassen werden anhand Animation Rigging verändert, während die Animation läuft
6. XYZ Werte werden extrahiert

Animation Rigging:

https://github.zhaw.ch/storage/user/6024/files/9eb6871e-9d43-4ee9-b863-9127ae1a79cc

### Kinetix: 
- Leider habe ich keine weiterren Informationen zu den Keyframes gefunden 
- Für die Emotes wird ein GLB File verwendet
- Kinetix beschreibt die Emotes als die Ablösung von Gifs, welche Self-expression durch diese Avatar-Emotes bieten soll
- Der folgende Ausschnitt deutet für mich darauf hin, dass der Prozess komplett ausserhalb der Unity Animation läuft
'To avoid the conflict between generation of humanoid AnimationClip at runtime and the Animator, we developed a proprietary Animation System composed of "KinetixCharacterComponent", "ClipSampler" and "BlendAnimation" scripts. They are automatically added at the GameObject of your animator when you initialize your SDK.'  https://docs.kinetix.tech/integration/integrate-kinetix-sdk/sdks-core-package

Das untenstehende Bild zeigt die Ansicht, wenn man sich im Portal von Kinetix einloggt. Die Emotes sind entsprechend aufrufbar, aber es gibt ekeine weiteren Informationen:

https://github.zhaw.ch/storage/user/6024/files/7b17d732-0b0d-4d10-b9e4-0764c1a9df77

### Wie funktionieren die Animationen in Unity und wie werden die Animationen bearbeitet?
#### Animation System (Animation data und Animation clips): Keyframing von Bewegungen im Unity Editor
![AnimationOverview-Controller](https://github.zhaw.ch/storage/user/6024/files/e46073b3-b908-4c67-bc37-588a37612268)

- Mecanim (State Machine -> Animator Controller): Retargeting animationen und Blending -> Hauptkonfigurator von Animationen

- Blend Trees and State Machines: Obwohl ein Avatar gerade in einem State vom Animator Controller ist, können andere Bewegungen gemacht werden (idle + in alle Richtungen laufen). Weitere Parameter können definiert werden

- Inverse Kinematics (IK): Für Definierung von Rotationsbewegungen von Gelenken
- Animation Retargeting: Animation kann auf verschiedene Avatare übertragen werden

#### Weitere
- Motion Capture (MoCap): Echtzeit Bewegungen werden direkt an Avatars übertragen
- Scene Motion Capture: Bewegungen werden zu einem Animation Clip umgewandelt. -> Könnte eventuell verwendet werden, um die Kinetix SDK Bewegungen in eine Animation Clip zu transformieren.
- https://assetstore.unity.com/packages/tools/animation/scene-motion-capture-19622#reviews

- Animation Rigging Package / Procedural Animation: Bewegungen werden nicht klar vorgegeben. Das Unity Package übernimmt selbst Bewegungen (Hand wird von links nach rechts bewegt. Ellbogen bewegt sich automatisch mit)

- Motion Matching for Unity Package: State Machine wird nicht mehr benötigt und Avatare können je nach was gerade gebraucht wird, zwischen den States automatisch wechseln. Die Pose, die gerade am besten passt, wird hineingeblended. Ist over-engineered für dieses Projekt
  https://assetstore.unity.com/packages/tools/animation/motion-matching-for-unity-145624

- Animation Scripting: Mit C# können Bewegungsmuster programmiert werden

- Third-party Animation Tools: Plugins wie Mixamo oder ReadyPlayerMe

### Wie kann eine Animation verändert werden?
'Are you using generic or humanoid rig setup? Humanoid rig setup animations can not be edited unless using Umotion or other asset from the store. Generic can be modified as needed.'
'You could create two poses or animations (external animation package) aiming up and aiming down. Set them in a new additive layer and put them in a blend tree. Then blend between the two animations based on the input of the player.'

- Timeline: Edit the Animation Curve / Keyframe
- Custom Scripts -> AnimatorOverrideController
- Muscle Animation Editor Package (https://assetstore.unity.com/packages/tools/animation/muscle-animation-editor-32233)
- UMotion Pro - Animation Editor Package (https://assetstore.unity.com/packages/tools/animation/umotion-pro-animation-editor-95991)
- Very Animation Package (https://assetstore.unity.com/packages/tools/animation/very-animation-96826)

## 15.02.2024
### Erster Versuch Definition + Abgrenzung BA
Diverse Möglichkeiten zur Umsetzung: 

#### A) Probieren: Nachbauen und Ausbauen von Lösung von DeepMotion
Avatar wird verändert, um neue Bewegung zu generieren (Proj. 2)
Zu viel: Kann nicht in gleicher Qualität umgesetzt werden

#### B) Bevor Bewegung dem Avatar übertragen wird, werden die KeyPoints bereits verändert

```diff
! C) Prototyp und Use Case erstellen
! Lösung Animation: schon da -> DeepMotion
! Ergänzung BA: Veränderung der Animationen
! Welche Möglichkeiten gibt es in Unity, um einen Avatar zu animieren ++ Wie kann ich welche Animationsmöglichkeit wie verändern ->> Kinetix wie wird es bewegt?

! 1.	Schritt:
! Ergänzung Tools: Analyse/Research
! Wie werden Avatare von Videos erstellt?

! 2. Schritt:
! Wie funktionieren die Animationen in Unity und wie werden die Animationen bearbeitet?
```

#### D) Video nehmen und bereits verändern durch zb DeepFake Staple Diffusion -> Personen mit anderen Begebenheiten sollen die Bewegungen machen. 
Ist die Bewegung dann anders, ob ein Sportler oder alte Person macht? 
Wird nur das Äussere verändert, oder auch die Bewegung an sich?
Avatar wird nicht benötigt

#### Ergänzung BA
-	Analyse/Research: Verschiedene Tools ausprobieren und je nach Use Case bewerten

- Storytelling Usecase: Virtuelle Umgebung machen, wo Physiotherapeut beurteilt, ob die neue Bewegung des Avatars kompensiert ist oder nicht. 

Weiteres Vorgehen bis nächstes Meeting:
- [x]	GitHub erstellen und Teams für Ablage
-	[x] Definition von Use Cases und Research

## 02.02.2024
### Recherche: Gibt es eine Lösung, welche die Bewegungen eines Video/Camera auf einem Avatar überträgt

#### Kinetix SDK
Die 3 Videos vom Drinkgesture Github habe ich exportiert und hier animiert: 

Vorteil: Videos können unbegrenzt und relativ einfach auf Avatare übertragen werden. 
Problem: Erstellte Animationen können nicht angeschaut werden.

- Wie funktioniert die Animationen genau?
- Was sind unsere Möglichkeiten, um diese Animationen abzuändern?
- Gibt es Möglichkeiten?
- Kann die Bewegung konvertiert werden zb in FBX

https://github.zhaw.ch/storage/user/6024/files/b5e260f4-c778-4889-9e98-5a41f013f5a6

#### DeepMotion
Zuerst kann ein Video in DeepMotion hochgeladen werden:

https://github.zhaw.ch/storage/user/6024/files/2eca383c-0b8c-44e2-abc2-a1cbaced128e

Danach mit FBX exportiert und in Unity hochgeladen werden. Dann noch wie immer Animator Controller erstellen, dann übernimmt der Avatar entsprechend die Animation:

https://github.zhaw.ch/storage/user/6024/files/a720370d-e0da-4227-ac8a-9cd37519d2ce

-	Motion Smoothness -> ist kostenpflichtig aber soll auch in Lösung inkludiert werden

#### Move One
Konnte ich nicht ausprobieren, aber könnte noch interessant sein.

https://github.zhaw.ch/storage/user/6024/files/8e9818c3-1484-443c-88f8-7bfc20b922c4

#### Omnianimation
Könnte interessant sein, weil die Parameter der Avatare angepasst werden können. Aber nicht für dieses Projekt.
https://omnianimation.ai
