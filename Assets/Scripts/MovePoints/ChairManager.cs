using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairManager : MonoBehaviour
{
    // waypoint que esta antes de las sillas que desde el script del npc decide a cual de los transform se dirije
    public Transform[] beforeChairs = new Transform[0];
    public GameObject[] chairs = new GameObject[0];
}
