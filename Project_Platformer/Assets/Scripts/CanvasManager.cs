
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CanvasManager : MonoBehaviour
{
    private GameObject currentCanvas;                                    // текущий карта
    private int numberCanvas;                                            // номер карты
    private byte counter;                                                // счетчик правильных ответов
    InputField InputField;                                               // поле ввода
    [SerializeField] private GameObject resultCanvas;                    // окно результата
    [SerializeField] private Text counterText;                           // результат
    [SerializeField]private GameObject[] canvas;                         // массив карт с вопросами


    
    void Start()
    {
        MoveCanvas();                              // перемес карт
        numberCanvas = 0;                          
        canvas[numberCanvas].SetActive(true);       // вкл первую карту
        currentCanvas = canvas[numberCanvas];       // текущая карта
        counter = 0;
    }    
    /// <summary>
    /// проверка ответа 
    /// </summary>
    /// <param name="value">ответ</param>
    public void PushButton(bool value)
    {
        if (value)            // если ответ верный
        {
            counter++;        // увеличиваем  счетчик правильных ответов
        }
        ChangeCanvas();       // смена карты
    }

    /// <summary>
    /// смена карты 
    /// </summary>
    public void ChangeCanvas()
    {
        if (numberCanvas == 9)                        // если последняя карта
        {
            counterText.text = counter.ToString();    // выводим 
            currentCanvas.SetActive(false);           // результат
            resultCanvas.SetActive(true);               
        } 
        else if (currentCanvas != null )              // проверка ну 0
        {
            currentCanvas.SetActive(false);             // стайт
            numberCanvas++;                             
            canvas[numberCanvas].SetActive(true);       
            currentCanvas = canvas[numberCanvas];      // машина
        }
    }

    /// <summary>
    /// проверка введенного ответа
    /// </summary>
    /// <param name="value">ответ</param>
    public void CheckAnswear(int value)
    {
        InputField = currentCanvas.GetComponentInChildren<InputField>();  // находим дочерний обьект inputfield на canvas

        if (value == int.Parse(InputField.text))                         // если ответ верный
        {
            counter++;                                                    // увеличиваем  счетчик правильных ответов
        }
        ChangeCanvas();                                                    // смена карты
    }

    /// <summary>
    /// перемешивание карт
    /// </summary>
    public void MoveCanvas()
    {
       GameObject tempValue;                                        //  временная переменная для карты
       int tempIndex;                                               //  временная переменная для элемента массива
        for (int index = 0 ; index < canvas.Length-1 ; index++)     //  перебераем массив
        {
            tempIndex = Random.Range(0, canvas.Length);             // случайным 
            tempValue =  canvas[index];                            // образом
            canvas[index] = canvas[tempIndex];                     // переставляем   
            canvas[tempIndex] = tempValue;                         // значения
        }
    }

    /// <summary>
    /// перезагрузка сцены
    /// </summary>
    public void Reset()
    {
        SceneManager.LoadScene(0);
    }

}
