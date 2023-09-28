using SSRS.Brand.Editor.Application.Attributes;
using SSRS.Brand.Editor.Application.ViewModels.Base;

namespace SSRS.Brand.Editor.ApplicationTests.ViewModels.Base;

[TestClass, ExcludeFromCodeCoverage]
public class ViewModelBaseTests
{
	private ProductViewModel? _product;

	[TestMethod]
	public void SetNameTest()
	{
		IList<string?> propertiesChanging = new List<string?>();
		IList<string?> propertiesChanged = new List<string?>();

		_product = new();
		_product.PropertyChanging += (sender, args) => propertiesChanging.Add(args.PropertyName);
		_product.PropertyChanged += (sender, args) => propertiesChanged.Add(args.PropertyName);

		_product.Name = "Name";

		Assert.AreEqual(nameof(_product.Name), propertiesChanging.First());
		Assert.AreEqual(nameof(_product.Name), propertiesChanged.First());
	}

	[TestMethod]
	public void SetQuantityTest()
	{
		IList<string?> propertiesChanging = new List<string?>();
		IList<string?> propertiesChanged = new List<string?>();

		_product = new(5, 5.5f, "Book");
		_product.PropertyChanging += (sender, args) => propertiesChanging.Add(args.PropertyName);
		_product.PropertyChanged += (sender, args) => propertiesChanged.Add(args.PropertyName);

		_product.Quantity = 10;

		Assert.AreEqual(nameof(_product.Quantity), propertiesChanging.First());
		Assert.AreEqual(nameof(_product.Quantity), propertiesChanging.Last());
		Assert.AreEqual(nameof(_product.Quantity), propertiesChanged.First());
		Assert.AreEqual(nameof(_product.TotalPrice), propertiesChanged.Last());
	}

	[TestMethod]
	public void SetPriceTest()
	{
		IList<string?> propertiesChanging = new List<string?>();
		IList<string?> propertiesChanged = new List<string?>();

		_product = new(5, 5.5f, "Book");
		_product.PropertyChanging += (sender, args) => propertiesChanging.Add(args.PropertyName);
		_product.PropertyChanged += (sender, args) => propertiesChanged.Add(args.PropertyName);

		_product.Price = 10;

		Assert.AreEqual(nameof(_product.Price), propertiesChanging.First());
		Assert.AreEqual(nameof(_product.TotalPrice), propertiesChanging.Last());
		Assert.AreEqual(nameof(_product.Price), propertiesChanged.First());
		Assert.AreEqual(nameof(_product.Price), propertiesChanged.Last());
	}

	private sealed class ProductViewModel : ViewModelBase
	{
		private int _quantity;
		private float _price;
		private string _name;

		public ProductViewModel()
		{
			_quantity = default;
			_price = default;
			_name = string.Empty;
		}

		public ProductViewModel(int quantity, float price, string name)
		{
			_quantity = quantity;
			_price = price;
			_name = name;
		}

		public string Name
		{
			get => _name;
			set => SetProperty(ref _name, value);
		}

		[NotifyPropertyChanged(nameof(TotalPrice))]
		public int Quantity
		{
			get => _quantity;
			set => SetProperty(ref _quantity, value);
		}

		[NotifyPropertyChanging(nameof(TotalPrice))]
		public float Price
		{
			get => _price;
			set => SetProperty(ref _price, value);
		}

		public float TotalPrice => Quantity * Price;
	}
}
