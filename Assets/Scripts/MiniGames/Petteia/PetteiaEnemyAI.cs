//Paul Reichling
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PetteiaEnemyAI : MonoBehaviour
{
	public List<PetteiaEnemyPiece> pieces;
	private PetteiaEnemyPiece currentPiece;
	private int movementDistance = 0;
	
	private PetteiaGameController pController;

	void Start()
    {
		pController = GetComponent<PetteiaGameController>();
		
	}

    void Update()
    {
	//	Debug.Log("Numpieces" + pieces.Count);
		//if (pieces.Count == 0 || Input.GetKeyDown(KeyCode.W)) {
		//	Debug.Log("youwin!");
		//	gameOver = true;
		//	winCanvas.SetActive(true);
			
		//	water.text ="+" + playerShip.GameResultWater().ToString();
		//	food.text = "+" + playerShip.GameResultFood().ToString();

		//	//	ship.cargo[1].amount_kg < dailyProvisionsKG * ship.crewRoster.Count
			
		//}
		//if (Input.GetKeyDown(KeyCode.W)) {
		//	PrintBoard();
		//}
		//if(!pController.GameOver && pController.yourTurn == false && isMoving == false) {
		//	isMoving = true;
		//	StartCoroutine(MakeMove()); //Checks if the user has made a move and runs the enemy move command is so
		//}
		
	}

	public void StartEnemyTurn() {
		if (!pController.GameOver) 
		{
			StartCoroutine(MakeMove());
		}
	}

	public IEnumerator CheckPieces() {
		Debug.Log("Enemy CheckPieces");
		for (int i = pieces.Count - 1; i >= 0; i--) {
			if (pieces[i] == null) {
				pieces.RemoveAt(i);
			}
		}
		Debug.Log("Done with Enemy CheckPieces");
		yield return null;
	}

	IEnumerator MakeMove() {
		
		yield return new WaitForSeconds(1f);
		//CheckPieces();

		string s = "";
		
		PetteiaEnemyPiece pieceToMove = null;
		foreach (PetteiaEnemyPiece p in pieces) { //Runs through each available enemy piece and sees if it can capture another piece.

			if (p == null) {
				break;
			}

			currentPiece = p;
			
			//moving up loop
			for (int x = (int)p.GetComponent<Positions>().pos.x; x > 2; x--) {
				//Debug.Log("looking up");
				//Debug.Log(currentg.name);
				if (pController.positions[x, (int)p.GetComponent<Positions>().pos.y] != 0 &&
					x != (int)p.GetComponent<Positions>().pos.x) {
					//Debug.Log("BREAKING");
					break;
				}
				if (pController.positions[x - 1, (int)p.GetComponent<Positions>().pos.y] == 2
					&& pController.positions[x - 2, (int)p.GetComponent<Positions>().pos.y] == 1
					&& pController.positions[x, (int)p.GetComponent<Positions>().pos.y] == 0) {
					pieceToMove = p;
					s = "up";
					movementDistance = (int)p.GetComponent<Positions>().pos.x - x;

					goto End;
				}

				if ((int)p.GetComponent<Positions>().pos.y <= 5) {
					//look right while moving 
					if (pController.positions[x, 1 + (int)p.GetComponent<Positions>().pos.y] == 2
						&& pController.positions[x, 2 + (int)p.GetComponent<Positions>().pos.y] == 1
						&& pController.positions[x, (int)p.GetComponent<Positions>().pos.y] == 0) {
						//Debug.Log("right looking");
						pieceToMove = p;
						s = "up";
						movementDistance = (int)p.GetComponent<Positions>().pos.x - x;

						goto End;
					}
				}
				if ((int)p.GetComponent<Positions>().pos.y >= 2) {
					//look left while moving 
					//Debug.Log(1 - (int)g.GetComponent<Positions>().pos.y);

					if (pController.positions[x, (int)p.GetComponent<Positions>().pos.y - 1] == 2
						&& pController.positions[x, (int)p.GetComponent<Positions>().pos.y - 2] == 1
						&& pController.positions[x, (int)p.GetComponent<Positions>().pos.y] == 0) {
						//Debug.Log("left looking");
						pieceToMove = p;
						s = "up";
						movementDistance = (int)p.GetComponent<Positions>().pos.x - x;

						goto End;
					}

				}
			}
			
			//////////////////////////////////////////////////////////////////////////////////////////
			
			//moving down loop
			for (int x = (int)p.GetComponent<Positions>().pos.x; x < 5; x++) {
				//Debug.Log("looking down");
				//Debug.Log(currentg.name);
				if (pController.positions[x, (int)p.GetComponent<Positions>().pos.y] != 0 && 
					x != (int)p.GetComponent<Positions>().pos.x) {
					//Debug.Log("BREAKING");
					break;
				}
					if (pController.positions[x + 1, (int)p.GetComponent<Positions>().pos.y] == 2
						&& pController.positions[x + 2, (int)p.GetComponent<Positions>().pos.y] == 1
						&& pController.positions[x, (int)p.GetComponent<Positions>().pos.y] == 0) {
						pieceToMove = p;
						s = "down";
						movementDistance = x - (int)p.GetComponent<Positions>().pos.x;

						goto End;
					}

					if ((int)p.GetComponent<Positions>().pos.y <= 5) {
						//look right while moving 
						if (pController.positions[x, 1 + (int)p.GetComponent<Positions>().pos.y] == 2
							&& pController.positions[x, 2 + (int)p.GetComponent<Positions>().pos.y] == 1
							&& pController.positions[x, (int)p.GetComponent<Positions>().pos.y] == 0) {
						//Debug.Log("right looking");
						pieceToMove = p;
							s = "down";
							movementDistance = x - (int)p.GetComponent<Positions>().pos.x;

							goto End;
						}
					}
					if ((int)p.GetComponent<Positions>().pos.y >= 2) {
						//look left while moving 
						//Debug.Log(1 - (int)g.GetComponent<Positions>().pos.y);

						if (pController.positions[x, (int)p.GetComponent<Positions>().pos.y - 1] == 2
							&& pController.positions[x, (int)p.GetComponent<Positions>().pos.y - 2] == 1
							&& pController.positions[x, (int)p.GetComponent<Positions>().pos.y] == 0) {
						//Debug.Log("left looking");
						pieceToMove = p;
							s = "down";
							movementDistance = x - (int)p.GetComponent<Positions>().pos.x;

							goto End;
						}
					
				}
			}

			////////////////////////////////////////////////////////////////////////////////////////

			//moving right loop
			for (int y = (int)p.GetComponent<Positions>().pos.y; y < 5; y++) {
				if (pController.positions[(int)p.GetComponent<Positions>().pos.x, y] != 0 &&
					y != (int)p.GetComponent<Positions>().pos.y) {
					//Debug.Log("BREAKING");
					break;
				}
				//Debug.Log("looking right");
				//Debug.Log(currentg.name);
				if (pController.positions[(int)p.GetComponent<Positions>().pos.x, y + 1 ] == 2
					&& pController.positions[(int)p.GetComponent<Positions>().pos.x, y + 2] == 1
					&& pController.positions[(int)p.GetComponent<Positions>().pos.x, y] == 0) {
					pieceToMove = p;
					s = "right";
					movementDistance =  y - (int)p.GetComponent<Positions>().pos.y ;

					goto End;
				}

				if ((int)p.GetComponent<Positions>().pos.x >= 2) {
					//look up while moving 
					if (pController.positions[(int)p.GetComponent<Positions>().pos.x - 1, y] == 2
						&& pController.positions[(int)p.GetComponent<Positions>().pos.x - 2, y ] == 1
						&& pController.positions[(int)p.GetComponent<Positions>().pos.x, y ] == 0) {
						//Debug.Log("up looking");
						pieceToMove = p;
						s = "right";
						movementDistance = y - (int)p.GetComponent<Positions>().pos.y;

						goto End;
					}
				}
				if ((int)p.GetComponent<Positions>().pos.x <=5 ) {
					//look down while moving 
					if (pController.positions[(int)p.GetComponent<Positions>().pos.x + 1, y] == 2
						&& pController.positions[(int)p.GetComponent<Positions>().pos.x + 2,y ] == 1
						&& pController.positions[(int)p.GetComponent<Positions>().pos.x,y ] == 0) {
						//Debug.Log("down looking");
						pieceToMove = p;
						s = "right";
						movementDistance = y - (int)p.GetComponent<Positions>().pos.y;

						goto End;
					}
				}
			}

			////////////////////////////////////////////////////////////////////////////////////////

			//moving left loop
			for (int y = (int)p.GetComponent<Positions>().pos.y; y > 2; y--) {
				if (pController.positions[(int)p.GetComponent<Positions>().pos.x, y] != 0 &&
					y != (int)p.GetComponent<Positions>().pos.y) {
					//Debug.Log("BREAKING");
					break;
				}
				//Debug.Log("looking left");
				//Debug.Log(currentg.name);
				if (pController.positions[(int)p.GetComponent<Positions>().pos.x, y - 1] == 2
					&& pController.positions[(int)p.GetComponent<Positions>().pos.x, y - 2] == 1
					&& pController.positions[(int)p.GetComponent<Positions>().pos.x, y] == 0) {
					pieceToMove = p;
					s = "left";
					movementDistance = (int)p.GetComponent<Positions>().pos.y - y ;

					goto End;
				}

				if ((int)p.GetComponent<Positions>().pos.x >= 2) {
					//look up while moving 
					if (pController.positions[(int)p.GetComponent<Positions>().pos.x - 1, y] == 2
						&& pController.positions[(int)p.GetComponent<Positions>().pos.x - 2, y] == 1
						&& pController.positions[(int)p.GetComponent<Positions>().pos.x, y] == 0) {
						//Debug.Log("up looking");
						pieceToMove = p;
						s = "left";
						movementDistance = (int)p.GetComponent<Positions>().pos.y - y;

						goto End;
					}
				}
				if ((int)p.GetComponent<Positions>().pos.x <= 5) {
					//look down while moving 
					if (pController.positions[(int)p.GetComponent<Positions>().pos.x + 1, y] == 2
						&& pController.positions[(int)p.GetComponent<Positions>().pos.x + 2, y] == 1
						&& pController.positions[(int)p.GetComponent<Positions>().pos.x, y] == 0) {
						//Debug.Log("down looking");
						pieceToMove = p;
						s = "left";
						movementDistance = (int)p.GetComponent<Positions>().pos.y - y;

						goto End;
					}
				}
			}

		}
		End:
		if (pieceToMove != null) {
			//Debug.Log("capture called with these params:");
			//Debug.Log(go.name + " " + s + " " + num);
			yield return StartCoroutine(MovePiece(pieceToMove.gameObject, s, movementDistance));
		} else {
			// Moves the piece randomly 1-3 spaces if it cannot find a capture. 
			int tries = 0;
			Rand:
			//Debug.Log("moving randomly");
			
			bool trying = false;
			movementDistance = 0;
			
			while (trying == false && tries < 50) {

				tries++;
				//Debug.Log(tries);
				int findPieceTries = 0;
				int direction = Random.Range(0, 4);
				do {
					pieceToMove = pieces.RandomElement();
					findPieceTries++;
					//Debug.Log("Trying to select a random enemy piece");
				} while (pieceToMove == null && findPieceTries < 100);

				if (findPieceTries >= 100) {
					Debug.Log("Found 100 null pieces in a row, uhoh!");
				}
				
				if (pieceToMove == null) {
					Debug.Log("Tried to move a null piece, whoopsies!");
				}
				currentPiece = pieceToMove;
				//Simplified Version not working 

				//for (int i = 0; i < num - 2; i++) {
				//	if ((int)go.GetComponent<Positions>().pos.x - i > 0) {
				//		//Debug.Log((int)go.GetComponent<Positions>().pos.x - i);
				//		if (p.positions[(int)go.GetComponent<Positions>().pos.y ,
				//			(int)go.GetComponent<Positions>().pos.x - i] == 0) {
				//			//Debug.Log("abley" + (int)go.GetComponent<Positions>().pos.y);
				//			//Debug.Log("ablex" + ((int)go.GetComponent<Positions>().pos.x - i));
				//			able = true;
				//			useNum =  i;
				//		} else {

				//			able = false;
				//			break;
				//		}
				//	}
				//	else {
				//		able = false;
				//		break;
				//	}
				//}

				////////////////////////////////////////////////////////////////////////

				if (direction == 0) {
					s = "up";
					//Debug.Log("moving randomly up ");
					if ((int)pieceToMove.GetComponent<Positions>().pos.x - 1 > 0) {
						//if (p.positions[(int)go.GetComponent<Positions>().pos.y,
						//			(int)go.GetComponent<Positions>().pos.x - 1] == 0) {
						if (pController.positions[(int)pieceToMove.GetComponent<Positions>().pos.x - 1,
									(int)pieceToMove.GetComponent<Positions>().pos.y] == 0) {
							trying = true;
							movementDistance = 1;
							//Debug.Log("can move 1");
							////Debug.Log((int)go.GetComponent<Positions>().pos.y + ";" +
									//((int)go.GetComponent<Positions>().pos.x - 1));
							if ((int)pieceToMove.GetComponent<Positions>().pos.x - 2 > 0) {
								if (pController.positions[(int)pieceToMove.GetComponent<Positions>().pos.x - 2,
									(int)pieceToMove.GetComponent<Positions>().pos.y] == 0) {
									movementDistance = Random.Range(1, 3);
									//Debug.Log("can move 2");
									////Debug.Log((int)go.GetComponent<Positions>().pos.y + ";" +
									//((int)go.GetComponent<Positions>().pos.x - 2));
									if ((int)pieceToMove.GetComponent<Positions>().pos.x - 3 > 0) {
										if (pController.positions[(int)pieceToMove.GetComponent<Positions>().pos.x - 3,
									(int)pieceToMove.GetComponent<Positions>().pos.y] == 0) {
											movementDistance = Random.Range(1, 4);
											//Debug.Log("can move 3");
											////Debug.Log((int)go.GetComponent<Positions>().pos.y + ";" +
									//((int)go.GetComponent<Positions>().pos.x - 3));
										}
										else {
											trying = true;
											movementDistance = Random.Range(1, 3);
											break;
										}
									}
								}
								else {
									trying = true;
									movementDistance = 1;
									break;
								}
								

							}
						}
						else {
							trying = false;
							break;
						}
						
					}
				}

				
				if (direction ==1) {
					s = "left";
					//Debug.Log("moving randomly left ");
					if ((int)pieceToMove.GetComponent<Positions>().pos.y - 1 > 0) {
						//if (p.positions[(int)go.GetComponent<Positions>().pos.y - 1,
						//			(int)go.GetComponent<Positions>().pos.x] == 0) {
						if (pController.positions[(int)pieceToMove.GetComponent<Positions>().pos.x,
									(int)pieceToMove.GetComponent<Positions>().pos.y - 1] == 0) {
							trying = true;
							movementDistance = 1;
							////Debug.Log((int)go.GetComponent<Positions>().pos.y - 1 + ";" +
								//	(int)go.GetComponent<Positions>().pos.x);
							if ((int)pieceToMove.GetComponent<Positions>().pos.y - 2 > 0) {
								if (pController.positions[(int)pieceToMove.GetComponent<Positions>().pos.x,
									(int)pieceToMove.GetComponent<Positions>().pos.y - 2] == 0) {
									movementDistance = Random.Range(1, 3);
									//Debug.Log("can move 2");
								//	//Debug.Log((int)go.GetComponent<Positions>().pos.y - 2 + ";" +
								//	(int)go.GetComponent<Positions>().pos.x);
									if ((int)pieceToMove.GetComponent<Positions>().pos.y - 3 > 0) {
										if (pController.positions[(int)pieceToMove.GetComponent<Positions>().pos.x,
									(int)pieceToMove.GetComponent<Positions>().pos.y - 3] == 0) {
											movementDistance = Random.Range(1, 4);
											//Debug.Log("can move 3");
										//	//Debug.Log((int)go.GetComponent<Positions>().pos.y - 3 + ";" +
									//(int)go.GetComponent<Positions>().pos.x);
										}
										else {
											trying = true;
											movementDistance = Random.Range(1, 3);
											break;
										}
									}
								}
								else {
									trying = true;
									movementDistance = 1;
									break;
								}
								

							}
						}
						else {
							trying = false;
							break;
						}
						
					}
				}
			
				if (direction == 2) {
					s = "right";
					//Debug.Log("moving randomly right ");
					if ((int)pieceToMove.GetComponent<Positions>().pos.y + 1 < 7) {
						//if (p.positions[(int)go.GetComponent<Positions>().pos.y - 1,
						//			(int)go.GetComponent<Positions>().pos.x] == 0) {
						if (pController.positions[(int)pieceToMove.GetComponent<Positions>().pos.x,
									(int)pieceToMove.GetComponent<Positions>().pos.y + 1] == 0) {
							trying = true;
							movementDistance = 1;
							////Debug.Log((int)go.GetComponent<Positions>().pos.y - 1 + ";" +
							//	(int)go.GetComponent<Positions>().pos.x);
							if ((int)pieceToMove.GetComponent<Positions>().pos.y + 2 < 7) {
								if (pController.positions[(int)pieceToMove.GetComponent<Positions>().pos.x,
									(int)pieceToMove.GetComponent<Positions>().pos.y + 2] == 0) {
									movementDistance = Random.Range(1, 3);
									//Debug.Log("can move 2");
									//	//Debug.Log((int)go.GetComponent<Positions>().pos.y - 2 + ";" +
									//	(int)go.GetComponent<Positions>().pos.x);
									if ((int)pieceToMove.GetComponent<Positions>().pos.y + 3 < 7) {
										if (pController.positions[(int)pieceToMove.GetComponent<Positions>().pos.x, 
									(int)pieceToMove.GetComponent<Positions>().pos.y + 3] == 0) {
											movementDistance = Random.Range(1, 4);
											//Debug.Log("can move 3");
											//	//Debug.Log((int)go.GetComponent<Positions>().pos.y - 3 + ";" +
											//(int)go.GetComponent<Positions>().pos.x);
										}
										else {
											trying = true;
											movementDistance = Random.Range(1, 3);
											break;
										}
									}
								}
								else {
									trying = true;
									movementDistance = 1;
									break;
								}


							}
						}
						else {
							trying = false;
							break;
						}

					}
				}


				if (direction == 3) {
					s = "down";
					
					//Debug.Log("moving randomly down ");
					if ((int)pieceToMove.GetComponent<Positions>().pos.x + 1 < 7) {
						//if (p.positions[(int)go.GetComponent<Positions>().pos.y,
						//			(int)go.GetComponent<Positions>().pos.x - 1] == 0) {
						if (pController.positions[(int)pieceToMove.GetComponent<Positions>().pos.x + 1,
									(int)pieceToMove.GetComponent<Positions>().pos.y] == 0) {
							trying = true;
							movementDistance = 1;
							//Debug.Log("can move 1");
							////Debug.Log((int)go.GetComponent<Positions>().pos.y + ";" +
							//((int)go.GetComponent<Positions>().pos.x - 1));
							if ((int)pieceToMove.GetComponent<Positions>().pos.x + 2 < 7) {
								if (pController.positions[(int)pieceToMove.GetComponent<Positions>().pos.x + 2,
									(int)pieceToMove.GetComponent<Positions>().pos.y] == 0) {
									movementDistance = Random.Range(1, 3);
									//Debug.Log("can move 2");
									////Debug.Log((int)go.GetComponent<Positions>().pos.y + ";" +
									//((int)go.GetComponent<Positions>().pos.x - 2));
									if ((int)pieceToMove.GetComponent<Positions>().pos.x + 3 < 7) {
										if (pController.positions[(int)pieceToMove.GetComponent<Positions>().pos.x + 3,
									(int)pieceToMove.GetComponent<Positions>().pos.y] == 0) {
											movementDistance = Random.Range(1, 4);
											//Debug.Log("can move 3");
											////Debug.Log((int)go.GetComponent<Positions>().pos.y + ";" +
											//((int)go.GetComponent<Positions>().pos.x - 3));
										}
										else {
											trying = true;
											movementDistance = Random.Range(1, 3);
											break;
										}
									}
								}
								else {
									trying = true;
									movementDistance = 1;
									break;
								}


							}
						}
						else {
							trying = false;
							break;
						}

					}
				}

				

			}
			if (movementDistance == 0) {
				if (tries >= 50) {
					yield return StartCoroutine(MovePiece(pieceToMove.gameObject, s, movementDistance)); //Move cant be found - pass turn
					Debug.Log("passing my turn");
					//Need some dialouge here like "I pass my turn TODO"
				}
				else {
					goto Rand; //Needs to make sure that the piece is not trying to move zero squares, since this isn't a legal move
				}
			}
			else {
				//Debug.Log("random called with these params:");
				//Debug.Log(go.name + " " + s + " " + num);
				yield return StartCoroutine(MovePiece(pieceToMove.gameObject, s, movementDistance));
				//Debug.Log("Tries to find a move: " + tries);
			}
		}


		//find out which piece we want to move AND why and where it needs to go 

		//Ending turn
		yield return null;

		StartCoroutine(pController.SwitchTurn());
		
	}

	IEnumerator MovePiece(GameObject piece, string dir, int dist) 
	{
		int x, y;
		////Debug test
		x = (int)piece.GetComponent<Positions>().pos.x;
		y = (int)piece.GetComponent<Positions>().pos.y;
		pController.positions[x, y] = 0;
		//Debug.Log((int)piece.GetComponent<Positions>().pos.x);
		//Debug.Log((int)piece.GetComponent<Positions>().pos.y);

		//piece.transform.Translate(Vector3.back * 6.25f);

		if (dir == "up") {
			//piece.transform.Translate(Vector3.forward * 6.25f * dist);
			x -= dist;
		}
		else if (dir == "left") {
			//piece.transform.Translate(Vector3.left * 6.25f * dist);
			y -= dist;

		}
		else if (dir == "right") {
			//piece.transform.Translate(Vector3.right * 6.25f * dist);
			y += dist;
		}
		else if (dir == "down") {
			//piece.transform.Translate(Vector3.back * 6.25f * dist);
			x += dist;
		}

		piece.transform.position = pController.BoardSquares[x, y].transform.position;
		yield return new WaitForSeconds(0.5f);


		pController.PlayMoveSound();
		pController.positions[x, y] = 1;

		//Debug.Log((int)piece.GetComponent<Positions>().pos.x);
		//Debug.Log((int)piece.GetComponent<Positions>().pos.y);
		//Debug.Log(currentg.name);
		//pController.PrintBoard();		

	}

	public void ToggleEnemyHighlight(bool toggle) 
	{
		foreach (PetteiaEnemyPiece p in pieces) {
			if (p != null) {
				p.highlight.SetActive(toggle);
			}
		}
	}


}
