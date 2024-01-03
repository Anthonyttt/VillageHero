
using UnityEngine;

public enum BuffType
{
    fireArrow,
    killaura,
    multishot,
    penetrate,
    power,
    helmet,
    cuirass,
    trousers,
    shoes
}
public abstract class Buff
{
    public Sprite icon;
    public string name;
    public Sprite color;
    public abstract void ApplyBuffToPlayer();
}

public class Killaura : Buff
{
    public Killaura()
    {
        icon = Resources.Load<Sprite>("Sprite/木剑");
        color = Resources.Load<Sprite>("Sprite/redbutton");
        name = "杀戮光环";
    }
    public override void ApplyBuffToPlayer()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>().createSword();
        
    }
}

public class FireArrow : Buff
{
    public FireArrow()
    {
        icon = Resources.Load<Sprite>("Sprite/附魔书");
        color = Resources.Load<Sprite>("Sprite/bluebutton");
        name = "火矢";
    }
    public override void ApplyBuffToPlayer()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>().fire = true;
    }
}

public class Multishot : Buff
{
    public Multishot()
    {
        icon = Resources.Load<Sprite>("Sprite/附魔书");
        color = Resources.Load<Sprite>("Sprite/bluebutton");
        name = "多重射击";
    }
    public override void ApplyBuffToPlayer()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>().arrowCount += 2;
        GameObject t = GameObject.FindGameObjectWithTag("arrow");
        if (t != null)
        {
            t.GetComponent<arrowControl>().harm *= 0.8f;
        }

        GameObject tt = GameObject.FindGameObjectWithTag("fireArrow");
        if (tt != null)
        {
            tt.GetComponent<arrowControl>().harm *= 0.8f;
        }
    }
}

public class Penetrate : Buff
{
    public Penetrate()
    {
        icon = Resources.Load<Sprite>("Sprite/附魔书");
        color = Resources.Load<Sprite>("Sprite/bluebutton");
        name = "穿透";
    }
    public override void ApplyBuffToPlayer()
    {
        GameObject t = GameObject.FindGameObjectWithTag("arrow");
        if (t != null)
        {
            t.GetComponent<arrowControl>().penetrate = true;
        }

        GameObject tt = GameObject.FindGameObjectWithTag("fireArrow");
        if (tt != null)
        {
            tt.GetComponent<arrowControl>().penetrate = true;
        }
    }
}

public class Power : Buff
{
    public Power()
    {
        icon = Resources.Load<Sprite>("Sprite/附魔书");
        color = Resources.Load<Sprite>("Sprite/bluebutton");
        name = "力量";
    }
    public override void ApplyBuffToPlayer()
    {
        GameObject t = GameObject.FindGameObjectWithTag("arrow");
        if (t != null)
        {
            t.GetComponent<arrowControl>().harm += 1f;
        }

        GameObject tt = GameObject.FindGameObjectWithTag("fireArrow");
        if (tt != null)
        {
            tt.GetComponent<arrowControl>().harm += 1f;
        }
    }
}

public class Helmet : Buff
{
    public Helmet()
    {
        icon = Resources.Load<Sprite>("Sprite/头盔");
        color = Resources.Load<Sprite>("Sprite/greenbutton");
        name = "头盔";
    }
    public override void ApplyBuffToPlayer()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>().equipLevel++;
    }
}
public class Cuirass : Buff
{
    public Cuirass()
    {
        icon = Resources.Load<Sprite>("Sprite/胸甲");
        color = Resources.Load<Sprite>("Sprite/greenbutton");
        name = "胸甲";
    }
    public override void ApplyBuffToPlayer()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>().equipLevel++;
    }
}

public class Trousers : Buff
{
    public Trousers()
    {
        icon = Resources.Load<Sprite>("Sprite/裤子");
        color = Resources.Load<Sprite>("Sprite/greenbutton");
        name = "裤子";
    }
    public override void ApplyBuffToPlayer()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>().equipLevel++;
    }
}

public class Shoes : Buff
{
    public Shoes()
    {
        icon = Resources.Load<Sprite>("Sprite/靴子");
        color = Resources.Load<Sprite>("Sprite/greenbutton");
        name = "靴子";
    }
    public override void ApplyBuffToPlayer()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>().equipLevel++;
    }
}