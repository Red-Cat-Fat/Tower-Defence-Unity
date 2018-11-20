using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Build : MonoBehaviour {
    public GameObject buildObject;
    public LayerMask hitLayers;

    public float gridSize = 5f;

    public bool process
    {
        get
        {
            return _process;
        }
        set
        {
            buildObject.SetActive(value);
            _process = value;
        }
    }
    private bool _process = true;
    private float _dalayValue = 0.25f;
    private float _dalay = 0;
    // Update is called once per frame
    void Update()
    {
        _dalay -= Time.deltaTime;
        Vector3 mouse = Input.mousePosition;//Get the mouse Position
        Ray castPoint = Camera.main.ScreenPointToRay(mouse);//Cast a ray to get where the mouse is pointing at
        RaycastHit hit;//Stores the position where the ray hit.
        if (Physics.Raycast(castPoint, out hit, Mathf.Infinity, hitLayers))//If the raycast doesnt hit a wall
        {
            if (buildObject != null)
            {
                if (process)
                {
                    Vector3 vector3 = new Vector3(hit.point.x - hit.point.x % gridSize, hit.point.y - hit.point.y % gridSize, hit.point.z - hit.point.z % gridSize);
                    buildObject.transform.position = vector3;//Move the target to the mouse position
                    if (Input.GetMouseButton(0) && _dalay <=0)
                    {
                        Instantiate(buildObject);
                        _dalay = _dalayValue;
                        //process = false;
                    }
                }
            }
        }
    }
}
