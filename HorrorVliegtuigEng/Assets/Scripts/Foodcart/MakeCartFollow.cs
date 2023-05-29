using UnityEngine;

public class MakeCartFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 offset;
    [SerializeField] private bool pushCart;
    [SerializeField] private bool readyToPush;

    private void Awake()
    {
        pushCart = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            readyToPush = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            readyToPush = false;
        }
    }

    private void Update()
    {
        if (readyToPush && Input.GetKeyDown(KeyCode.E))
        {
            pushCart = true;
        }
        if (pushCart && Input.GetKeyDown(KeyCode.F))
        {
            pushCart = false;
        }

        if (pushCart)
        {
            transform.position = player.position + offset;
        }
    }

    public bool getPushCart()
    {
        return pushCart;
    }
}
