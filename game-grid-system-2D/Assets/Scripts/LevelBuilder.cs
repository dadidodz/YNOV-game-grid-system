using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

[System.Serializable]
public class LevelElement{
    public string m_Character;
    public GameObject m_Prefab;
}

public class LevelBuilder : MonoBehaviour
{
    public int m_CurrentLevel;
    public List<LevelElement> m_LevelElements;
    private Level m_Level;

    GameObject GetPrefab(char c){
        LevelElement levelElement = m_LevelElements.Find(le => le.m_Character == c.ToString());
        if (levelElement != null)
            return levelElement.m_Prefab;
        else
            return null;
    }

    public void NextLevel(){
        m_CurrentLevel++;
        if (m_CurrentLevel >= GetComponent<Levels>().m_Levels.Count){
            m_CurrentLevel = 0;
        }
    }

    public void Build(){
        m_Level = GetComponent<Levels>().m_Levels[m_CurrentLevel];
        int startx = -m_Level.Width / 2;
        int x = startx;
        int y = -m_Level.Height /2;
        foreach (var row in m_Level.m_Rows){
            foreach (var ch in row)
            {
                Debug.Log(ch);
                GameObject prefab = GetPrefab(ch);
                if (prefab){
                    Debug.Log(prefab.name);
                    Instantiate(prefab, new UnityEngine.Vector3(x, y, 0), UnityEngine.Quaternion.identity);
                }
                x++;
            }
            y++;
            x = startx;
        }
    }
}
