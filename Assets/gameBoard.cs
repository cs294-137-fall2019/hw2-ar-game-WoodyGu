using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameBoard : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> childrenObjects = new List<GameObject>();
    public GameObject[,] gameBoardCells = new GameObject[3,3];
    public GameObject messageText;
    public float targetTime = 10.0f;

    void Start()
    {
        foreach (Transform child in transform)
        {
            childrenObjects.Add(child.gameObject);

        }
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                gameBoardCells[i, j] = childrenObjects[i].transform.GetChild(j).gameObject;
            }
        }
        this.messageText = childrenObjects[3].transform.GetChild(0).gameObject;
        this.messageText.SetActive(false);
        generateNumbers();
    }

    // Update is called once per frame
    void Update()
    {
        targetTime -= Time.deltaTime;

        if (targetTime <= 0.0f)
        {
            timerEnded();
        }
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (gameBoardCells[i, j].GetComponent<gameCell>().isClicked)
                {
                    // blank at left
                    if (i + 1 < 3 && gameBoardCells[i + 1, j].GetComponent<gameCell>().getNumber() == -1)
                    {
                        swapNumbers(i, j, i + 1, j);
                    }

                    //blank at upper
                    if (j + 1 < 3 && gameBoardCells[i, j + 1].GetComponent<gameCell>().getNumber() == -1)
                    {
                        swapNumbers(i, j, i, j + 1);
                    }

                    // black at right
                    if (i - 1 >= 0 && gameBoardCells[i - 1, j].GetComponent<gameCell>().getNumber() == -1)
                    {
                        swapNumbers(i, j, i - 1, j);
                    }

                    // blank at down
                    if (j - 1 >= 0 && gameBoardCells[i, j - 1].GetComponent<gameCell>().getNumber() == -1)
                    {
                        swapNumbers(i, j, i, j - 1);
                    }
                }
                if (isValid())
                {
                    this.messageText.GetComponent<UnityEngine.UI.Text>().text = "You Win!";
                    this.messageText.SetActive(true);
                }
                //if (this.moves >= 10)
                //{
                //    this.messageText.GetComponent<UnityEngine.UI.Text>().text = "You Lose!";
                //    this.messageText.SetActive(true);
                //}
            }
        }
    }

    bool isValid()
    {
        int[] success = new int[9] { 1, 2, 3, 4, 5, 6, 7, 8, -1 };
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (gameBoardCells[i, j].GetComponent<gameCell>().getNumber() != success[i * 3 + j])
                {
                    return false;
                }
            }
        }
        return true;
    }

    void timerEnded()
    {
        this.messageText.GetComponent<UnityEngine.UI.Text>().text = "You Lose!";
        this.messageText.SetActive(true);
    }

    void generateNumbers()
    {
        int[] hardCode = new int[9] {1, 2, 3, 4, 6, 8, 7, 5, -1 };
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                gameBoardCells[i, j].GetComponent<gameCell>().setNumber(hardCode[i * 3 + j]);
            }
        }
    }

    void swapNumbers(int xi, int xj, int yi, int yj)
    {
        int cellOne = gameBoardCells[xi, xj].GetComponent<gameCell>().getNumber();
        gameBoardCells[xi, xj].GetComponent<gameCell>().setNumber(-1);
        gameBoardCells[yi, yj].GetComponent<gameCell>().setNumber(cellOne);
        gameBoardCells[xi, xj].GetComponent<gameCell>().isClicked = false;
    }

    public void resetGame()
    {
        int[] hardCode = new int[9] { 1, 2, 3, 4, 6, 8, 7, 5, -1 };
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                gameBoardCells[i, j].GetComponent<gameCell>().setNumber(hardCode[i * 3 + j]);
            }
        }
        this.messageText.SetActive(false);
        this.targetTime = 10.0f;
    }
}

//for (int i = 0; i< 3; i++)
//        {
//            for (int j = 0; j< 3; j++)
//            {

//            }
//        }