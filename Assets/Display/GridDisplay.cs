using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random=System.Random;
using System.Threading.Tasks;
using System.Threading;
using System;



public class GridDisplay : MonoBehaviour
{
    // Hauteur de la grille en nombre de cases
    public static int height = 22;
    // Largeur de la grille en nombre de cases
    public static int width = 10;
    public static Random _R = new Random ();
    public static List<List<SquareColor>> board = new List<List<SquareColor>>();

    //info : liste des index des lignes à clear une fois complète
    private static List<int> lines = new List<int>();
    private static int sizeListLines =0;
    public static SquareColor color = SquareColor.TRANSPARENT;  
    public static Block block= null;
    private static float speedGame = 0.99F;
    public static  bool loose = false;
    public static  bool sameBlock = false;
    public static TypeOfBlock typeOfBlock;
    private static int scoreTotal=0;
    private static int gainPoint =0;
    private static bool gainThreeHundredPoint = true;
    // Cette fonction se lance au lancement du jeu, avant le premier affichage.
    public static void Initialize(){
        //initialisation de la grille
        for (int i=0;i<GridDisplay.height;i++){
            List<SquareColor> Ligne = new List<SquareColor>();
            for (int j = 0;j<GridDisplay.width;j++){
                    Ligne.Add(SquareColor.TRANSPARENT);                
            }
            board.Add(Ligne);
        }
        GridDisplay.SetColors(board);                 
        Task t1 = Task.Run(() => { 
            while(!GridDisplay.loose){
                //accélération de la vitesse plus le score est haut
                if(gainThreeHundredPoint){
                    gainPoint = scoreTotal;
                    gainThreeHundredPoint = false;
                }
                if(gainPoint+100 < scoreTotal && speedGame > 0.20F){
                    speedGame = speedGame - 0.01F;
                    gainThreeHundredPoint = true;
                }        
                typeOfBlock = RandomEnumValue<TypeOfBlock>();
                color = getAColorblock();
                block = new Block();

                if(!GridDisplay.loose){                    
                sameBlock = true;
                }else {
                    sameBlock = false;
                }
                while(sameBlock){
                    GridDisplay.SetTickFunction(FunctionPerTick);   
                }
                
                GridDisplay.lLneCompleted();
               
            }
            block = null;
        });        
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


    private static SquareColor getAColorblock(){
        Random random = new Random();
        var num = random.Next(1,8);
        
        switch (num) 
        {
        case 1:
            return SquareColor.DEEP_BLUE;
            
        case 2:
            return SquareColor.LIGHT_BLUE;
            
        case 3:
            return SquareColor.GREEN;
            
        case 4:
            return SquareColor.RED;
       
        case 5:
            return SquareColor.PURPLE;
          
        case 6:
            return SquareColor.ORANGE;
            
        case 7:
            return SquareColor.YELLOW; 
        }
         return SquareColor.RED;  
    }

   
    private static void FunctionPerTick(){
        
        if(block != null){
        block.MoveDown();        
        //flèches de gauche
        SetMoveLeftFunction(block.moveLeft);
         //flèches de droite
        SetMoveRightFunction(block.moveRight);
         //flèches du bas
        SetRushFunction(Rush);
        //barre espace
        SetRotateFunction(block.Rotate);   
        // /!\ si placé autre part --> erreur le jeu de marche plus 
        //GridDisplay.SetColors(board);
        GridDisplay.SetScore(scoreTotal);

        SetTickTime(GridDisplay.speedGame);
        } else {
            //sound voice : "GAME OVER"
            musicGameOver.instance2.GetComponent<AudioSource>().Play();
            TriggerGameOver();
        }
    }

    
    /*
    * role : renvoie une valeur aléatoire du type TypeOfBlock
    * retour : TypeOfBlock
    * entrée : <TypeOfBLock> : la liste de tout les TypeOfBLock
    */
    private static TypeOfBlock RandomEnumValue<TypeOfBlock> (){
    var v = System.Enum.GetValues (typeof (TypeOfBlock));
    return (TypeOfBlock) v.GetValue (_R.Next(v.Length)); 
}

    /*
    * role : déplacement instantanément le block vers le bas
    * retour : void
    * entrée : void
    */
    private static void Rush(){
        float tmp = speedGame;
        speedGame = 0.5F;
        while(sameBlock){
        block.MoveDown();  
        GridDisplay.SetColors(board);
        } 
        speedGame = tmp; 

    }

    /*
    * role : Regarde les lignes complétées et appelle la fonction clearLine
    * retour : void
    * entrée : void
    */
    private static void LineCompleted (){
        sizeListLines =0;
        lines.Clear();
        bool lineIsCompleted = true;    
        for (int i=0;i<GridDisplay.height;i++){     
            lineIsCompleted = true;     
            for (int j = 0;j<GridDisplay.width;j++){
                if(GridDisplay.board[i][j] == SquareColor.TRANSPARENT){
                    lineIsCompleted = false;
                }
                
            }
            if(lineIsCompleted){
                    lines.Add(i);
                    sizeListLines ++;
                }
        }
       
        if(sizeListLines>0){
            ClearLine(lines ,sizeListLines);
        }
    }

    /*
    * role : supprime les lignes vides et incrémente le score en foncion du nombre de ligne supprimé
    * retour : void
    * entrée : lines : liste des lignes, sizeListLines : nombre de ligne
    */

    private static void ClearLine(List<int> lines, int sizeListLines){
        
            
        for (int i=lines[0];i>0;i--){          
            for (int j = 0;j<GridDisplay.width;j++){             
                     //nb fois qu'on descent une ligne
                     for(int k = 0; k< sizeListLines; k++){
                        GridDisplay.board[i+k][j] =GridDisplay.board[i+k-1][j];
                }
            }         
        }
        //clear ligne dépasse
         for (int i=0;i<sizeListLines;i++){          
            for (int j = 0;j<GridDisplay.width;j++){
                GridDisplay.board[i][j] = SquareColor.TRANSPARENT;
            }
         } 

        if(sizeListLines == 1){
            scoreTotal =scoreTotal + 40;

        } else if(sizeListLines == 2){
            scoreTotal =scoreTotal + 100;

        } else if(sizeListLines == 3){
            scoreTotal =scoreTotal + 300;
        } 
        //pour 4 lignes
        else {
            scoreTotal =scoreTotal + 1200;
        }    
    }

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
