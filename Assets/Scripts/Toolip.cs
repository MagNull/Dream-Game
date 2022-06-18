using System.Collections;
using System.Collections.Generic;
using Source.Slime_Components;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Toolip : MonoBehaviour
{
    public GameObject _panelDialog;
    public string Text;
    public Text dialog;
    public GameObject canvas;
    public Transform slimeTrans;
    private bool _isTurnOn;
    private bool _isNear;

    void Awake()
    {
        _isNear = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Slime slime))
            _isNear = true;

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Slime slime))
            _isNear = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Slime slime))
        {
            _isNear = false;
            _panelDialog.transform.DOScale(0f, 0.5f);
            //_panelDialog.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (_isNear)
        {
            //_panelDialog.gameObject.SetActive(true);
            _panelDialog.transform.DOScale(1f, 0.5f);
            dialog.text = Text;
        }
        canvas.transform.position = new Vector3(slimeTrans.position.x, slimeTrans.position.y + 1, 0.0f);
    }
}