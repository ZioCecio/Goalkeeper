using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour {

	void OnMouseDown(){

		GameManager.Instance.Click(name.ToCharArray()[0] - '0');
	}
}