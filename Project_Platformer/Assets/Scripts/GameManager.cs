using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject prefabPlayer;
    [SerializeField]
    private Transform pointSpawn;
    [SerializeField]
    private Transform pointFinish;
    private GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        Player = Instantiate(prefabPlayer, pointSpawn.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
