using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class music : MonoBehaviour
{

    //public static music instance;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    

     public static music instance;
 
    void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

     void Update()
    {
       
 
        if (GridDisplay.loose){
            music.instance.GetComponent<AudioSource>().Pause();
         
        }
      
 
    }


}
