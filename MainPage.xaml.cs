namespace CollectionViewScroll;

public partial class MainPage : ContentPage
{
    private readonly List<ItemModel> _items;

    public MainPage()
    {
        InitializeComponent();

        var itemCategories = new List<ItemModelGroup>();
        var categories = new List<string>
        {
            "Category A",
            "Category B",
            "Category C",
            "Category D",
            "Category E",
            "Category F",
        };

        foreach (var cat in categories)
        {
            var items = new List<ItemModel>();
            for (var i = 0; i < 5; i++)
            {
                items.Add(new ItemModel()
                {
                    Text = $"{cat} item #{i}",
                    Price = 10,
                    Description = "Item description"
                });
            }

            itemCategories.Add(new ItemModelGroup(items)
            {
                Name = cat
            });
        }

        _items = itemCategories.SelectMany(x => x).ToList();
        ItemsCollectionView.ItemsSource = itemCategories;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        ItemsCollectionView.Scrolled += ItemsCollectionViewOnScrolled;
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        ItemsCollectionView.Scrolled += ItemsCollectionViewOnScrolled;
    }

    private void ItemsCollectionViewOnScrolled(object sender, ItemsViewScrolledEventArgs e)
    {
        if (e.FirstVisibleItemIndex < _items.Count && _items[e.FirstVisibleItemIndex] is ItemModel itemInView)
        {
            Label.Text = itemInView.Text;
        }
    }
}