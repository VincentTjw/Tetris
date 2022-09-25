using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random=System.Random;
using System.Threading.Tasks;
using System.Threading;



public class GridDisplay : MonoBehaviour
{


    public static KeyCode moveUp;
    public static KeyCode moveRight;
    // Hauteur de la grille en nombre de cases
    public static int height = 22;

    // Largeur de la grille en nombre de cases
    public static int width = 10;
    public static List<List<SquareColor>> board = new List<List<SquareColor>>();    

    // Cette fonction se lance au lancement du jeu, avant le premier affichage.
    public static void Initialize(){
        bool loose = false;
        bool sameBlock = true;
      
        //initialisation de la grille
        for (int i=0;i<GridDisplay.height;i++){
            List<SquareColor> Ligne = new List<SquareColor>();
            for (int j = 0;j<GridDisplay.width;j++){
                    Ligne.Add(SquareColor.TRANSPARENT);                
            }
            board.Add(Ligne);
        }

        GridDisplay.SetColors(board);
               
         

        //id between 0-6 for choose a block (7 id possible)
        //TODO : id random
        //TODO ; color random

        
      
            //SetTickFunction(//TODO);
             Task t1 = Task.Run(() => {
              while(!loose){
                


             int id = 0;
            
            SquareColor color = getAColorblock();
            block block = new block(color, id);
            GridDisplay.SetColors(board);
            

            blockGoDown(id,block,color,sameBlock,loose);
            /*if(Input.GetKeyDown ("KeyRight")){
                SetMoveRightFunction(block.moveRight(color,id)); 
                GridDisplay.SetColors(board);   */ 



            //TODO check if a line is completed

             
        
          

        }

        TriggerGameOver();

          });

        
        

        

       // }  
                    
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


    public static void blockGoDown (int id, block block, SquareColor color, bool sameBlock, bool loose){
        
        if(id ==0){
            if(block.BTL1 == 1 && block.BTR1 == 21 && !block.isPossibleToGoDown(id)){
                loose = true;
                sameBlock = false;                
            }

        

           
            while(sameBlock){  

                  
            
                
                               
               
                if(block.BTL1 != 21 && block.BTR1 != 21 && block.isPossibleToGoDown(id)){                    
                  GridDisplay.board[block.TPL1][block.TPL2] = SquareColor.TRANSPARENT;       
                    GridDisplay.board[block.TPR1][block.TPR2]  = SquareColor.TRANSPARENT;  
                    
                    GridDisplay.board[block.BTL1+1][block.BTL2] = color;
                    GridDisplay.board[block.BTR1+1][block.BTR2] = color;
                    block.TPL1 ++;
                    block.TPR1 ++;  
                    block.BTL1 ++;
                    block.BTR1 ++;  
                    GridDisplay.SetColors(board);            
                } else {
                    sameBlock = false;}

                GridDisplay.SetColors(board);       
           
        
            Task.Delay(200).Wait();        
        }


        
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
