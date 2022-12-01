using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
        sumDinero.text = gameManager.dinMidDia+ "$";
    }

    public IEnumerator Esperar()
    {
        gameManager.dinMidDia++;
        yield return new WaitForSeconds(0.005f);
        if(gameManager.dinMidDia != gameManager.gameData.dineroPJ)
        {
            StartCoroutine(Esperar());
        }
    }
}
