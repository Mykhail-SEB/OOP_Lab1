// Console.WriteLine("\n" + new string('–', 25));
// Console.WriteLine(new string('–', 25) + "\n");
using System.Data.SqlTypes;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Intrinsics.Arm;
using OOP_Lab1;
int Current_amout_of_items=0;
string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
GunBase_Class placeholder_gun = new(userName);
GunBase_Class[] main_Array = new GunBase_Class[3]; 
main_Array[0] = placeholder_gun;
void Run_Debug_Filling()
{
    GunBase_Class Temp = new(userName)
    {
        Damage = 23,
        Display_name = "USP-S",
        Internal_name = "test_usp",
        Max_ammo = 12,
        //Loaded_ammo = 12,
        Ammo_reserve = 60,
        Manufacturing_date = "01.01.1993",
        Manufacturer = "H&K"
    };
    main_Array[Current_amout_of_items] = Temp;
    Current_amout_of_items++;

    Temp = new(userName)
    {
        Damage = 75,
        Display_name = "Desert Eagle",
        Internal_name = "temp_deagle",
        Max_ammo = 7,
        //Loaded_ammo = 7,
        Ammo_reserve = 21,
        Manufacturing_date = "01.12.1983",
        Manufacturer = "IMI"
    };
    main_Array[Current_amout_of_items] = Temp;
    Current_amout_of_items++;

    Temp = new(userName)
    {
        Damage = 16,
        Display_name = "Glock-19",
        Internal_name = "temp_glock19",
        Max_ammo = 20,
        //Loaded_ammo = 20,
        Ammo_reserve = 80,
        Manufacturing_date = "01.01.1988",
        Manufacturer = "Glock GmbH"
    };
    main_Array[Current_amout_of_items] = Temp;
    Current_amout_of_items++;
}

