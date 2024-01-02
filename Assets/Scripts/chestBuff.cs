using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;
using Random = UnityEngine.Random;

public class chestBuff : MonoBehaviour
{
    public Dictionary<BuffType, Buff> buffDicitionary;
    

    // 三个button
    public Button[] button=new Button[3];
    void Start()
    {
        buffDicitionary = new Dictionary<BuffType, Buff>()
        {
            { BuffType.killaura, new Killaura() },
            { BuffType.fireArrow ,new FireArrow()},
            { BuffType.multishot ,new Multishot()},
            { BuffType.penetrate ,new Penetrate()},
            { BuffType.power ,new Power()},
            { BuffType.helmet ,new Helmet()},
            { BuffType.cuirass ,new Cuirass()},
            { BuffType.trousers ,new Trousers()},
            { BuffType.shoes ,new Shoes()}
        };
        
        
        // 循环三次，给每一个button都随机一个buff
        for (int i = 0; i < 3; i++)
        {
            // 从枚举类中随机选择一个buff
            BuffType randomBuffType = randomBuff();
            buffButton bb = button[i].transform.GetComponent<buffButton>();
            
            // 尝试获取字典中的对应buff的类，如果获取到就执行
            if (buffDicitionary.TryGetValue(randomBuffType, out Buff buff))
            {
                // 将获取到的随机buff类保存到对应的buffButton类中
                bb.buff = buff;
                bb.setColor(buff.color);
                bb.setIcon(buff.icon);
                bb.setName(buff.name);
            }
            
        }
        
    }
    
    private BuffType randomBuff()
    {
        Array buffTypes = Enum.GetValues(typeof(BuffType));
        return (BuffType)buffTypes.GetValue(Random.Range(0, buffTypes.Length));
    }
    
}
