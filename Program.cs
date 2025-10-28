// Console.WriteLine("\n" + new string('–', 25));
// Console.WriteLine(new string('–', 25) + "\n");
using System.Data.SqlTypes;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Intrinsics.Arm;
using OOP_Lab1;
#region Setup Area
GunBase_Class.Item_counter = 0;
string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
GunBase_Class placeholder_gun = new(userName);
GunBase_Class[] main_Array = new GunBase_Class[3];
main_Array[0] = placeholder_gun;

int static_menu_choice = -1;
string Parse_input_string;

int INPUT_TEMP;
int menu_choice=0, N;
Console.WriteLine("-1 = Make 3 items for debug purposes");
Console.WriteLine("How many items you want to make? ");
N = int.Parse(Console.ReadLine());
switch (N)
{
    case -1:
        Run_Debug_Filling();
        Console.WriteLine("Debug filling, max of items is 10.");
        N = 10;
        break;
    default:
        break;
}
Array.Resize(ref main_Array, N);
#endregion

#region Main program loop
while (true)
{

    Console.WriteLine("\n" + new string('–', 40));
    Console.WriteLine($"{new string(' ', 10)}Main Menu");
    Console.WriteLine("  1. Create item. ");
    Console.WriteLine("  2. Output all items. ");
    Console.WriteLine("  3. Find an item. ");
    Console.WriteLine("  4. Interactions. ");
    Console.WriteLine("  5. Delete item. ");
    Console.WriteLine("  6. Demonstate static methods. ");
    Console.WriteLine("  0. Close the program");
    Console.WriteLine(new string('–', 40) + "\n");
    bool Boolean;
    do
    {
        Boolean = int.TryParse(Console.ReadLine(), out INPUT_TEMP);
        if (Boolean)
        {
            menu_choice = INPUT_TEMP;
            Boolean = false;
        }
        else
        {
            Boolean = true;
            Console.WriteLine("Input numbers.");
        }
    } while (Boolean);
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
            int pointer = 1;
            do
            {
                if (pointer < 1) Console.WriteLine("Must be greater than 0. Repeat input. ");
                if (pointer > main_Array.Length) Console.WriteLine($"Must not be greater than {main_Array.Length + 1}. Repeat input. ");
                pointer = int.Parse(Console.ReadLine());
            } while (pointer < 1 || pointer > main_Array.Length + 1);
            GunBase_Class item = main_Array[pointer - 1];
            Interact_menu(item);
            break;
        case 5:
            if (GunBase_Class.Item_counter > 0)
                Delete_item();
            else
                Console.WriteLine("Already no items! ");
            break;
        case 6:
            Demonstrate_static_methods();
            break;
        case 0:
            return 200;
        default:
            Console.WriteLine("Input 1-5, or 0.");
            break;
    }
}
#endregion

