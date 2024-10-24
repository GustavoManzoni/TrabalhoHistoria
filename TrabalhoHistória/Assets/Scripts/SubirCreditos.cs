using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SubirCreditos : MonoBehaviour
{
  
    RectTransform _creditsRectTransform;
    [SerializeField] float speed;
    [SerializeField] float maxPosY;
    [SerializeField] GameObject _leaveButton_Btn;
    // Start is called before the first frame update
    void Start()
    {
        _creditsRectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (_creditsRectTransform.anchoredPosition.y <= maxPosY)
        _creditsRectTransform.anchoredPosition +=  Vector2.up * speed * Time.deltaTime * 10;
        else
        {
            _leaveButton_Btn.SetActive(true);


        }
        
    }
    public void LeaveBtn()
    {

        SceneManager.LoadScene("MainMenu");

    }
}
