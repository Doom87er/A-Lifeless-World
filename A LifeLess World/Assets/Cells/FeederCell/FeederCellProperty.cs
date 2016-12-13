using UnityEngine;
using System.Collections;

public class FeederCellProperty : MonoBehaviour {

	public CellProperty_Global cellStats;
	public GameObject offspring;

	private bool trigUpdate = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (trigUpdate == true)//one interaction at a time
			return;

		if (trigUpdate) {
			this.GetComponent<Rigidbody> ().velocity = (cellStats.getVector () * cellStats.getSpeed());
			cellStats.formToGrid ();
			trigUpdate = false;
		}

	}

	void OnCollisionEnter(Collision coll){

		if (coll.gameObject.tag == "BasicCell") {
			CellProperty_Global otherStats = coll.gameObject.GetComponent<CellProperty_Global> ();

			if (otherStats.getEnergy () > 0) {
				otherStats.alterEnergy (-1);
				cellStats.alterEnergy (1);
			}

			if(cellStats.getEnergy() >= 10){
				cellStats.setEnergy(0);
				GameObject child = (GameObject) Instantiate(offspring,new Vector3(transform.position.x,transform.position.y + 1,transform.position.z), Quaternion.identity);
				CellProperty_Global childproperty = child.GetComponent<CellProperty_Global> ();
				switch (Random.Range (1, 4)) {
				case 1:
					childproperty.setVector (Vector3.left);
					break;
				case 2:
					childproperty.setVector (Vector3.right);
					break;
				case 3:
					childproperty.setVector (Vector3.forward);
					break;
				case 4:
					childproperty.setVector (Vector3.back);
					break;
				}
				childproperty.setSpeed (1);
			}

		}
	}
}
