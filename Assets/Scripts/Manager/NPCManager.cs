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
    [SerializeField]//cada dia de la semana se tiene que ciolocar asi porque el numero de clientes hay que colocarlo a mano0 desde el motor 
    float timeMax3; //dia es el numero de clientes que entra timemax y timemin es el intervalo de tiempo que tarda los clientes en entrar despues de que entre otro
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
        //se hace un switch con el dia actual gamedata.dia para decidir cuantos npc saldran ese dia
        //tengo que cambiar esto de los dias puesto que tengo que añadir las semanas asique lo que hare es cambiarlo todo por un array
        //de dos variables int fecha[] = new int [semanas][dias] por cada semana hay seis dias, de esta forma seria mucho mas reescalable
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
