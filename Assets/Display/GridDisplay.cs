using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class GridDisplay : MonoBehaviour
{

    // Hauteur de la grille en nombre de cases
    public static int height = 22;

    // Largeur de la grille en nombre de cases
    public static int width = 10;
    public static List<List<SquareColor>> board = new List<List<SquareColor>>();    

    // Cette fonction se lance au lancement du jeu, avant le premier affichage.
    public static void Initialize(){
        bool loose = false;
        
        //initialisation de la grille
        for (int i=0;i<22;i++){
            List<SquareColor> Ligne = new List<SquareColor>();
            for (int j = 0;j<10;j++){
                    Ligne.Add(SquareColor.TRANSPARENT);                
            }
            board.Add(Ligne);
        }         
         GridDisplay.SetColors(board);

          for(int i =0; i < width; i++){
                 board[0][i] = (block.getModel1())[i];
                 board[1][i] = (block.getModel2())[i];
              } 


        //coordonnée objet
        //ligne
        
        //colomne
            
       


         
         
         int k=0;
        while(!loose ) {

          
            SetMoveRightFunction(block.moveRight());
              board[0][i] = (block.getModel1())[i];
                 board[1][i] = (block.getModel2())[i];
             
             

              //get les cases des objets en cours
                //puis on applique la descente
                //puis a chaque tick il faut vérif les collisions --> on verif les cases suivante avant de le déplacer 
                
             
            GridDisplay.SetColors(board);


             //tick per second             
            GridDisplay.SetTickFunction(GridDisplay.TickFunction());
            //GridDisplay.SetTickTime(1);
           
             

        }

   

        


        
        // TODO : Complétez cette fonction de manière à appeler le code qui initialise votre jeu.
        // TODO : Appelez SetTickFunction en lui passant en argument une fonction ne prenant pas d'argument et renvoyant Void.
        //        Cette fonction sera exécutée à chaque tick du jeu, c'est à dire, initialement, toutes les secondes.
        //        Vous pouvez utiliser toutes les méthodes statiques ci-dessous pour mettre à jour l'état du jeu.
        // TODO : Appelez SetMoveLeftFunction, SetMoveRightFunction, SetRotateFunction, SetRushFunction pour enregistrer 
        //        quelle fonction sera appelée lorsqu'on appuie sur les flèches directionnelles gauche, droite, la barre d'espace
        //        et la flèche du bas du clavier.
        //
        // /!\ Ceci est la seule fonction du fichier que vous avez besoin de compléter, le reste se trouvant dans vos propres classes!
                  
    }

    // Paramètre la fonction devant être appelée à chaque tick. 
    // C'est ici que le gros de la logique temporelle de votre jeu aura lieu!
    // Cette fonction peut être une méthode d'une autre classe
    // et doit renvoyer void, et ne prendre aucun argument.
    public static void SetTickFunction(TickFunction function){
        _grid.Tick = function;
    }

    // Paramètre la fonction devant être appelée lorsqu'on appuie sur la barre d'espace 
    // pour faire tourner la pièce dans le sens horaire.
    // Cette fonction peut être une méthode d'une autre classe
    // et doit renvoyer void, et ne prendre aucun argument.
    public static void SetRotateFunction(RotateFunction function){
        _grid.Rotate = function;
    }

    // Paramètre la fonction devant être appelée lorsqu'on appuie sur la flèche de gauche 
    // pour bouger la pièce vers la gauche.
    // Cette fonction peut être une méthode d'une autre classe
    // et doit renvoyer void, et ne prendre aucun argument.
    public static void SetMoveLeftFunction(MoveFunction function){
        _grid.MoveLeft = function;
    }

    // Paramètre la fonction devant être appelée lorsqu'on appuie sur la flèche de droite 
    // pour bouger la pièce vers la droite.
    // Cette fonction peut être une méthode d'une autre classe
    // et doit renvoyer void, et ne prendre aucun argument.
    public static void SetMoveRightFunction(MoveFunction function){
        _grid.MoveRight = function;
    }

    // Paramètre la fonction devant être appelée lorsqu'on appuie sur la barre d'espace
    // pour faire descendre la pièce tout en bas.
    // Cette fonction peut être une méthode d'une autre classe
    // et doit renvoyer void, et ne prendre aucun argument.
    public static void SetRushFunction(RushFunction function){
        _grid.Rush = function;
    }

    // Modifie l'intervale de rendu du jeu. A modifier pour modifier la difficulté en cours de partie.
    public static void SetTickTime(float seconds){
        _grid.tick = seconds;
    }

    // Modifie toutes les couleurs de chaque case de la grille.
    // Cette fonction doit prendre en argument un tableau de LIGNES, de haut vers le bas, contenant 
    // des couleurs de case allant de gauche vers la droite.
    // Vous appellerez a priori cette fonction une fois par TickFunction, une fois le nouvel état de la grille
    // calculé.
    public static void SetColors(List<List<SquareColor>> colors){
        _grid.SetColors(colors);
    }

    // Modifie visuellement le score de l'utilisateur en bas à droite.
    public static void SetScore(int score){
        _grid.SetScore(score);
    }
    // Déclenche visuellement le GameOver et arrête le jeu.
    public static void TriggerGameOver(){
        _grid.TriggerGameOver();
    }



<<<<<<< HEAD
    //function 
    public static void TickFunction(){
        _grid.TickFunction();
    }
=======
   
>>>>>>> a8b5ad85b153686909fbe51e3269879d8071476c



/// Les lignes au delà de celle-ci ne vous concernent pas.

    private static _GridDisplay _grid = null;
    void Awake()
    {
        _grid = GameObject.FindObjectOfType<_GridDisplay>();
        _grid.height = height;
        _grid.width = width;
    }

    void Start(){
        Initialize();
    }
    
}
