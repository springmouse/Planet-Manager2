using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resizer : MonoBehaviour {

    public float m_width;
    public float m_height;
	
	void Update ()
    {
        float width = Screen.width;
        float height = Screen.height;

        gameObject.transform.localScale = new Vector3(width / m_width, height / m_height, 0);
	}
}
