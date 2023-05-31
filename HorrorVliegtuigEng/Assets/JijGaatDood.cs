using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JijGaatDood : MonoBehaviour
{

    public bool JijMagDood;
    // Start is called before the first frame update
    void Start()
    {
       // GetComponent<JijGaatDood>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (JijMagDood == true)
        {
            if (other.gameObject.tag == "Player")
            {
                Debug.Log("DOOOOD other");
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }


}
