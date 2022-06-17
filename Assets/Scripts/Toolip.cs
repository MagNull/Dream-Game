using System.Collections;
using System.Collections.Generic;
using Source.Slime_Components;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Toolip : MonoBehaviour
{
    public GameObject _panelDialog;
    public string Text;
    public Text dialog;
    public GameObject canvas;
    private Transform slimeTrans;
    private bool _isTurnOn;
    private bool _isNear;

    void Awake()
    {
        _isNear = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Slime slime))
            slimeTrans = slime.GetComponent<Transform>();
            _isNear = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Slime slime))
            slimeTrans = slime.GetComponent<Transform>();
            _isNear = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Slime slime))
        {
            _isNear = false;
            _panelDialog.gameObject.SetActive(false);
        }

        }

    private void Update()
    {
        if (_isNear)
        {
            print("true");
            _panelDialog.gameObject.SetActive(true);
            dialog.text = Text;
            canvas.transform.position = new Vector3 (slimeTrans.position.x, slimeTrans.position.y + 1,0.0f);

        }

    }
}
