using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block
{   
     //INFO : dans blockList il n'y a que notre block en cours
    private List<List<SquareColor>> blockList = new List<List<SquareColor>>();


    private int heightBlock = 4;
    private int widthBlock = 4;
    //column of blockList
    private int posColumn = 3;

     //line of blockList
    private int posLine = 0;

    private bool moveIn4By4 = false;

    //*******CONSTRUCTOR*******
    public Block()
    {
        //enum de block
        SquareColor color = GridDisplay.color;

        //initialisation de la liste        
        for (int i = 0; i < this.heightBlock; i++)
        {
            List<SquareColor> line = new List<SquareColor>();
            for (int j = 0; j < this.widthBlock; j++)
            {
                line.Add(SquareColor.TRANSPARENT);
            }
            blockList.Add (line);
        }

        //création du type de block en fonction d'un choix alétoire précemment fait
        switch (GridDisplay.typeOfBlock)
        {
            case TypeOfBlock.I_Block:
                //base :  _ _ _ _
                blockList[0][0] = color;
                blockList[0][1] = color;
                blockList[0][2] = color;
                blockList[0][3] = color;
                break;
            case TypeOfBlock.J_Block:
                blockList[0][0] = color;
                blockList[0][1] = color;
                blockList[0][2] = color;
                blockList[1][2] = color;
                break;
            case TypeOfBlock.L_Block:
                blockList[0][0] = color;
                blockList[0][1] = color;
                blockList[0][2] = color;
                blockList[1][0] = color;
                break;
            case TypeOfBlock.Z_Block:
                blockList[0][0] = color;
                blockList[0][1] = color;
                blockList[1][1] = color;
                blockList[1][2] = color;
                break;
            case TypeOfBlock.S_Block:
                blockList[1][0] = color;
                blockList[1][1] = color;
                blockList[0][1] = color;
                blockList[0][2] = color;
                break;
            case TypeOfBlock.M_Block:
                blockList[0][0] = color;
                blockList[0][1] = color;
                blockList[0][2] = color;
                blockList[1][1] = color;
                break;
            case TypeOfBlock.O_Block:
                blockList[0][0] = color;
                blockList[1][0] = color;
                blockList[0][1] = color;
                blockList[1][1] = color;
                break;
        }

        for (int i = 0; i < 4; i++)
        {
            for (int j = posColumn; j < 4 + posColumn; j++)
            {
                //test pour savoir si c'est loose
                if (i >= 2 && GridDisplay.board[i][j] != SquareColor.TRANSPARENT)
                {
                    GridDisplay.loose = true;
                    GridDisplay.sameBlock = false;
                    break;
                }
                else{
                    GridDisplay.board[i][j] = blockList[i][j - posColumn];
                }
                
            }
            if (GridDisplay.loose)
            {

                break;
            }
        }
    }

    //*******END CONSTRUCTOR*******



    //*******FUNCTION CHECK IF_POSSIBLE_TO_MOVE*******

    /*
    * role : vérifie que l'on peut déplacer le block vers le bas
    * retour : bool
    * entrée : void
    */
    private bool IsPossibleToGoDown()
    {
        bool isPossible = false;
        moveIn4By4 = false;
        if (posLine < GridDisplay.height - 4)
        {
            for (int i = posLine; i < posLine + 4; i++)
            {
                for (int j = posColumn; j < posColumn + 4; j++)
                {
                    //si vrai on est sur le postion de l'un de nos blocks
                    if (GridDisplay.board[i][j] == GridDisplay.color && GridDisplay.board[i][j] == this.blockList[i - posLine][j - posColumn]){
                        //le block en dessous est transparent ou égale à un de notre tableau
                        if (GridDisplay.board[i + 1][j] == SquareColor.TRANSPARENT || 
                                (GridDisplay.board[i + 1][j] == GridDisplay.color && GridDisplay.board[i + 1][j] == this.blockList[i - posLine + 1][j - posColumn]))
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
            //on verifie si la dernière ligne de blocklist contient, un block, si oui on ne peut pas descendre /!\
            for (int i = posLine + 3; i >= posLine + 3; i--)
            {
                for (int j = posColumn; j < posColumn + 4; j++)
                {
                
                    if (this.blockList[i - posLine][j - posColumn] ==  GridDisplay.color)
                    {
                        return false;
                    }
                }
            }
            //on vérifie que l'on peut déplacer notre block dans blockList
            for (int i = posLine; i < posLine + 3; i++)
            {
                for (int j = posColumn; j < posColumn + 4; j++)
                {
                    if (GridDisplay.board[i][j] == GridDisplay.color && GridDisplay.board[i][j] == this.blockList[i - posLine][j - posColumn])
                    {
                        
                        if (GridDisplay.board[i + 1][j] == SquareColor.TRANSPARENT ||
                                (GridDisplay.board[i + 1][j] == GridDisplay.color && GridDisplay.board[i + 1][j] == this.blockList[i - posLine + 1][j - posColumn]))
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

    /*
    * role : vérifie que l'on peut déplacer le block vers la droite
    * retour : bool
    * entrée : void
    */
    private bool IsPossibleToGoRight()
    {
        bool isPossible = false;
        if (posColumn < GridDisplay.width - 4)
        {

           
            for (int i = posLine; i < posLine + 4; i++)
            {
                for (int j = posColumn; j < posColumn + 4; j++)
                {
                    if (GridDisplay.board[i][j] == GridDisplay.color && GridDisplay.board[i][j] == this.blockList[i - posLine][j - posColumn])
                    {
                        if (GridDisplay.board[i][j + 1] == SquareColor.TRANSPARENT ||
                            (GridDisplay.board[i][j + 1] == GridDisplay.color && GridDisplay.board[i][j + 1] == this.blockList[i - posLine][j - posColumn + 1]))
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
            for (int i = posLine; i < posLine + 4; i++)
            {
                for (int j = posColumn + 3; j >= posColumn + 3; j--)
                {
                    if (this.blockList[i - posLine][j - posColumn] == GridDisplay.color)
                    {
                        return false;
                    }
                }
            }

            for (int i = posLine; i < posLine + 4; i++)
            {
                for (int j = posColumn; j < posColumn + 3; j++)
                {
                    if (GridDisplay.board[i][j] == GridDisplay.color &&GridDisplay.board[i][j] == this.blockList[i - posLine][j - posColumn])
                    {
                        
                        if (GridDisplay.board[i][j + 1] ==SquareColor.TRANSPARENT ||
                                (GridDisplay.board[i][j + 1] == GridDisplay.color &&GridDisplay.board[i][j + 1] ==this.blockList[i - posLine][j - posColumn + 1]))
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

    /*
    * role : vérifie que l'on peut déplacer le block vers la gauche
    * retour : bool
    * entrée : void
    */
    private bool IsPossibleToGoLeft()
    {
        bool isPossible = false;
        if (posColumn > 0)
        {
            for (int i = posLine; i < posLine + 4; i++)
            {
                for (int j = posColumn; j < posColumn + 4; j++)
                {
                    if (GridDisplay.board[i][j] == GridDisplay.color &&GridDisplay.board[i][j] ==this.blockList[i - posLine][j - posColumn])
                    {
  
                        if (
                            GridDisplay.board[i][j - 1] ==
                            SquareColor.TRANSPARENT ||
                            (
                            GridDisplay.board[i][j - 1] == GridDisplay.color &&
                            GridDisplay.board[i][j - 1] ==
                            this.blockList[i - posLine][j - posColumn - 1]
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
          
            for (int i = posLine; i < posLine + 4; i++)
            {
                for (int j = posColumn ; j >= posColumn ; j--)
                {
                    if (this.blockList[i - posLine][j - posColumn] == GridDisplay.color)
                    {
                        return false;
                    }
                }
            }

            for (int i = posLine; i < posLine + 4; i++)
            {
                for (int j = posColumn+1; j < posColumn + 4; j++)
                {
                    if (GridDisplay.board[i][j] == GridDisplay.color &&GridDisplay.board[i][j] == this.blockList[i - posLine][j - posColumn])
                    {
                       
                        if (GridDisplay.board[i][j -1] ==SquareColor.TRANSPARENT ||
                                (GridDisplay.board[i][j -1] == GridDisplay.color &&GridDisplay.board[i][j -1] ==this.blockList[i - posLine][j - posColumn -1]))
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

    /*
    * role : déplace le block vers le bas
    * retour : void
    * entrée : void
    */
    public void MoveDown() {
        if (this != null)
        {
           
            if (IsPossibleToGoDown() && !moveIn4By4)
            {
                //pn efface la ligne au dessus
                for (int i = posLine; i < posLine + 4; i++)
                {
                    for (int j = posColumn; j < posColumn + 4; j++)
                    {
                        if (
                            blockList[i - posLine][j - posColumn] ==
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

                //déplacement une ligne plus bas
                posLine++;

                //re-affichage
                for (int i = posLine; i < posLine + 4; i++)
                {
                    for (int j = posColumn; j < posColumn + 4; j++)
                    {
                        if (GridDisplay.board[i][j] == SquareColor.TRANSPARENT)
                        {
                            GridDisplay.board[i][j] =
                                blockList[i - posLine][j - posColumn];
                        }
                    }
                }

            }
            else if (IsPossibleToGoDown() && moveIn4By4)
            {
                //pn efface les blocks au dessus
                for (int i = posLine + 2; i >= posLine; i--)
                {
                    for (int j = posColumn; j < posColumn + 4; j++)
                    {
                        //parcours inverse pour éviter de supprimer des blocks de notre blocks de départ avant de les avoir déplacés

                        if (blockList[i - posLine][j - posColumn] ==GridDisplay.board[i][j] &&GridDisplay.board[i][j] == GridDisplay.color)
                        {
                            GridDisplay.board[i][j] = SquareColor.TRANSPARENT;
                            blockList[i - posLine][j - posColumn] = SquareColor.TRANSPARENT;
                            blockList[i - posLine + 1][j - posColumn] = GridDisplay.color;
                        }
                    }
                }

    
                for (int i = posLine; i < posLine + 4; i++)
                {
                    for (int j = posColumn; j < posColumn + 4; j++)
                    {
                        if (GridDisplay.board[i][j] ==SquareColor.TRANSPARENT ||
                            (GridDisplay.board[i][j] == GridDisplay.color &&GridDisplay.board[i][j] == this.blockList[i - posLine][j - posColumn]))
                        {
                            GridDisplay.board[i][j] =blockList[i - posLine][j - posColumn];
                        }
                    }
                }
            }
            else
            {
                moveIn4By4 = false;
                GridDisplay.sameBlock = false;
            }
        }
        
        GridDisplay.SetColors(GridDisplay.board);
    }

    /*
    * role : déplace le block vers la droite
    * retour : void
    * entrée : void
    */
     public void MoveRight()
    {
        if (this != null)
        {
            if (IsPossibleToGoRight() && !moveIn4By4)
            {
                for (int i = posLine; i < posLine + 4; i++)
                {
                    for (int j = posColumn; j < posColumn + 4; j++)
                    {
                        if (
                            blockList[i - posLine][j - posColumn] ==
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
                posColumn++;
                
                for (int i = posLine; i < posLine + 4; i++)
                {
                    for (int j = posColumn; j < posColumn + 4; j++)
                    {
                        if (GridDisplay.board[i][j] == SquareColor.TRANSPARENT)
                        {
                            GridDisplay.board[i][j] =
                                blockList[i - posLine][j - posColumn];
                        }
                    }
                }

                
            }
            else if (IsPossibleToGoRight() && moveIn4By4)
            {             
                for (int j = posColumn+2; j >= posColumn ; j--)
                {
                        for (int i = posLine; i < posLine+4; i++)
                    {
                        
                        //PARCOURS INVERSE POUR PAS DELETE DE BLOCK : parcours de haut en bas de droite vers la gauche pour pas avoir de perte 
                        if (blockList[i - posLine][j - posColumn] == GridDisplay.board[i][j] && GridDisplay.board[i][j] == GridDisplay.color)
                        {
                            GridDisplay.board[i][j] = SquareColor.TRANSPARENT;
                            blockList[i - posLine][j - posColumn] =SquareColor.TRANSPARENT;
                            blockList[i - posLine][j - posColumn+1] = GridDisplay.color;
                        }
                    }
                }

                //ON REAFFICHE LA LIST DU BLOCK DANS LE BOARD 1 case plus à droite
                for (int i = posLine; i < posLine + 4; i++)
                {
                    for (int j = posColumn; j < posColumn + 4; j++)
                    {
                        if (GridDisplay.board[i][j] ==SquareColor.TRANSPARENT ||(GridDisplay.board[i][j] == GridDisplay.color &&GridDisplay.board[i][j] ==this.blockList[i - posLine][j - posColumn]))
                        {
                            GridDisplay.board[i][j] =blockList[i - posLine][j - posColumn];
                        }
                    }
                }

            }
            else
            {
                moveIn4By4 = false;
            }
        }

       
        GridDisplay.SetColors(GridDisplay.board);
    }

    /*
    * role : déplace le block vers la gauche
    * retour : void
    * entrée : void
    */
    public void MoveLeft()
    {
        if (this != null)
        {
            if (IsPossibleToGoLeft() && !moveIn4By4)
            {
                for (int i = posLine; i < posLine + 4; i++)
                {
                    for (int j = posColumn; j < posColumn + 4; j++)
                    {
                        if (
                            blockList[i - posLine][j - posColumn] ==
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

                posColumn--;

                //ON REAFFICHE LA LIST DU BLOCK DANS LE BOARD
                for (int i = posLine; i < posLine + 4; i++)
                {
                    for (int j = posColumn; j < posColumn + 4; j++)
                    {
                        if (GridDisplay.board[i][j] == SquareColor.TRANSPARENT)
                        {
                            GridDisplay.board[i][j] =
                                blockList[i - posLine][j - posColumn];
                        }
                    }
                }

            }
            else if (IsPossibleToGoLeft() && moveIn4By4)
            {                           
                for (int j = posColumn+1; j <= posColumn+3 ; j++)
                {
                        for (int i = posLine; i < posLine+4; i++)
                    {
                        if (blockList[i - posLine][j - posColumn] == GridDisplay.board[i][j] && GridDisplay.board[i][j] == GridDisplay.color)
                        {
                            GridDisplay.board[i][j] = SquareColor.TRANSPARENT;
                            blockList[i - posLine][j - posColumn] =SquareColor.TRANSPARENT;
                            blockList[i - posLine][j - posColumn-1] = GridDisplay.color;
                        }
                    }
                }

                for (int i = posLine; i < posLine + 4; i++)
                {
                    for (int j = posColumn; j < posColumn + 4; j++)
                    {
                        if (GridDisplay.board[i][j] ==SquareColor.TRANSPARENT ||(GridDisplay.board[i][j] == GridDisplay.color &&GridDisplay.board[i][j] ==this.blockList[i - posLine][j - posColumn]))
                        {
                            GridDisplay.board[i][j] =blockList[i - posLine][j - posColumn];
                        }
                    }
                }

            
            
            }
            else
            {
                moveIn4By4 = false;
            }
        }
        //TODO :VERIF
        GridDisplay.SetColors(GridDisplay.board);
    }

    //*******END DEPLACEMEMNT***********

    
    //**********ROTATION**************

    /*
    * role : vérifie que l'on peut tourner le block
    * retour : bool
    * entrée : void
    */
private bool IsPossibleToRotate(){
        bool isPossible = true;
        List<List<SquareColor>> blockListTest = new List<List<SquareColor>>();
        //init test
         for (int i = 0; i < 4; i++){
            List<SquareColor> Ligne = new List<SquareColor>();
            for (int j = 0; j < 4; j++)
            {
                Ligne.Add(SquareColor.TRANSPARENT);
            }
            blockListTest.Add(Ligne);
        }
        //ajout transformation dans test
        for (int i = posLine+3; i >= posLine; i--)
        {
            for (int j = posColumn; j < posColumn + 4; j++)
            {   
               
                blockListTest[j-posColumn][(3-(i-posLine))] = this.blockList[i-posLine][j-posColumn];
            }
        }

        //verification
        for (int i = posLine; i < posLine + 4; i++)
        {
            for (int j = posColumn; j < posColumn + 4; j++)
            {
                //si sur nos nouvelles pos sur board les blocks ne sont pas transparents on renvoit false
                 //ne pas oublier que le bloc dans board est toujours écrit
                if (blockListTest[i - posLine][j - posColumn] == GridDisplay.color && GridDisplay.board[i][j] != SquareColor.TRANSPARENT && GridDisplay.board[i][j] != this.blockList[i-posLine][j-posColumn]){
                    return false;
                }
            }
        }
        return isPossible;      

}
    
    /*
    * role : tounre le block
    * retour : void
    * entrée : void
    */
    public void Rotate()
    {

        if (this != null && GridDisplay.typeOfBlock != TypeOfBlock.O_Block)
        {
            if(IsPossibleToRotate()){
                List<List<SquareColor>> blockListTmp =new List<List<SquareColor>>();
                //suppresion dans board
                for (int i = posLine; i < posLine + 4; i++)
                {
                    for (int j = posColumn; j < posColumn + 4; j++)
                    {
                        if (GridDisplay.board[i][j] == SquareColor.TRANSPARENT ||
                                (GridDisplay.board[i][j] == GridDisplay.color &&GridDisplay.board[i][j] == this.blockList[i - posLine][j - posColumn]))
                        {
                            GridDisplay.board[i][j] = SquareColor.TRANSPARENT;
                        }
                    }
                }
                    //init
                 for (int i = 0; i < 4; i++){
                        List<SquareColor> Ligne = new List<SquareColor>();
                        for (int j = 0; j < 4; j++){
                            Ligne.Add(SquareColor.TRANSPARENT);
                        }
                        blockListTmp.Add(Ligne);
                }

                //ajout transformation dans temp
                for (int i = posLine+3; i >= posLine; i--)
                {
                    for (int j = posColumn; j < posColumn + 4; j++)
                    {   
                     
                        blockListTmp[j-posColumn][(3-(i-posLine))] = this.blockList[i-posLine][j-posColumn];
                    }
                }

                //re-attribution
                for(int i =0; i < 4; i++){
                    for(int j = 0; j < 4;j++){
                        this.blockList[i][j] = blockListTmp[i][j];                         
                    }
                }

                //re-affichage dans board
                for (int i = posLine; i < posLine + 4; i++)
                {
                        for (int j = posColumn; j < posColumn + 4; j++)
                        {
                            if (GridDisplay.board[i][j] == SquareColor.TRANSPARENT)
                            {
                                GridDisplay.board[i][j] = blockList[i - posLine][j - posColumn];
                            }
                        }
                }
            }
        }

        //TODO :VERIF
        GridDisplay.SetColors(GridDisplay.board);
    }


    //*************************************


   
   
}
