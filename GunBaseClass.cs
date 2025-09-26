using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;

namespace OOP_Lab1
{
    internal class GunBase_Class
    {
        public string internal_name, manufacturing_date, manufacturer;
        public string display_name;
        public int max_ammo, loaded_ammo, ammo_reserve;

        #region functions;
        public string General_info()
        {
            return ("Name: " + display_name + "\n" + "Manufacturer: " + manufacturer);
        }

        public string check_ammo()
        {
            return (loaded_ammo + " rounds out of " + max_ammo);
        }
        public string check_reserve()
        {
            return ($"{ammo_reserve} bullets left. ");
        }
        public string reload()
        {
            string message;
            if (loaded_ammo == max_ammo)
            {
                return ("Already full!");
            }
            if (!(max_ammo - loaded_ammo >= ammo_reserve))
            {
                ammo_reserve -= max_ammo - loaded_ammo;
                loaded_ammo = max_ammo;
                return ($"Reloaded to full! {ammo_reserve} bullets left.");
            }
            if (max_ammo - loaded_ammo >= ammo_reserve && ammo_reserve != 0)
            {
                loaded_ammo += ammo_reserve;
                message = ($"There were not enough bullets for full reload, {ammo_reserve} loaded; {loaded_ammo} rounds out of {max_ammo}.");
                ammo_reserve = 0;
                return message;
            }
            if (ammo_reserve <= 0)
            {
                return ("No munition left!");
            }
            return (" ");
        }

        public string Fire()
        {
            if (loaded_ammo>=1)
            {
                loaded_ammo -= 1;
                return "*pew*";
            }
            else
            {
                return "The gun clicks. It seems that it has ran out of bullets.";
            }
        }
        public string FireTenRounds()
        {
            if (loaded_ammo >= 10)
            {
                loaded_ammo -= 10;
                return "*pew-pew*";
            }
            else if (loaded_ammo >=1 && loaded_ammo <10)
            {
                loaded_ammo = 0;
                return "The burst stops earlier than expected. The gun is empty!";
            }
            else
            {
                return "The gun clicks. It seems that it has ran out of bullets.";
            }
        }
        public override string ToString()
        {
            return ($"Name: {display_name}, Magazine size: {max_ammo}, Reserves: {ammo_reserve}" +
                $", Manufacturer: {manufacturer}, Date of production: {manufacturing_date}");
        }
        #endregion
    }
}