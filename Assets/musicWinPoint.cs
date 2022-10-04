using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicWinPoint : MonoBehaviour
{
    public static musicWinPoint instanceWin;
    // Start is called before the first frame update
    void Start()
    {
          if (instanceWin != null)
            Destroy(gameObject);
        else
        {
            instanceWin = this;
            DontDestroyOnLoad(this.gameObject);
        }


        
        
    }

  

 
    void Awake()
    {
 
    }

     void Update()
    {
       
 
               
            
 
    }
}