#region Functions
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
    main_Array[GunBase_Class.Item_counter] = Temp;
    GunBase_Class.Item_counter++;

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
    main_Array[GunBase_Class.Item_counter] = Temp;
    GunBase_Class.Item_counter++;

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
    main_Array[GunBase_Class.Item_counter] = Temp;
    GunBase_Class.Item_counter++;
    GunBase_Class.Item_counter = GunBase_Class.Item_counter;
    Console.WriteLine("DEBUG: parsing line:\n ");
    Console.WriteLine("public_name, internal_name, 75, 500, Example Factory, 11.09.2001, 20\n" );
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
        Console.WriteLine(new string('–', 26) + "\n");
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
                        if (Bullets_to_fire > 0 && Bullets_to_fire < +50)
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
    int ammo_mag = 1, ammo_reserve, damage = 1; DateTime localDate;
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
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
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
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
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
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
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
    switch (constructor_rng)
    {
        case 1:
                Object = new GunBase_Class();
                Object.Display_name = public_name;
                Object.Internal_name = private_name;
                Object.Max_ammo = ammo_mag;
                Object.Ammo_reserve = ammo_reserve;
                Object.Manufacturer = manufac;
                Object.Manufacturing_date = localDate.ToString();
                Console.WriteLine("  Constructor used: GunBase_Class()");
                break;
        case 2:
                Object = new GunBase_Class(userName);
                Object.Display_name = public_name;
                Object.Internal_name = private_name;
                Object.Max_ammo = ammo_mag;
                Object.Ammo_reserve = ammo_reserve;
                Object.Manufacturer = manufac;
                Object.Manufacturing_date = localDate.ToString();
                Console.WriteLine("  Constructor used: GunBase_Class(userName)");
                break;
        case 3:
                Object = new GunBase_Class(public_name, private_name, ammo_mag, ammo_reserve, manufac, localDate.ToString(), damage, userName);
                Console.WriteLine("  Constructor used: GunBase_Class(public_name, private_name, ammo_mag, ammo_reserve, manufac, localDate.ToString(), damage, userName)");
                break;
    }

    main_Array[GunBase_Class.Item_counter] = Object;
    Console.WriteLine("  Object created!");
    GunBase_Class.Item_counter++;;
}
void Output_items()
{
    Console.WriteLine("Total amount of items: " + GunBase_Class.Item_counter);
    for (int i = 0; i < GunBase_Class.Item_counter; i++)
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
                for (int i = 0; i < GunBase_Class.Item_counter; i++)
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
            for (int i = 0; i < GunBase_Class.Item_counter; i++)
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
            for (int i = 0; i < GunBase_Class.Item_counter; i++)
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
{
    while (true)
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
            GunBase_Class.Item_counter--;
            return;
        }
        else Console.WriteLine($"Numbers only, 1 to {main_Array.Length}");
    }

}
void Demonstrate_static_methods()
{

    Console.WriteLine("  1. Custom method"); // CHANGE THIS WHEN I HAVE ANY IDEA WHAT TO DO
    Console.WriteLine("  2. Parse");
    Console.WriteLine("  3. TryParse");
    Console.WriteLine("  0. Return to main menu");
    GunBase_Class Object = new();
    bool Boolean;
    do
    {
        Boolean = int.TryParse(Console.ReadLine(), out INPUT_TEMP);
        if (Boolean)
        {
            static_menu_choice = INPUT_TEMP;
            Boolean = false;
        }
        else
        {
            Boolean = true;
            Console.WriteLine("Input numbers.");
        }
    } while (Boolean);
    switch (static_menu_choice)
    {
        case 1:
            string message = GunBase_Class.Total_amount_shots_print();
            Console.WriteLine("total amount of shots: " + message);
            break;
        case 2:
            Console.WriteLine("Input parsed string for conversion in to item");
            Console.WriteLine("Input must be in the folowing form: {Display_name}, {Internal_name}, {Max_ammo}, {Ammo_reserve}, {Manufacturer}, {Manufacturing_date}, {Damage}");
            Console.WriteLine("Separation MUST be in a form of koma followed by coma and space.");
            Parse_input_string = Console.ReadLine();
            Object = GunBase_Class.Parse(Parse_input_string);
            main_Array[GunBase_Class.Item_counter] = Object;
            GunBase_Class.Item_counter++;
            break;
        case 3:
            Console.WriteLine("Input parsed string for conversion in to item");
            Console.WriteLine("Input must be in the folowing form: {Display_name}, {Internal_name}, {Max_ammo}, {Ammo_reserve}, {Manufacturer}, {Manufacturing_date}, {Damage}");
            Console.WriteLine("Separation MUST be in a form of koma followed by coma and space.");
            GunBase_Class new_item;
            bool static_Flag = true;
            do
            {
                Parse_input_string = Console.ReadLine();
                static_Flag = GunBase_Class.TryParse(Parse_input_string, out new_item);
                if (static_Flag)
                {
                    Console.WriteLine("Item created!");
                    static_Flag = false;
                    main_Array[GunBase_Class.Item_counter] = new_item;
                    GunBase_Class.Item_counter++;
                }
                else
                {
                    Console.WriteLine("Wrong input string!");
                    static_Flag = true;
                }
            } while (static_Flag);
            break;
    };
}
#endregion


//GunBase_Class test_item = new();
//int expected = 14;
//test_item.Loaded_ammo = 15; test_item.Max_ammo = 20; test_item.Ammo_reserve = 15;
//test_item.Fire();
//int actual =  test_item.Loaded_ammo;
////Assert.AreEqual(expected, actual);

//GunBase_Class.total_amount_of_shots=1;