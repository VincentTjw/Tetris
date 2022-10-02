using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class block {

    public static List<List<SquareColor>> blockList = new List<List<SquareColor>>();

    public static int heightBlockL = 4;

    public static int xDepart = 3;

    public static int line = 0;
    public static int widthBlockL = 4;

    

    public static bool moveIn4By4 = false;



    

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
  
       
        switch (GridDisplay.typeOfBlock) 
        {
        case TypeOfBlock.I_Block:
                //base :  _ _ _ _
                blockList[0][0] = couleur;
                blockList[0][1] = couleur;
                blockList[0][2] = couleur;
                blockList[0][3] = couleur;
                //Debug.Log("BLOCK = I ");
                break;
                              
        case TypeOfBlock.J_Block:
                //TODO
                blockList[0][0] = couleur;
                blockList[0][1] = couleur;
                blockList[0][2] = couleur;
                blockList[1][2] = couleur;
                //Debug.Log("BLOCK = j ");
                break;
        case TypeOfBlock.L_Block:
                //TODO
                blockList[0][0] = couleur;
                blockList[0][1] = couleur;
                blockList[0][2] = couleur;
                blockList[1][0] = couleur;
                //Debug.Log("BLOCK = L ");
                break;
        case TypeOfBlock.Z_Block:
                //TODO
                blockList[0][0] = couleur;
                blockList[0][1] = couleur;
                blockList[1][1] = couleur;
                blockList[1][2] = couleur;
                //Debug.Log("BLOCK = z ");
                break;
       case TypeOfBlock.S_Block:
                //TODO
                blockList[1][0] = couleur;
                blockList[1][1] = couleur;
                blockList[0][1] = couleur;
                blockList[0][2] = couleur;
                //Debug.Log("BLOCK = s ");
                break;
        case TypeOfBlock.M_Block:
                //TODO
                blockList[0][0] = couleur;
                blockList[0][1] = couleur;
                blockList[0][2] = couleur;
                blockList[1][1] = couleur;
                //Debug.Log("BLOCK = m ");
                break;
        case TypeOfBlock.O_Block:
                //TODO
                blockList[0][0] = couleur;
                blockList[1][0] = couleur;
                blockList[0][1] = couleur;
                blockList[1][1] = couleur;
                //Debug.Log("BLOCK = o ");
                break;
                
        }

   
        for(int i =0; i < 4; i++){
             for(int j = xDepart; j < 4+xDepart;j++){                   
                    GridDisplay.board[i][j]= blockList [i][j-xDepart] ;
                 
            }
        }     
       
    }


        public bool isPossibleToGoDown(){
            //step 1 : block can go down
            //step 2 : move the list 
            //step 3 : move in 4*4 list
            
            moveIn4By4 = false;
        //si notre tableeau n'est pas arrivé en bas
      
    
        if(line < GridDisplay.height-5){
              //Debug.Log("line = "+line+"  <  "+ (GridDisplay.height-5));
            //on regarde la ligne en dessous du tableau
           for(int i = line+4 ; i<line+5; i++){
                for(int j = xDepart; j<xDepart+4; j++){                  
                        //on verif que la ligne en dessous de block list est vide                   
                        if(GridDisplay.board[i+1][j] != SquareColor.TRANSPARENT){
                            return false;
                        } 
                      
                   
                }
           }

            
              
            } else {
                   moveIn4By4 = true;
                //on verif que c'est vide en dessous de chaque block dans notre tableau
                for(int i = line ; i<line+3; i++){
                    for(int j = xDepart; j<xDepart+4; j++){
                        //on get un de nos blocks
                        if( GridDisplay.board[i][j] == GridDisplay.color && GridDisplay.board[i][j] == blockList[i-line][j-xDepart]){
                            //on verif que c'est pas un de nos blocks qui est de dessous de l'autre
                            if(GridDisplay.board[i+1][j] != blockList[i+1-line][j-xDepart]){
                                //on verif que la ligne en dessous de block list est vide                   
                                if(GridDisplay.board[i+1][j] != SquareColor.TRANSPARENT ){
                                    return false;
                                }   
                                
                

                            }

                        }

                    }
                }
            }

            return true;

        }


    public void MoveDown(){
        

        //INFO : dans blocklist il n'y a que notre block
        if(isPossibleToGoDown() && !moveIn4By4){
            //ON EFFACE LA LIGNE AU DESSUS
            for(int i =line; i < line+1; i++){
             for(int j = xDepart; j < xDepart+4;j++){
                
                if(GridDisplay.board[i][j] == SquareColor.TRANSPARENT || blockList[i-line][j-xDepart] == GridDisplay.board[i][j]){
                    //TODO : les escaliers ne s'efface pas entièrement
                    if(GridDisplay.board[i][j]== GridDisplay.color ){
                    GridDisplay.board[i+1][j] = GridDisplay.color;
                    GridDisplay.board[i][j] = SquareColor.TRANSPARENT;
                }
                }//else { //if(GridDisplay.board[i][j] != transparent && blockList[i-line][j-xDepart] != GridDisplay.board[i][j]){ --> explication + clair avec cet exemple
                      //on ne fait rien }
                
            
             }
            }
            //affichage une ligne plus bas
            line ++;
            //ON REAFFICHE LA LIST DU BLOCK DANS LE BOARD
            for(int i =line; i < line+4; i++){
                for(int j = xDepart; j < xDepart+4;j++){
                    if(GridDisplay.board[i][j]== SquareColor.TRANSPARENT){
                    GridDisplay.board[i][j]= blockList[i-line][j-xDepart] ;
                    } //sinon on laisse la couleur d'avant
                }
            }

        //ON REAFFICHE LE BLOCK PLUS BAS DANS SA LIST
        } else if (isPossibleToGoDown() && moveIn4By4) {
            //se déplacer dans le petit tableau
             for(int i =line; i < line+4; i++){
                for(int j = xDepart; j < xDepart+4;j++){
                if(blockList[i-line][j-xDepart]== GridDisplay.color ){
                    blockList[i+1-line][j-xDepart] = GridDisplay.color;
                    blockList[i-line][j-xDepart] = SquareColor.TRANSPARENT;
                }
                
             }
        }
        //TODO : réécrire tableau

        /*
         for(int i =line; i < line+4; i++){
             for(int j = xDepart; j < 4+xDepart;j++){                   
                    if(GridDisplay.board[i][j] == SquareColor.TRANSPARENT || blockList[i-line][j-xDepart] == GridDisplay.board[i][j]){
                GridDisplay.board[i][j]= blockList[i-line][j-xDepart] ;
                }
                 
            }
        }  */
         
            
       
            
        } else {
         
            GridDisplay.sameBlock = false;

        }
        
    
    }

    public void isPossibleToGoRight(){
         moveIn4By4 = false;
        if (xDepart < GridDisplay.width-4){
                      for(int i = line+4 ; i<line+5; i++){
                for(int j = xDepart; j<xDepart+4; j++){                                    
                        if(GridDisplay.board[i][j+1] != SquareColor.TRANSPARENT){
                            return false;
                        } 
                      
                   
                }
           }
        }
        else {
            else {
                   moveIn4By4 = true;
                
                for(int i = line ; i<line+3; i++){
                    for(int j = xDepart; j<xDepart+4; j++){
                  
                        if( GridDisplay.board[i][j] == GridDisplay.color && GridDisplay.board[i][j] == blockList[i-line][j-xDepart]){
                            if(GridDisplay.board[i][j+1] != blockList[i-line][j+1-xDepart]){                  
                                if(GridDisplay.board[i][j+1] != SquareColor.TRANSPARENT ){
                                    return false;
                                }   
        }
    }
    
    public void moveRight(){

         if(isPossibleToGoRight() && !moveIn4By4){
             for(int i =line; i < line+1; i++){
             for(int j = xDepart; j < xDepart+4;j++){
         if(GridDisplay.board[i][j] == SquareColor.TRANSPARENT || blockList[i-line][j-xDepart] == GridDisplay.board[i][j]){
                   
                    if(GridDisplay.board[i][j]== GridDisplay.color ){
                    GridDisplay.board[i][j+1] = GridDisplay.color;
                    GridDisplay.board[i][j] = SquareColor.TRANSPARENT;
                
                }
         }}}
        //TODO : move right
        
    }


     public void moveLeft(){
        //TODO : move right
        
    }



    public void rotate(){
        for (int i = 0; i < heightBlockL ; i++){
            for (int j = 0 ; j<widthBlockL ; j++){
                if (blockList [i][j] != blockList[line][xDepart]){
                public static List<List<SquareColor>> blockList = new List<List<SquareColor>>();
                }
            }
        }
    }

}
        


