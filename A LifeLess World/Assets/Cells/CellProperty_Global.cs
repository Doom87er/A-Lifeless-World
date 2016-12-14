using UnityEngine;
using System.Collections;

//all cells must have their own version of this script  <-!!!!!IMPORTANT!!!!!
public class CellProperty_Global : MonoBehaviour {
	
	
	//DO NOT REFERANCE THESE VALUES DIRECTLY
	//TODO: change these to private and add a way to manipulate these values manually
	public int energy = 0;
	public float speed = 0;
	public Vector3 vector = Vector3.zero;

	/*
	//Start and Update should not be used in the global properties script.
	void Start () {
	
	}
	
	
	void Update () {
	
	}
	*/

	//copys all global stats from one cell to the other
	public void copy(CellProperty_Global copyTo){
		copyTo.setEnergy (this.getEnergy());
		copyTo.setSpeed (this.getSpeed ());
		copyTo.setVector (this.getVector ());
	}
	/*used by:
	BasicCell: when upgrading into a new cell
	
	*/


	//TODO: update these to prevent the abillity to alter values with get methods
	//i'm not going to specify the function of these very common, very simple methods
	//if you can't figure them out yourself: god help you.
	public int getEnergy(){
		return this.energy;
	}

	public void setEnergy(int energy){
		this.energy = energy;
	}

	
	public void alterEnergy(int energy){
		this.energy += energy;
	}

	public float getSpeed(){
		return this.speed;
	}

	public void setSpeed(float speed){
		this.speed = speed;
	}

	
	public void alterSpeed(float speed){
		this.speed += speed;
	}

	public Vector3 getVector(){
		return this.vector;
	}

	
	public void setVector(Vector3 vector){
		this.vector = vector;
	}
	
	//NOTE: there is no "alter" vector function since Vector3 has its own method for handling that
	//but it might be worth will to make our own version inorder to make a more "standardized" method
	//for making contextual alterations to a cell's vector (Doom87er)

	//aligns the cell to a standard axis, unless moving along that axis
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
	//used by: ->EVERYONE<- ALL CELLS *NEED* THIS OR THEY WILL NOT ALIGN WITH OTHER CELLS. NO EXCEPTIONS!!!
}
