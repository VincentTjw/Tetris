using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Oblock {

    public List<SquareColor> list = new List<SquareColor>();
    int width = 10;
    int height =2;

    int size = 2;
    int startOf = 4; //TODO : valeur random entre 0 et 8 

    public Oblock(SquareColor color){
        int r = 0;
    for(int j = 0 ; j < height; j++){
        for(int i=0; i<width; i++){
           
             if (r>= startOf && r < startOf+size) {
                list.Add(color);
                r++;
            } else {
                list.Add(SquareColor.TRANSPARENT);
                 r++;
            }
        }
    }


    }

    public List<SquareColor> getModel (){
        return list;
    }




}
