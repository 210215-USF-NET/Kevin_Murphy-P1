using System;
/// <summary>
/// 
/// </summary>

namespace ToHModels
{
    public class Hero
    {
        private string heroName;
        private int hp;
       
        public string HeroName {
            
            get{return heroName;}
            set{
                if(value.Equals(null)){}//Throw exception
                heroName = value;
            } 
        
        }
        public int HP { get; set; }
        public Element ElementType { get; set; }

        public SuperPower SuperPower { get; set; }
    }
}
