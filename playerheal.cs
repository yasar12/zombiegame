using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerheal : MonoBehaviour
{
    [SerializeField]public float healt=100f;
  


    public void takedamagee(float damage)
    { 
    healt-=damage;
        if (healt < 0 )
        {
            
            GetComponent<daedth_handeller>().handledeadth();
        }

    }
  
}
