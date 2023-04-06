using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponswitch : MonoBehaviour
{

   

    [SerializeField] int currentweapon = 0;
    void Start()
    {
        
        setweaponactive();
    }
 void Update()
    {
        int previousweapon = currentweapon;
        processkeyinput();
        processscroolwheel();
        if (previousweapon!=currentweapon)
        {
            setweaponactive();
        }
    }

    private void processscroolwheel()
    {
        if (Input.GetAxis("Mouse ScrollWheel")>0)
        {
            if (currentweapon>=transform.childCount-1)
            {
                currentweapon = 0;
            }
            else
            {
                currentweapon++;
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (currentweapon==0)
            {
                currentweapon = 1;
            }
            else
            {
                currentweapon--;
            }
        }
    }

    private void processkeyinput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentweapon = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentweapon = 1;
        }
    }

    private void setweaponactive()
    {
        
        int weaponindex = 0;
        foreach (Transform weapon in transform)
        {
            if (weaponindex==currentweapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else 
            {
                weapon.gameObject.SetActive(false);
            }
            weaponindex++;
        }

    }
   
}
