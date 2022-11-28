using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPCManager : MonoBehaviour
{
    [SerializeField]
    GameObject NPC;

    [Header("Numero de NPC por dia")]
    [SerializeField]
    int dia1;
    [SerializeField]
    int dia2;
    [SerializeField]
    int dia3;
    [SerializeField]
    int dia4;
    [SerializeField]
    int dia5;
    [SerializeField]
    int dia6;
    [SerializeField]
    float timeMax;
    [SerializeField]
    float timeMin;

    int npcNum;
    float tiempo;
    int npcgen;
    public int npcCreados;
    float numsalida;

    GameManager gameManager;

    public Transform target;

    private void Start()
    {
        npcgen = 0;
        gameManager = FindObjectOfType<GameManager>();
        switch (gameManager.gameData.dia)
        {
            case 1:
                npcNum = dia1;
                break;
            case 2:
                npcNum = dia2;
                break;
            case 3:
                npcNum = dia3;
                break;
            case 4:
                npcNum = dia4;
                break;
            case 5:
                npcNum = dia5;
                break;
            case 6:
                npcNum = dia6;
                break;
        }
        numsalida = 10f;
    }
    void Update()
    {
            tiempo += Time.deltaTime;
            if (tiempo > numsalida)
            {
                tiempo = 0;
                if (npcgen < npcNum)
                {
                    Instantiate(NPC);
                    npcgen++;
                    numsalida = Random.Range(timeMin,timeMax +1);
                }
            }
            if(npcCreados >= npcNum)
            {
                gameManager.CambioDia();

            }
    }
}
