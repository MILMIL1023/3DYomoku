using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCPU : MonoBehaviour
{
    public GameObject Whiteprefab;
    public GameManager gameManager;
    public void cpuhand(){
        int x, y, z;
        x = Random.Range(0, gameManager.boardWidth);
        y = Random.Range(0, gameManager.boardHeight);
        while (!gameManager.IsValidPlacement(x, y)){
            x = Random.Range(0, gameManager.boardWidth);
            y = Random.Range(0, gameManager.boardHeight);
        }
        for (z = 0; z < 4; z++){
            if (gameManager.board[x, y, z] == -1){
                gameManager.board[x, y, z] = gameManager.currentPlayer;
                gameManager.currentPlayer = 0;
                Debug.Log("CPUの手番");
                Instantiate(Whiteprefab, new Vector3(2*x, z, 2*y), Quaternion.identity);
                Debug.Log(x + "," + y + "," + z);
                break;
            }
        }
        if (gameManager.CheckWin(x, y, z)){
            Debug.Log("CPUの勝ち");
        }
    }
}
