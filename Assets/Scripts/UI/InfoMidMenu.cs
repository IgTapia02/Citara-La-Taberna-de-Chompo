using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //libreria de texto que utiliza el unity 3d

public class InfoMidMenu : MonoBehaviour
{
    GameManager gameManager;

    [SerializeField]
    TMP_Text sumDinero;

   [SerializeField] GameObject boton1, boton2;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        boton1.SetActive(false);
        boton2.SetActive(false);
    }

    private void Update()
    {
        sumDinero.text = gameManager.dinMidDia + "$";
        if(gameManager.gameData.dia == 6)
        {
            if (gameManager.gameData.semana == 1)
                boton1.SetActive(true);

            if (gameManager.gameData.semana == 2)
                boton2.SetActive(true);
        }
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
