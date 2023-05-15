using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPCManager : MonoBehaviour
{
    [SerializeField] GameObject[] NPC = new GameObject[3];

    [SerializeField] int[] NpcDias = new int[18];
    [SerializeField] int[] TimeMax = new int[18];
    [SerializeField] int[] TimeMin = new int[18];


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
        if (gameManager.gameData.semana == 1)
        {
            switch (gameManager.gameData.dia)
            {
                case 1:
                    npcNum = NpcDias[0];
                    timeMax = TimeMax[0];
                    timeMin = TimeMin[0];
                    break;
                case 2:
                    npcNum = NpcDias[1];
                    timeMax = TimeMax[1];
                    timeMin = TimeMin[1];
                    break;
                case 3:
                    npcNum = NpcDias[2];
                    timeMax = TimeMax[2];
                    timeMin = TimeMin[2];
                    break;
                case 4:
                    npcNum = NpcDias[3];
                    timeMax = TimeMax[3];
                    timeMin = TimeMin[3];
                    break;
                case 5:
                    npcNum = NpcDias[4];
                    timeMax = TimeMax[4];
                    timeMin = TimeMin[4];
                    break;
                case 6:
                    npcNum = NpcDias[5];
                    timeMax = TimeMax[5];
                    timeMin = TimeMin[5];
                    break;
            }

        }else 
        if (gameManager.gameData.semana == 2)
        {
            switch (gameManager.gameData.dia)
            {
                case 1:
                    npcNum = NpcDias[6];
                    timeMax = TimeMax[6];
                    timeMin = TimeMin[6];
                    break;
                case 2:
                    npcNum = NpcDias[7];
                    timeMax = TimeMax[7];
                    timeMin = TimeMin[7];
                    break;
                case 3:
                    npcNum = NpcDias[8];
                    timeMax = TimeMax[8];
                    timeMin = TimeMin[8];
                    break;
                case 4:
                    npcNum = NpcDias[9];
                    timeMax = TimeMax[9];
                    timeMin = TimeMin[9];
                    break;
                case 5:
                    npcNum = NpcDias[10];
                    timeMax = TimeMax[10];
                    timeMin = TimeMin[10];
                    break;
                case 6:
                    npcNum = NpcDias[11];
                    timeMax = TimeMax[11];
                    timeMin = TimeMin[11];
                    break;
            }
        }
        else
        if (gameManager.gameData.semana == 3)
        {
            switch (gameManager.gameData.dia)
            {
                case 1:
                    npcNum = NpcDias[12];
                    timeMax = TimeMax[12];
                    timeMin = TimeMin[12];
                    break;
                case 2:
                    npcNum = NpcDias[13];
                    timeMax = TimeMax[13];
                    timeMin = TimeMin[13];
                    break;
                case 3:
                    npcNum = NpcDias[14];
                    timeMax = TimeMax[14];
                    timeMin = TimeMin[14];
                    break;
                case 4:
                    npcNum = NpcDias[15];
                    timeMax = TimeMax[15];
                    timeMin = TimeMin[15];
                    break;
                case 5:
                    npcNum = NpcDias[16];
                    timeMax = TimeMax[16];
                    timeMin = TimeMin[16];
                    break;
                case 6:
                    npcNum = NpcDias[17];
                    timeMax = TimeMax[17];
                    timeMin = TimeMin[17];
                    break;
            }
        }
        numsalida = 10f;//un valor inicial para el spawn del primer cliente
    }
    void Update()
    {
        //un contador simpleen el que cada vez que se genere un npc se cambai el tiempo que tarda en salir, numsalida, con un numero aleatorio entre timemin y timemax
        //en cuanto se creen todos los npc indicados se cambia de dia(gamemanager.cambiodia)
            tiempo += Time.deltaTime;
            if (tiempo > numsalida)
            {
                tiempo = 0;
                if (npcgen < npcNum)
                {
                    Instantiate(NPC[Random.Range(0,3)]);
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
