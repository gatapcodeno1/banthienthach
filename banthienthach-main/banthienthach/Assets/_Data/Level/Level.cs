
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : DatMonoBehaviour
{
    [Header("Level")]
    public int levelCurrent = 0;
    public int levelMax = 99;

    public virtual void LevelUp()
    {
        this.levelCurrent += 1;
        this.LimitLevel();


    }

    public virtual void SetLevel(int level)
    {
        this.levelCurrent = level;
        this.LimitLevel();
    }

    protected virtual void LimitLevel()
    {
        if(this.levelCurrent > this.levelMax) this.levelCurrent = this.levelMax;
        if(this.levelCurrent < 1) this.levelCurrent = 1;
    }
}