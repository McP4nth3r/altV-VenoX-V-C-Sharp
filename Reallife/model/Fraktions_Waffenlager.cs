using System;

namespace VenoXV.Reallife.model
{
    public class Fraktions_Waffenlager
    {
        


        public int weapon_knuckle { get; set; }
        public int weapon_baseball { get; set; }
        public int weapon_nightstick { get; set; }
        public int weapon_tazer { get; set; }
        public int weapon_pistol { get; set; }
        public int weapon_pistol50 { get; set; }
        public int weapon_revolver { get; set; }
        public int weapon_pumpshotgun { get; set; }
        public int weapon_mp5 { get; set; }
        public int weapon_combatpdw { get; set; }
        public int weapon_assaultrifle { get; set; }
        public int weapon_carbinerifle { get; set; }
        public int weapon_advancedrifle { get; set; }
        public int weapon_gusenberg { get; set; }
        public int weapon_rifle { get; set; }
        public int weapon_sniperrifle { get; set; }
        public int weapon_rpg { get; set; }
        public int weapon_bzgas { get; set; }
        public int weapon_molotov { get; set; }
        public int weapon_smokegrenade { get; set; }



        public int weapon_pistol_ammo { get; set; }
        public int weapon_pistol50_ammo { get; set; }
        public int weapon_revolver_ammo { get; set; }
        public int weapon_pumpshotgun_ammo { get; set; }
        public int weapon_mp5_ammo { get; set; }
        public int weapon_combatpdw_ammo { get; set; }
        public int weapon_assaultrifle_ammo { get; set; }
        public int weapon_carbinerifle_ammo { get; set; }
        public int weapon_advancedrifle_ammo { get; set; }
        public int weapon_gusenberg_ammo { get; set; }
        public int weapon_rifle_ammo { get; set; }
        public int weapon_sniperrifle_ammo { get; set; }
        public int weapon_rpg_ammo { get; set; }





        public Fraktions_Waffenlager() { }
        public Fraktions_Waffenlager(int weapon_knuckle, int weapon_nightstick, int weapon_tazer, int weapon_pistol, int weapon_pistol50, 
            int weapon_revolver, int weapon_pumpshotgun, int weapon_combatpdw, int weapon_assaultrifle, int weapon_advancedrifle, int weapon_carbinerifle,
            int weapon_gusenberg, int weapon_sniperrifle, int weapon_rpg, int weapon_bzgas, int weapon_molotov, int weapon_smokegrenade,
            int weapon_pistol_ammo,int weapon_pistol50_ammo, int weapon_revolver_ammo, int weapon_pumpshotgun_ammo, int weapon_combatpdw_ammo, int weapon_assaultrifle_ammo,
            int weapon_carbinerifle_ammo, int weapon_advancedrifle_ammo, int weapon_gusenberg_ammo, int weapon_sniperrifle_ammo, int weapon_rpg_ammo)
        {
            this.weapon_knuckle = weapon_knuckle;
            this.weapon_nightstick = weapon_nightstick;
            this.weapon_tazer = weapon_tazer;
            this.weapon_pistol = weapon_pistol;
            this.weapon_pistol50 = weapon_pistol50;
            this.weapon_revolver = weapon_revolver;
            this.weapon_pumpshotgun = weapon_pumpshotgun;
            this.weapon_combatpdw = weapon_combatpdw;
            this.weapon_assaultrifle = weapon_assaultrifle;
            this.weapon_carbinerifle = weapon_carbinerifle;
            this.weapon_advancedrifle = weapon_advancedrifle;
            this.weapon_gusenberg = weapon_gusenberg;
            this.weapon_sniperrifle = weapon_sniperrifle;
            this.weapon_rpg = weapon_rpg;
            this.weapon_bzgas = weapon_bzgas;
            this.weapon_molotov = weapon_molotov;
            this.weapon_smokegrenade = weapon_smokegrenade;


            this.weapon_pistol_ammo = weapon_pistol_ammo;
            this.weapon_pistol50_ammo = weapon_pistol50_ammo;
            this.weapon_revolver_ammo = weapon_revolver_ammo;
            this.weapon_pumpshotgun_ammo = weapon_pumpshotgun_ammo;
            this.weapon_combatpdw_ammo = weapon_combatpdw_ammo;
            this.weapon_assaultrifle_ammo = weapon_assaultrifle_ammo;
            this.weapon_carbinerifle_ammo = weapon_carbinerifle_ammo;
            this.weapon_advancedrifle_ammo = weapon_advancedrifle_ammo;
            this.weapon_gusenberg_ammo = weapon_gusenberg_ammo;
            this.weapon_sniperrifle_ammo = weapon_sniperrifle_ammo;
            this.weapon_rpg_ammo = weapon_rpg_ammo;
        }
        
    }
}
