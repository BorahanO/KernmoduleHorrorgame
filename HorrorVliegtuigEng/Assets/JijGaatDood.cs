using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JijGaatDood : MonoBehaviour
{

    public bool JijMagDood = false;
    public bool JijZietMijNiet;

    public bool dubbleCheck;
    // Start is called before the first frame update
    void Start()
    {
       // GetComponent<JijGaatDood>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (dubbleCheck == true)
        {
            if(JijZietMijNiet == true)
            {
                if (JijMagDood == true && JijZietMijNiet == true)
                {
                    Debug.Log("DOOOOD");
                    SceneManager.LoadScene("JumpScare");
                }
            }
  
        }
    }

    private void OnTriggerEnter(Collider other)
    {
            if (other.gameObject.tag == "Player")
            {
            Debug.Log(other);
            JijMagDood = true;
            }

    }


}
