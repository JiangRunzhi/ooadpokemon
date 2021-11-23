public class Pokemon
{
    public int type;
    public int hp;
    public int hpLimit;
    public int attack;
    public int defense;
    public int speed;

    public Pokemon(int type,int hpLimit,int attack,int defense,int speed)
    {
        this.type = type;
        this.hp = hpLimit;
        this.hpLimit = hpLimit;
        this.attack = attack;
        this.defense = defense;
        this.speed = speed;
    }
}