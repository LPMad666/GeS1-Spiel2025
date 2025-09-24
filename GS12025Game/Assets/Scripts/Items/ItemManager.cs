using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager instance { get; private set; }
    public GameObject player;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("Multiple instances of ItemManager detected. Destroying duplicate");
        }
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
