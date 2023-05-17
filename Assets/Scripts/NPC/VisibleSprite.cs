using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibleSprite : MonoBehaviour
{
    Transform tr;

    // Start is called before the first frame update
    void Start()
    {
        tr = transform;            
    }

    // Update is called once per frame
    void Update()
    {
        if(tr.parent.rotation.eulerAngles.y >=  10 && tr.parent.rotation.eulerAngles.y <= 240)
            tr.rotation = Quaternion.Euler(0, 90, 0);
        else
            tr.rotation = Quaternion.Euler(0, -90, 0);
    }
}
