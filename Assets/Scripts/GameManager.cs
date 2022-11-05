using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int dineroPJ;
    public Text Dinero;

    int dia, mes;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Dinero.text = dineroPJ + "$";
    }
}
