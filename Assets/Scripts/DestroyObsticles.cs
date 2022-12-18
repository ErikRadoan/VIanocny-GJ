using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObsticles : MonoBehaviour
{
    void Update()
    {
        if(gameObject.transform.position.y < -6)
        {Destroy(gameObject);}
    }
}
