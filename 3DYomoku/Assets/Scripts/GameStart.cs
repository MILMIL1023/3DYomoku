using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    public GameObject boardpartsPrefab;

    public int columns = 4;
    public int rows = 4;

    public Vector3 startPosition = new Vector3(0,0,0);

    void Start()
    {
        for (int i = 0; i < rows; i++){
            for (int j = 0; j < columns; j++){
                Vector3 spawnPos = startPosition + new Vector3(j, 0, i);
                GameObject boardpart = Instantiate(boardpartsPrefab, spawnPos, Quaternion.identity);
            }
        }        
    }
}
