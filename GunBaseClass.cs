using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.WebSockets;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;

namespace OOP_Lab1
{
    public class GunBase_Class
    {
        private string _internal_name, _manufacturing_date, _manufacturer;
        private string _display_name, _user_who_created;
        private int _max_ammo, _loaded_ammo, _ammo_reserve;
        private int _damage;

        private static int _item_counter;
        public static int total_amount_of_shots = 0;

        #region fields

        public static int Item_counter
        {
            get { return _item_counter; }
            set
            {
                _item_counter = value;
            }
        }
        public string Display_name
        {
            get { return _display_name; }
            set
            {
                if (value.Length < 3)
                    throw new Exception("The name is too short.");
                if (value.Length > 20)
                    throw new Exception("The name is too long.");
                else _display_name = value;
            }
        }
        public string Internal_name
        {
            get { return _internal_name; }
            set 
            {
                if (value.Length < 3)
                    throw new Exception("The name is too short.");
                if (value.Length > 20)
                    throw new Exception("The name is too long.");
                else _internal_name = value; 
            }
        }
        public string Manufacturing_date
        {
            get { return _manufacturing_date; }
            set { _manufacturing_date = value; }
        }
        public string Manufacturer
        {
            get { return _manufacturer; }
            set
            {
                if (value.Length < 3)
                    throw new Exception("Name of manufacturer is too short, must be longer than 3");
                if (value.Length > 20)
                    throw new Exception("Name of manufacturer is too long, Must be shorter than 20");
                else _manufacturer = value; 
            }
        }
        public string User_who_created
        {
            get { return _user_who_created; }
            private set { _user_who_created = value; }
        }
        public int Max_ammo
        {
            get { return _max_ammo; }
            set 
            {
                if (value <= 0)
                    throw new Exception("Magazine size must be greater than 0.");
                if (value >= 100)
                    throw new Exception($"Magazine size must be lesser than 100.");
                else _max_ammo = value; 
            }
        }
        public int Loaded_ammo
        {
            get { return _loaded_ammo; }
            set
            {
                _loaded_ammo = value;
            }
        }
        public int Ammo_reserve
        {
            get { return _ammo_reserve; }
            set
            {
                if (value < 0)
                    throw new Exception("Reserve of ammunition must be greater or equal to 0.");
                if (value >= (_max_ammo * 10))
                    throw new Exception($"Reserve of ammunition must be lesser than {(_max_ammo * 10)}.");
                else _ammo_reserve = value; 
            }
        }
        public int Damage 
        { 
            get { return  _damage; } 
            set
            {
                if (value < 0)
                    throw new Exception("Damage cannot be smaller than 1. ");
                if (value > 120)
                    throw new Exception("Damage cannot be greater than 120");
                else _damage = value;
            }
        }
        #endregion

