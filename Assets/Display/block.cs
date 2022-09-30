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

        //TODO : attention si sur la 3eme ou 4eme ligne il y a des blocks il ne faut pas les effacer.
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
            
           
        //si notre tableeau n'est pas arrivé en bas
      
    
        if(line < GridDisplay.height-4){
            //TODO : verif pourquoi ça dépasse
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
            }return true;
        }

    public void MoveDown(){
        //TODO : if block can move down and it is at the top of the board or if 2 first line has a block in middle in the spawn isLoose = true;
        

        //INFO : dans blocklist il n'y a que notre block
        if(isPossibleToGoDown() && !moveIn4By4){
            //ON EFFACE LA LIGNE AU DESSUS
            for(int i =line; i < line+1; i++){
             for(int j = xDepart; j < xDepart+4;j++){
                //TODO : les escaliers ne s'efface pas entièrement
                //TODO PARCCOURIR TOUT LE TABLEAU SI AU DESSUS UN DE MES BLOCKS JE NE FAIS RIEN SINON JE SUPPRIME I ET AFFICHE A I+1
                //TODO : + test avec le L dans tout les sens pour verif que c'est bon
                if(GridDisplay.board[i][j] == SquareColor.TRANSPARENT || blockList[i-line][j-xDepart] == GridDisplay.board[i][j]){
                   
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
        //*************WORK IN 4BY4LIST*************
        } else if (isPossibleToGoDown() && moveIn4By4) {
            //se déplacer dans le petit tableau
             for(int i =line; i < line+4; i++){
                for(int j = xDepart; j < xDepart+4;j++){
                    //TODO : déplacer dans le tableau board et dans le tableau blockList
                    //TODO PARCCOURIR TOUT LE TABLEAU SI AU DESSUS UN DE MES BLOCKS JE NE FAIS RIEN SINON JE SUPPRIME I ET AFFICHE A I+1
                  if(blockList[i-line][j-xDepart]== GridDisplay.color ){
                    blockList[i+1-line][j-xDepart] = GridDisplay.color;
                    blockList[i-line][j-xDepart] = SquareColor.TRANSPARENT;
                }
                
             }
        }
    

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
    public bool isPossibleToGoRight(){
            //step 1 : block can go down
            //step 2 : move the list 
            //step 3 : move in 4*4 list
    }
     public bool isPossibleToGoLeft(){
            //step 1 : block can go down
            //step 2 : move the list 
            //step 3 : move in 4*4 list
    }

    public void moveRush(){
        //TODO : rush down block
    }

    public void rotate(){
        //TODO : rotate block in block list
    }

    public void moveRight(){
        //TODO : move right
        
    }


     public void moveLeft(){
        //TODO : move right
        
    }

    

}
        



