using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class block {

    //coordonnées de chaque block
    public int TPL1, TPL2,TPR1, TPR2,BTL1, BTL2,BTR1, BTR2;

    public block(SquareColor color, int id){
        //there is 7 id (0 - 6)
        if(id == 0){
            GridDisplay.board[0][4] = color;
            GridDisplay.board[0][5] = color;
            GridDisplay.board[1][4] = color;
            GridDisplay.board[1][5] = color;
            TPL1 = 0;
            TPL2 = 4;
            TPR1 = 0;
            TPR2 = 5;
            BTL1 = 1;
            BTL2 = 4;
            BTR1 = 1;
            BTR2 = 5;
        }else if (id == 1){
            GridDisplay.board[0][4] = color;
            GridDisplay.board[1][4] = color;
            GridDisplay.board[1][5] = color;
            GridDisplay.board[1][6] = color;
            TPL1 = 0;
            TPL2 = 4;
            TPR1 = 1;
            TPR2 = 4;
            BTL1 = 1;
            BTL2 = 5;
            BTR1 = 1;
            BTR2 = 6;

                
            } else if (id == 2){
           
                
            } else if (id == 3){
                
                
            } else if (id == 4){
              
                
            } else if (id == 5){
            
                
            } else if (id == 6){
             
                
            }

       
        }


        public bool isPossibleToGoDown(int id, int pos){
            if (id ==0){
                if(GridDisplay.board[BTL1+1][BTL2] == SquareColor.TRANSPARENT && GridDisplay.board[BTR1+1][BTR2] == SquareColor.TRANSPARENT){
                    return true;
                }else {
                    return false;
                }

                //for other block we need to get the rotation
            } else if (id == 1){
                // cas : |_ _ _
                if(pos == 1){
                    if(GridDisplay.board[TPR1+1][TPR2] == SquareColor.TRANSPARENT && GridDisplay.board[BTL1+1][BTL2] == SquareColor.TRANSPARENT && GridDisplay.board[BTR1+1][BTR2] == SquareColor.TRANSPARENT){
                    return true;
                }else {
                    return false;
                }

                }
                return false;


                

            } else if (id == 2){
                 return false;
                
            } else if (id == 3){
                 return false;
                
            } else if (id == 4){
                 return false;
                
            } else if (id == 5){
                 return false;
                
            } else if (id == 6){
                 return false;
                
            }
            return false;

        }

    
    public MoveFunction moveRight(SquareColor color, int id){
        if(id ==0){
            if(TPR2 != 9 && BTR2 != 9 && isPossibleToMove()){
                    GridDisplay.board[TPL1][TPL2] = SquareColor.TRANSPARENT;       
                    GridDisplay.board[BTL1][BTL2]  = SquareColor.TRANSPARENT;  
                    
                    GridDisplay.board[TPR1][TPR2+1] = color;
                    GridDisplay.board[BTR1][BTR2+1] = color;
                    TPL2 ++;
                    TPR2 ++;  
                    BTL2 ++;
                    BTR2 ++;
            }
        }else if (id == 1){
                
            } else if (id == 2){
           
                
            } else if (id == 3){
                
                
            } else if (id == 4){
              
                
            } else if (id == 5){
            
                
            } else if (id == 6){
             
                
            }


        //SURE ??????
        return null;
        
    }

    public bool isPossibleToMove(){
        //TODO :
        return true;
    }

}



