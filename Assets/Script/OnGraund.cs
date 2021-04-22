using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGraund : MonoBehaviour {
    public GameObject objeto;
    private float positionX = 0.6f;

	// Use this for initialization
	void Start () {
        objeto.GetComponent<Enemi_Ground>().lado = 1f;    

	}

    
    private void OnTriggerExit2D(Collider2D other){
        if (other.gameObject.tag == "Plataforma"){            
            objeto.GetComponent<Enemi_Ground>().lado = objeto.GetComponent<Enemi_Ground>().lado * (-1);
            this.transform.position = new Vector3(objeto.transform.position.x - positionX, this.transform.position.y, this.transform.position.z);
            positionX *= -1;
        }
    }
}
