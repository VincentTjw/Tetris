using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block
{
    public List<List<SquareColor>> blockList = new List<List<SquareColor>>();

    public int heightBlockL = 4;

    public int xDepart = 3;

    public int line = 0;

    public int widthBlockL = 4;

    public int lineIn4By4 = 0;

    public int posBlock = 0;

    //TODO : verif qu'elle bien faite
    public bool moveIn4By4 = false;

    //*******CONSTRUCTOR*******
    public block()
    {
        //enum de block
        SquareColor couleur = GridDisplay.color;

        //TODO : si ligne déjà écrire par block (ligne 1/2/3 alors on renvoit erreur et isLoose = true)
        for (int i = 0; i < this.heightBlockL; i++)
        {
            List<SquareColor> Ligne = new List<SquareColor>();
            for (int j = 0; j < this.widthBlockL; j++)
            {
                Ligne.Add(SquareColor.TRANSPARENT);
            }
            blockList.Add (Ligne);
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
                blockList[0][0] = couleur;
                blockList[0][1] = couleur;
                blockList[0][2] = couleur;
                blockList[1][2] = couleur;

                //Debug.Log("BLOCK = j ");
                break;
            case TypeOfBlock.L_Block:
                blockList[0][0] = couleur;
                blockList[0][1] = couleur;
                blockList[0][2] = couleur;
                blockList[1][0] = couleur;

                //Debug.Log("BLOCK = L ");
                break;
            case TypeOfBlock.Z_Block:
                blockList[0][0] = couleur;
                blockList[0][1] = couleur;
                blockList[1][1] = couleur;
                blockList[1][2] = couleur;

                //Debug.Log("BLOCK = z ");
                break;
            case TypeOfBlock.S_Block:
                blockList[1][0] = couleur;
                blockList[1][1] = couleur;
                blockList[0][1] = couleur;
                blockList[0][2] = couleur;

                //Debug.Log("BLOCK = s ");
                break;
            case TypeOfBlock.M_Block:
                blockList[0][0] = couleur;
                blockList[0][1] = couleur;
                blockList[0][2] = couleur;
                blockList[1][1] = couleur;

                //Debug.Log("BLOCK = m ");
                break;
            case TypeOfBlock.O_Block:
                blockList[0][0] = couleur;
                blockList[1][0] = couleur;
                blockList[0][1] = couleur;
                blockList[1][1] = couleur;

                //Debug.Log("BLOCK = o ");
                break;
        }

        for (int i = 0; i < 4; i++)
        {
            for (int j = xDepart; j < 4 + xDepart; j++)
            {
                //if(GridDisplay.board[i][j] == SquareColor.TRANSPARENT ){
                if (i >= 2 && GridDisplay.board[i][j] != SquareColor.TRANSPARENT)
                {
                    GridDisplay.loose = true;
                    GridDisplay.sameBlock = false;
                    break;
                }
                else
                {
                    GridDisplay.board[i][j] = blockList[i][j - xDepart];
                }
                //TODO : refaire les cas si loose
            }
            if (GridDisplay.loose)
            {
                break;
            }
        }
    }

    //*******END CONSTRUCTOR*******



    //*******FUNCTION CHECK IF_POSSIBLE_TO_MOVE*******
    //step 1 : block can go down
    //step 2 : move the list
    //step 3 : move in 4*4 list
    public bool isPossibleToGoDown()
    {
        bool isPossible = false;
        moveIn4By4 = false;
        if (line < GridDisplay.height - 4)
        {
            for (int i = line; i < line + 4; i++)
            {
                for (int j = xDepart; j < xDepart + 4; j++)
                {
                    //si vrai on est sur le postion de l'un de nos blocks
                    if (GridDisplay.board[i][j] == GridDisplay.color && GridDisplay.board[i][j] == this.blockList[i - line][j - xDepart]){
                        //le block en dessous est transparent ou égale à un de notre tableau
                        if (GridDisplay.board[i + 1][j] == SquareColor.TRANSPARENT || 
                                (GridDisplay.board[i + 1][j] == GridDisplay.color && GridDisplay.board[i + 1][j] == this.blockList[i - line + 1][j - xDepart]))
                        {
                            isPossible = true;
                        }
                        else{
                            return false;
                        }
                    }
                }
            }
        }
        else{
            // verif si dernier ligne de blocklist contient un block on ne peut pas descendre /!\
            for (int i = line + 3; i >= line + 3; i--)
            {
                for (int j = xDepart; j < xDepart + 4; j++)
                {
                    //Debug.Log("line =" + line + " & line+3 =" + line + 3);
                    if (this.blockList[i - line][j - xDepart] ==  GridDisplay.color)
                    {
                        return false;
                    }
                }
            }

            for (int i = line; i < line + 3; i++)
            {
                for (int j = xDepart; j < xDepart + 4; j++)
                {
                    if (GridDisplay.board[i][j] == GridDisplay.color && GridDisplay.board[i][j] == this.blockList[i - line][j - xDepart])
                    {
                        
                        if (GridDisplay.board[i + 1][j] == SquareColor.TRANSPARENT ||
                                (GridDisplay.board[i + 1][j] == GridDisplay.color && GridDisplay.board[i + 1][j] == this.blockList[i - line + 1][j - xDepart]))
                        {
                            isPossible = true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            moveIn4By4 = true;
        }
        return isPossible;
    }

    public bool isPossibleToGoRight()
    {
        bool isPossible = false;
        if (xDepart < GridDisplay.width - 4)
        {
            for (int i = line; i < line + 4; i++)
            {
                for (int j = xDepart; j < xDepart + 4; j++)
                {
                    //si vrai on est sur le postion de l'un de nos blocks
                    if (GridDisplay.board[i][j] == GridDisplay.color && GridDisplay.board[i][j] == this.blockList[i - line][j - xDepart])
                    {
                        //le block en dessous est transparent ou égale à un de notre tableau
                        if (GridDisplay.board[i][j + 1] == SquareColor.TRANSPARENT ||
                            (GridDisplay.board[i][j + 1] == GridDisplay.color && GridDisplay.board[i][j + 1] == this.blockList[i - line][j - xDepart + 1]))
                        {
                            isPossible = true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
        }
        else{
            //TODO : verif !!!
            //verifie si il n'y a pas de block sur la ligne la plus a droite
            for (int i = line; i < line + 4; i++)
            {
                for (int j = xDepart + 3; j >= xDepart + 3; j--)
                {
                    if (this.blockList[i - line][j - xDepart] == GridDisplay.color)
                    {
                        return false;
                    }
                }
            }

            for (int i = line; i < line + 4; i++)
            {
                for (int j = xDepart; j < xDepart + 3; j++)
                {
                    if (GridDisplay.board[i][j] == GridDisplay.color &&GridDisplay.board[i][j] == this.blockList[i - line][j - xDepart])
                    {
                        //  if(i>20){
                        if (
                            GridDisplay.board[i][j + 1] ==SquareColor.TRANSPARENT ||
                                (GridDisplay.board[i][j + 1] == GridDisplay.color &&GridDisplay.board[i][j + 1] ==this.blockList[i - line][j - xDepart + 1]))
                        {
                            isPossible = true;
                            //Debug.Log("line : i+1 = "+i+1+" | j = "+j+"| isPossible= "+ isPossible);
                        }
                        else
                        {
                            return false;
                        }
                        //}else {return false;}
                    }
                }
            }
            moveIn4By4 = true;
        }

        return isPossible;
    }

    public bool isPossibleToGoLeft()
    {
        bool isPossible = false;
        if (xDepart > 0)
        {
            for (int i = line; i < line + 4; i++)
            {
                for (int j = xDepart; j < xDepart + 4; j++)
                {
                    //si vrai on est sur le postion de l'un de nos blocks

                    if (
                        GridDisplay.board[i][j] == GridDisplay.color &&
                        GridDisplay.board[i][j] ==
                        this.blockList[i - line][j - xDepart]
                    )
                    {
                        //le block en dessous est transparent ou égale à un de notre tableau
                        if (
                            GridDisplay.board[i][j - 1] ==
                            SquareColor.TRANSPARENT ||
                            (
                            GridDisplay.board[i][j - 1] == GridDisplay.color &&
                            GridDisplay.board[i][j - 1] ==
                            this.blockList[i - line][j - xDepart - 1]
                            )
                        )
                        {
                            isPossible = true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
        }
        else
        {
            //TODO : verif !!!
            //verifie si il n'y a pas de block sur la ligne la plus a gauche
            for (int i = line; i < line + 4; i++)
            {
                for (int j = xDepart ; j >= xDepart ; j--)
                {
                    if (this.blockList[i - line][j - xDepart] == GridDisplay.color)
                    {
                        return false;
                    }
                }
            }

            for (int i = line; i < line + 4; i++)
            {
                for (int j = xDepart+1; j < xDepart + 4; j++)
                {
                    if (GridDisplay.board[i][j] == GridDisplay.color &&GridDisplay.board[i][j] == this.blockList[i - line][j - xDepart])
                    {
                       
                        if (GridDisplay.board[i][j -1] ==SquareColor.TRANSPARENT ||
                                (GridDisplay.board[i][j -1] == GridDisplay.color &&GridDisplay.board[i][j -1] ==this.blockList[i - line][j - xDepart -1]))
                        {
                            isPossible = true;
                          
                        }
                        else
                        {
                            return false;
                        }
                    
                    }
                }
            }
            moveIn4By4 = true;
        }

        return isPossible;
    }

    //*******END FUNCTION CHECK IF_POSSIBLE_TO_MOVE*******




    //*********DEPLACEMENT**********
    public void MoveDown() {
        if (this != null)
        {
            //INFO : dans blocklist il n'y a que notre block
            if (isPossibleToGoDown() && !moveIn4By4)
            {
                //ON EFFACE LA LIGNE AU DESSUS
                for (int i = line; i < line + 4; i++)
                {
                    for (int j = xDepart; j < xDepart + 4; j++)
                    {
                        if (
                            blockList[i - line][j - xDepart] ==
                            GridDisplay.board[i][j]
                        )
                        {
                            if (GridDisplay.board[i][j] == GridDisplay.color)
                            {
                                GridDisplay.board[i][j] =
                                    SquareColor.TRANSPARENT;
                            }
                        }
                    }
                }

                //affichage une ligne plus bas
                line++;

                //ON REAFFICHE LA LIST DU BLOCK DANS LE BOARD
                for (int i = line; i < line + 4; i++)
                {
                    for (int j = xDepart; j < xDepart + 4; j++)
                    {
                        if (GridDisplay.board[i][j] == SquareColor.TRANSPARENT)
                        {
                            GridDisplay.board[i][j] =
                                blockList[i - line][j - xDepart];
                        }
                    }
                }

                //ON REAFFICHE LE BLOCK PLUS BAS DANS SA LIST
                //*************WORK IN 4BY4LIST*************
            }
            else if (isPossibleToGoDown() && moveIn4By4)
            {
                //ON EFFACE Les block AU DESSUS
                for (int i = line + 2; i >= line; i--)
                {
                    for (int j = xDepart; j < xDepart + 4; j++)
                    {
                        //PARCOURS INVERSE POUR PAS DELETE DE BLOCK

                        if (
                            blockList[i - line][j - xDepart] ==
                            GridDisplay.board[i][j] &&
                            GridDisplay.board[i][j] == GridDisplay.color
                        )
                        {
                            GridDisplay.board[i][j] = SquareColor.TRANSPARENT;
                            blockList[i - line][j - xDepart] =
                                SquareColor.TRANSPARENT;
                            blockList[i - line + 1][j - xDepart] =
                                GridDisplay.color;
                        }
                    }
                }

                //ON REAFFICHE LA LIST DU BLOCK DANS LE BOARD 1 case plus bas
                for (int i = line; i < line + 4; i++)
                {
                    for (int j = xDepart; j < xDepart + 4; j++)
                    {
                        if (
                            GridDisplay.board[i][j] ==
                            SquareColor.TRANSPARENT ||
                            (
                            GridDisplay.board[i][j] == GridDisplay.color &&
                            GridDisplay.board[i][j] ==
                            this.blockList[i - line][j - xDepart]
                            )
                        )
                        {
                            GridDisplay.board[i][j] =
                                blockList[i - line][j - xDepart];
                        }
                    }
                }

                //******************************************
            }
            else
            {
                moveIn4By4 = false;
                GridDisplay.sameBlock = false;
            }
        }
    }

     public void moveRight()
    {
        if (this != null)
        {
            if (isPossibleToGoRight() && !moveIn4By4)
            {
                for (int i = line; i < line + 4; i++)
                {
                    for (int j = xDepart; j < xDepart + 4; j++)
                    {
                        if (
                            blockList[i - line][j - xDepart] ==
                            GridDisplay.board[i][j]
                        )
                        {
                            if (GridDisplay.board[i][j] == GridDisplay.color)
                            {
                                GridDisplay.board[i][j] =
                                    SquareColor.TRANSPARENT;
                            }
                        }
                    }
                }

                //affichage une colonne à droite
                xDepart++;

                //ON REAFFICHE LA LIST DU BLOCK DANS LE BOARD
                for (int i = line; i < line + 4; i++)
                {
                    for (int j = xDepart; j < xDepart + 4; j++)
                    {
                        if (GridDisplay.board[i][j] == SquareColor.TRANSPARENT)
                        {
                            GridDisplay.board[i][j] =
                                blockList[i - line][j - xDepart];
                        }
                    }
                }

                
            }
            else if (isPossibleToGoRight() && moveIn4By4)
            {             
                for (int j = xDepart+2; j >= xDepart ; j--)
                {
                        for (int i = line; i < line+4; i++)
                    {
                        
                        //PARCOURS INVERSE POUR PAS DELETE DE BLOCK : parcours de haut en bas de droite vers la gauche pour pas avoir de perte 
                        Debug.Log("i - line = "+(i-line)+" | j-xDepart = "+(j-xDepart)+"| ");
                        if (blockList[i - line][j - xDepart] == GridDisplay.board[i][j] && GridDisplay.board[i][j] == GridDisplay.color)
                        {
                            GridDisplay.board[i][j] = SquareColor.TRANSPARENT;
                            blockList[i - line][j - xDepart] =SquareColor.TRANSPARENT;
                            blockList[i - line][j - xDepart+1] = GridDisplay.color;
                        }
                    }
                }

                //ON REAFFICHE LA LIST DU BLOCK DANS LE BOARD 1 case plus à droite
                for (int i = line; i < line + 4; i++)
                {
                    for (int j = xDepart; j < xDepart + 4; j++)
                    {
                        if (GridDisplay.board[i][j] ==SquareColor.TRANSPARENT ||(GridDisplay.board[i][j] == GridDisplay.color &&GridDisplay.board[i][j] ==this.blockList[i - line][j - xDepart]))
                        {
                            GridDisplay.board[i][j] =blockList[i - line][j - xDepart];
                        }
                    }
                }

            }
            else
            {
                moveIn4By4 = false;
            }
        }
    }

    public void moveLeft()
    {
        if (this != null)
        {
            if (isPossibleToGoLeft() && !moveIn4By4)
            {
                for (int i = line; i < line + 4; i++)
                {
                    for (int j = xDepart; j < xDepart + 4; j++)
                    {
                        if (
                            blockList[i - line][j - xDepart] ==
                            GridDisplay.board[i][j]
                        )
                        {
                            if (GridDisplay.board[i][j] == GridDisplay.color)
                            {
                                GridDisplay.board[i][j] =
                                    SquareColor.TRANSPARENT;
                            }
                        }
                    }
                }

                xDepart--;

                //ON REAFFICHE LA LIST DU BLOCK DANS LE BOARD
                for (int i = line; i < line + 4; i++)
                {
                    for (int j = xDepart; j < xDepart + 4; j++)
                    {
                        if (GridDisplay.board[i][j] == SquareColor.TRANSPARENT)
                        {
                            GridDisplay.board[i][j] =
                                blockList[i - line][j - xDepart];
                        }
                    }
                }

                //ON REAFFICHE LE BLOCK PLUS BAS DANS SA LIST
                //*************WORK IN 4BY4LIST*************
            }
            else if (isPossibleToGoLeft() && moveIn4By4)
            {

                //TODO
                           
                for (int j = xDepart+1; j <= xDepart+3 ; j++)
                {
                        for (int i = line; i < line+4; i++)
                    {
                        
                        //PARCOURS INVERSE POUR PAS DELETE DE BLOCK : parcours de haut en bas de droite vers la gauche pour pas avoir de perte 
                        Debug.Log("i - line = "+(i-line)+" | j-xDepart = "+(j-xDepart)+"| ");
                        if (blockList[i - line][j - xDepart] == GridDisplay.board[i][j] && GridDisplay.board[i][j] == GridDisplay.color)
                        {
                            GridDisplay.board[i][j] = SquareColor.TRANSPARENT;
                            blockList[i - line][j - xDepart] =SquareColor.TRANSPARENT;
                            blockList[i - line][j - xDepart-1] = GridDisplay.color;
                        }
                    }
                }

                //ON REAFFICHE LA LIST DU BLOCK DANS LE BOARD 1 case plus à droite
                for (int i = line; i < line + 4; i++)
                {
                    for (int j = xDepart; j < xDepart + 4; j++)
                    {
                        if (GridDisplay.board[i][j] ==SquareColor.TRANSPARENT ||(GridDisplay.board[i][j] == GridDisplay.color &&GridDisplay.board[i][j] ==this.blockList[i - line][j - xDepart]))
                        {
                            GridDisplay.board[i][j] =blockList[i - line][j - xDepart];
                        }
                    }
                }

            
            
            }
            else
            {
                moveIn4By4 = false;
            }
        }
    }

    //*******END DEPLACEMEMNT***********

    public void rotate()
    {
        if (this != null)
        {
            bool isPossibleToRotate = true;

            List<List<SquareColor>> blockListTmp =
                new List<List<SquareColor>>();

            //initialisation tmp
            for (int i = 0; i < this.heightBlockL; i++)
            {
                List<SquareColor> Ligne = new List<SquareColor>();
                for (int j = 0; j < this.widthBlockL; j++)
                {
                    Ligne.Add(SquareColor.TRANSPARENT);
                }
                blockListTmp.Add (Ligne);
            }

            //suppresion dans board
            for (int i = line; i < line + 4; i++)
            {
                for (int j = xDepart; j < xDepart + 4; j++)
                {
                    if (
                        GridDisplay.board[i][j] == SquareColor.TRANSPARENT ||
                        (
                        GridDisplay.board[i][j] == GridDisplay.color &&
                        GridDisplay.board[i][j] ==
                        this.blockList[i - line][j - xDepart]
                        )
                    )
                    {
                        GridDisplay.board[i][j] = SquareColor.TRANSPARENT;
                    }
                }
            }

            //stokage dans tmp
            if (posBlock == 0)
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        blockListTmp[j][i] = this.blockList[i][j];
                        this.blockList[i][j] = SquareColor.TRANSPARENT;
                    }
                }
                posBlock = 0;
                //posBlock =1;
                //première pos
            } /*else if(posBlock ==1){
            for(int i =4; i > 0; i--){
                for(int j = 4; j > 0;j++){
                    blockListTmp[i][j] = this.blockList[i][j];                     
                    this.blockList[i][j] =SquareColor.TRANSPARENT;                                  
                     
                }

            }
            posBlock =2;

            } if(posBlock ==2){
            for(int i =0; i < 4; i++){
                for(int j = 0; j < 4;j++){
                    blockListTmp[j][i] = this.blockList[i][j];                     
                    this.blockList[i][j] =SquareColor.TRANSPARENT;                                  
                     
                }

            }
            posBlock =3;

            } else{
            for(int i =0; i < 4; i++){
                for(int j = 0; j < 4;j++){
                    blockListTmp[j][i] = this.blockList[i][j];                     
                    this.blockList[i][j] =SquareColor.TRANSPARENT;                                  
                     
                }

            }
            posBlock =0;
            } */

            //verification
            for (int i = line; i < line + 4; i++)
            {
                for (int j = xDepart; j < xDepart + 4; j++)
                {
                    if (blockListTmp[i - line][j - xDepart] == GridDisplay.color
                    )
                    {
                        if (GridDisplay.board[i][j] == SquareColor.TRANSPARENT)
                        {
                            isPossibleToRotate = true;
                        }
                        else
                        {
                            isPossibleToRotate = false;
                            break;
                        }
                    }
                }
            }

            //si posibilité de rotate
            //Debug.Log("can rotate = " + isPossibleToRotate);
            if (isPossibleToRotate)
            {
                //réatribution
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        this.blockList[i][j] = blockListTmp[i][j];
                    }
                }

                //suppresion sur board
                //réaffichage
                for (int i = line; i < line + 4; i++)
                {
                    for (int j = xDepart; j < xDepart + 4; j++)
                    {
                        if (GridDisplay.board[i][j] == SquareColor.TRANSPARENT)
                        {
                            GridDisplay.board[i][j] =
                                blockList[i - line][j - xDepart];
                        }
                    }
                }

                //sinon on ne fait rien
            }
            else
            {
            }
        }
    }

   
}
