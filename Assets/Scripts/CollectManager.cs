using UnityEngine;

public class CollectManager : MonoBehaviour
{
    public static CollectManager Instance;

    private int itemsCollected = 0;
    public int requiredItemsToCollect = 3;
    public GameObject gateObject;
    public Vector3 moveUpAmount = new Vector3(0, 5, 0);

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ItemCollected()
    {
        itemsCollected++;
        Debug.Log("Items collected: " + itemsCollected);

        if (itemsCollected >= requiredItemsToCollect)
        {
            MoveGate();
        }
    }

    private void MoveGate()
    {
        if (gateObject != null)
        {
            gateObject.transform.position += moveUpAmount;
            Debug.Log("Gate moved up!");
        }
    }
}