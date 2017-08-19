using System.Collections.Generic;
using UnityEngine;

public class ReverseChildLayerOrder : MonoBehaviour {

	void Start () {
		Canvas[] children = GetComponentsInChildren<Canvas> ();
		foreach (Canvas canvas in children) {
			canvas.sortingOrder = canvas.sortingOrder;
		}
	}

}
