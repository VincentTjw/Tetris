# Tetris
Bienvenue dans le projet Tetris de Favennec Mélaine et Terentjew Vincent !

__POUR TELECHARGER LE JEU__ : il faut récupérer le code avec git pull + le tag finale-version ou git pull + la branche DEV-Melaine


#BUT : 
Le projet consiste à créer un jeu Tetris basé sur ses règles.
Mais c'et quoi un Tetris ?

Tetris est un jeu vidéo de puzzle conçu par Alekseï Pajitnov à partir de juin 1984 sur Elektronika 60. (source : wikipedia = https://fr.wikipedia.org/wiki/Tetris).

Le but est de créer des ligne complète avec des pièces de couleur pour gagner des points, la seule façon de perdre est de remplir la grille jusqu'à qu'une nouvelle pièce ne puisse plus apparaître (Game Over).

Action possible : 
- déplacement à droite (flêche de droite)
- déplacement à gauche (flêche de gauche)
- déplacement rapide vers le bas (flêche du bas)
- rotation de la pièce (barre espace)

Dans un premier temps nous avons réfléchit en groupe à l'architecture du projet (les classes, les méthodes).
Puis une fois décidés nous nous sommes répartie le travail :
Mélaine : ...
Vincent : ...

Nous avons pris le temps en séance pour se répartir correctement le travail et se poser des questions mutuellement sur nos codes respectifs.

Au début de projet nous sommes partie d'un squelette du Tetris fonctionnel au niveau de l'affichage sur Unity.

Décomposition des objectifs : 

- objectif 1 : mise en place d'une classe block

- objectif 2 : mise en place de la boucle principale et de l'enumération des type de bloc

- objectif 3 : création des méthodes dans gridDisplay et dans bloc

- objectif 4 : relier bloc et gridDisplay avec avec des appels

- objectif 5 : vérification et résolution des problèmes

- objectif bonus : incrémentation de la vitesse de déplacement d'un bloc en fonction du score et mise en place de son (les sons ont été pris sur youtube)


Problème rencontré/difficulté : lors du déplacement de blockList qui contient notre bloc et une fois arrivé en bas déplacer à l'intérieur de cette listes.

Problème non résolue/non satisfaisant : Le fonctionnement de note rotate ne satisfait pas les règles du Tetris : on ne fait pas tourner notre bloc directement 
                                        mais on tourne la liste contenant notre bloc ce qui à tendance à décaler la pièce.



Futur : On pourrait proposer une interface graphique plus développée et une fonction de rotation plus orientée selon les règles du Tetris (avec un centre de gravité du bloc). On pourrait aussi proposer un menu et une sauvegarde de son score en local.


