using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New PackLevel", menuName = "Game/LevelSudoku")]
public class DataLevel : ScriptableObject
{
    public List<GridSudoku> m_GridsLevel = new List<GridSudoku>();
}
