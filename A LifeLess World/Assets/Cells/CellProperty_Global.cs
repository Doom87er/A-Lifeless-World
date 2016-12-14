//(*) having problems with cell's that alter eachother. currently all values are changed instantly, so when two meet one will use the values AFTER the other has already changed them

using UnityEngine;
using System.Collections;

public class CellProperty_Global : MonoBehaviour {
	
	
	
	//TODO: change these to private and add a way to manipulate these values manually
	public int energy = 0;
	public float speed = 0;
	public Vector3 vector = Vector3.zero;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void copy(CellProperty_Global copyTo){
		copyTo.setEnergy (this.getEnergy());
		copyTo.setSpeed (this.getSpeed ());
		copyTo.setVector (this.getVector ());
	}

	public int getEnergy(){
		return this.energy;
	}

	public void setEnergy(int energy){
		this.energy = energy;
	}

	//TODO:change this so it waits untill the next frame to update*
	public void alterEnergy(int energy){
		this.energy += energy;
	}

	public float getSpeed(){
		return this.speed;
	}

	public void setSpeed(float speed){
		this.speed = speed;
	}

	//TODO:change this so it waits untill the next frame to update*
	public void alterSpeed(float speed){
		this.speed += speed;
	}

	public Vector3 getVector(){
		return this.vector;
	}

	//TODO:change this so it waits untill the next frame to update*
	public void setVector(Vector3 vector){
		this.vector = vector;
	}

	public void formToGrid(){
		float x = this.transform.position.x;
		float y = this.transform.position.y;
		float z = this.transform.position.z;

		if (this.vector.x == 0) {
			x = Mathf.Round (this.transform.position.x);
		}
		if (this.vector.y == 0) {
			y = Mathf.Round (this.transform.position.y);
		}
		if (this.vector.z == 0) {
			z = Mathf.Round (this.transform.position.z);
		}

		this.transform.position = new Vector3 (x,y,z);
	}
}
