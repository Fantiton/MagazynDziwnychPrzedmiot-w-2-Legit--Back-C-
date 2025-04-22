// See https://aka.ms/new-console-template for more information
using MagazynDziwnychPrzedmiotów_2_Legit__Back_C_;

Console.WriteLine("Podaj pojemność magazynu: ");

int capacity = int.Parse(Console.ReadLine());

Console.WriteLine("Podaj maksymalną wagę zawartości magazynu: ");

float maxCombinedWeight = float.Parse(Console.ReadLine());

Storage storage = new Storage(capacity, maxCombinedWeight);

void Main()
{
    string input = Console.ReadLine();

    switch(input){
        case "add":
            AddItem();
            break;
        case "list":
            ListAll();
            break;
        }

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
    }

    void ListAll(){
        storage.ListAll();
    }
}
