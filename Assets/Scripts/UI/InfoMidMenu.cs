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
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        sumDinero.text = dinero2 + "$";
    }
    public int SumDinero()
    {
        do
        {
            dinero2++;
            StartCoroutine(Esperar());
        } while (dinero2 != gameManager.gameData.dineroPJ);

        return dinero2;
    }

    IEnumerator Esperar()
    {
        yield return new WaitForSeconds(10f);
    }
}
