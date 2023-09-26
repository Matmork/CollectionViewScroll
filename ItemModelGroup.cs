namespace CollectionViewScroll;

public class ItemModelGroup : List<ItemModel>
{
    public string Id { get; set; }
    public string Name { get; set; }

    public ItemModelGroup(IEnumerable<ItemModel> items) : base(items)
    {
    }
}