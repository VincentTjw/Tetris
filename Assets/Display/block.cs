using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class block {

    public List<SquareColor> list1 = new List<SquareColor>();
     public List<SquareColor> list2 = new List<SquareColor>();
    int width = 10;
    int height =2;

    int size = 2;
    int startOf = 4; //TODO : valeur random entre 0 et 8 

    public block(SquareColor color, int id){
        //there is 7 id (0 - 6)

    //O block
    if(id ==0) {
        GridDisplay.board[0][startOf]   = color;
        GridDisplay.board[0][startOf+1] = color;
        GridDisplay.board[1][startOf+1] = color;
        GridDisplay.board[1][startOf]   = color;

    } 
    //left stairs --_ _
    else if (id == 1){
        GridDisplay.board[0][startOf]   = color;
        GridDisplay.board[0][startOf+1] = color;
        GridDisplay.board[1][startOf+1] = color;
        GridDisplay.board[1][startOf+2]   = color;

    } //left L |_ _ _
    else if (id == 2){
        GridDisplay.board[0][startOf]   = color;
        GridDisplay.board[1][startOf] = color;
        GridDisplay.board[1][startOf+1] = color;
        GridDisplay.board[1][startOf+2]   = color;

    } //line _ _ _ _
     else if (id == 3){
        GridDisplay.board[0][startOf]   = color;
        GridDisplay.board[0][startOf+3] = color;
        GridDisplay.board[0][startOf+1] = color;
        GridDisplay.board[0][startOf+2]   = color;

    } //middle 
    else if (id == 4){
        GridDisplay.board[0][startOf]   = color;
        GridDisplay.board[1][startOf-1] = color;
        GridDisplay.board[1][startOf+1] = color;
        GridDisplay.board[1][startOf]   = color;

    }// Right L _ _ _|
    else if (id == 5){
        GridDisplay.board[0][startOf]   = color;
        GridDisplay.board[1][startOf-1] = color;
        GridDisplay.board[1][startOf-2] = color;
        GridDisplay.board[1][startOf]   = color;

    }//right stairs _ _--
    else if (id == 6){
        GridDisplay.board[0][startOf]   = color;
        GridDisplay.board[0][startOf+1] = color;
        GridDisplay.board[1][startOf-1] = color;
        GridDisplay.board[1][startOf]   = color;

    }


    }

   


    public static void moveRight(SquareColor color,int topLeftC,int topLeftL,int topRightC,int topRightL,int BottomLeftC,int  BottomLeftL,int  BottomRightC,int  BottomRightL){
       if(block.isPossibleToMove){
        GridDisplay.board[topLeftL][topLeftC] = SquareColor.TRANSPARENT;
        GridDisplay.board[BottomLeftL][BottomLeftC] = SquareColor.TRANSPARENT;
        GridDisplay.board[topRightL+1][topRightC] = color;
        GridDisplay.board[BottomRightL+1][BottomRightC] = color;
       }
    }

    public static bool isPossibleToMove(){

    }


}
