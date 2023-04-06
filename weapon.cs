using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class weapon : MonoBehaviour
{

    [SerializeField] Camera fpcam;
    [SerializeField] float range = 100f;
    [SerializeField] float gun1damage = 25f;
    [SerializeField] ParticleSystem muzzleflash;
    [SerializeField] GameObject hiteffect;
    [SerializeField] Ammo ammoslot;
    [SerializeField] AmmoType ammoType;
     bool canshoot=true;
    [SerializeField]float timebetweenshoots = 1f;
    [SerializeField] TextMeshProUGUI ammo;
    private void OnEnable()
    {
        canshoot = true;
    }

    void currentammo() {
        int currentammoo = ammoslot.getammo(ammoType);
        ammo.text= currentammoo.ToString();
    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1")&&canshoot==true)
        {
            
              StartCoroutine(shoot());
             
            
              
        }
            currentammo();
        
    }

    IEnumerator shoot()
    {
        
        canshoot = false;
        if (ammoslot.getammo(ammoType) > 0)
        {
          
            playMuzzleflash();
            processraycast();
            ammoslot.reduceammo(ammoType);

        }
        yield return new WaitForSeconds(timebetweenshoots);
        canshoot = true;
    }

    void playMuzzleflash()
    {
        muzzleflash.Play();
    }

     void processraycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpcam.transform.position, fpcam.transform.forward, out hit, range))
        {
               createhiteffect(hit);
            enemyhealt target = hit.transform.GetComponent<enemyhealt>();
            if (target == null)
            {
                return;
            }
        
            target.takedamage(gun1damage);
        }
        else
        {
            return;
        }
    }

    void createhiteffect(RaycastHit hit)
    {
     GameObject impact  = Instantiate(hiteffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact,.1f);
       
    }
}
