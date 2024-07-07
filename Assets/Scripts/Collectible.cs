using System.Collections;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public float holdTime = 1.0f;
    private bool isHolding = false;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                if (!isHolding)
                {
                    StartCoroutine(HoldToCollect());
                }
            }
            else
            {
                isHolding = false;
                StopAllCoroutines();
            }
        }
    }

    private IEnumerator HoldToCollect()
    {
        isHolding = true;
        yield return new WaitForSeconds(holdTime);
        CollectItem();
    }

    private void CollectItem()
    {
        gameObject.SetActive(false);
        CollectManager.Instance.ItemCollected();
        Debug.Log("Item Collected!");
    }
}