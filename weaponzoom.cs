using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
public class weaponzoom : MonoBehaviour
{
    [SerializeField]public  Camera fpscamera;
    [SerializeField]public  float zoomedOutFOV = 40f;
    [SerializeField]public  float zoomedInFOV = 20F;
   public  bool zoomactive=false;



    private void OnDisable()
    {
        zoomactive = false;  
        fpscamera.fieldOfView = zoomedOutFOV;
    }
    public  void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            
            
          if(zoomactive==false)
         {
                zoomactive = true;
                fpscamera.fieldOfView = zoomedInFOV;
          }
            else
            {
                zoomactive= false;
                fpscamera.fieldOfView = zoomedOutFOV;
            }

        }
        

       
    }
    void zoom() { 
    
    }
}
