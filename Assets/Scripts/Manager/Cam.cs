using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    //variables que establecen los puntos donde la camara se queda estable
    [SerializeField]
    float izqMax , derMax;
    [SerializeField]
    float arribaMax , abajoMax;
    [SerializeField]
    Transform player;

    void Update()
    {
        //si el player sobrepasa las posiciones fijadas desde el motor la camara se quedara estatica
        if (player.position.x < arribaMax && player.position.x > abajoMax)
        {
            transform.position = new Vector3((player.position.x -14), transform.position.y, transform.position.z);//cambiar segun restaurante
        }

        if (player.position.z < izqMax && player.position.z > derMax)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, player.position.z);
        }
       /*if (player.position.x < izqMax && player.position.x > derMax)
        {
            transform.position = new Vector3((player.position.x - 6), transform.position.y, transform.position.z);
        }

        if (player.position.z < arribaMax && player.position.z > -3.71)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, player.position.z);
        }*/
    }
}
