using UnityEngine;
using System.Collections;

public class BasicCellProperty : MonoBehaviour {
	
	//all cell property scripts MUST have this, and have a prefab with their Global stats script assigned to this value
	public CellProperty_Global cellStats;
	
	//this value deffines what this cell evovles into
	//can be altered but never null
	public GameObject nextGen;

	//this value MUST be included in ALL cell property scripts
	//when true, causes the cell to update it's self the next frame
	private bool trigUpdate = true;

	/*
	//the start function should be disabled for all property scripts
	// if adding code here, test the upgarde to feedercell action in (OnCollisionEnter)
	void Start () {
	
	}
	*/
	
	//keep the update function as sparse as possible, if it dosen't need to execute for EVERY frame
	//then put it in the trigUpdate
	void Update () {
		
		//this MUST be in every cell property script
		//updates the cell's property's when ever it interacts with something
		if (trigUpdate) {
			this.GetComponent<Rigidbody> ().velocity = (cellStats.getVector () * cellStats.getSpeed());//ensures that any acidental bumps don't move the cell of deffined course
			cellStats.formToGrid ();//ensures that all cells line up perfectly with eachother
			trigUpdate = false;//ensures that update trigger runs only once
		}

		
	}

	//all cell's must have this function to define interaction
	void OnCollisionEnter(Collision coll){

		//all cell property scripts SHOULD do this, prevents cells from doing weird things
		if (trigUpdate == true)//one interaction at a time
			return;

		//TODO: drop tags and add an integer ID to global stats so we can use a switch statment instead of if statments
		if(coll.gameObject.tag == "BasicCell"){
			
			CellProperty_Global otherStats = coll.gameObject.GetComponent<CellProperty_Global>();

			cellStats.setVector(cellStats.getVector() * -1);//should make this a default interaction

			if (cellStats.getEnergy() <= otherStats.getEnergy()) {//if other cell has more energy increase own energy
				cellStats.alterEnergy(1);
			} else if(cellStats.getEnergy() > 0){//if other cell has less energy and we have energy, reduce own energy
				cellStats.alterEnergy(-1);
			}

			if (cellStats.getEnergy () >= 20) {
				cellStats.setEnergy (0);
				GameObject newCell = (GameObject) Instantiate(nextGen ,new Vector3(transform.position.x,transform.position.y,transform.position.z), Quaternion.identity);
				cellStats.copy (newCell.GetComponent<CellProperty_Global> ());
				Destroy (this.gameObject);
			}

		}

		if (coll.gameObject.tag == "FeederCell") {
			cellStats.setVector(cellStats.getVector() * -1);
		}

		trigUpdate = true;//scheduals this cell to update itself next frame
	}
	



}
