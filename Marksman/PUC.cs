using System;
using System.Collections.Generic;
using System.Linq;
using LeagueSharp;
using LeagueSharp.Common;

namespace Marksman
{
    class PUC
    {
        public static Obj_AI_Hero Player = ObjectManager.Player;
        public static Champion Champion;
        public static IEnumerable<Obj_AI_Hero> AllHeros = ObjectManager.Get<Obj_AI_Hero>();
        public static IEnumerable<Obj_AI_Hero> AllHerosFriend = ObjectManager.Get<Obj_AI_Hero>().Where(hero => hero.IsAlly);
        public static IEnumerable<Obj_AI_Hero> AllHerosEnemy = ObjectManager.Get<Obj_AI_Hero>().Where(hero => hero.IsEnemy);

        //public Champion Champion;
        //public Orbwalker Orbwalker;

        public static Menu Menu;

        public PUC()
        {

            Game.PrintChat("======  Primes Ultimate Carry Loaded! ======");
            Game.PrintChat("Beta version v 0.15");
            Game.PrintChat("This is a Beta version, not all is active,");
            Game.PrintChat("=================================");

            Player = ObjectManager.Player;
            Menu = new Menu("Primes Ultimate Carry", Player.ChampionName + "UltimateCarry", true);

           var autolevelMenu = new Menu("Primes AutoLevel", "Primes_AutoLevel");
            AutoLevel.AddtoMenu(autolevelMenu);
            var loadbaseult = false;
            switch (Player.ChampionName)
            {
                case "Ashe":
                    loadbaseult = true;
                    break;
                case "Draven":
                    loadbaseult = true;
                    break;
                case "Ezreal":
                    loadbaseult = true;
                    break;
                case "jinx":
                    loadbaseult = true;
                    break;
            }
            if (loadbaseult)
            {
                var baseUltMenu = new Menu("Primes BaseUlt", "Primes_BaseUlt");
                BaseUlt.AddtoMenu(baseUltMenu);
            }

            //if(Utility.Map.GetMap()._MapType == Utility.Map.MapType.SummonersRift ||
            //	Utility.Map.GetMap()._MapType == Utility.Map.MapType.TwistedTreeline)
            //{
            //	var tarzanMenu = new Menu("Primes Tarzan", "Primes_Tarzan");
            //	Jungle.AddtoMenu(tarzanMenu);
            //}

            LoadChampionPlugin();

            Menu.AddToMainMenu();

            
        }

        private void LoadChampionPlugin()
        {

            try
            {
                // ReSharper disable once AssignNullToNotNullAttribute
                var handle = System.Activator.CreateInstance(null, "Primes_Ultimate_Carry.Champion_" + ObjectManager.Player.ChampionName);
                Champion = (Champion)handle.Unwrap();
            }
            // ReSharper disable once EmptyGeneralCatchClause
            catch (Exception)
            {
            }

        }

        
    }
}
