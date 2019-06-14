using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Color color;
    public string playerName;
    public int startingUnits = 2; //35 para 3 jugadores. Ver reglas
    public int currentUnits = 2;
    public Sprite meeple;
    public bool droppedArmy;

    public bool isTurn;
    public Army army;

    // Start is called before the first frame update
    void Start()
    {
        startingUnits = 2;
        currentUnits = 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
