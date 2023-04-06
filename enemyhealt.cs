using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyhealt : MonoBehaviour
{
    [SerializeField] float hitpoints = 10000f;
    bool isdead = false;
    public bool Isdead() {

        return isdead;
    }
    public void takedamage(float damage)
    {
        BroadcastMessage("OnDamageTaken");
        hitpoints -= damage;
        if (hitpoints <= 0)
        {
           
            die();
        isdead=true;
        }
    }

    private void die()
    {
        if (isdead==false)
        {
 GetComponent<Animator>().SetTrigger("die");

        }
       
    }
}
