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

        int r = 0;
    for(int j = 0 ; j < height; j++){
        for(int i=0; i<width; i++){

           
             if (r>= startOf && r < startOf+size) {
                if(j == 0){
                     list1.Add(color);
                
                }else {
                    list2.Add(color);
                }
                r++;
               
            } else {
                if(j == 0){
                     list1.Add(SquareColor.TRANSPARENT);
                
                }else {
                   list2.Add(SquareColor.TRANSPARENT);
                }
               
                 r++;
            }
        }
    }


    }

    public void getOBlock (){
        GridDisplay.board[0][]
    }

}


