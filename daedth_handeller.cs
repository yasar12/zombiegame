using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class daedth_handeller : MonoBehaviour
{
    [SerializeField]public Canvas gameover;
    public void Start()
    {
        gameover.enabled = false;

    }

    public void handledeadth()
    {
        gameover.enabled = true;
        Time.timeScale = 0;
        FindObjectOfType<weaponswitch>().enabled = false;
        Cursor.lockState = CursorLockMode.None;//aşşağıdaki kod ile birlikte diğelimki oldunuz mouse imlecini serbest bırakıyor ve görünür kılıyor
        Cursor.visible = true;
    }
}
