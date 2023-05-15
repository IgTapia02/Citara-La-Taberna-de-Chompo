using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //libreria de texto que utiliza el unity 3d

public class InfoMidMenu : MonoBehaviour
{
    GameManager gameManager;

    [SerializeField]
    TMP_Text sumDinero;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        sumDinero.text = gameManager.dinMidDia + "$";
    }

    public IEnumerator Esperar()
    {
        //contador que va sumando el dinero del dia al dinero general pero con un pequeño retardo para que quede mas estetico
        gameManager.dinMidDia++;
        yield return new WaitForSeconds(0.005f);
        if(gameManager.dinMidDia != gameManager.gameData.dineroPJ)
        {
            StartCoroutine(Esperar());
        }
    }
}
