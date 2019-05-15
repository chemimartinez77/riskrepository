using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Color color;
    public string playerName;
    public int currentUnits = 5; //35 para 3 jugadores. Ver reglas
    public Sprite meeple;
    public bool droppedArmy;
    public Army army;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
