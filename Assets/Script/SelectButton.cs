using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectButton : MonoBehaviour
{
    public int id;
    public GridSystem gridSystem;

    public void ButtonSelect()
    {
        gridSystem.selectButtonInt.Add(id);//id yi liste atıyoruz
        gridSystem.LevelControl();//Methodu çalıştırıyoruz 
    }
}
