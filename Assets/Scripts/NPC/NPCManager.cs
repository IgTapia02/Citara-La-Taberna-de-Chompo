using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPCManager : MonoBehaviour
{
    [SerializeField]
    GameObject NPC;

    [Header("Dia1")]
    [SerializeField]
    int dia1;
    [SerializeField]
    float timeMax1;
    [SerializeField]
    float timeMin1;
    [Header("Dia2")]
    [SerializeField]
    int dia2;
    [SerializeField]
    float timeMax2;
    [SerializeField]
    float timeMin2;
    [Header("Dia3")]
    [SerializeField]
    int dia3;
    [SerializeField]
    float timeMax3;
    [SerializeField]
    float timeMin3;
    [Header("Dia4")]
    [SerializeField]
    int dia4;
    [SerializeField]
    float timeMax4;
    [SerializeField]
    float timeMin4;
    [Header("Dia5")]
    [SerializeField]
    int dia5;
    [SerializeField]
    float timeMax5;
    [SerializeField]
    float timeMin5;
    [Header("Dia6")]
    [SerializeField]
    int dia6;
    [SerializeField]
    float timeMax6;
    [SerializeField]
    float timeMin6;


    float timeMax;
    float timeMin;


   




    int npcNum;
    float tiempo;
    
    int npcgen;
    [Header("NPCCreados")]
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
                timeMax = timeMax1;
                timeMin = timeMin1;
                break;
            case 2:
                npcNum = dia2;
                timeMax = timeMax2;
                timeMin = timeMin2;
                break;
            case 3:
                npcNum = dia3;
                timeMax = timeMax3;
                timeMin = timeMin3;
                break;
            case 4:
                npcNum = dia4;
                timeMax = timeMax4;
                timeMin = timeMin4;
                break;
            case 5:
                npcNum = dia5;
                timeMax = timeMax5;
                timeMin = timeMin5;
                break;
            case 6:
                npcNum = dia6;
                timeMax = timeMax6;
                timeMin = timeMin6;
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
