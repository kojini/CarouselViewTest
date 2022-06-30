using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CarouselViewTest;

public partial class MainPage : ContentPage
{
	public ObservableCollection<Data> TestData { get; set; }

	public MainPage()
	{
		InitializeComponent();
        CreateData();
        BindingContext = this;
    }

    private void CreateData()
    {
        TestData = new ObservableCollection<Data>();
        foreach (var i in Enumerable.Range(0, 50))
        {
            TestData.Add(new Data
            {
                Name = $"Name {i}",
                Address = $"Address {i}",
                Age = i,
                Score = i * 10,
                PastResults = CreatePastResults()
            });
        }
    }

    private List<PastResult> CreatePastResults()
    {
        return Enumerable.Range(0, 5).Select(x => new PastResult
            {
                Age = x,
                Score = x + 1000,
                Comment = $"Comment {x}: you are awesome"
            })
            .ToList();
    }
    
}

public class Data
{
    public string Name { get; set; }

    public string Address { get; set; }
    public int Age { get; set; }
    public int Score { get; set; }
    public List<PastResult> PastResults { get; set; }
}

public class PastResult
{
    public int Age { get; set; }
    public int Score { get; set; }
    public string Comment { get; set; }
}