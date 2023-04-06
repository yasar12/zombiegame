using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class batterypickup : MonoBehaviour
{
    [SerializeField] float restoreangle =5f;
    [SerializeField] float addIntensity = 1f;
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Player") {
            other.GetComponentInChildren<flashlightsystem>().restorelight(addIntensity);
            other.GetComponentInChildren<flashlightsystem>().restorelightinsetsity(restoreangle);
            Destroy(gameObject);
        }
    }
    void Update()
    {
        
    }
}
