using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InfoMidMenu : MonoBehaviour
{
    GameManager gameManager;

    [SerializeField]
    TMP_Text sumDinero;

    int dinero2;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        sumDinero.text = dinero2 + "$";
    }

    public IEnumerator Esperar()
    {
        dinero2++;
        yield return new WaitForSeconds(0.005f);
        if(dinero2 != gameManager.gameData.dineroPJ && gameManager.gameData.dineroPJ != 0)
        {
            StartCoroutine(Esperar());
        }
    }
}
