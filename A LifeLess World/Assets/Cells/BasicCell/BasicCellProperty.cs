using UnityEngine;
using System.Collections;

public class BasicCellProperty : MonoBehaviour {
	/*dead code
	public float speed = 0.0f;
	public Vector3 cellStats.getVector() = new Vector3(0.0f,0.0f,0.0f);
	public float energy = 0;
	*/
	public CellProperty_Global cellStats;
	public GameObject nextGen;

	private bool trigUpdate = true;

	/*// if adding code here, test the upgarde to feedercell action in (OnCollisionEnter)
	void Start () {
	
	}
	*/
	
	// Update is called once per frame
	void Update () {
		

		if (trigUpdate) {
			this.GetComponent<Rigidbody> ().velocity = (cellStats.getVector () * cellStats.getSpeed());
			cellStats.formToGrid ();
			trigUpdate = false;
		}

		/*
		if (cellStats.getSpeed() != 0.0f) {//reduce overhead further?
			this.transform.Translate (cellStats.getVector() * (cellStats.getSpeed() * Time.deltaTime));

		}
		*/
	}

	void OnCollisionEnter(Collision coll){

		if (trigUpdate == true)//one interaction at a time
			return;

		if(coll.gameObject.tag == "BasicCell"){
			//GameObject cellOther = coll.gameObject;
			
			//BasicCellProperty cellOtherProperty = coll.gameObject.GetComponent<BasicCellProperty> ();
			CellProperty_Global otherStats = coll.gameObject.GetComponent<CellProperty_Global>();

			cellStats.setVector(cellStats.getVector() * -1);

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

		trigUpdate = true;
	}
	



}
