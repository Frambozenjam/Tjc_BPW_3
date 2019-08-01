using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_3DText : MonoBehaviour
{
    MeshRenderer comp_TextMesh;
    Collider comp_Collider;

    // Start is called before the first frame update
    void Start()
    {
        comp_TextMesh = GetComponent<MeshRenderer>();
        comp_Collider = GetComponent<Collider>();

        comp_TextMesh.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            comp_TextMesh.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            comp_TextMesh.enabled = false;
        }
    }
}
