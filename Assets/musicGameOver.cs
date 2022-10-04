using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicGameOver : MonoBehaviour
{

     public static musicGameOver instance2;
    // Start is called before the first frame update
    void Start()
    {
          if (instance2 != null)
            Destroy(gameObject);
        else
        {
            instance2 = this;
            DontDestroyOnLoad(this.gameObject);
        }


        
        
    }

  

 
    void Awake()
    {
 
    }

     void Update()
    {
       
 
               
            
          
            //BGmusic.instance.GetComponent<AudioSource>().Play();
 
    }
}
