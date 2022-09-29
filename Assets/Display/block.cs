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
           //TODO : 2 step move in 4*4 list
           //TODO : 1 step move the list 
            bool isPossible = false;
            bool moveIn4By4 = false;
        
            

           if(line < 22-4){
           //si on bloque et que la case qui se déplace est transparent on peut alors continuer en imprimant le bloc du jeu dans le tableau 4*4
           for(int i = line+4 ; i<line+4+1; i++){
                //cas ou il y a au moins une ligne en dessous ( rempli de couleur ou non)
                for(int j = xDepart; j<xDepart+4; j++){
                   if( GridDisplay.board[i][j] == SquareColor.TRANSPARENT){


                   } else {
                    //un bloc donc 
                    //TODO : verifier au dessus de ce bloc si block transparent

                    //si transparent au dessus de tous 
                    //TODO : on descend le petit tableau 
                    //TODO : on parcours le tableau et tout block different va prendre -1 en hauteur 
                    //TODO : check qu'il n'y a pas de pb avec le TODO précédent 

                    //sinon
                    //on ne peut pas descendre le tableau fin objet à l'interieur ne pas descendre non plus
                   } 
                }
           }

           } else {
            //TODO : travailler dans petit tableau

            //si on dessous de l'objet c'est vide
            //TODO : on descend 
            //sinon fin 
           }

           // return isPossible;

        }

//TODO : refaire
    public void MoveDown(){
        if(isPossibleToGoDown){
            line ++;
            //TODO : supprimer l'ancienne pos
        for(int i =xDepart; i < 4+i; i++){
             for(int j = line; j < 4;j++){

             }

        }

        //TODO : s'occuper des blocs qui font pas parti de l'objet

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



