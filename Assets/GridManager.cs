using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{

    public const int size = 4;
    public int columnLength, rowLength;
    public float xSpace, ySpace;
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 16; i++)
        {
            Instantiate(prefab, new Vector3(xSpace * (i % columnLength), ySpace * (i / columnLength)), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
