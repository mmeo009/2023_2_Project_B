using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GenericContainerExample : MonoBehaviour
{
    private GenericContainer<int> intContainer;
    private GenericContainer<string> stringContainer;

    void Start()
    {
        intContainer = new GenericContainer<int>(10);                       //int형 컨테이너 선언 10칸
        stringContainer = new GenericContainer<string>(15);                 //string형 컨테이너 선언 15칸
    }
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Alpha1))
        {
            intContainer.Add(Random.Range(0, 100));
            DisplayContainerItems(intContainer);
        }
        if(Input.GetKeyUp(KeyCode.Alpha2))
        {
            string randomString = "item " + Random.Range(0, 100);
            stringContainer.Add(randomString);
            DisplayContainerItems(stringContainer);
        }
    }
    private void DisplayContainerItems<T>(GenericContainer<T> container)
    {//생성한 컨테이너를 Debug.Log에서 볼 수 있게 만든 함수
        T[] items = container.GetItems();
        string temp = "";
        for(int i = 0; i < items.Length; i++)                       //컨테이너를 순환해서 배열값을 문자열로 변환
        {
            if (items[i] != null)
            {
                temp += items[i].ToString() + " - ";
            }
            else
            {
                temp += "Empty - ";
            }
        }
        Debug.Log(temp);
    }
}