int menu_choice,N;
Console.WriteLine("-1 = Debug");
Console.WriteLine("How many items you want to make? ");
N = int.Parse(Console.ReadLine());
switch (N)
{
    case -1:
        Run_Debug_Filling();
        Console.WriteLine("Debug filling, max of items is 5.");
        N = 5;
        break;
    default:
        break;
}
Array.Resize(ref main_Array, N);
while (true){
    
    Console.WriteLine("\n" + new string('–', 40));
    Console.WriteLine($"{new string(' ',10)}Main Menu");
    Console.WriteLine("  1. Create item");
    Console.WriteLine("  2. Output all items");
    Console.WriteLine("  3. Find an item");
    Console.WriteLine("  4. Interactions");
    Console.WriteLine("  5. Delete item");
    Console.WriteLine("  0. Close the program");
    Console.WriteLine(new string('–', 40) + "\n"); 
    //bool Boolean;
    //do
    //{
    //    Boolean = int.TryParse(Console.ReadLine(), out menu_choice);
    //    if (!(Boolean))
    //    {

    //        Boolean = true;
    //    }
    //} while (Boolean);
    menu_choice = int.Parse(Console.ReadLine());
    switch (menu_choice)
    {
        case 1:
            create_object();
            break;
        case 2:
            Output_items();
            break;
        case 3:
            Find_item();
            break;
        case 4:
            Output_items();
            Console.WriteLine("Select an item. ");
            int pointer=1;
            do
            {
                if (pointer < 1) Console.WriteLine("Must be greater than 0. Repeat input. ");
                if (pointer > main_Array.Length) Console.WriteLine($"Must not be greater than {main_Array.Length + 1}. Repeat input. ");
                pointer = int.Parse(Console.ReadLine());
            } while (pointer < 1 || pointer > main_Array.Length + 1);
            GunBase_Class item = main_Array[pointer-1];
            Interact_menu(item);
            break;
        case 5:
            if (Current_amout_of_items > 0)
                Delete_item();
            else
                Console.WriteLine("Already no items! ");
            break;
        case 0:
            return 200;
        default:
            Console.WriteLine("Input 1-5, or 0.");
            break;
    }
}
string Interact_menu(GunBase_Class Temp)
{
    while (true)
    {
        Console.WriteLine("\n" + new string('–', 26));
        Console.WriteLine(" 1. Output general info.");
        Console.WriteLine(" 2. Check magazine.");
        Console.WriteLine(" 3. Check how much left in reserve.");
        Console.WriteLine(" 4. Reload.");
        Console.WriteLine(" 5. Fire one round.");
        Console.WriteLine(" 6. Fire ten rounds.");
        Console.WriteLine(" 7. Fire some rounds.");
        Console.WriteLine(" 9. Return to menu.");
        Console.WriteLine(new string('–', 26)+ "\n");
        int choice = int.Parse(Console.ReadLine());
        string output;
        switch (choice)
        {
            case 1:
                output = Temp.General_info();
                Console.WriteLine(output);
                break;
            case 2:
                output = Temp.check_ammo();
                Console.WriteLine(output);
                break;
            case 3:
                output = Temp.check_reserve();
                Console.WriteLine(output);
                break;
            case 4:
                output = Temp.reload();
                Console.WriteLine(output);
                break;
            case 5:
                output = Temp.Fire();
                Console.WriteLine(output);
                break;
            case 6:
                output = Temp.FireTenRounds();
                Console.WriteLine(output);
                break;
            case 7:
                bool Flag;
                do
                {
                    Console.WriteLine(" How many bullets to fire? ");
                    int Bullets_to_fire;
                    Flag = int.TryParse(Console.ReadLine(), out Bullets_to_fire);
                    if (Flag)
                    {
                        if (Bullets_to_fire >0 && Bullets_to_fire <+ 50)
                        {
                            output = Temp.Fire(Bullets_to_fire);
                            Console.WriteLine(output);
                            break;
                        }
                        else
                        {
                            if (Bullets_to_fire < 1)
                                Console.WriteLine(" Well, you wanted to fire, right? so do it! ");
                            if (Bullets_to_fire > 50)
                                Console.WriteLine(" The gun will overheat! dont try to fire more than 50 at once.");
                        }
                    }
                    else
                    {
                        Console.WriteLine(" Integer please, not a string. ");
                        Flag = true;
                    }
                } while (Flag);
                    break;
            case 9:
                return "Back to the menu.";
            default:
                Console.WriteLine("Pick 1-7 or 9.\n");
                break;
        }
    }
}
void create_object()
{
    string public_name = "placeholder", private_name = "placeholder", manufac = "placeholder", date = "01.01.1981";
    int ammo_mag = 1, ammo_reserve, damage = 1;
    GunBase_Class Object = new GunBase_Class();
    bool Flag = false;
    do 
    {
        Flag = false;
        Console.WriteLine(" Input displayed name: ");
        public_name = Console.ReadLine();
        try { Object.Display_name = public_name; }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Flag = true;
        }

    } while (Flag); //visible name
    do 
    {
        Flag = false;
        Console.WriteLine(" Input internal name: ");
        private_name = Console.ReadLine();
        try { Object.Internal_name = private_name; }
        catch (Exception ex) { Console.WriteLine(ex.Message);
            Flag = true;
        }
    } while (Flag);//internal name
    do
    {
        Flag = false;
        bool Boolean;
        Console.WriteLine(" Input the mag size: ");
        Boolean = Int32.TryParse(Console.ReadLine().ToString(), out ammo_mag); //tryparse
        try { Object.Max_ammo = ammo_mag; }
        catch (Exception ex) { Console.WriteLine(ex.Message);
            Flag = true;
        };
    } while (Flag);//magsize
    do 
    {
        Flag = false;
        bool Boolean;
        Console.WriteLine(" Input the reserve size: ");
        Boolean = Int32.TryParse(Console.ReadLine().ToString(), out ammo_reserve);//tryparse
        if (!(Boolean))
        {
            ammo_reserve = -1;
        }
        try { Object.Ammo_reserve = ammo_reserve; }
        catch (Exception ex) { Console.WriteLine(ex.Message);
            Flag = true;
        }
    } while (Flag);//reserve ammo

    do //manufacturer
    {
        Flag = false;
        Console.WriteLine(" Input name of manufacturer: ");
        manufac = Console.ReadLine();
        try { Object.Manufacturer = manufac; }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Flag = true;
        }
    } while (Flag);//manufacturer

    DateTime localDate;
    do 
    {
        localDate = DateTime.Now;
        Object.Manufacturing_date = localDate.ToString();
    } while (false);//Manufacturing date
    do 
    {
        Flag = false;
        bool Boolean;
        Console.WriteLine(" How much damage should the gun deal? ");
        Boolean = Int32.TryParse(Console.ReadLine().ToString(), out damage);
        if (!(Boolean))
        {
            damage = -1;
            Console.WriteLine(" Input integer. ");
            continue;
        }
        try { Object.Damage = damage; }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Flag = true;
        }

    } while (Flag);//Damage

    Random intger = new Random();
    int constructor_rng = intger.Next(1, 4);
    switch (constructor_rng) {
        case 1:
            {
                Object = new GunBase_Class();
                Object.Display_name = public_name;
                Object.Internal_name = private_name;
                Object.Max_ammo = ammo_mag;
                Object.Ammo_reserve = ammo_reserve;
                Object.Manufacturer = manufac;
                Object.Manufacturing_date = localDate.ToString();
                Console.WriteLine("  Constructor used: GunBase_Class()");
                break;
            } 
        case 2:
            {
                Object = new GunBase_Class(userName);
                Object.Display_name = public_name;
                Object.Internal_name = private_name;
                Object.Max_ammo = ammo_mag;
                Object.Ammo_reserve = ammo_reserve;
                Object.Manufacturer = manufac;
                Object.Manufacturing_date = localDate.ToString();
                Console.WriteLine("  Constructor used: GunBase_Class(userName)");
                break;
            }
        case 3:
            {
                Object = new GunBase_Class(public_name, private_name, ammo_mag, ammo_reserve, manufac, localDate.ToString(), damage, userName);
                Console.WriteLine("  Constructor used: GunBase_Class(public_name, private_name, ammo_mag, ammo_reserve, manufac, localDate.ToString(), damage, userName)");
                break;
            }
    }

    main_Array[Current_amout_of_items] = Object;
    Console.WriteLine("  Object created!");
    Current_amout_of_items++;
}
void Output_items()
{
    for (int i = 0; i < Current_amout_of_items; i++)
    {
        GunBase_Class item = main_Array[i];
        Console.WriteLine($" {i + 1}. {item.ToString()}");
    }
}
void Find_item()
{
    Console.WriteLine("By which parameter?");
    Console.WriteLine("  1. Display name");
    Console.WriteLine("  2. Internal name");
    Console.WriteLine("  3. Manufacturer");
    int find_item_case = int.Parse(Console.ReadLine());
    Console.WriteLine();
    string search_display_name;
        switch (find_item_case)
    {
        case 1:
            {
                Console.WriteLine("Input name (partial name search supported, case-insessitive): ");
                search_display_name = Console.ReadLine();
                for (int i = 0; i < Current_amout_of_items; i++)
                {
                    int index = main_Array[i].Display_name.IndexOf(search_display_name, StringComparison.OrdinalIgnoreCase);

                    bool containsSubString = (index != -1);
                    if (containsSubString)
                    {
                        Console.WriteLine(i + 1 + ". " + main_Array[i].ToString());
                    }
                }
                    break;
            }
        case 2:
            Console.WriteLine("Input internal name (partial name search supported, case-insessitive): ");
            search_display_name = Console.ReadLine();
            for (int i = 0; i < Current_amout_of_items; i++)
            {
                int index = main_Array[i].Internal_name.IndexOf(search_display_name, StringComparison.OrdinalIgnoreCase);

                bool containsSubString = (index != -1);
                if (containsSubString)
                {
                    Console.WriteLine(i + 1 + ". " + main_Array[i].ToString());
                }
            }
            break;
        case 3:
            Console.WriteLine("Input the name of manufacturer (partial name search supported, case-insessitive): ");
            search_display_name = Console.ReadLine();
            for (int i = 0; i < Current_amout_of_items; i++)
            {
                int index = main_Array[i].Manufacturer.IndexOf(search_display_name, StringComparison.OrdinalIgnoreCase);

                bool containsSubString = (index != -1);
                if (containsSubString)
                {
                    Console.WriteLine(i + 1 + ". " + main_Array[i].ToString());
                }
            }
            break;
        default: 
            break;
    }
}
void Delete_item()
{while (true)
    {
        Output_items();
        Console.WriteLine("Which item to delete? ");
        int index_to_delete;
        bool Boolean = int.TryParse(Console.ReadLine(), out index_to_delete);
        if (Boolean)
        {
            for (int i = index_to_delete - 1; i < main_Array.Length - 1; i++)
            {
                main_Array[i] = main_Array[i + 1];
            }
            Current_amout_of_items--;
            return;
        }
        else Console.WriteLine($"Numbers only, 1 tp {main_Array.Length}");
    }

}