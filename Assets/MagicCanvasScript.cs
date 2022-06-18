using UnityEngine;

public class MagicCanvasScript : MonoBehaviour
{
    private GameObject _magicCanvas;
    private void Awake()
    {
        //_magicCanvas = transform.GetComponent<Ma>();
        //gameObject.SetActive(false);
    }

    public void ChangeVisible()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
