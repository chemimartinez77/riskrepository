using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    public GameObject cartelMaderaFase;   
    public Country[] countries;
    public Player[] players;
    public int playerIndex = 0;
    public int maxCountries = 6;
    public int startingUnits;
    public Button nextPlayerButton;
    public Image currentPlayerImage;
    public Text currentPlayerName;
    public int unitsDropped = 0;

    public Text phaseText;

    public Player currentPlayer = null;
    //public int maxPlayers = 3;

    public GameConstants.Phase currentPhase;
    private bool phaseChange = false;

    // Start is called before the first frame update
    void Start(){
        currentPlayer = players[playerIndex];
        currentPhase = GameConstants.Phase.Start;
        currentPlayer.droppedArmy = false;
        currentPlayerImage.sprite = currentPlayer.meeple;
        currentPlayerName.text = currentPlayer.playerName;
        startingUnits = players.Length * currentPlayer.startingUnits;
        unitsDropped = 0;
        cartelMaderaFase.SetActive(true);
    }

    // Update is called once per frame
    void Update(){ //EN REALIDAD ESTO NO SE TIENE QUE HACER EN CADA PUTO FRAME. UN EVENTO CLICK LO DISPARARÁ.
        // if (phaseChange){
        //     changePhase();
        // }
        
    }

    public void clickOnCountry(Country countryClicked){
        switch (currentPhase){
            case GameConstants.Phase.Start:
                GameConstants.ClearConsole();
                if (!currentPlayer.droppedArmy && currentPlayer.isTurn && unitsDropped < startingUnits){ //¿Dropeo army?
                    Debug.Log("- Hay que dorpear army. "+currentPlayer.playerName);
                    if (maxCountries > unitsDropped){ //¿Hay algún país vacío?
                        Debug.Log("- Hay países vacíos. maxCountries: "+ maxCountries);
                        if (countryClicked.army.units == 0){ //Si se hace click sobre un país vacío
                            currentPlayer.currentUnits -=1;
                            countryClicked.army.units += 1;
                            Debug.Log("- countryClicked.army.units: "+countryClicked.army.units);
                            countryClicked.army.gameObject.SetActive(true);
                            countryClicked.army.GetComponent<SpriteRenderer>().sprite = currentPlayer.meeple;
                            countryClicked.owner = currentPlayer;
                            currentPlayer.droppedArmy = true;
                            unitsDropped+=1;
                            changeTurn();
                        }
                    } else {
                        Debug.Log("No hay paises vacíos");
                        if (countryClicked.owner == currentPlayer && currentPlayer.currentUnits > 0){
                            Debug.Log("- Hay que dropear en el propio país");
                            currentPlayer.currentUnits -=1;
                            countryClicked.army.units += 1;
                            Debug.Log("countryClicked.army.units: "+countryClicked.army.units);
                            countryClicked.army.textUnits.text = "x"+countryClicked.army.units.ToString();
                            unitsDropped+=1;
                            currentPlayer.droppedArmy = true;
                            changeTurn();
                        } else if (countryClicked.owner != currentPlayer ){
                            Debug.Log("- Hay que dropear en OTRO país");
                        } else {
                            //FIN DE FASE
                            Debug.Log("SACABO LA FASE INICIAL - Todos los países están ocupados");
                            changePhase();
                        }
                    }
                } else { //Poner a parpadear el botoncico de next player
                    Debug.Log("//Hay que activar el botón de cambio de turno");
                    //StartCoroutine(nextPlayerButton.GetComponent<InAndOut>().ZoomInOut());
                    //De momento cambio automático de turno
                    //changeTurn();
                }
                countryClicked = null;
                break;
            case GameConstants.Phase.Combat:
                phaseText.text = "Combate";
                cartelMaderaFase.GetComponent<SpriteRenderer>().sprite = GameConstants.IMG2Sprite.LoadNewSprite("F:/UnityRepository/riskrepository/Assets/Resources/Pics/cartelmaderafase.combate.png");
                countryClicked.GetComponent<SpriteRenderer>().color = GameConstants.ConvertColor(255,0,255,1);
                Debug.Log("FASE DE COMBATE. SELECCIONAR DEFENSOR");
                break;
            case GameConstants.Phase.Relocate:
                phaseText.text = "Ubicación";
                Debug.Log("FASE DE REUBICACIÓN. SELECCIONAR 2 CIUDADES CONECTADAS ENTRE SÍ");
                break;
            case GameConstants.Phase.Reinforcement:
                phaseText.text = "Combate";
                Debug.Log("FASE DE REFUERZOS.");
                break;
        }
    }

    public void changeTurn(){
        StopAllCoroutines();
        //Debug.Log("last player: "+currentPlayer.name);
        if (currentPhase == GameConstants.Phase.Start){
            if (unitsDropped >= startingUnits){
                changePhase();
            }
            currentPlayer.droppedArmy = false;
        }
        currentPlayer.isTurn = false;
        playerIndex += 1;
        if (playerIndex >= players.Length){
            playerIndex = 0;
        }
        currentPlayer = players[playerIndex];
        currentPlayer.isTurn = true;
        currentPlayerImage.sprite = currentPlayer.meeple;
        currentPlayerName.text = currentPlayer.playerName;
        //canvasController.nextPlayerButton.OnPointerUp.
    }

    public void changePhase(){
        switch (currentPhase){
            case GameConstants.Phase.Start:
                if (playerIndex >= players.Length){
                    playerIndex = 0;
                }
                currentPlayer = players[playerIndex];
                currentPlayer.isTurn = true;
                currentPlayerImage.sprite = currentPlayer.meeple;
                currentPlayerName.text = currentPlayer.playerName + "attacks";
                currentPhase = GameConstants.Phase.Combat;
                break;
            case GameConstants.Phase.Combat:
                phaseText.text = "Combate";
                Debug.Log("FASE DE COMBATE. SELECCIONAR ATACANTE");
                Debug.Log("FASE DE COMBATE. SELECCIONAR DEFENSOR");
                break;
            case GameConstants.Phase.Relocate:
                phaseText.text = "Ubicación";
                Debug.Log("FASE DE REUBICACIÓN. SELECCIONAR 2 CIUDADES CONECTADAS ENTRE SÍ");
                break;
            case GameConstants.Phase.Reinforcement:
                phaseText.text = "Combate";
                Debug.Log("FASE DE REFUERZOS.");
                break;
        }
    }

    public void ActivatePhaseChange(){
        phaseChange = true;
    }

    public void DropArmy(){

    }

}
