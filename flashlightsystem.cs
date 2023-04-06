using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashlightsystem : MonoBehaviour
{
    [SerializeField] float lightdecay = 0.1f;
    [SerializeField] float angledecay = 1.0f;
    [SerializeField] float minimumangle = 20f;
    Light mylight;
    void Start()
    {
       mylight= GetComponent<Light>();
    }
    private void FixedUpdate()
    {
        decreaselight();
        decreaselightintensity();
    }
    void Update()
    {
        
    }

    private void decreaselightintensity()
    {
        if (Time.time % 2 == 0&&this.enabled==true&&mylight.spotAngle>minimumangle)
        {
            
            mylight.spotAngle -= angledecay*Time.deltaTime;
        }
    }

    private void decreaselight()
    {
        if ( this.enabled == true&&mylight.intensity>0.1f )
        {
mylight.intensity -= lightdecay*Time.deltaTime*2;
           
        }
        
    }

    public void restorelight(float restoreangle) {
       
    mylight.spotAngle += restoreangle;
    }
    public void restorelightinsetsity(float intensityamount) {
       
 mylight.intensity += intensityamount;
        
   
    }
}