        #region functions;
        public string General_info()
        {
            return ("Name: " + _display_name  + ", Manufacturer: " + _manufacturer);
        }
        public string check_ammo()
        {
            return (_loaded_ammo + " rounds out of " + _max_ammo);
        }
        public string check_reserve()
        {
            return ($"{_ammo_reserve} bullets left. ");
        }
        public string reload()
        {
            string message;
            if (_loaded_ammo == _max_ammo)
            {
                return ("Already full!");
            }
            if (!(_max_ammo - _loaded_ammo >= _ammo_reserve))
            {
                _ammo_reserve -= _max_ammo - _loaded_ammo;
                _loaded_ammo = _max_ammo;
                return ($"Reloaded to full! {_ammo_reserve} bullets left.");
            }
            if (_max_ammo - _loaded_ammo >= _ammo_reserve && _ammo_reserve != 0)
            {
                _loaded_ammo += _ammo_reserve;
                message = ($"There were not enough bullets for full reload, {_ammo_reserve} loaded; {_loaded_ammo} rounds out of {_max_ammo}.");
                _ammo_reserve = 0;
                return message;
            }
            if (_ammo_reserve <= 0)
            {
                return ("No munition left!");
            }
            return (" ");
        }
        private void Deal_damage(float Damage)
        {
            Random RNG = new Random();
            float RandomDamageModifier = RNG.Next(75, 126) / 100;
            Console.WriteLine($"Dealt {Damage * RandomDamageModifier} points of damage.");
        }
        public string Fire()
        {
            if (_loaded_ammo>=1)
            {
                _loaded_ammo -= 1;
                Deal_damage(Damage);
                total_amount_of_shots++;
                return "*pew*";
            }
            else
            {
                return "The gun clicks. It seems that it has ran out of bullets.";
            }
        }
        public string Fire(int Bullets_to_fire)
        {

            if (_loaded_ammo >= Bullets_to_fire)
            {
                _loaded_ammo -= Bullets_to_fire;
                for (int i = 0; i < Bullets_to_fire; i++)
                {
                    Deal_damage(Damage);
                    total_amount_of_shots++;
                }
                return $"Fired {Bullets_to_fire} rounds. ";
            }
            else if (_loaded_ammo >= 1 && _loaded_ammo < Bullets_to_fire)
            {
                for (int i = 0; i < _loaded_ammo; i++)
                {
                    Deal_damage(Damage);
                    total_amount_of_shots++;
                }
                _loaded_ammo = 0;
                return "The burst stops earlier than expected. The gun is empty!";
            }
            else
            {
                return "The gun clicks. It seems that it has ran out of bullets.";
            }
        }
        public string FireTenRounds()
        {
            if (_loaded_ammo >= 10)
            {
                _loaded_ammo -= 10;
                for (int i = 0; i<10;i++)
                {
                    Deal_damage(Damage);
                    total_amount_of_shots++;
                }
                return "*pew-pew*";
            }
            else if (_loaded_ammo >=1 && _loaded_ammo <10)
            {
                for (int i = 0; i < _loaded_ammo; i++)
                {
                    Deal_damage(Damage);
                    total_amount_of_shots++;
                }
                _loaded_ammo = 0;
                return "The burst stops earlier than expected. The gun is empty!";
            }
            else
            {
                return "The gun clicks. It seems that it has ran out of bullets.";
            }
        }
        public override string ToString()
        {
            return ($"{_display_name}, {_internal_name}, {_max_ammo}, {_ammo_reserve}, {_manufacturer}, {_manufacturing_date}, {_damage}");
        }
        public static GunBase_Class Parse(string input_string)
        {
            string[] input_string_array = input_string.Split(", ", StringSplitOptions.RemoveEmptyEntries);
            #region checks for TryParse
            string display_Name, internal_name, manufacturer_name, manufacturer_date;
            int mag_size = 15000, reserve_ammo, damage;
            bool Flag_wrong_amount_parameters = false;
            try
            {
                if (input_string_array.Length != 7)
                {
                    Flag_wrong_amount_parameters = true;
                    throw new Exception("Wrong amount of parameters for parse!");
                }
                //bool Flag_publicName = false;
                display_Name = input_string_array[0];
                if (display_Name.Length < 3)
                    throw new Exception("Public name is too short.");
                if (display_Name.Length > 20)
                    throw new Exception("Public name is too long.");
                //Flag_publicName = true;
                //bool Flag_privateName = false;
                internal_name = input_string_array[1];
                if (internal_name.Length < 3)
                    throw new Exception("Internal name is too short.");
                if (internal_name.Length > 20)
                    throw new Exception("Internal name is too long.");
                //Flag_privateName = true;
                //bool Flag_magSize = false;
                mag_size = int.Parse(input_string_array[2]);
                if (mag_size <= 0)
                    throw new Exception("Magazine size must be greater than 0.");
                if (mag_size >= 100)
                    throw new Exception($"Magazine size must be lesser than 100.");
                //Flag_magSize = true;
                //bool Flag_reserveAmmo = false;
                mag_size = int.Parse(input_string_array[3]);
                if (mag_size < 0)
                    throw new Exception("Reserve of ammunition must be greater or equal to 0.");
                if (mag_size >= (mag_size * 10))
                    throw new Exception($"Reserve of ammunition must be lesser than {(mag_size * 10)}.");
                //        Flag_reserveAmmo = true;
                // bool Flag_manufacturer = false;
                manufacturer_name = input_string_array[4];
                if (manufacturer_name.Length < 3)
                    throw new Exception("Name of manufacturer is too short, must be longer than 3");
                if (manufacturer_name.Length > 20)
                    throw new Exception("Name of manufacturer is too long, Must be shorter than 20");
                //        Flag_manufacturer = true;
                bool Flag_manufacturingDate = false;
                manufacturer_date = input_string_array[5];
                //bool Flag_damage = false;
                damage = int.Parse(input_string_array[6]);
                if (damage < 0)
                    throw new Exception("Damage cannot be smaller than 1. ");
                if (damage > 120)
                    throw new Exception("Damage cannot be greater than 120");
                //Flag_damage = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            #endregion
            string user = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                GunBase_Class Parsed_Item = new GunBase_Class(input_string_array[0], input_string_array[1], int.Parse(input_string_array[2]), int.Parse(input_string_array[3]), input_string_array[4], input_string_array[5], int.Parse(input_string_array[6]), user);
                return Parsed_Item;
        }
        public static bool TryParse(string input_string,  out GunBase_Class Parsed_item)
        {
            Parsed_item = null;
            try
            {
                Parsed_item = GunBase_Class.Parse(input_string);
                return true;
            }
            catch (Exception ex) 
            { 
                Console.WriteLine("Something went wrong!");
                return false;
            }
        }

        public static string Total_amount_shots_print()
        {
            return total_amount_of_shots.ToString();
        }
        #endregion

        #region constructors
        public GunBase_Class()
        {
            _user_who_created = "unknown";
            _loaded_ammo = _max_ammo;
        }
        public GunBase_Class(string user) : base()
        {
            _user_who_created = user;
        }
        
        public GunBase_Class(string display_name, string internal_name, int mag_size, int reserve_size, string manufacturer, string prod_date, int damage, string user)
        {
            Display_name = display_name;
            Internal_name = internal_name;
            Max_ammo = mag_size;
            Ammo_reserve = reserve_size;
            Manufacturer = manufacturer;
            Manufacturing_date = prod_date;
            Damage = damage;
            Loaded_ammo = Max_ammo;
            User_who_created = user;
        }
        #endregion

    }
}