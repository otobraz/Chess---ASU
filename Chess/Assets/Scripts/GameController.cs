﻿using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	private string[,] gameBoard;

	public GameObject blackPawn, blackRook, blackHorse, blackBishop, blackQueen, blackKing;

	public GameObject whitePawn, whiteRook, whiteHorse, whiteBishop, whiteQueen, whiteKing;

	private GameObject selectedPiece;

	// Use this for initialization
	void Start () {	
		initializeGameBoard ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void initializeGameBoard(){
		gameBoard = new string[8, 8];
		for (int i = 0; i < 8; i++) {
			gameBoard[1,i] = "wP";	Instantiate (whitePawn, new Vector3 (1, whitePawn.transform.position.y, i), Quaternion.identity);
			gameBoard[6,i] = "bP";	Instantiate (blackPawn, new Vector3 (6, whitePawn.transform.position.y, i), Quaternion.identity);
		}

		gameBoard [0, 0] = "wR";	Instantiate (whiteRook, new Vector3 (0, whiteRook.transform.position.y, 0), Quaternion.identity);
		gameBoard [0, 0] = "wH";	Instantiate (whiteHorse, new Vector3 (0, whiteHorse.transform.position.y, 1), Quaternion.identity);
		gameBoard [0, 2] = "wB";	Instantiate (whiteBishop, new Vector3 (0, whiteBishop.transform.position.y, 2), Quaternion.identity);
		gameBoard [0, 3] = "wQ";	Instantiate (whiteQueen, new Vector3 (0, whiteQueen.transform.position.y, 3), Quaternion.identity);
		gameBoard [0, 4] = "wK";	Instantiate (whiteKing, new Vector3 (0, whiteKing.transform.position.y, 4), whiteKing.transform.rotation);
		gameBoard [0, 5] = "wB";	Instantiate (whiteBishop, new Vector3 (0, whiteBishop.transform.position.y, 5), Quaternion.identity);
		gameBoard [0, 6] = "wH";	Instantiate (whiteHorse, new Vector3 (0, whiteHorse.transform.position.y, 6), Quaternion.identity);
		gameBoard [0, 7] = "wR";	Instantiate (whiteRook, new Vector3 (0, whiteRook.transform.position.y, 7), Quaternion.identity);

		gameBoard [7, 0] = "bR";	Instantiate (blackRook, new Vector3 (7, blackRook.transform.position.y, 0), Quaternion.identity);
		gameBoard [7, 1] = "bH";	Instantiate (blackHorse, new Vector3 (7, blackHorse.transform.position.y, 1), Quaternion.identity);
		gameBoard [7, 2] = "bB";	Instantiate (blackBishop, new Vector3 (7, blackBishop.transform.position.y, 2), Quaternion.identity);
		gameBoard [7, 3] = "bQ";	Instantiate (blackQueen, new Vector3 (7, blackQueen.transform.position.y, 3), Quaternion.identity);
		gameBoard [7, 4] = "bK";	Instantiate (blackKing, new Vector3 (7, blackKing.transform.position.y, 4), blackKing.transform.rotation);
		gameBoard [7, 5] = "bB";	Instantiate (blackBishop, new Vector3 (7, blackBishop.transform.position.y, 5), Quaternion.identity);
		gameBoard [7, 6] = "bH";	Instantiate (blackHorse, new Vector3 (7, blackHorse.transform.position.y, 6), Quaternion.identity);
		gameBoard [7, 7] = "bR";	Instantiate (blackRook, new Vector3 (7, blackRook.transform.position.y, 7), Quaternion.identity);
	}


	public void UpdateGameBoard(){

	}

	//Return the piece selected atm
	public GameObject getSelectedPiece(){
		return selectedPiece;
	}

	//Select the piece
	public void SelectedPiece(GameObject piece){

		if (getSelectedPiece()) {
			Debug.Log("Animation_Selection"); //Play animation(selection)

		}
		selectedPiece = piece;
		Debug.Log (selectedPiece.name + " is selected");
	}
	
	//Move the piece selected
	public void MovePiece(Vector3 coordToMove){
		switch(getSelectedPiece().tag){
			case "White":
				WhitePiecesController whitePieceController = selectedPiece.GetComponent<WhitePiecesController> ();
				if(whitePieceController.IsMoveValid(coordToMove)){
					selectedPiece.transform.position = coordToMove;
					Debug.Log ("Animation_moving"); //Play animation(moving)
					selectedPiece = null;
				}
				break;
			case "Black":	
				BlackPiecesController blackPieceController = selectedPiece.GetComponent<BlackPiecesController> ();
				if(blackPieceController.IsMoveValid(coordToMove)){
					selectedPiece.transform.position = coordToMove;
					Debug.Log ("Animation_moving"); //Play animation(moving)
					selectedPiece = null;
				}
				break;
		}
			
	}

	/*
	// for example, this would go on the tile to handle snapping for initial placement:
	// you need to have a reference of the unit being placed
	void OnMouseOver()
	{
		if (tileIsPasable)
		{
			Unit.GetComponent<unitScript>().snapping = true;
			Unit.transform.position = this.transform.position;
		}
	}
	void OnMouseExit()
	{
		if (tileIsPasable)
		{
			Unit.GetComponent<unitScript>().snapping = false;
		}
	}
	void OnMouseDown()
	{
		if (tileIsPasable)
		{
			Unit.GetComponent<unitScript>().snapping = true;
			Unit.transform.position = this.transform.position;
			Unit.GetComponent<unitScript>().state = UnitScript.State.idle;  
		}
	}
	
	// then this bit would be on the unit, 
	//it attaches the unit to the mouse when it is not being snapped to he grid
	if(snapping == false){
		Vector3 screenPos = Input.mousePosition;
		screenPos.z = 40f;
		Vector3 worldPos = Camera.mainCamera.ScreenToWorldPoint(screenPos);
		transform.position = worldPos;
	}*/
}
