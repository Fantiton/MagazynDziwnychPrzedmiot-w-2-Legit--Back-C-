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
            ListStorages();
            break;
        case "slp":
            ListStoragesP();
            break;
        case "sch":
            ChangeActiveStorage();
            break;
        case "m":
            ShowStorage();
            break;
        case "ml":
            ListStorage();
            break;
        case "ml foh":
            ListStorageFOH();
            break;
        case "ms":
            ShowItem();
            break;
        case "ma":
            AverageWeirdness();
            break;
        case "mc":
            AddItem();
            break;
        case "help":
            Console.WriteLine("sc - stwórz magazyn \n" +
                              " sl - lista magazynów \n" +
                              " slp - lista magazynów z pojemnością \n" +
                              " sch - zmień aktywny magazyn \n" +
                              " m - pokaż aktywny magazyn \n" +
                              " ml - lista przedmiotów w aktywnym magazynie \n" +
                              " ml foh - lista przedmiotów w aktywnym magazynie z wagą większą niż podana \n" +
                              " ms - pokaż przedmiot \n" +
                              " ma - średni poziom dziwności w aktywnym magazynie \n" +
                              " mc - dodaj przedmiot do aktywnego magazynu");
            Main();
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
            Console.Write($"Pojemność: {capacity} \n Ilość Przedmiotów: {currentItemCount} \n Udźwig: {maxCombinedWeight} \n Waga zawartości: {contentWeight} \n");

            Main();
            return;
        }
    }

    void ListStorages()
    {
        if (storages.Count == 0)
        {
            Console.WriteLine("Nie ma żadnych magazynów.");
            Main();
            return;
        }
        else
        {
            Console.WriteLine("Lista magazynów:");
            for (int i = 0; i < storages.Count; i++)
            {
                Console.WriteLine("Magazyn nr. " + (i + 1).ToString());
                int capacity = storages[i].GetCapacity();
                int currentItemCount = storages[i].GetCurrentItemCount();
                float maxCombinedWeight = storages[i].GetMaxCombinedWeight();
                float contentWeight = storages[i].GetContentWeight();
                Console.Write($"Pojemność: {capacity} \n Ilość Przedmiotów: {currentItemCount} \n Udźwig: {maxCombinedWeight} \n Waga zawartości: {contentWeight}");
            }
        }
        Main();
    }

    void ListStoragesP()
    {
        if (storages.Count == 0)
        {
            Console.WriteLine("Nie ma żadnych magazynów.");
            Main();
            return;
        }
        else
        {
            Console.WriteLine("Lista magazynów:");
            for (int i = 0; i < storages.Count; i++)
            {
                Console.WriteLine("Magazyn nr. " + (i + 1).ToString());
                float  fill = storages[i].GetContentWeight();
                float maxContentWeight = storages[i].GetMaxCombinedWeight();
                float fillPercentage = (float)fill / maxContentWeight * 100;
                Console.WriteLine($"Zajętość: {fillPercentage:F1}%");
            }
        }
        Main();
    }

    void ListStorage()
    {
        if (activeStorage == null)
        {
            Console.WriteLine("Nie ma żadnych magazynów.");
            Main();
            return;
        }
        else
        {
            activeStorage.ListAll();
            Main();
            return;
        }
    }

    void ListStorageFOH(){
        if (activeStorage == null)
        {
            Console.WriteLine("Nie ma żadnych magazynów.");
            Main();
            return;
        }
        else
        {
            Console.WriteLine("Podaj wagę");
            float weight = (float)Math.Round(float.Parse(Console.ReadLine()), 3);
            List<Item> result = activeStorage.ListFragileOrheavy(weight);
            foreach (var item in result)
            {
                Console.WriteLine(item.description());
            }
            Main();
            return;
        }
    }

    void AddItem()
    {
        if (activeStorage == null)
        {
            Console.WriteLine("Nie ma żadnych magazynów.");
            Main();
            return;
        }
        else
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
            activeStorage.AddItem(item);
            Main();
            return;
        }
    }

    void ListAll(){
        activeStorage.ListAll();

        Main();
    }

    void ShowItem()
    {
        Console.WriteLine("Podaj nazwę przedmiotu: ");
        string name = Console.ReadLine();
        foreach (var item in activeStorage.GetItems())
        {
            if (item.GetName() == name)
            {
                Console.WriteLine(item.description());

                Main();
            }
        }
        Console.WriteLine("Nie znaleziono przedmiotu.");

        Main();
        return;
    }

    void AverageWeirdness()
    {
        if (activeStorage == null)
        {
            Console.WriteLine("Nie ma żadnych magazynów.");
            Main();
            return;
        }
        else
        {
            Console.WriteLine($"Średni poziom dziwności: {activeStorage.AverageWeirdness():F1}");
            Main();
            return;
        }
    }

    void ChangeActiveStorage()
    {
        if (storages.Count == 0)
        {
            Console.WriteLine("Nie ma żadnych magazynów.");
            Main();
            return;
        }
        else
        {
            Console.WriteLine("Lista magazynów:");
            foreach (var storage in storages)
            {
                Console.WriteLine("Magazyn nr. " + (storages.IndexOf(storage) + 1).ToString());
            }

            Console.WriteLine("Podaj numer magazynu: ");
            int storageNumber = int.Parse(Console.ReadLine());
            if (storageNumber > storages.Count || storageNumber < 1)
            {
                Console.WriteLine("Nie ma takiego magazynu.");
                Main();
                return;
            }
            else
            {
                activeStorage = storages[storageNumber - 1];
                Console.WriteLine($"Aktywny magazyn zmieniony na magazyn nr. {storageNumber}");
                Main();
                return;
            }
        }
    }
}
