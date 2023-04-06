using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammopickup : MonoBehaviour
{

    [SerializeField] int ammoAmount = 5;
    [SerializeField] AmmoType ammoType;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") {
            FindObjectOfType<Ammo>().moreceammo(ammoType,ammoAmount);
            Destroy(gameObject);
        }
    }
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }
}
