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

    float tiempo;
    int npcCreados;
    public bool last;

    GameManager gameManager;

    public Transform target;

    private void Start()
    {
        last = false;
        gameManager = FindObjectOfType<GameManager>();
    }
    void Update()
    {
        if(gameManager.dia == 1)
        {
            tiempo += Time.deltaTime;
            if (tiempo > 10)
            {
                tiempo = 0;
                Instantiate(NPC);
                npcCreados++;
            }
            if(npcCreados >= dia1)
            {
                gameManager.dia = 2;
                last = true;
            }
        }
    }
}
