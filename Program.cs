// Console.WriteLine("\n" + new string('–', 25));
// Console.WriteLine(new string('–', 25) + "\n");
using System.Data.SqlTypes;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using OOP_Lab1;
int Current_amout_of_items=0;
GunBase_Class placeholder_gun = new();
GunBase_Class[] main_Array = new GunBase_Class[3]; 
main_Array[0] = placeholder_gun;
void Run_Debug_Filling()
{
    GunBase_Class Temp = new()
    {
        display_name = "USP-S",
        internal_name = "temp_usp",
        max_ammo = 12,
        loaded_ammo = 12,
        ammo_reserve = 60,
        manufacturing_date = "01.01.1993",
        manufacturer = "H&K"
    };
    main_Array[Current_amout_of_items] = Temp;
    Current_amout_of_items++;

    Temp = new()
    {
        display_name = "Desert Eagle",
        internal_name = "temp_deagle",
        max_ammo = 7,
        loaded_ammo = 7,
        ammo_reserve = 21,
        manufacturing_date = "01.12.1983",
        manufacturer = "IMI"
    };
    main_Array[Current_amout_of_items] = Temp;
    Current_amout_of_items++;

    Temp = new()
    {
        display_name = "Glock-19",
        internal_name = "temp_glock19",
        max_ammo = 20,
        loaded_ammo = 20,
        ammo_reserve = 80,
        manufacturing_date = "01.01.1988",
        manufacturer = "Glock GmbH"
    };
    main_Array[Current_amout_of_items] = Temp;
    Current_amout_of_items++;
}

int menu_choice,N;
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
            {
                Console.WriteLine($"Deleted {main_Array[Current_amout_of_items - 1].display_name}");
                Current_amout_of_items--;
            }
            else
            {
                Console.WriteLine("Already no items! ");
            }
            
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
        Console.WriteLine("\n" + new string('–', 25));
        Console.WriteLine("1. Output general info.");
        Console.WriteLine("2. Check magazine.");
        Console.WriteLine("3. Check how much left in reserve.");
        Console.WriteLine("4. Reload.");
        Console.WriteLine("5. Fire one round.");
        Console.WriteLine("6. Fire ten rounds.");
        Console.WriteLine("9. Return to menu.");
        Console.WriteLine(new string('–', 25)+ "\n");
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
            case 9:
                return "Back to the menu.";
            default:
                Console.WriteLine("Pick 1-6 or 9.\n");
                break;
        }
    }
}
void create_object()
{
    string public_name="placeholder", private_name = "placeholder", manufac = "placeholder", date = "01.01.1981";
    int ammo_mag=1, ammo_reserve=1;
    do //visible name
    {
        if (public_name.Length < 3 )
            Console.WriteLine("The name is too short.");
        if (public_name.Length >20 )
            Console.WriteLine("The name is too long.");
        Console.WriteLine("Input displayed name: ");
        public_name = Console.ReadLine();
    } while (public_name.Length < 3 || public_name.Length > 20);    

    do //internal name
    {
        if (private_name.Length < 3)
            Console.WriteLine("The name is too short.");
        if (private_name.Length > 20)
            Console.WriteLine("The name is too long.");        
        Console.WriteLine("Input internal name: ");
        private_name = Console.ReadLine();
    } while (private_name.Length < 3 || private_name.Length > 20);

    do //magsize
    {
        if (ammo_mag <= 0)
            Console.WriteLine("Magazine size must be greater than 0.");
        if (ammo_mag >= 100)
            Console.WriteLine($"Magazine size must be lesser than 100.");
        Console.WriteLine("Input the mag size: ");
        ammo_mag = int.Parse(Console.ReadLine()); //tryparse
    } while (!(ammo_mag > 0 && ammo_mag <= 100));

    do //reserve ammo
    {
        if (ammo_reserve <= 0)
            Console.WriteLine("Reserve of ammunition must be greater than 0.");
        if (ammo_reserve >= (ammo_mag*10))
            Console.WriteLine($"Reserve of ammunition must be lesser than {(ammo_mag*10)}.");
        Console.WriteLine("Input the reserve size: ");
        ammo_reserve = int.Parse(Console.ReadLine()); //tryparse
    } while (!(ammo_reserve >= 0 && ammo_reserve <= (ammo_mag * 10)));

    do //manufacturer
    {
        if (manufac.Length < 3)
            Console.WriteLine("Name of manufacturer is too short, must be longer than 3");
        if (manufac.Length > 20)
            Console.WriteLine("Name of manufacturer is too long, Must be shorter than 20");
        Console.WriteLine("Input name of manufacturer: ");
        manufac = Console.ReadLine();
    } while (manufac.Length < 3 || manufac.Length > 20);

    do //Manufacturing date
    {

    } while (false);
    //Manufacturng time
    DateTime localDate = DateTime.Now;
    GunBase_Class Object = new GunBase_Class();
    Object.display_name = public_name;
    Object.internal_name = private_name;
    Object.max_ammo = ammo_mag;
    Object.ammo_reserve = ammo_reserve;
    Object.manufacturer = manufac;
    Object.manufacturing_date = localDate.ToString();
    Console.WriteLine("Gun created!");
    main_Array[Current_amout_of_items] = Object;
    Current_amout_of_items++;
}
void Output_items()
{
    for (int i = 0; i < Current_amout_of_items; i++)
    {
        GunBase_Class item = main_Array[i];
        Console.WriteLine(i+1 +". " + item.ToString());
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
                    int index = main_Array[i].display_name.IndexOf(search_display_name, StringComparison.OrdinalIgnoreCase);

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
                int index = main_Array[i].internal_name.IndexOf(search_display_name, StringComparison.OrdinalIgnoreCase);

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
                int index = main_Array[i].manufacturer.IndexOf(search_display_name, StringComparison.OrdinalIgnoreCase);

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