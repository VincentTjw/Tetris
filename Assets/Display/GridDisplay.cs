using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random=System.Random;
using System.Threading.Tasks;
using System.Threading;
using System;




/*
*   INFO : 
*   id (type of block): 
*   0 = O
*
*   1 = |___     2 = ___|
*
*   3 = ¯¯|_     4 = _|¯¯
*
*    5 = _|_     6 = _____
*   
* block can have position between 1-4;
*
*/



public class GridDisplay : MonoBehaviour
{
    // Hauteur de la grille en nombre de cases
    public static int height = 22;
    // Largeur de la grille en nombre de cases
    public static int width = 10;
    static Random _R = new Random ();
    public static List<List<SquareColor>> board = new List<List<SquareColor>>();
    public static List<int> lines = new List<int>();
    public static int sizeListLines =0;
    public static SquareColor color = SquareColor.TRANSPARENT;  
    public static block block= null;
    public static float speedGame = 0.4F;
    public static  bool loose = false;
    public static  bool sameBlock = false;
    public static TypeOfBlock typeOfBlock;
    public static int scoreTotal=100;
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

                //TODO  ACCELERER AVEC UN STOCKAGE TEMP DU GAIN 
                          
                typeOfBlock = RandomEnumValue<TypeOfBlock>();
                color = getAColorblock();
                block = new block();
                if(!GridDisplay.loose){
                    
                sameBlock = true;
                }else {
                    sameBlock = false;
                }
                while(sameBlock){
                    GridDisplay.SetTickFunction(functionPerTick);   
                }
                
                GridDisplay.lineCompleted();
                
                
            }


            Debug.Log("game over start, loose = "+GridDisplay.loose); 
            block = null;
            
            
            
        });


        
 
                    
        // TODO : Complétez cette fonction de manière à appeler le code qui initialise votre jeu.
        // TODO : Appelez SetTickFunction en lui passant en argument une fonction ne prenant pas d'argument et renvoyant Void.
        //        Cette fonction sera exécutée à chaque tick du jeu, c'est à dire, initialement, toutes les secondes.
        //        Vous pouvez utiliser toutes les méthodes statiques ci-dessous pour mettre à jour l'état du jeu.
        // TODO : Appelez SetMoveLeftFunction, SetMoveRightFunction, SetRotateFunction, SetRushFunction pour enregistrer 
        
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


    public static SquareColor getAColorblock(){
        
        
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

   
    public static void functionPerTick(){
            
            //Random random = new Random();
            //var num = random.Next(0,2);//0,7 //max value not selected
        if(block != null){
        
        block.MoveDown();        
        //flèches de gauche
        SetMoveLeftFunction(block.moveLeft);
         //flèches de droite
        SetMoveRightFunction(block.moveRight);
         //flèches du bas
        SetRushFunction(rush);
        //barre espace

        //todo : faire 2 autres rotations
        SetRotateFunction(block.rotate);   
        
        // /!\ si placé autre part --> erreur le jeu de marche plus 
        GridDisplay.SetColors(board);
        
        //TODO 
        //musicWinPoint.instanceWin.GetComponent<AudioSource>().Play(); 


        GridDisplay.SetScore(scoreTotal);

        

        SetTickTime(GridDisplay.speedGame);
        } else {
            musicGameOver.instance2.GetComponent<AudioSource>().Play();
            TriggerGameOver();
        }

  
       
    }


    static TypeOfBlock RandomEnumValue<TypeOfBlock> (){

    var v = System.Enum.GetValues (typeof (TypeOfBlock));
    return (TypeOfBlock) v.GetValue (_R.Next(v.Length)); 
}

    public static void rush (){
        float tmp = speedGame;
        speedGame = 0.01F;
        while(sameBlock){
        block.MoveDown();  
        } 
        speedGame = tmp; 

    }

    public static void lineCompleted (){
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
        Debug.Log("size = "+sizeListLines);
        if(sizeListLines>0){
            clearLine(lines ,sizeListLines);
        }
    }

    public static void clearLine(List<int> lines, int sizeListLines){
        //TODO : verif 
            
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
