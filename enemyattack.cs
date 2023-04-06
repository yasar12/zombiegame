using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyattack : MonoBehaviour
{
   public playerheal targett;
    
    [SerializeField]public float damage = 40f;
    


   public void Start()
    {
        targett=FindObjectOfType<playerheal>();
       
       
    }
    public void AttackHitevent() { 

    if (targett = null)
        {
            return;
        }

        targett.takedamagee(damage);
        Debug.Log("bang bang");
    }
    
   
    
}
