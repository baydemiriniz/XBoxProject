using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GridSystem : MonoBehaviour
{
    public Text inputText;
    public SelectButton button;
    public GridLayoutGroup gridLayout;
    public List<int> selectButtonInt =new List<int>();
    private int spawnSize;
    public void SetGrid()
    {
        selectButtonInt.Clear();
        for (int i = 0; i < gridLayout.transform.childCount; i++)
        {
            Destroy(gridLayout.transform.GetChild(i).gameObject);
        }
        spawnSize = Convert.ToInt32(inputText.text);
        float cellSizeWidth = gridLayout.gameObject.GetComponent<RectTransform>().rect.width / spawnSize;
        float cellSizeHeight = gridLayout.gameObject.GetComponent<RectTransform>().rect.height / spawnSize;
        gridLayout.cellSize=new Vector2(cellSizeWidth,cellSizeHeight);
        for (int i = 0; i <(spawnSize*spawnSize) ; i++)
        {
            SelectButton id= Instantiate(button, gridLayout.transform);
            id.id = i + 1;
            id.gridSystem = this;
        }
    }

    public void LevelControl()
    {
        if (selectButtonInt.Count >= 3)
        {
            int id = selectButtonInt.Count - 1;
            for (int i = 0; i < id; i++)
            {
                Debug.Log(selectButtonInt[id]+ "ve"+selectButtonInt[i]);
                if ((selectButtonInt[id] - 1 == selectButtonInt[i] &&(selectButtonInt[i] % spawnSize!=0)) || 
                    ((selectButtonInt[id] + 1 == selectButtonInt[i] &&(selectButtonInt[id] % spawnSize!=0))||  
                     selectButtonInt[id] - spawnSize == selectButtonInt[i] ||
                     selectButtonInt[id] + spawnSize == selectButtonInt[i]))
                {
                    for (int s = 0; s < id; s++)
                    {
                        if (selectButtonInt[i] - spawnSize == selectButtonInt[s] ||
                            selectButtonInt[i] + spawnSize == selectButtonInt[s] ||
                            ((selectButtonInt[i] - 1 == selectButtonInt[s]) &&(selectButtonInt[s]%spawnSize != 0 )) || 
                            (selectButtonInt[i] + 1 == selectButtonInt[s]) &&(selectButtonInt[i]%spawnSize != 0))
                        {
                            SetGrid();
                            return;
                        }
                        if (s != i) 
                        {    
                            if (selectButtonInt[id] - spawnSize == selectButtonInt[s] ||
                                selectButtonInt[id] + spawnSize == selectButtonInt[s] ||
                                ((selectButtonInt[id] - 1 == selectButtonInt[s]) &&(selectButtonInt[s]%spawnSize != 0 )) || 
                                (selectButtonInt[id] + 1 == selectButtonInt[s]) &&(selectButtonInt[id]%spawnSize != 0))
                            {
                                Debug.Log(selectButtonInt[id]+ "ve"+selectButtonInt[s]);
                                SetGrid();
                                return;
                            }
                        }
                    }
                }
            }
        }
    }
}
