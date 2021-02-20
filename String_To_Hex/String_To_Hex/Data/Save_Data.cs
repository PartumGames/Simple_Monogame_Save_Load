using System.Text;

namespace String_To_Hex.Data
{
    
    /// <summary>
    /// Class we want to save
    /// </summary>
    public class Save_Data
    {
        public string usersName;
        public float health;
        public float mana;
        public float hunger;
        public float thirst;
        public float stamina;
        public int weaponId;

        public Save_Data(string usersName, float health, float mana, float hunger, float thirst, float stamina, int weaponId)
        {
            this.usersName = usersName;
            this.health = health;
            this.mana = mana;
            this.hunger = hunger;
            this.thirst = thirst;
            this.stamina = stamina;
            this.weaponId = weaponId;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("user name: " + usersName);
            sb.Append(" | health: " + health.ToString());
            sb.Append(" | mana: " + mana.ToString());
            sb.Append(" | hunger: " + hunger.ToString());
            sb.Append(" | thirst: " + thirst.ToString());
            sb.Append(" | stamina: " + stamina.ToString());
            sb.Append(" | weaponID: " + weaponId.ToString());

            return sb.ToString();
        }
    }
}
