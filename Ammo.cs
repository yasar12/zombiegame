using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{

    
    [SerializeField] AmmoSlot[] slots;
    [System.Serializable]
      private class AmmoSlot
    {
        public AmmoType ammotypee;
        public int ammoamount;
    }
    public int getammo(AmmoType ammotypee) { 
    
    return gettammoslot(ammotypee).ammoamount;
    }
    public void reduceammo(AmmoType ammotypee) {

        gettammoslot(ammotypee).ammoamount--;
    }
    public void moreceammo(AmmoType ammotypee,int ammoamount)
    {

        gettammoslot(ammotypee).ammoamount+=ammoamount;
    }

    private AmmoSlot gettammoslot(AmmoType ammotype)
    { 
    foreach (AmmoSlot slot in slots) {
            if (slot.ammotypee==ammotype)
            {
                return slot;
            }
        }
        return null;
    }
}
