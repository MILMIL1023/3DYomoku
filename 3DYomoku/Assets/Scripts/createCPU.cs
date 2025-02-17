using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createCPU : MonoBehaviour
{
    public GameManager gameManager;
    void cpuhand(){
        int x, y, z;
        x = Random.Range(0, gameManager.boardWidth);
        y = Random.Range(0, gameManager.boardHeight);
        z = Random.Range(0, gameManager.boardDepth);
        while (!gameManager.IsValidPlacement(x, y)){
            x = Random.Range(0, gameManager.boardWidth);
            y = Random.Range(0, gameManager.boardHeight);
            z = Random.Range(0, gameManager.boardDepth);
        }
        for (z = 0; z < 4; z++){
            if (gameManager.board[x, y, z] == -1){
                gameManager.board[x, y, z] = gameManager.currentPlayer;
                Debug.Log(x + "," + y + "," + z);
                break;
            }
        }
        if (gameManager.CheckWin(x, y, z)){
            Debug.Log("CPUの勝ち");
        }
    }
}
