using UnityEngine;
using System.Collections;

public class SinglePlayer : MonoBehaviour {

    public GameObject Canvas;
    public GameObject Cube;
    public GameObject currentDetonator;
    private int _currentExpIdx = -1;
    public GameObject[] detonatorPrefabs;
    public float explosionLife = 10;
    public float timeScale = 1.0f;
    public float detailLevel = 1.0f;
    public float speedRotation;

    public float forceExplosion;
    public float radiusExplosion;

    public float durationBeforeChangeScreen;
    private float timeToChangeLvl = -10;
	// Use this for initialization
	void Start () {
        this._currentExpIdx = 5;
	}
	
	// Update is called once per frame
	void Update () {
        if (this.timeToChangeLvl != -10)
         if (Time.time > timeToChangeLvl)
             Application.LoadLevel("LogoMenu");
	}

    public void ClickNewGame()
    {
        if (this.Cube != null)
        {
            DestroyObject(Cube);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            Detonator dTemp = (Detonator)currentDetonator.GetComponent("Detonator");

            float offsetSize = dTemp.size / 3;

            GameObject exp = (GameObject)Instantiate(currentDetonator, Cube.GetComponent<Rigidbody>().position, Quaternion.identity);
            dTemp = (Detonator)exp.GetComponent("Detonator");


            Destroy(exp, explosionLife);
            Cube.GetComponent<Rigidbody>().AddExplosionForce(this.forceExplosion, Cube.GetComponent<Rigidbody>().position, this.radiusExplosion);
            DestroyObject(Cube);
            this.timeToChangeLvl = Time.time + this.durationBeforeChangeScreen;
        }
    }

    public void ClickContinue()
    {
        Debug.Log("continue");
    }

    public void ClickMultiplayer()
    {
        this.Cube.GetComponent<Rigidbody>().AddTorque(0, this.speedRotation, 0);

        if (this.Canvas.active)
            this.Canvas.SetActive(false);
        else
            this.Canvas.SetActive(true);
    
    }
}
