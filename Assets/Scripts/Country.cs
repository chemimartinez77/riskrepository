using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Country : MonoBehaviour
{
    public Country[] limits;
    public GameController gameController;
    public string countryName;
    public Army army;
    public Player owner;

    public bool zoomable = true;
    //public GameController gameController;

    private bool highlighted = false;

    // Start is called before the first frame update
    void Start()
    {
        army.gameObject.SetActive(false);

        // army = Resources.Load<Army>("Prefabs/Army");
        // Destroy(GetComponent<PolygonCollider2D>());
        // gameObject.AddComponent<PolygonCollider2D>();

    }

    // Update is called once per frame
    void Update(){
        //CheckDropArmy();
        CheckClick();
    }

    private void CheckClick(){
        if(Input.GetMouseButtonDown(0) && highlighted){ //LEFT BUTTON CLICKED
            gameController.clickOnCountry(this);
        }
        
    }

    private void OnMouseEnter() {
        highlighted = true;
    }

    private void OnMouseExit() {
        highlighted = false;
    }

 }
