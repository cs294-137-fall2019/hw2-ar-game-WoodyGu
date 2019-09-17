using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameCell : MonoBehaviour, OnTouch3D
{
    public int number;
    public bool isClicked;

    public float debounceTime = 0.5f;
    // Stores a counter for the current remaining wait time.
    private float remainingDebounceTime;
    // Start is called before the first frame update
    void Start()
    {
        this.number = 0;
        this.remainingDebounceTime = 0;
        this.isClicked = false;
        TextMesh textToDisplay = GetComponentInChildren<TextMesh>();
        textToDisplay.text = this.number.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (remainingDebounceTime > 0)
        {
            remainingDebounceTime -= Time.deltaTime;
        }
    }

    public void OnTouch()
    {

        if (remainingDebounceTime <= 0)
        {
            this.isClicked = !this.isClicked;

            //if (isClicked)
            //{
            //    GetComponent<Renderer>().material.color = Color.green;
            //}
            //else
            //{
            //    GetComponent<Renderer>().material.color = Color.white;
            //}
            //this.number = (this.number + 1) % 10;
            //TextMesh textToDisplay = GetComponentInChildren<TextMesh>();
            //textToDisplay.text = this.number.ToString();
            remainingDebounceTime = debounceTime;
        }
    }

    public int getNumber()
    {
        return this.number;
    }

    public void setNumber(int newNumber)
    {
        if (newNumber == -1)
        {
            this.number = newNumber;
            TextMesh textToDisplay = GetComponentInChildren<TextMesh>();
            textToDisplay.text = "";
        }
        else
        {
            this.number = newNumber;
            TextMesh textToDisplay = GetComponentInChildren<TextMesh>();
            textToDisplay.text = this.number.ToString();
        }
    }

}
