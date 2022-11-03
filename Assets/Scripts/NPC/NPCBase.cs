using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBase : MonoBehaviour
{
    [SerializeField]
    Transform target;

    [SerializeField]
    int speed;

    [SerializeField]
    public GameObject chair1, chair2, chair3, chair4;

    int state; // 0- entrando, 1- sentado esperando, 3- esperando pedido, 4- saliendo

    void Start()
    {
        state = 0;
        chair1 = GameObject.Find("Chair (1)");
        chair2 = GameObject.Find("Chair (2)");
        chair3 = GameObject.Find("Chair (3)");
        chair4 = GameObject.Find("Chair (4)");
    }

    void Update()
    {
        if (state == 0)
        {
            Move();
        }
        if(state == 4)
        {
            Move();
        }
    }

    void Move()
    {
        transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
        transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Waypoint"))
        {
            if(state == 0)
            {
                target = other.gameObject.GetComponent<WayPoints>().point;
            }
            if(state == 4)
            {
                target = other.gameObject.GetComponent<WayPoints>().Exitpoint;
            }
        }

        if(other.CompareTag("Chairmanager"))
        {
            if(state == 0)
            {
                if(chair1.GetComponent<Chair>().fill == false)
                {
                    target = other.gameObject.GetComponent<ChairManager>().chair1;
                }
                else if (chair2.GetComponent<Chair>().fill == false)
                {
                    target = other.gameObject.GetComponent<ChairManager>().chair2;
                }
                else if (chair3.GetComponent<Chair>().fill == false)
                {
                    target = other.gameObject.GetComponent<ChairManager>().chair3;
                }
                else if (chair4.GetComponent<Chair>().fill == false)
                {
                    target = other.gameObject.GetComponent<ChairManager>().chair4;
                }
                else
                {
                    state =  4;
                    target = other.gameObject.GetComponent<ChairManager>().Exitpoint;
                }
            }
        }
        if(other.CompareTag("Chair"))
        {
            if(state == 0)
            {
                state = 1;
            }
        }
    }
}
