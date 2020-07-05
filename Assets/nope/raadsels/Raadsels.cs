using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Raadsels : MonoBehaviour
{
    // Start is called before the first frame update
    public string[] raadsels;
    public GameObject Traadsel;
    private TextMesh mesh;

    void Start()
    {
        mesh = Traadsel.GetComponent<TextMesh>();
        mesh.text = raadsels[0];
    }

    // Update is called once per frame
    void Update()
    {
     
    }
}
