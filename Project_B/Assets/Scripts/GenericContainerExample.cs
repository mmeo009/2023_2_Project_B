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
        intContainer = new GenericContainer<int>(10);                       //int�� �����̳� ���� 10ĭ
        stringContainer = new GenericContainer<string>(15);                 //string�� �����̳� ���� 15ĭ
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
    {//������ �����̳ʸ� Debug.Log���� �� �� �ְ� ���� �Լ�
        T[] items = container.GetItems();
        string temp = "";
        for(int i = 0; i < items.Length; i++)                       //�����̳ʸ� ��ȯ�ؼ� �迭���� ���ڿ��� ��ȯ
        {
            if (items[i] != null)
            {
                temp += items[i].ToString() + " - ";                //���ʸ� ���°��� String ���� ��ȯ
            }
            else
            {
                temp += "Empty - ";                                 //��������� Empty ���ڿ�
            }
        }
        Debug.Log(temp);
    }
}
