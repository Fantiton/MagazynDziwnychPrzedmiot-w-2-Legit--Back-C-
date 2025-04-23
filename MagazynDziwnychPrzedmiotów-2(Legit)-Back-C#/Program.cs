// See https://aka.ms/new-console-template for more information
using MagazynDziwnychPrzedmiotów_2_Legit__Back_C_;

List<Storage> storages = new List<Storage>();
Storage activeStorage = null;

Main();

void Main()
{
    Console.WriteLine("Wpisz komendę");

    string input = Console.ReadLine();

    switch(input){
        case "sc":
            CreateStorage();
            break;
        case "sl":
            //ListStorages();
            break;
        case "slp":
            //ListStoragesP();
            break;
        case "m":
            ShowStorage();
            break;
        case "ml":
            //ListStorage();
            break;
        case "ml foh":
            //ListStorageFOH();
            break;
        case "ms":
            //ShowItem();
            break;
        case "ma":
            //AverageWeirdness();
            break;
        case "mc":
            //AddItem();
            break;
        default:
            Main();
            break;
    }

    void CreateStorage()
    {
        Console.WriteLine("Podaj pojemność magazynu. (W ilości przedmiotów)");

        int capacity = int.Parse(Console.ReadLine());

        Console.WriteLine("Podaj maksymalny udźwig magazynu. (W kg)");

        float maxCombinedWeight = float.Parse(Console.ReadLine());

        Storage storage = new Storage(capacity, maxCombinedWeight);

        storages.Add(storage);
        activeStorage = storage;

        Main();
    }

    void ShowStorage()
    {
        if (activeStorage == null)
        {
            Console.WriteLine("Nie ma żadnych magazynów.");
            Main();
            return;
        }
        else
        {
            Console.WriteLine("Aktywny magazyn:");
            Console.WriteLine("Magazyn nr. " + (storages.IndexOf(activeStorage) + 1).ToString());
            int capacity = activeStorage.GetCapacity();
            int currentItemCount = activeStorage.GetCurrentItemCount();
            float maxCombinedWeight = activeStorage.GetMaxCombinedWeight();
            float contentWeight = activeStorage.GetContentWeight();
            Console.Write($"Pojemność: {capacity} \n Ilość Przedmiotów: {currentItemCount} \n Udźwig: {maxCombinedWeight} \n Waga zawartości: {contentWeight}");

            Main();
            return;
        }
    }

    /*
    void AddItem()
    {
        Console.WriteLine("Podaj nazwę przedmiotu: ");
        string name = Console.ReadLine();
        Console.WriteLine("Podaj wagę przedmiotu: ");
        float weight = float.Parse(Console.ReadLine());
        Console.WriteLine("Podaj poziom dziwności przedmiotu: ");
        int strangenessLevel = int.Parse(Console.ReadLine());
        Console.WriteLine("Czy przedmiot jest kruchy? (TAK/NIE): ");
        bool isFragile = Console.ReadLine().ToUpper() == "TAK";
        Item item = new Item(name, weight, strangenessLevel, isFragile);
        storage.AddItem(item);

        Main();
    }

    void ListAll(){
        storage.ListAll();

        Main();
    }

    void ShowItem()
    {
        Console.WriteLine("Podaj nazwę przedmiotu: ");
        string name = Console.ReadLine();
        foreach (var item in storage.GetItems())
        {
            if (item.GetName() == name)
            {
                Console.WriteLine(item.description());

                Main();
            }
        }
        Console.WriteLine("Nie znaleziono przedmiotu.");

        Main();
    }
    */
}
