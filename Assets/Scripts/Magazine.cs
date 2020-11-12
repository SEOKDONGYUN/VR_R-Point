using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magazine : MonoBehaviour
{
    public int numberOfBullet = 8;
    public GameObject bullet;

    private void Update()
    {
        if(numberOfBullet <= 1)
        {
            Destroy(bullet);
            //gameObject.tag = "Untagged";
        }
    }
}
