using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Oblock {

    public List<SquareColor> list1 = new List<SquareColor>();
     public List<SquareColor> list2 = new List<SquareColor>();
    int width = 10;
    int height =2;

    int size = 2;
    int startOf = 2; //TODO : valeur random entre 0 et 8 

    public Oblock(SquareColor color){
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

    public List<SquareColor> getModel1 (){
        return list1;
    }

public List<SquareColor> getModel2 (){
        return list2;
    }


}
