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
        //esto solo es con la demo, se activa cuando dia > 6, se quitara cuando continuemos con el juego
        if(gameManager.findemo==true)
        {
            sumDinero.text = "Has terminado la Demo con: " + gameManager.gameData.dineroPJ + "$";
        }else
        //se muestra el dinero del jugador
        {
            sumDinero.text = gameManager.dinMidDia + "$";
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
