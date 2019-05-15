using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Army : MonoBehaviour
{
    public Player owner;
    public Country countryLocated;
    public int units;
    public GameController gameController;
    public TextMeshPro textUnits;
    public Sprite armySprite;
    
    // Start is called before the first frame update
    // Con Start no funcionaba correctamente el seteo de units a 0.
    void Awake() 
    {
        units = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
