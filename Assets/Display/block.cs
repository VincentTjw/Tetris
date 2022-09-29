using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class block {

    public static List<List<SquareColor>> blockList = new List<List<SquareColor>>();

    public static int heightBlockL = 4;

    public static int xDepart = 4;

    public static int line = 0;
    public static int widthBlockL = 4;


    

    public block(){
        //enum de block
        SquareColor couleur = GridDisplay.color;
        //TODO : blockList.clear !!
        for (int i=0;i<block.heightBlockL;i++){
            List<SquareColor> Ligne = new List<SquareColor>();
            for (int j = 0;j<block.widthBlockL;j++){
                    Ligne.Add(SquareColor.TRANSPARENT);                
            }
            blockList.Add(Ligne);
        }
        
        switch (TypeOfBlock) 
        {
        case TypeOfBlock.I_Block:
                //base :  _ _ _ _
                blockList[0][0] = couleur;
                blockList[1][0] = couleur;
                blockList[2][0] = couleur;
                blockList[3][0] = couleur;
                 
                 

            
        case TypeOfBlock.L_Block:
                //TODO
        case TypeOfBlock.J_Block:
                //TODO
            
        case TypeOfBlock.O_Block:
                //TODO
        case TypeOfBlock.S_Block:
                //TODO
        case TypeOfBlock.Z_Block:
                //TODO

        }

   
        for(int i =xDepart; i < 4+i; i++){
             for(int j = 0; j < 4;j++){
                    GridDisplay.board[i][j] = blockList [i-xDepart][j];
            }
        }     
       
    }


        public bool isPossibleToGoDown(){
           //TODO : block can go down
           //TODO : first step move in 4*4 list
           //TODO : step 2 move the list 
            bool isPossible = false;
           
           //si on bloque et que la case qui se déplace est transparent on peut alors continuer en imprimant le bloc du jeu dans le tableau 4*4
           for(int i =0; i < 4; i++){
             for(int j = 0; j < 4;j++){
                
                
                if(blockList[i][j] == GridDisplay.color){
                    if(blockList[i+1][j] == SquareColor.TRANSPARENT || blockList[i+1][j] == GridDisplay.color  ){
                        isPossible = true;

                    }else {
                        return false;
                    }
                }
                
             }
           }

            return isPossible;

        }

    public void MoveDown(){
        if(isPossibleToGoDown){
            line ++;
            //TODO : supprimer l'ancienne pos
        for(int i =xDepart; i < 4+i; i++){
             for(int j = line; j < 4;j++){
                
             }

        }

        for(int i =xDepart; i < 4+i; i++){
             for(int j = line; j < 4;j++){
                    GridDisplay.board[i][j] = blockList [i-xDepart][j];
            }
        }   

        }
        
    
    }
    
    public void moveRight(){
        //TODO : move right
        
    }


     public void moveLeft(){
        //TODO : move right
        
    }

    

}



